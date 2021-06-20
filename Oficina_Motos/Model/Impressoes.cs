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
    public class Impressoes
    {
         VendaDb vendaDb = new VendaDb();
         Itens_VendaDb itens_vendaDb = new Itens_VendaDb();
         ParcelaDb parcelaDb = new ParcelaDb();
         Crediario crediario = new Crediario();
         CrediarioDb crediarioDB = new CrediarioDb();

        iTextSharp.text.Font arialPequena = FontFactory.GetFont("Arial", 9);
        iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 10);
        iTextSharp.text.Font arialGrande = FontFactory.GetFont("Arial", 16);
        iTextSharp.text.Font bold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, Font.BOLD);
        iTextSharp.text.Font bigbold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, Font.BOLD);
        iTextSharp.text.Font mediumbold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, Font.BOLD);


        private PdfPTable tableCliente(Cliente cliente, Contato contato)
        {
            PdfPCell cell = new PdfPCell();
            //dados do cliente          
            PdfPTable Clie = new PdfPTable(4);
            Clie.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            //configura o tamanho das colunas da tabela
            Clie.HorizontalAlignment = 0;
            Clie.TotalWidth = 580f;
            Clie.LockedWidth = true;
            float[] clie_widths = new float[] { 70f, 300f, 40f, 160f };
            Clie.SetWidths(clie_widths);
            cell = new PdfPCell(new Phrase("CLIENTE: ", bold));

            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Clie.AddCell(cell);
            cell = new PdfPCell(new Phrase(cliente.Nome.ToString(), arial));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Clie.AddCell(cell);
            cell = new PdfPCell(new Phrase("Tel:", bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Clie.AddCell(cell);
            cell = new PdfPCell(new Phrase(contato.Telefone_1, arial));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Clie.AddCell(cell);
            cell = new PdfPCell(new Phrase("CPF:", bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Clie.AddCell(cell);
            cell = new PdfPCell(new Phrase(cliente.Cpf, arial));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Clie.AddCell(cell);
            cell = new PdfPCell(new Phrase("Tel 2:", bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Clie.AddCell(cell);
            cell = new PdfPCell(new Phrase(contato.Telefone_2, arial));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            Clie.AddCell(cell);

            return Clie;
        }

        private PdfPTable tableEndereco(Endereco endereco)
        {
            PdfPCell cell = new PdfPCell();
            //dados do endereço          
            PdfPTable tableEndereco = new PdfPTable(4);
            tableEndereco.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            //configura o tamanho das colunas da tabela
            tableEndereco.HorizontalAlignment = 0;
            tableEndereco.TotalWidth = 580f;
            tableEndereco.LockedWidth = true;
            float[] tableEndereco_widths = new float[] { 70f, 300f, 40f, 160f };
            tableEndereco.SetWidths(tableEndereco_widths);
            cell = new PdfPCell(new Phrase("ENDEREÇO: ", bold));

            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableEndereco.AddCell(cell);
            cell = new PdfPCell(new Phrase(endereco.Logradouro +" "+ endereco.Nome + ", " + endereco.Numero, arial));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableEndereco.AddCell(cell);
            cell = new PdfPCell(new Phrase("Bairro: ", bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableEndereco.AddCell(cell);
            cell = new PdfPCell(new Phrase(endereco.Bairro, arial));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableEndereco.AddCell(cell);
            cell = new PdfPCell(new Phrase("CIDADE: ", bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableEndereco.AddCell(cell);
            cell = new PdfPCell(new Phrase(endereco.Cidade, arial));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableEndereco.AddCell(cell);
            cell = new PdfPCell(new Phrase("CEP:", bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableEndereco.AddCell(cell);
            cell = new PdfPCell(new Phrase(endereco.Cep, arial));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableEndereco.AddCell(cell);
            return tableEndereco;
        }

        private void quadroCliente(PdfPTable Clie, PdfPTable tableEndereco, PdfWriter pdfWriter)
        {
            float heigthClie = Clie.TotalHeight;
            float heigthEndereco = tableEndereco.TotalHeight;
            float heigthTotal = heigthClie + heigthEndereco;

            PdfContentByte cb = pdfWriter.DirectContent;
            //primeiro quadro, linha vertical esquerda
            cb.MoveTo(20, 771);
            cb.LineTo(20, 770 - heigthTotal);
            cb.Stroke();
            //primeiro quadro, linha  vertical direita
            cb.MoveTo(580, 771);
            cb.LineTo(580, 770 - heigthTotal);
            cb.Stroke();
            //primeiro quadro, linha  horizontal superior
            cb.MoveTo(20, 771);
            cb.LineTo(580, 771);
            cb.Stroke();
            //primeiro quadro, linha  horizontal inferior
            cb.MoveTo(20, 770 - heigthTotal);
            cb.LineTo(580, 770 - heigthTotal);
            cb.Stroke();
        }

        private void quadroVeiculo(PdfPTable Clie, PdfPTable tableEndereco, PdfPTable veiculo, PdfPTable defeito, PdfWriter pdfWriter)
        {
            float heigthClie = Clie.TotalHeight;
            float heigthEndereco = tableEndereco.TotalHeight;
            float heigthTotal = heigthClie + heigthEndereco;
            //variaveis para o tamanho dinâmico do quadro
            float heigthVeiculo = veiculo.TotalHeight;
            float heigthProblema = defeito.TotalHeight;
            float heigthTotal_2 = heigthVeiculo + heigthProblema;
            PdfContentByte cb = pdfWriter.DirectContent;

            //segundo quadro vertical esquerda
            cb.MoveTo(20, 767 - heigthTotal);
            cb.LineTo(20, 767 - heigthTotal - heigthTotal_2);
            cb.Stroke();
            //segundo quadro vertical direita
            cb.MoveTo(580, 767 - heigthTotal);
            cb.LineTo(580, 767 - heigthTotal - heigthTotal_2);
            cb.Stroke();
            //segundo quadro, linha horizontal cima
            cb.MoveTo(20, 767 - heigthTotal);
            cb.LineTo(580, 767 - heigthTotal);
            cb.Stroke();
            //segundo quadro, linha horizontal baixo
            cb.MoveTo(20, 767 - heigthTotal - heigthTotal_2);
            cb.LineTo(580, 767 - heigthTotal - heigthTotal_2);
            cb.Stroke();
        }

        private PdfPTable preencheVeiculo(Veiculo veiculo)
        {
            PdfPCell cell = new PdfPCell();
            //dados do veiculo         
            PdfPTable dtveiculo = new PdfPTable(6);
            dtveiculo.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            //configura o tamanho das colunas da tabela
            dtveiculo.HorizontalAlignment = 0;
            dtveiculo.TotalWidth = 580f;
            dtveiculo.LockedWidth = true;                    
            float[] dtveiculo_widths = new float[] { 40f, 150f, 50f, 130f, 50f, 140f };
              //mo       pla      cor    ano      km
            //{ 30, 100, 30, 50, 22, 60, 22, 30, 20, 50 };
            dtveiculo.SetWidths(dtveiculo_widths);
            cell = new PdfPCell(new Phrase("MOTO:", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(veiculo.Descricao, arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase("MARCA:", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(veiculo.Marca, arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase("MODELO:", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(veiculo.Modelo, arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase("COR:", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(veiculo.Cor, arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);

            cell = new PdfPCell(new Phrase("PLACA:", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(veiculo.Placa, arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);

            cell = new PdfPCell(new Phrase("ANO:", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(veiculo.Ano, arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);

            cell = new PdfPCell(new Phrase(" ", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(" ", arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);

            cell = new PdfPCell(new Phrase(" ", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(" ", arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);

            cell = new PdfPCell(new Phrase("KM:", bold)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            cell = new PdfPCell(new Phrase(veiculo.Km, arial)) { PaddingTop = 5 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            dtveiculo.AddCell(cell);
            return dtveiculo;
        }

        private PdfPTable preencheDefeito(Veiculo veiculo)
        {
            PdfPCell cell = new PdfPCell();
            PdfPTable defeito = new PdfPTable(2);
            defeito.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            //configura o tamanho das colunas da tabela
            defeito.HorizontalAlignment = 0;
            defeito.TotalWidth = 580f;
            defeito.LockedWidth = true;
            float[] defeito_widths = new float[] { 80f, 400 };
            defeito.SetWidths(defeito_widths);
            cell = new PdfPCell(new Phrase("Defeito Relatado: ", bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            defeito.AddCell(cell);

            cell = new PdfPCell(new Phrase(veiculo.Defeito, bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            defeito.AddCell(cell);

            cell = new PdfPCell(new Phrase("Defeito Verificado: ", bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            defeito.AddCell(cell);

            cell = new PdfPCell(new Phrase(veiculo.Problema_verificado, bold));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            defeito.AddCell(cell);

            return defeito;
        }

        private PdfPTable preencheHeadPecas()
        {
            PdfPCell cell = new PdfPCell();
            PdfPTable headPecas = new PdfPTable(6);
            headPecas.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            //configura o tamanho das colunas da tabela
            headPecas.HorizontalAlignment = 0;
            headPecas.TotalWidth = 580f;
            headPecas.LockedWidth = true;
            float[] headPecas_widths = new float[] { 30f, 20f, 235f, 35f, 25f, 40f };
            headPecas.SetWidths(headPecas_widths);

            cell = new PdfPCell(new Phrase("Cód", bold)) { PaddingTop = 10 };
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            headPecas.AddCell(cell);
            cell = new PdfPCell(new Phrase("Loc", bold)) { PaddingTop = 10 };
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

            return headPecas;
        }

        public void imprimeOs(int id_os)
        {
            Ordem_Servico os = new Ordem_Servico();
            Ordem_ServicoDb ordem_servicoDb = new Ordem_ServicoDb();
            Orcamento orcamento = new Orcamento();
            OrcamentoDb orcamentoDb = new OrcamentoDb();
            Veiculo veiculo = new Veiculo();
            VeiculoDb veiculoDb = new VeiculoDb();
            Itens_OrcamentoDb itens_orcamentoDb = new Itens_OrcamentoDb();
            Cliente cliente = new Cliente();
            ClienteDb clienteDb = new ClienteDb();
            EnderecoDb enderecoDb = new EnderecoDb();
            Endereco endereco = new Endereco();
            Contato contato = new Contato();
            ContatoDb contatoDb = new ContatoDb();

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

        public void imprimeVenda(int id_venda)
        {
            Venda venda = new Venda();

            Cliente cliente = new Cliente();
            ClienteDb clienteDb = new ClienteDb();
            EnderecoDb enderecoDb = new EnderecoDb();
            Endereco endereco = new Endereco();
            Contato contato = new Contato();
            ContatoDb contatoDb = new ContatoDb();

            venda = vendaDb.constroiVenda(id_venda);
            cliente = clienteDb.constroiCliente(venda.Id_cliente.ToString());

            contato = contatoDb.consultaPorId(cliente.Id_contato.ToString());
            endereco = enderecoDb.consultaPorId(cliente.Id_endereco.ToString());
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


        ////dados da venda ou OS          
        //PdfPTable refer = new PdfPTable(4);
        //refer.DefaultCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;

        ////configura o tamanho das colunas da tabela
        //refer.HorizontalAlignment = 0;
        //refer.TotalWidth = 580f;
        //refer.LockedWidth = true;
        //float[] refer_widths = new float[] { 80f, 100f, 100f, 100f };
        //refer.SetWidths(refer_widths);
        //cell = new PdfPCell(new Phrase("REFERENTE À: ", bold));
        //cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //refer.AddCell(cell);
        //cell = new PdfPCell(new Phrase("ORDEM SERVIÇO", bold));
        //cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //refer.AddCell(cell);
        //cell = new PdfPCell(new Phrase("N°: " + id_referencia, arial));
        //cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //refer.AddCell(cell);
        //cell = new PdfPCell(new Phrase(""));
        //cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //refer.AddCell(cell);
        //pdfDoc.Add(refer);

        //                                  numero crediario,   venda ou OS,   id da venda ou OS
        public void imprimeCrediario(int id_crediario, string referencia, int id_referencia)
        {
            Cliente cliente = new Cliente();
            ClienteDb clienteDb = new ClienteDb();
            EnderecoDb enderecoDb = new EnderecoDb();
            Endereco endereco = new Endereco();
            Contato contato = new Contato();
            ContatoDb contatoDb = new ContatoDb();
            crediario = crediarioDB.retornaPorId(id_crediario);
            cliente = clienteDb.constroiCliente(crediario.Id_cliente.ToString());
            contato = contatoDb.consultaPorId(cliente.Id_contato.ToString());
            endereco = enderecoDb.consultaPorId(cliente.Id_endereco.ToString());
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
                        float[] titulo_widths = new float[] { 385f, 75f};
                        titulo.SetWidths(titulo_widths);

                        cell = new PdfPCell(new Phrase(nomeRelatorio, mediumbold)) { PaddingTop = 5 };
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        titulo.AddCell(cell);
                        string data = crediario.Data.Substring(0,9);
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

        public void imprimeOrcamento(int num_orc)
        {
            Orcamento orcamento = new Orcamento();
            OrcamentoDb orcamentoDb = new OrcamentoDb();
            Veiculo veiculo = new Veiculo();
            VeiculoDb veiculoDb = new VeiculoDb();
            Itens_OrcamentoDb itens_orcamentoDb = new Itens_OrcamentoDb();
            Cliente cliente = new Cliente();
            ClienteDb clienteDb = new ClienteDb();
            EnderecoDb enderecoDb = new EnderecoDb();
            Endereco endereco = new Endereco();
            Contato contato = new Contato();
            ContatoDb contatoDb = new ContatoDb();

            string fileName = "Orcamento N°" + num_orc + ".pdf";
            string pdfPath = @"C:\Relatorios\Orcamentos\" + fileName;
            string nomeRelatorio = "    Orcamento N°" + num_orc;

            orcamento = orcamentoDb.constroiOrcamento(num_orc);
            veiculo = veiculoDb.constroiVeiculo(orcamento.Id_veiculo.ToString());
            cliente = clienteDb.constroiCliente(orcamento.Id_cliente.ToString());
            contato = contatoDb.consultaPorId(cliente.Id_contato.ToString());
            endereco = enderecoDb.consultaPorId(cliente.Id_endereco.ToString());


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

                        cell = new PdfPCell(new Phrase("Data " + orcamento.Data, mediumbold)) { PaddingTop = 5 }; ;
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
                        //cria a tabela produtos
                        PdfPTable dgProd = new PdfPTable(6);
                        dgProd.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        dgProd.HorizontalAlignment = 0;
                        dgProd.TotalWidth = 560f;
                        dgProd.LockedWidth = true;
                        float[] widths = new float[] { 30f, 20f, 235f, 35f, 25f, 40f };
                        dgProd.SetWidths(widths);
                        //preenche a tabela com dados do data grid

                        DataTable itens_orcamento = new DataTable();
                        itens_orcamento = itens_orcamentoDb.consultaTodosItens(orcamento.Id);
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



                        //cria a tabela servicos
                        PdfPTable dgServ = new PdfPTable(6);
                        dgServ.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //configura o tamanho das colunas da tabela
                        dgServ.HorizontalAlignment = 0;
                        dgServ.TotalWidth = 560f;
                        dgServ.LockedWidth = true;
                        float[] srvwidths = new float[] { 30f, 20f, 235f, 35f, 25f, 40f };
                        dgServ.SetWidths(srvwidths);
                        //preenche a tabela com dados do data grid

                        DataTable serv_orcamento = new DataTable();
                        serv_orcamento = itens_orcamentoDb.consultaServicosOrcamento(orcamento.Id);

                        for (int i = 0; i <= serv_orcamento.Rows.Count - 1; i++)
                        {

                            PdfPCell pdfCell0 = new PdfPCell(new Phrase(serv_orcamento.Rows[i][3].ToString(), baseFontNormal));
                            pdfCell0.HorizontalAlignment = Element.ALIGN_LEFT;
                            dgServ.AddCell(pdfCell0);
                            PdfPCell pdfCell1 = new PdfPCell(new Phrase(serv_orcamento.Rows[i][2].ToString(), baseFontNormal));
                            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                            dgServ.AddCell(pdfCell1);

                            //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());
                            PdfPCell pdfCell5 = new PdfPCell(new Phrase(serv_orcamento.Rows[i][4].ToString(), baseFontNormal));
                            pdfCell5.HorizontalAlignment = Element.ALIGN_LEFT;
                            dgServ.AddCell(pdfCell5);

                            for (int j = 5; j <= 6; j++)
                            {
                                //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());
                                PdfPCell pdfCell = new PdfPCell(new Phrase(serv_orcamento.Rows[i][j].ToString(), baseFontNormal));
                                pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                dgServ.AddCell(pdfCell);
                            }
                            //dgProd.AddCell(itens_orcamento.Rows[i][j].ToString());
                            PdfPCell pdfCell8 = new PdfPCell(new Phrase(serv_orcamento.Rows[i][8].ToString(), baseFontNormal));
                            pdfCell8.HorizontalAlignment = Element.ALIGN_RIGHT;
                            dgServ.AddCell(pdfCell8);

                        }
                        //adiciona a tabela ao documento
                        pdfDoc.Add(dgServ);

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

                        decimal total_pecas = itens_orcamentoDb.totalPecas(orcamento.Id);
                        decimal total_servicos = itens_orcamentoDb.totalServicos(orcamento.Id);
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
                        total.AddCell(new Phrase("Total:", bigbold));
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

        public void imprimePedido(int id_pedido)
        {
            Pedido pedido = new Pedido();
            PedidoDb pedidoDb = new PedidoDb();
            Itens_Pedido itens_pedido = new Itens_Pedido();
            Itens_PedidoDb itens_pedidoDb = new Itens_PedidoDb();
            Fornecedor fornecedor = new Fornecedor();
            FornecedorDb fornecedorDb = new FornecedorDb();
            DataTable dtItens = new DataTable();
            
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
                        float[] clie_widths = new float[] { 80f, 200f, 80f, 125F};
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

        public void relatorioEstoque(int tipo)//0 para zerado, 1 para baixo
        {
            string fileName = "";
            string nomeRelatorio = "";
            EstoqueDb estoqueDb = new EstoqueDb();
            DataTable dtItens = new DataTable();

            if(tipo == 0)
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
                            if(dtItens.Rows[i][6].ToString() == "True")
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