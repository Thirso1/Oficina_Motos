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
    public partial class FrmAberturaCaixa1 : Form
    {
        LoginDb loginDb = new LoginDb();
        Login login = new Login();
        Usuario usuario = new Usuario();
        UsuarioDb usuarioDb = new UsuarioDb();
        decimal dinheiro;
        decimal saldoEmCaixa;
        decimal ValorAbertura;

        public FrmAberturaCaixa1()
        {
            InitializeComponent();
        }

        private void FrmAberturaCaixa1_Load(object sender, EventArgs e)
        { 
            login = LoginDb.caixa_login();
            usuario = usuarioDb.consultaPorID(login.Id_usuario);

            if (usuario.Perfil != "Gerente")
            {
                MessageBox.Show("Usuário " + usuario.Login + " não tem permissão para abrir o caixa.");
                this.Close();
            }

            decimal valorAnterior = Convert.ToDecimal(Fluxo_caixaDb.valorAtual());
            textSaldoEmCaixa.Text = valorAnterior.ToString();            
            textUsuario.Text = login.Usuario;
            txtDinheiro.Select();
            verificaFechamentoAnterior();
        }

        private void verificaFechamentoAnterior()
        {
            DataTable fechamento = new DataTable();
            fechamento = Fluxo_caixaDb.ultimoFechamento();
            textDataUltimoFechamento.Text = fechamento.Rows[0][1].ToString();
            textRecolUltFechamento.Text = fechamento.Rows[0][6].ToString();
            textUsuarioUltFechamento.Text = fechamento.Rows[0][7].ToString();
            //fechamento.Rows[0][]
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtDinheiro.Text == "")
            {
                txtDinheiro.Select();
            }
            else
            {
                dinheiro = Convert.ToDecimal(txtDinheiro.Text);
                saldoEmCaixa = Convert.ToDecimal(textSaldoEmCaixa.Text);
                ValorAbertura = dinheiro;
                textValorAbertura.Text = ValorAbertura.ToString();
                DialogResult result = MessageBox.Show("Confirma Valor: " + textValorAbertura.Text, "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    Fluxo_caixa fluxo = new Fluxo_caixa();
                    fluxo.Grupo = "abertura";
                    fluxo.Descricao = "abertura";
                    fluxo.Id_forma_pag = 1;
                    fluxo.Entrada = ValorAbertura;
                    fluxo.Saida = 0;
                    fluxo.Usuario = login.Usuario;

                    try
                    {
                        Fluxo_caixaDb.insere(fluxo);
                        LoginDb.atualiza(1, true, login.Usuario, login.Id_usuario);
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.ToString());
                    }

                    this.Close();
                }
            }
           
        }

        private void txtDinheiro_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {

                //formata com o ponto de milhar

                string virgula = ",";
                //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                //por isso na proxima linha conto quantos caractes tem no textbox
                string dinheiro = txtDinheiro.Text;
                int cont = txtDinheiro.Text.Length;
                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                switch (cont)
                {
                    case 3:
                        string posicao1 = dinheiro.Substring(0, 1);
                        string posicao2 = dinheiro.Substring(1, 1);
                        string posicao3 = dinheiro.Substring(2, 1);
                        txtDinheiro.Text = posicao1 + virgula + posicao2 + posicao3;
                        txtDinheiro.SelectionStart = txtDinheiro.Text.Length;
                        break;

                    case 5:
                        //virgula = dinheiro.Substring(1, 1); ;
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(2, 1);
                        posicao3 = dinheiro.Substring(3, 1);
                        string posicao4 = dinheiro.Substring(4, 1);
                        txtDinheiro.Text = posicao1 + posicao2 + virgula + posicao3 + posicao4;
                        txtDinheiro.SelectionStart = txtDinheiro.Text.Length;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;
                    case 6:
                        //virgula = dinheiro.Substring(1, 1); ;
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(1, 1);
                        posicao3 = dinheiro.Substring(3, 1);
                        posicao4 = dinheiro.Substring(4, 1);
                        string posicao5 = dinheiro.Substring(5, 1);

                        txtDinheiro.Text = posicao1 + posicao2 + posicao3 + virgula + posicao4 + posicao5;
                        txtDinheiro.SelectionStart = txtDinheiro.Text.Length;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;
                    case 7:
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(1, 1);
                        posicao3 = dinheiro.Substring(2, 1);
                        posicao4 = dinheiro.Substring(4, 1);
                        posicao5 = dinheiro.Substring(5, 1);
                        string posicao6 = dinheiro.Substring(6, 1);
                        txtDinheiro.Text = posicao1 + posicao2 + posicao3 + posicao4 + virgula + posicao5 + posicao6;
                        txtDinheiro.SelectionStart = txtDinheiro.Text.Length;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;
                    case 8:
                        posicao1 = dinheiro.Substring(0, 1);//1
                        posicao2 = dinheiro.Substring(1, 1);//2
                        posicao3 = dinheiro.Substring(2, 1);//3
                        posicao4 = dinheiro.Substring(3, 1);//4
                        posicao5 = dinheiro.Substring(5, 1);//5
                        posicao6 = dinheiro.Substring(6, 1);//6
                        string posicao7 = dinheiro.Substring(7, 1);//7

                        txtDinheiro.Text = posicao1 + posicao2 + posicao3 + posicao4 + posicao5 + virgula + posicao6 + posicao7;
                        txtDinheiro.SelectionStart = txtDinheiro.Text.Length;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;

                }
            }
            catch (Exception)
            {
            }
        }

 
        private void txtDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtDinheiro.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == 13))
            {

                btnConfirmar.Select();
                if (txtDinheiro.Text == "")
                {
                    txtDinheiro.Select();
                }

                else
                {
                    dinheiro = Convert.ToDecimal(txtDinheiro.Text);
                    saldoEmCaixa = Convert.ToDecimal(textSaldoEmCaixa.Text);
                    ValorAbertura = dinheiro + saldoEmCaixa;
                    textValorAbertura.Text = ValorAbertura.ToString();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDinheiro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
