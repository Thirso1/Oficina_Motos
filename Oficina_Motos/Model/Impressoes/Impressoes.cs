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
        protected Cliente cliente = new Cliente();
        protected ClienteDb clienteDb = new ClienteDb();
        protected EnderecoDb enderecoDb = new EnderecoDb();
        protected Endereco endereco = new Endereco();
        protected Contato contato = new Contato();
        protected ContatoDb contatoDb = new ContatoDb();
        protected iTextSharp.text.Font arialPequena = FontFactory.GetFont("Arial", 9);
        protected iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 10);
        protected iTextSharp.text.Font arialGrande = FontFactory.GetFont("Arial", 16);
        protected iTextSharp.text.Font bold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, Font.BOLD);
        protected iTextSharp.text.Font bigbold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, Font.BOLD);
        protected iTextSharp.text.Font mediumbold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, Font.BOLD);


        protected PdfPTable tableCliente(Cliente cliente, Contato contato)
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

        protected PdfPTable tableEndereco(Endereco endereco)
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

        protected void quadroCliente(PdfPTable Clie, PdfPTable tableEndereco, PdfWriter pdfWriter)
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

        protected void quadroVeiculo(PdfPTable Clie, PdfPTable tableEndereco, PdfPTable veiculo, PdfPTable defeito, PdfWriter pdfWriter)
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

        protected PdfPTable preencheVeiculo(Veiculo veiculo)
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

        protected PdfPTable preencheDefeito(Veiculo veiculo)
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

        protected PdfPTable preencheHeadPecas()
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
       
        
    }
}