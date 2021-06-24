using iTextSharp.text;
using iTextSharp.text.pdf;
using Oficina_Motos.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina_Motos.Model
{
    public class ImprimeOS: Impressoes
    {
        public void imprimeOs(int id_os)
        {
            Ordem_Servico os = new Ordem_Servico();
            Ordem_ServicoDb ordem_servicoDb = new Ordem_ServicoDb();
            Orcamento orcamento = new Orcamento();
            OrcamentoDb orcamentoDb = new OrcamentoDb();
            Veiculo veiculo = new Veiculo();
            VeiculoDb veiculoDb = new VeiculoDb();
            Itens_OrcamentoDb itens_orcamentoDb = new Itens_OrcamentoDb();

            os = ordem_servicoDb.constroiOs(id_os);
            cliente = clienteDb.constroiCliente(os.Id_cliente.ToString());
            contato = contatoDb.consultaPorId(cliente.Id_endereco.ToString());
            endereco = enderecoDb.consultaPorId(cliente.Id_endereco.ToString());
            veiculo = veiculoDb.constroiVeiculo(os.Id_veiculo.ToString());

            string fileName = "Ordem de Serviço N°" + os.Id + ".pdf";
            string pdfPath = @"C:\Relatorios\Ordem_de_Servico\" + fileName;
            string nomeRelatorio = "Ordem de Serviço N°" + os.Id;

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
                        titulo.TotalWidth = 580f;
                        titulo.LockedWidth = true;
                        float[] titulo_widths = new float[] { 350f, 170f };
                        titulo.SetWidths(titulo_widths);

                        cell = new PdfPCell(new Phrase(nomeRelatorio, mediumbold)) { PaddingTop = 5 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);

                        cell = new PdfPCell(new Phrase("Data " + os.Data_hora_inicio, mediumbold)) { PaddingTop = 5 }; ;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);                       

                        pdfDoc.Add(titulo);
                        // 
                        PdfPTable Clie = tableCliente(cliente, contato);
                        PdfPTable tableEnd = tableEndereco(endereco);
                        PdfPTable tableVeiculo = preencheVeiculo(veiculo);
                        PdfPTable tableDefeito = preencheDefeito(veiculo);

                        pdfDoc.Add(Clie);
                        pdfDoc.Add(tableEnd);
                        quadroCliente(Clie, tableEnd, pdfWriter);
                        //
                        Phrase espaco = new Phrase("", arial);
                        pdfDoc.Add(espaco);
                        pdfDoc.Add(tableVeiculo);                       
                        pdfDoc.Add(tableDefeito);

                        //
                        quadroVeiculo(Clie, tableEnd, tableVeiculo, tableDefeito, pdfWriter);

                        //cria o cabeçalho                         
                        pdfDoc.Add(preencheHeadPecas());

                        //
                        //cria a tabela 
                        PdfPTable dgProd = new PdfPTable(6);
                        dgProd.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        dgProd.HorizontalAlignment = 0;
                        dgProd.TotalWidth = 560f;
                        dgProd.LockedWidth = true;
                        float[] dgProd_widths = new float[] { 30f, 20f, 235f, 35f, 25f, 40f };
                        dgProd.SetWidths(dgProd_widths);
                        //preenche a tabela com dados do data grid

                        DataTable itens_orcamento = new DataTable();
                        itens_orcamento = itens_orcamentoDb.consultaTodosItens(os.Id);
                        iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                        for (int i = 0; i <= itens_orcamento.Rows.Count - 1; i++)
                        {
                            for (int j = 2; j <= 2; j++)
                            {
                                int id_produto = Convert.ToInt32(itens_orcamento.Rows[i][j]);
                                if (id_produto != 0)
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(itens_orcamento.Rows[i][j].ToString(), baseFontNormal));
                                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    dgProd.AddCell(pdfCell);
                                }
                                else
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(itens_orcamento.Rows[i][j + 1].ToString(), baseFontNormal));
                                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    dgProd.AddCell(pdfCell);
                                }

                            }
                            for (int j = 4; j <= 5; j++)
                            {
                                //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());
                                PdfPCell pdfCell = new PdfPCell(new Phrase(itens_orcamento.Rows[i][j].ToString(), baseFontNormal));
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;

                                dgProd.AddCell(pdfCell);
                            }
                            for (int j = 6; j <= 8; j++)
                            {
                                //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());
                                PdfPCell pdfCell = new PdfPCell(new Phrase(itens_orcamento.Rows[i][j].ToString(), baseFontNormal));
                                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                dgProd.AddCell(pdfCell);
                            }
                        }
                        //adiciona a tabela ao documento
                        pdfDoc.Add(dgProd);

                        PdfPTable linha = new PdfPTable(1);
                        linha.HorizontalAlignment = 0;
                        linha.DefaultCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                        //configura o tamanho das colunas da tabela
                        linha.TotalWidth = 560f;
                        linha.LockedWidth = true;
                        float[] width_linha = new float[] { 520f };
                        linha.SetWidths(width_linha);
                        //total.HorizontalAlignment = Right;
                        linha.AddCell("");
                        pdfDoc.Add(linha);

                        decimal total_pecas = itens_orcamentoDb.totalPecas(os.Id);
                        decimal total_servicos = itens_orcamentoDb.totalServicos(os.Id);
                        decimal total_os = total_pecas + total_servicos;

                        PdfPTable totais = new PdfPTable(3);
                        totais.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        totais.TotalWidth = 560f;
                        totais.LockedWidth = true;
                        float[] width_totais = new float[] { 350f, 110f, 80f };
                        totais.SetWidths(width_totais);
                        //totais.HorizontalAlignment = Right;
                        totais.AddCell("");
                        totais.AddCell("Total Peças: ");
                        PdfPCell CellPecas = new PdfPCell(new Phrase(total_pecas.ToString(), bold));
                        CellPecas.HorizontalAlignment = Element.ALIGN_RIGHT;
                        CellPecas.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        totais.AddCell(CellPecas);

                        totais.AddCell("");
                        totais.AddCell("Total Serviços: ");
                        PdfPCell CellServicos = new PdfPCell(new Phrase(total_servicos.ToString(), bold));
                        CellServicos.HorizontalAlignment = Element.ALIGN_RIGHT;
                        CellServicos.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        totais.AddCell(CellServicos);

                        totais.AddCell("");
                        totais.AddCell("Descontos: ");
                        PdfPCell CellDesconto = new PdfPCell(new Phrase("0,00", bold));
                        CellDesconto.HorizontalAlignment = Element.ALIGN_RIGHT;
                        CellDesconto.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        totais.AddCell(CellDesconto);
                        pdfDoc.Add(totais);

                        PdfPTable total = new PdfPTable(3);
                        total.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        total.TotalWidth = 560f;
                        total.LockedWidth = true;
                        float[] width_total = new float[] { 350f, 110f, 80f };
                        total.SetWidths(width_total);
                        //total.HorizontalAlignment = Right;
                        total.AddCell("");
                        total.AddCell(new Phrase("Total OS:", bigbold));
                        PdfPCell cellTotal = new PdfPCell((new Phrase(total_os.ToString(), bigbold)));
                        cellTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cellTotal.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        total.AddCell(cellTotal);
                        pdfDoc.Add(total);

                        pdfDoc.Close();
                        System.Diagnostics.Process.Start(pdfPath);

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