using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Oficina_Motos.Controler;
using Oficina_Motos.Model;

namespace Oficina_Motos.Model
{
    class ImprimeVenda: Impressoes
    {
        public void imprimeVenda(int id_venda)
        {
            Venda venda = new Venda();
            VendaDb vendaDb = new VendaDb();
            Itens_VendaDb itens_vendaDb = new Itens_VendaDb();

            venda = vendaDb.constroiVenda(id_venda);
            cliente = clienteDb.consultaPorId(venda.Id_cliente);

            contato = cliente.Contato;
            endereco = cliente.Endereco;
            string fileName = "Venda N°" + id_venda + ".pdf";
            string pdfPath = @"C:\Relatorios\Venda\" + fileName;
            string nomeRelatorio = "Documento Auxiliar de Venda N°" + id_venda;

            using (FileStream msReport = new FileStream(pdfPath, FileMode.Create))
            {
                //step 1
                using (Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 50f, 50f))
                {
                    try
                    {
                        PdfPCell cell = new PdfPCell();
                        // step 2
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                        pdfWriter.PageEvent = new ITextEvents();

                        //open the stream 
                        pdfDoc.Open();
                        //nome do relatorio 
                        PdfPTable titulo = new PdfPTable(2);
                        titulo.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //configura o tamanho das colunas da tabela
                        titulo.HorizontalAlignment = 0;
                        titulo.TotalWidth = 560f;
                        titulo.LockedWidth = true;
                        float[] titulo_widths = new float[] { 350f, 170f };
                        titulo.SetWidths(titulo_widths);

                        cell = new PdfPCell(new Phrase(nomeRelatorio, mediumbold)) { PaddingTop = 5 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);

                        cell = new PdfPCell(new Phrase("Data " + venda.Data_hora, mediumbold)) { PaddingTop = 5 }; ;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);

                        pdfDoc.Add(titulo);
                        // 
                        PdfPTable Clie = tableCliente(cliente, contato);
                        PdfPTable tableEnd = tableEndereco(endereco);

                        pdfDoc.Add(Clie);
                        pdfDoc.Add(tableEnd);
                        quadroCliente(Clie, tableEnd, pdfWriter);
                        //
                        Phrase espaco = new Phrase("", arial);
                        pdfDoc.Add(espaco);

                        //

                        //cria o cabeçalho                         
                        pdfDoc.Add(preencheHeadPecas());

                        //cria a tabela 
                        PdfPTable dgProd = new PdfPTable(6);
                        dgProd.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        dgProd.HorizontalAlignment = 10;
                        dgProd.TotalWidth = 560f;
                        dgProd.LockedWidth = true;
                        float[] widths = new float[] { 30f, 20f, 235f, 35f, 25f, 40f };
                        dgProd.SetWidths(widths);
                        //preenche a tabela com dados do data grid

                        DataTable itens_venda = new DataTable();
                        itens_venda = itens_vendaDb.consultaPorIdVendaComLocalizacao(id_venda);

                        for (int i = 0; i <= itens_venda.Rows.Count - 1; i++)
                        {
                            for (int j = 2; j <= 4; j++)
                            {
                                //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());

                                cell = new PdfPCell(new Phrase(itens_venda.Rows[i][j].ToString(), arialPequena));
                                dgProd.AddCell(cell);
                            }
                            for (int h = 5; h <= 7; h++)
                            {
                                //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());
                                cell = new PdfPCell(new Phrase(itens_venda.Rows[i][h].ToString(), arialPequena));
                                cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                                dgProd.AddCell(cell);
                            }
                        }
                        //adiciona a tabela ao documento
                        pdfDoc.Add(dgProd);

                        decimal total_pecas = itens_vendaDb.totalPecas(id_venda);
                        PdfPTable totais = new PdfPTable(3);
                        totais.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        totais.HorizontalAlignment = 10;
                        totais.TotalWidth = 560f;
                        totais.LockedWidth = true;
                        float[] width_totais = new float[] { 360, 160, 50 };
                        totais.SetWidths(width_totais);
                        //totais.HorizontalAlignment = Right;
                        totais.AddCell("");
                        totais.AddCell("Descontos: ");
                        totais.AddCell("0,00");
                        pdfDoc.Add(totais);

                        PdfPTable total = new PdfPTable(3);
                        total.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //configura o tamanho das colunas da tabela
                        total.TotalWidth = 560f;
                        total.LockedWidth = true;
                        float[] width_total = new float[] { 340, 130, 80 };
                        total.SetWidths(width_total);
                        //total.HorizontalAlignment = Right;
                        total.AddCell("");
                        total.AddCell(new Phrase("Total:", arialGrande));
                        total.AddCell(new Phrase(total_pecas.ToString(), arialGrande));
                        pdfDoc.Add(total);

                        pdfDoc.Close();
                        //abre o programa padrao dowindows para pdf
                        System.Diagnostics.Process.Start(pdfPath);
                        //imprime direto na impressora --- mas esta dando erro
                        //Imprimir(pdfPath);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                    }
                }
            }
        }
    }
}
