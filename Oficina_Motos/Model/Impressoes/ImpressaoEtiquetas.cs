using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Controler;

namespace Oficina_Motos.Model
{
    public class ImpressaoEtiquetas
    {
        public void imprimeEtiquetas()
        {
            ProdutoDb produtoDb = new ProdutoDb();
            iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 10);
            iTextSharp.text.Font arialBold = FontFactory.GetFont("Arial", 10, Font.BOLD);

            string data = DateTime.Today.ToString("yyyy_MM_dd");
            string pdfPath = @"C:\Relatorios\Etiquetas\" + data+".pdf";
            string nomeRelatorio = "Etiquetas_" + data;

            using (FileStream msReport = new FileStream(pdfPath, FileMode.Create))
            {
                //step 1
                using (Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 20f, 20f))
                {
                    try
                    {
                        PdfPCell cell = new PdfPCell();
                        // step 2
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                        pdfWriter.PageEvent = new ITextEventsSemLogo();

                        //open the stream 
                        pdfDoc.Open();

                        //cria a tabela produtos
                        PdfPTable dgProd = new PdfPTable(3);
                        dgProd.DefaultCell.FixedHeight = 57f;
                        //dgProd.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        dgProd.HorizontalAlignment = 0;
                        dgProd.TotalWidth = 470f;
                        dgProd.LockedWidth = true;
                        float[] widths = new float[] { 156f, 156f, 156f };
                        dgProd.SetWidths(widths);
                        //preenche a tabela com dados do data grid

                        DataTable produtos = new DataTable();
                        produtos = produtoDb.consultaTodos();

                        for (int i = 0; i < produtos.Rows.Count; i++)
                        {
                            //cria a tabela produtos
                            PdfPTable celula = new PdfPTable(1);
                            //celula.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            //configura o tamanho das colunas da tabela
                            celula.HorizontalAlignment = 0;
                            celula.TotalWidth = 156f;
                            celula.LockedWidth = true;
                            float[] widthsCelula = new float[] { 156f };
                            celula.SetWidths(widthsCelula);

                            string cod = "Cód " + produtos.Rows[i][0].ToString();
                            string desc = produtos.Rows[i][1].ToString();
                            //
                            string locFormatada;
                            string loc = produtos.Rows[i][6].ToString();
                            if(loc.Length == 3)
                            {
                                string gond = loc.Substring(0, 1);
                                string prat = loc.Substring(1, 1);
                                string gav = loc.Substring(2, 1);
                                locFormatada = "Gond " + gond + " | Prat " + prat + " | Gav " + gav;
                            }
                            else
                            {
                                locFormatada = loc;
                            }                           

                            PdfPCell pdfCell_1 = new PdfPCell(new Phrase(locFormatada, arialBold));
                            pdfCell_1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            pdfCell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                            celula.AddCell(pdfCell_1);
                            PdfPCell pdfCell_2 = new PdfPCell(new Phrase(desc, arial));
                            pdfCell_2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            pdfCell_2.HorizontalAlignment = Element.ALIGN_LEFT;
                            celula.AddCell(pdfCell_2);
                            PdfPCell pdfCell_3 = new PdfPCell(new Phrase(cod, arialBold));
                            pdfCell_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            pdfCell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                            celula.AddCell(pdfCell_3);
                            //
                            dgProd.AddCell(celula);
                        }
                        //adiciona a tabela ao documento
                        pdfDoc.Add(dgProd);

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
