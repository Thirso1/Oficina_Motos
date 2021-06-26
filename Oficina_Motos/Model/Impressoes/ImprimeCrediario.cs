using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Oficina_Motos.Controler;

namespace Oficina_Motos.Model
{
    class ImprimeCrediario: Impressoes
    {

        //                                  numero crediario,   venda ou OS,   id da venda ou OS
        public void imprimeCrediario(int id_crediario, string referencia, int id_referencia)
        {
            ParcelaDb parcelaDb = new ParcelaDb();
            Crediario crediario = new Crediario();
            CrediarioDb crediarioDB = new CrediarioDb();
            //Cliente cliente = new Cliente();
            //ClienteDb clienteDb = new ClienteDb();
            //EnderecoDb enderecoDb = new EnderecoDb();
            //Endereco endereco = new Endereco();
            //Contato contato = new Contato();
            //ContatoDb contatoDb = new ContatoDb();
            crediario = crediarioDB.retornaPorId(id_crediario);
            cliente = clienteDb.consultaPorId(crediario.Id_cliente);
            contato = cliente.Contato;
            endereco = cliente.Endereco;
            string fileName = "Crediario N°" + id_crediario + ".pdf";
            string pdfPath = @"C:\Relatorios\Crediario\" + fileName;
            string nomeRelatorio = "Crediario N°" + id_crediario;
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
                        float[] titulo_widths = new float[] { 385f, 75f };
                        titulo.SetWidths(titulo_widths);

                        cell = new PdfPCell(new Phrase(nomeRelatorio, mediumbold)) { PaddingTop = 5 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);
                        string data = crediario.Data.Substring(0, 9);
                        cell = new PdfPCell(new Phrase("Data " + data, mediumbold)) { PaddingTop = 5 };
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
                        //
                        //
                        ////cria o cabeçalho 
                        PdfPTable headParcelas = new PdfPTable(6);
                        headParcelas.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        ////configura o tamanho das colunas da tabela
                        headParcelas.HorizontalAlignment = 0;
                        headParcelas.TotalWidth = 560f;
                        headParcelas.LockedWidth = true;
                        float[] header_widths = new float[] { 50f, 50f, 70f, 70f, 220f, 140f };
                        headParcelas.SetWidths(header_widths);
                        cell = new PdfPCell(new Phrase("Parcela ", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headParcelas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Valor ", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headParcelas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Vencimento ", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headParcelas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Data Pag. ", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headParcelas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Ass. Pagador ", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headParcelas.AddCell(cell);
                        cell = new PdfPCell(new Phrase("Visto Recebedor ", bold)) { PaddingTop = 10 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headParcelas.AddCell(cell);
                        pdfDoc.Add(headParcelas);


                        PdfPTable dgParcelas = new PdfPTable(6);
                        dgParcelas.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        dgParcelas.HorizontalAlignment = 0;
                        dgParcelas.TotalWidth = 560f;
                        dgParcelas.LockedWidth = true;
                        float[] widths = new float[] { 50f, 50f, 70f, 70f, 220f, 140f };
                        dgParcelas.SetWidths(widths);
                        //preenche a tabela com dados do data grid
                        DataTable parcelas = new DataTable();
                        parcelas = parcelaDb.consultaPorId(id_crediario);



                        for (int i = 0; i <= parcelas.Rows.Count - 1; i++)
                        {
                            //MessageBox.Show(dataGridView1.Rows[i].Cells[4].Value.ToString());
                            dgParcelas.AddCell(parcelas.Rows[i]["num_parcela"].ToString() + "/" + parcelas.Rows[0]["qtde_parcelas"].ToString());
                            dgParcelas.AddCell(parcelas.Rows[i]["valor"].ToString());
                            DateTime vencimento = Convert.ToDateTime(parcelas.Rows[i]["vencimento"]);
                            dgParcelas.AddCell(vencimento.ToString("dd/MM/yyyy"));
                            dgParcelas.AddCell("__/__/____");
                            dgParcelas.AddCell("____________________________");
                            dgParcelas.AddCell("________________");


                            //MessageBox.Show(parcelas.Rows[i][j].ToString());

                        }
                        pdfDoc.Add(dgParcelas);
                        pdfDoc.Close();
                        System.Diagnostics.Process.Start(pdfPath);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
        }

    }
}
