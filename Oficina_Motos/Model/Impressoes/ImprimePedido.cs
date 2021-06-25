using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Oficina_Motos.Controler;

namespace Oficina_Motos.Model
{
    class ImprimePedido
    {
        Pedido pedido = new Pedido();
        PedidoDb pedidoDb = new PedidoDb();
        Itens_Pedido itens_pedido = new Itens_Pedido();
        Itens_PedidoDb itens_pedidoDb = new Itens_PedidoDb();
        Fornecedor fornecedor = new Fornecedor();
        FornecedorDb fornecedorDb = new FornecedorDb();
        DataTable dtItens = new DataTable();

        public void imprimePedido(int id_pedido)
        {
            pedido = pedidoDb.constroiPedido(id_pedido);
            fornecedor = fornecedorDb.consultaPorId(pedido.Id_fornecedor);
            dtItens = itens_pedidoDb.consultaPorIdPedido(id_pedido);

            string fileName = "Pedido N°" + pedido.Id + ".pdf";
            string pdfPath = @"C:\Relatorios\Pedidos\" + fileName;
            string nomeRelatorio = "Pedido N°" + pedido.Id;

            using (FileStream msReport = new FileStream(pdfPath, FileMode.Create))
            {
                //step 1
                using (Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 50f, 50f))
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
                        cell = new PdfPCell(new Phrase("Data:" + pedido.Data, bold));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);

                        cell = new PdfPCell(new Phrase(nomeRelatorio, bigbold)) { PaddingBottom = 5 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);

                        pdfDoc.Add(titulo);
                        //                   
                        //dados do cliente          
                        PdfPTable Clie = new PdfPTable(4);
                        Clie.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //configura o tamanho das colunas da tabela
                        Clie.HorizontalAlignment = 0;
                        Clie.TotalWidth = 580f;
                        Clie.LockedWidth = true;
                        float[] clie_widths = new float[] { 80f, 200f, 80f, 125F };
                        Clie.SetWidths(clie_widths);
                        cell = new PdfPCell(new Phrase("Fornecedor: ", bold));

                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        Clie.AddCell(cell);
                        cell = new PdfPCell(new Phrase(fornecedor.Nome.ToString(), arial));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        Clie.AddCell(cell);
                        cell = new PdfPCell(new Phrase("CNPJ:", bold));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        Clie.AddCell(cell);
                        cell = new PdfPCell(new Phrase(fornecedor.Cnpj, arial));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        Clie.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Vendedor:", bold));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        Clie.AddCell(cell);
                        cell = new PdfPCell(new Phrase(fornecedor.Vendedor, arial));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        Clie.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Cel Vendedor:", bold));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        Clie.AddCell(cell);
                        cell = new PdfPCell(new Phrase(fornecedor.Cel_vendedor, arial));
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        Clie.AddCell(cell);
                        pdfDoc.Add(Clie);

                        float heigthTotal = Clie.TotalHeight;
                        //float heigthEndereco = tableEndereco.TotalHeight;

                        PdfContentByte cb = pdfWriter.DirectContent;
                        //primeiro quadro vertical esquerda
                        cb.MoveTo(20, 349);
                        cb.LineTo(20, 347 - heigthTotal);
                        cb.Stroke();
                        //primeiro quadro vertical direita
                        cb.MoveTo(580, 349);
                        cb.LineTo(580, 347 - heigthTotal);
                        cb.Stroke();
                        //primeiro quadro horizontal cima
                        cb.MoveTo(20, 349);
                        cb.LineTo(580, 349);
                        cb.Stroke();
                        //primeiro quadro horizontal baixo
                        cb.MoveTo(20, 347 - heigthTotal);
                        cb.LineTo(580, 347 - heigthTotal);
                        cb.Stroke();

                        //cria o cabeçalho 
                        PdfPTable headPecas = new PdfPTable(5);
                        headPecas.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //configura o tamanho das colunas da tabela
                        headPecas.HorizontalAlignment = 0;
                        headPecas.TotalWidth = 580f;
                        headPecas.LockedWidth = true; //  30f, 290f, 35f, 25f, 40f };
                        float[] header_widths = new float[] { 30f, 290f, 35f, 25f, 40f };
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
                        cell = new PdfPCell(new Phrase("Qtde", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headPecas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Sub Tot", bold)) { PaddingTop = 10 };
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
                        float[] widths = new float[] { 25f, 300f, 35f, 25f, 40f };
                        dgProd.SetWidths(widths);
                        //preenche a tabela com dados do data grid

                        iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                        for (int i = 0; i <= dtItens.Rows.Count - 1; i++)
                        {
                            for (int j = 2; j <= 3; j++)
                            {
                                //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());
                                PdfPCell pdfCell = new PdfPCell(new Phrase(dtItens.Rows[i][j].ToString(), baseFontNormal));
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;

                                dgProd.AddCell(pdfCell);
                            }
                            for (int j = 5; j <= 7; j++)
                            {
                                //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());
                                PdfPCell pdfCell = new PdfPCell(new Phrase(dtItens.Rows[i][j].ToString(), baseFontNormal));
                                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                dgProd.AddCell(pdfCell);
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
                        PdfPCell cellTotal = new PdfPCell((new Phrase(pedido.Valor.ToString(), bigbold)));
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
