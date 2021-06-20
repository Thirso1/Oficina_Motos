using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Controler;
using Oficina_Motos.Model;

namespace Oficina_Motos.View
{
    public partial class FrmCheque : Form
    {
        public FrmCheque(int tipo, decimal valor)
        {
            InitializeComponent();
            this.valor = valor;
            this.tipo = tipo;
        }

        int tipo;
        decimal valor;
        decimal cheque;
        decimal troco;
        Login login = new Login();

        string tipoRecebimento;

        string TipoRecebimento(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    tipoRecebimento = "venda";
                    break;
                case 2:
                    tipoRecebimento = "ordem serviço";
                    break;
                case 22:
                    tipoRecebimento = "ordem serviço";
                    break;
                case 222:
                    tipoRecebimento = "ordem serviço";
                    break;
                case 3:
                    tipoRecebimento = "crediario";
                    break;
                case 4:
                    tipoRecebimento = "parcela";
                    break;
            }
            return tipoRecebimento;
        }

        private FrmRecebimento recebimento;

        public FrmRecebimento Recebimento
        {
            get { return recebimento; }
            set { recebimento = value; }
        }

        private void FrmCheque_Load(object sender, EventArgs e)
        {
            textTotal.Text = valor.ToString();
            textValorCheque.Select();
            login = LoginDb.caixa_login();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (textValorCheque.Text == "")
            {
                MessageBox.Show("Preencha o valor");
                textValorCheque.Select();
            }
            else
            {
                cheque = Convert.ToDecimal(textValorCheque.Text);
                if (cheque < valor)
                {

                }
                else if (cheque > valor)
                {
                    troco = Convert.ToDecimal(textTroco.Text);

                    DialogResult result = MessageBox.Show("Confirma troco em dinheiro?", "Não", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        try
                        {
                            Fluxo_caixa fluxo = new Fluxo_caixa();
                            fluxo.Grupo = TipoRecebimento(tipo);
                            fluxo.Descricao = TipoRecebimento(tipo);
                            fluxo.Id_forma_pag = 3;
                            fluxo.Entrada = valor;
                            fluxo.Saida = 0;
                            fluxo.Usuario = login.Usuario;
                            Fluxo_caixaDb.insere(fluxo);

                            fluxo.Grupo = "troco";
                            fluxo.Descricao = "troco";
                            fluxo.Id_forma_pag = 1;
                            fluxo.Entrada = 0;
                            fluxo.Saida = troco;
                            fluxo.Usuario = login.Usuario;
                            Fluxo_caixaDb.insere(fluxo);

                            fluxo.Grupo = "troco";
                            fluxo.Descricao = "troco";
                            fluxo.Id_forma_pag = 3;
                            fluxo.Entrada = troco;
                            fluxo.Saida = 0;
                            fluxo.Usuario = login.Usuario;
                            Fluxo_caixaDb.insere(fluxo);

                            Recebimento.Recebido = true;
                            this.Close();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.ToString());
                        }
                    }
                }
                else
                {
                    Fluxo_caixa fluxo = new Fluxo_caixa();
                    fluxo.Grupo = TipoRecebimento(tipo);
                    fluxo.Descricao = TipoRecebimento(tipo);
                    fluxo.Id_forma_pag = 3;
                    fluxo.Entrada = valor;
                    fluxo.Saida = 0;
                    fluxo.Usuario = login.Usuario;
                    Fluxo_caixaDb.insere(fluxo);
                    Recebimento.Recebido = true;
                    this.Close();
                }
            }
        }

        private void textValorCheque_KeyUp(object sender, KeyEventArgs e)
        {
            string virgula = ",";
            //adicionei o try catch pois qndo ele adiciona o ponto de milhar e se vc precisar apagar todos os caracteres
            //acontece um erro. Então o catch deixa passar mesmo ocorrendo o erro.
            try
            {
                //formata com o ponto de milhar
                //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                //por isso na proxima linha conto quantos caractes tem no textbox
                string dinheiro = textValorCheque.Text;
                int cont = textValorCheque.TextLength;
                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                switch (cont)
                {
                    case 3:
                        string posicao1 = dinheiro.Substring(0, 1);
                        string posicao2 = dinheiro.Substring(1, 1);
                        string posicao3 = dinheiro.Substring(2, 1);
                        textValorCheque.Text = posicao1 + virgula + posicao2 + posicao3;
                        textValorCheque.SelectionStart = cont + 1;
                        break;

                    case 5:
                        //virgula = dinheiro.Substring(1, 1); ;
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(2, 1);
                        posicao3 = dinheiro.Substring(3, 1);
                        string posicao4 = dinheiro.Substring(4, 1);
                        textValorCheque.Text = posicao1 + posicao2 + virgula + posicao3 + posicao4;
                        textValorCheque.SelectionStart = cont + 2;
                        string verifica = textValorCheque.Text;
                        conta_ocorrencias(',', verifica);
                        break;
                    case 6:
                        //virgula = dinheiro.Substring(1, 1); ;
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(1, 1);
                        posicao3 = dinheiro.Substring(3, 1);
                        posicao4 = dinheiro.Substring(4, 1);
                        string posicao5 = dinheiro.Substring(5, 1);

                        textValorCheque.Text = posicao1 + posicao2 + posicao3 + virgula + posicao4 + posicao5;
                        textValorCheque.SelectionStart = cont + 3;
                        verifica = textValorCheque.Text;
                        conta_ocorrencias(',', verifica);
                        break;
                    case 7:
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(1, 1);
                        posicao3 = dinheiro.Substring(2, 1);
                        posicao4 = dinheiro.Substring(4, 1);
                        posicao5 = dinheiro.Substring(5, 1);
                        string posicao6 = dinheiro.Substring(6, 1);
                        textValorCheque.Text = posicao1 + posicao2 + posicao3 + posicao4 + virgula + posicao5 + posicao6;
                        textValorCheque.SelectionStart = cont + 4;
                        verifica = textValorCheque.Text;
                        conta_ocorrencias(',', verifica);
                        break;

                }
            }
            catch (Exception)
            {
            }
        }

        public void conta_ocorrencias(char caracter, string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == caracter)
                {
                    count++;
                }
            }
            if (count > 1)
            {
                textValorCheque.Text = "";
            }
        }

        private void textValorCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == 13))
            {
                btnConfirmar.Select();
                    if (textValorCheque.Text == "")
                    {
                        MessageBox.Show("Preencha o valor");
                    }
                    else
                    {
                        cheque = Convert.ToDecimal(textValorCheque.Text);
                        troco = cheque - valor;
                        textTroco.Text = troco.ToString();
                    }
            }
        }

        private void textValorCheque_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}