using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Model;
using Oficina_Motos.Controler;


namespace Oficina_Motos.View
{
    public partial class FrmFechamento : Form
    {
        Login login = new Login();

        decimal entradaDinheiro = 0;
        decimal entradaCartao = 0;
        decimal entradaCheques = 0;

        decimal saidaDinheiro = 0;
        decimal saidaCheques = 0;

        decimal saldoDinheiro = 0;
        decimal saldoCheque = 0;

        decimal recolherDinheiro = 0;
        decimal recolherCheques = 0;
        decimal fundoCaixa = 0;
   
        public FrmFechamento()
        {
            InitializeComponent();
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        private void FrmFechamento_Load(object sender, EventArgs e)
        {
            login = LoginDb.caixa_login();
            textUsuario.Text = login.Usuario;
            textRecolherDinheiro.Select();
            preencheValores();
        }

        private void preencheValores()
        {
            entradaDinheiro = Fluxo_caixaDb.entradasPorForma(1);
            entradaCartao = Fluxo_caixaDb.entradasPorForma(2);
            entradaCheques = Fluxo_caixaDb.entradasPorForma(3);
            saidaDinheiro = Fluxo_caixaDb.saidasPorForma(1);
            saidaCheques = Fluxo_caixaDb.saidasPorForma(3);
            saldoDinheiro = Fluxo_caixaDb.saldoPorForma(1);
            saldoCheque = Fluxo_caixaDb.saldoPorForma(3);


            Fechamento ultimoFechamento = new Fechamento();
            FechamentoDb fechamentoDb = new FechamentoDb();
            ultimoFechamento = fechamentoDb.ultimoFechamento();

            textEntradaDinheiro.Text = entradaDinheiro.ToString();
            textEntradaCartao.Text = entradaCartao.ToString();
            textEntradaCheque.Text = entradaCheques.ToString();

            textSaidaDinheiro.Text = saidaDinheiro.ToString();
            textRecolhimentoCheques.Text = saidaCheques.ToString();

            textSaldoDinheiro.Text = saldoDinheiro.ToString();
            textSaldoCheque.Text = saldoCheque.ToString();

            textRecolherDinheiro.Text = saldoDinheiro.ToString();
            textRecolherCheques.Text = saldoCheque.ToString();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            calculaFundoCaixa();

            string valores = string.Format("Dinheiro: "+ textRecolherDinheiro.Text + "{0}"+"Cheques:"+ textRecolherCheques.Text + "{0}"+"Fundo de Caixa: "+ calculaFundoCaixa().ToString(), Environment.NewLine);

            DialogResult result = MessageBox.Show(valores, "Confirma Recolhimento: ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                try
                {
                    Fluxo_caixa recolhimentoDinheiro = new Fluxo_caixa();
                    recolhimentoDinheiro.Grupo = "recolhimento";
                    recolhimentoDinheiro.Descricao = "recolhimento";
                    recolhimentoDinheiro.Id_forma_pag = 1;
                    recolhimentoDinheiro.Entrada = 0;
                    recolhimentoDinheiro.Saida = Convert.ToDecimal(textRecolherDinheiro.Text);
                    recolhimentoDinheiro.Usuario = login.Usuario;

                    Fluxo_caixa recolhimentoCheques = new Fluxo_caixa();
                    recolhimentoCheques.Grupo = "recolhimento";
                    recolhimentoCheques.Descricao = "recolhimento";
                    recolhimentoCheques.Id_forma_pag = 3;
                    recolhimentoCheques.Entrada = 0;
                    recolhimentoCheques.Saida = Convert.ToDecimal(textRecolherCheques.Text);
                    recolhimentoCheques.Usuario = login.Usuario;

                    Fechamento fechamento = new Fechamento();
                    fechamento.EntradaDinheiro = entradaDinheiro;
                    fechamento.EntradaCartao = entradaCartao;
                    fechamento.EntradaCheque = entradaCheques;
                    fechamento.SaidaDinheiro = saidaDinheiro;
                    fechamento.SaidaCheque = saidaCheques;
                    fechamento.RecolhimentoCheque = recolhimentoCheques.Saida;
                    fechamento.RecolhimentoDinheiro = recolhimentoDinheiro.Saida;
                    fechamento.FundoCaixa = calculaFundoCaixa();
                    fechamento.Id_usuario = login.Id_usuario;

                    Fluxo_caixaDb.insere(recolhimentoDinheiro);
                    Fluxo_caixaDb.insere(recolhimentoCheques);
                    FechamentoDb fechamentoDb = new FechamentoDb();
                    fechamentoDb.insere(fechamento);
                    LoginDb.atualiza(1, false, login.Usuario, login.Id_usuario);

                    MessageBox.Show("Caixa Fechado!");
                    //Impressoes.fechamentoCaixa();
                    this.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
            }
        }

        private void textRecolherDinheiro_KeyUp(object sender, KeyEventArgs e)
        {
            textRecolherDinheiro.Text = MascaraDecimal.mascara(textRecolherDinheiro.Text);
            textRecolherDinheiro.SelectionStart = textRecolherDinheiro.Text.Length;

        }

        private void textRecolherDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                textRecolherDinheiro.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == 13))
            {

                btnConfirmar.Select();
                calculaFundoCaixa();
            }
        }

        private decimal calculaFundoCaixa()
        {
            if (textRecolherDinheiro.Text == "")
            {
                textRecolherDinheiro.Text = "0,00";
            }
            recolherDinheiro = Convert.ToDecimal(textRecolherDinheiro.Text);

            fundoCaixa = saldoDinheiro - recolherDinheiro;
            if(fundoCaixa < 0)
            {
                textFundoCaixa.Text = "";
                textRecolherDinheiro.Text = "";
                textRecolherDinheiro.Select();
            }
            else
            {
                textFundoCaixa.Text = fundoCaixa.ToString();
                return fundoCaixa;
            }
            return 0;
        }

        private void FrmFechamento_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
