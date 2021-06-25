using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Oficina_Motos.Controler;

namespace Oficina_Motos.Model
{
    class RelatorioEstoque: Impressoes
    {
        EstoqueDb estoqueDb = new EstoqueDb();
        DataTable dtItens = new DataTable();

        public void relatorioEstoque(int tipo)//0 para zerado, 1 para baixo
        {
            string fileName = "";
            string nomeRelatorio = "";           

            if (tipo == 0)
            {
                dtItens = estoqueDb.consultaEstoqueZerado();
                fileName = "Produtos_estoque_zerado.pdf";
                nomeRelatorio = "Produtos com Estoque Zerado";
            }
            else if (tipo == 1)
            {
                dtItens = estoqueDb.consultaEstoqueBaixo();
                fileName = "Produtos_estoque_baixo.pdf";
                nomeRelatorio = "Produtos com Estoque Baixo";
            }
            else if (tipo == 2)
            {
                //dtItens = estoqueDb.();
                //fileName = "Produtos_estoque.pdf";
                //nomeRelatorio = "Relatório de Produtos";
            }

            string pdfPath = @"C:\Relatorios\Pedidos\" + fileName;

            using (FileStream msReport = new FileStream(pdfPath, FileMode.Create))
            {
                //step 1
                using (Document pdfDoc = new Document(PageSize.A5.Rotate(), 40f, 10f, 50f, 50f))
                {
                    try
                    {
                        iTextSharp.text.Font arial = FontFactory.GetFont("Century Gothic", 10);
                        PdfPCell cell = new PdfPCell();
                        iTextSharp.text.Font bold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, Font.BOLD);
                        iTextSharp.text.Font bigbold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, Font.BOLD);

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
                        float[] titulo_widths = new float[] { 200f, 400 };
                        titulo.SetWidths(titulo_widths);
                        cell = new PdfPCell(new Phrase("Data:" + DateTime.Today, bold));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);

                        cell = new PdfPCell(new Phrase(nomeRelatorio, bigbold)) { PaddingBottom = 5 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);

                        pdfDoc.Add(titulo);
                        //                   

                        //cria o cabeçalho 
                        PdfPTable headPecas = new PdfPTable(5);
                        headPecas.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //configura o tamanho das colunas da tabela
                        headPecas.HorizontalAlignment = 0;
                        headPecas.TotalWidth = 580f;
                        headPecas.LockedWidth = true; //  30f, 290f, 35f, 40f, 40f };
                        float[] header_widths = new float[] { 30f, 290f, 35f, 40f, 40f };
                        headPecas.SetWidths(header_widths);

                        cell = new PdfPCell(new Phrase("Cód", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headPecas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Descrição", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headPecas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Val Uni", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headPecas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Estoque", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headPecas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Pedido", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headPecas.AddCell(cell);

                        pdfDoc.Add(headPecas);

                        //
                        //cria a tabela 
                        PdfPTable dgProd = new PdfPTable(5);
                        dgProd.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        dgProd.HorizontalAlignment = 0;
                        dgProd.TotalWidth = 580f;
                        dgProd.LockedWidth = true;
                        float[] widths = new float[] { 25f, 300, 35f, 40f, 40f };
                        dgProd.SetWidths(widths);
                        //preenche a tabela com dados do data grid

                        iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                        for (int i = 0; i <= dtItens.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= 2; j += 2)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(dtItens.Rows[i][j].ToString(), baseFontNormal));
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                dgProd.AddCell(pdfCell);
                            }
                            PdfPCell Cell_2 = new PdfPCell(new Phrase(dtItens.Rows[i][4].ToString(), baseFontNormal));
                            Cell_2.HorizontalAlignment = Element.ALIGN_RIGHT;
                            dgProd.AddCell(Cell_2);

                            PdfPCell Cell_3 = new PdfPCell(new Phrase(dtItens.Rows[i][5].ToString(), baseFontNormal));
                            Cell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                            dgProd.AddCell(Cell_3);
                            if (dtItens.Rows[i][6].ToString() == "True")
                            {
                                PdfPCell Cell_4 = new PdfPCell(new Phrase("Sim", baseFontNormal));
                                Cell_4.HorizontalAlignment = Element.ALIGN_CENTER;
                                dgProd.AddCell(Cell_4);
                            }
                            else if (dtItens.Rows[i][6].ToString() == "False")
                            {
                                PdfPCell Cell_4 = new PdfPCell(new Phrase("Não", baseFontNormal));
                                Cell_4.HorizontalAlignment = Element.ALIGN_CENTER;
                                dgProd.AddCell(Cell_4);
                            }

                        }
                        //adiciona a tabela ao documento
                        pdfDoc.Add(dgProd);

                        PdfPTable total = new PdfPTable(4);
                        total.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        total.TotalWidth = 580f;
                        total.LockedWidth = true;
                        float[] width_total = new float[] { 100f, 180f, 100f, 100f };
                        total.SetWidths(width_total);
                        //total.HorizontalAlignment = Right;
                        total.AddCell("");
                        total.AddCell("");
                        total.AddCell(new Phrase("Total Geral:", bigbold));
                        PdfPCell cellTotal = new PdfPCell((new Phrase("", bigbold)));
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
