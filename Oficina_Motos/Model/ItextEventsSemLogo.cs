using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina_Motos.Model
{
    public class ITextEventsSemLogo : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;
        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;
        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;
        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;

        #region Fields
        private string _header;
        #endregion
        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(20, 40);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {
                MessageBox.Show(de.ToString());
            }
            catch (System.IO.IOException ioe)
            {
                MessageBox.Show(ioe.ToString());
            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            //Phrase p1Header = new Phrase("Rua Wenceslau Braz, 183 - Centro - Itamogi - MG - Tel:(35)9 9829-2809", baseFontNormal);

            //Create PdfTable object
            PdfPTable pdfTab = new PdfPTable(3);

            //We will have to create separate cells to include image logo and 2 separate strings
            //Row 1
            //Image imagem1 = Image.GetInstance(@"C:\Users\casa\Desktop\logo_thiago_min_2.jpg");
            PdfPCell pdfCell1 = new PdfPCell();
            PdfPCell pdfCell2 = new PdfPCell();
            PdfPCell pdfCell3 = new PdfPCell();
            String text = " ";

            //Add paging to header
            {
                
            }
            //Add paging to footer
            {
                
            }

            //Row 2
            PdfPCell pdfCell4 = new PdfPCell();
            PdfPCell pdfCell5 = new PdfPCell();
            PdfPCell pdfCell6 = new PdfPCell();
            //Row 3 
            //PdfPCell pdfCell5 = new PdfPCell();//new Phrase("Data:" + PrintTime.ToShortDateString()+ "   Hora:" + string.Format("{0:t}", DateTime.Now, baseFontNormal)));
            //PdfPCell pdfCell6 = new PdfPCell();
            //PdfPCell pdfCell7 = new PdfPCell();

            //set the alignment of all three cells and set border to 0
            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER;

            pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
            pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell4.VerticalAlignment = Element.ALIGN_BOTTOM;
            pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
            //pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE;

            pdfCell4.Colspan = 3;

            pdfCell1.Border = 0;
            pdfCell2.Border = 0;
            pdfCell3.Border = 0;
            pdfCell4.Border = 0;
            pdfCell5.Border = 0;
            pdfCell6.Border = 0;
            //pdfCell7.Border = 0;

            //add all three cells into PdfTable
            pdfTab.AddCell(pdfCell1);
            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(pdfCell3);
            pdfTab.AddCell(pdfCell4);
            pdfTab.AddCell(pdfCell5);
            pdfTab.AddCell(pdfCell6);
            //pdfTab.AddCell(pdfCell7);

            pdfTab.TotalWidth = document.PageSize.Width;
            pdfTab.WidthPercentage = 70;
            pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;

            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 20, 420, writer.DirectContent);
            //set pdfContent value

            //Move the pointer and draw line to separate header section from rest of page
            //cb.MoveTo(40, document.PageSize.Height - 47);//margem esquerda da linha
            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 47);
            //cb.Stroke();

            //Move the pointer and draw line to separate footer section from rest of page
           
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 12);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 12);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();
        }
    }
}

