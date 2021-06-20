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
    public partial class FrmRetirada : Form
    {
        public FrmRetirada()
        {
            InitializeComponent();
        }
        Login login = new Login();
        Usuario usuario = new Usuario();
        UsuarioDb usuarioDb = new UsuarioDb();
        string grupo;
        string descricao;
        bool gerente;
        decimal saldo;
        private void FrmRetirada_Load(object sender, EventArgs e)
        {
            //carrega o combo de fornecedores
            loadComboBox();
            //busca o usuario logado
            login = LoginDb.caixa_login();
            textUsuario.Text = login.Usuario;
            //busca o saldo disponivel
            saldo = Fluxo_caixaDb.totalDinheiro();
            textSaldo.Text = saldo.ToString();
            textDiscriminar.Enabled = false;
            gerente = verificaPerfil();

        }

        private void loadComboBox()
        {
            FornecedorDb fornecedorDB = new FornecedorDb();
            DataTable fornecedor = new DataTable();
            fornecedor = fornecedorDB.consultaTodos();
            if (fornecedor != null)
            {
                //Carrrega itens do DataTable para a ComboBox
                for (int i = 0; i < fornecedor.Rows.Count; i++)
                {
                    cbFornecedor.Items.Add(fornecedor.Rows[i]["nome"].ToString());
                }
                cbFornecedor.Items.Add("vale funcionário");
                cbFornecedor.Items.Add("salário");
                cbFornecedor.Items.Add("recolhimento");
                cbFornecedor.Items.Add("contas de consumo");
                cbFornecedor.Items.Add("outros");

            }
        }

        private void cbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFornecedor.Text == "outros")
            {
                textDiscriminar.Enabled = true;
                grupo = "outros";
                btnConfirmar.Enabled = true;
            }
            if (cbFornecedor.Text == "contas de consumo")
            {
                textDiscriminar.Enabled = true;
                grupo = "contas de consumo";
                btnConfirmar.Enabled = true;
            }
            else if (cbFornecedor.Text != "outros" && cbFornecedor.Text != "contas de consumo")
            {
                textDiscriminar.Enabled = false;
                btnConfirmar.Enabled = true;
                grupo = "fornecedor";
            }

            if (cbFornecedor.Text == "vale funcionário" || cbFornecedor.Text == "salário")
            {
                if (gerente)
                {
                    grupo = "funcionários";
                    btnConfirmar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Usuário não autorizado");
                    btnConfirmar.Enabled = false;
                }
            }
            else if (cbFornecedor.Text == "recolhimento")
            {
                if (gerente)
                {
                    grupo = "recolhimento";
                    btnConfirmar.Enabled = true;
                    descricao = cbFornecedor.Text;
                }
                else
                {
                    MessageBox.Show("Usuário não autorizado");
                    btnConfirmar.Enabled = false;
                }
            }
           
        }

        private bool verificaPerfil()
        {
            usuario = usuarioDb.consultaPorID(login.Id_usuario);
            string perfil = usuario.Perfil;
            if(perfil == "Gerente")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (textValor.Text == "" || cbFornecedor.Text == "")
            {
            }
            else if (cbFornecedor.Text == "outros" && textDiscriminar.Text == "")
            {
                MessageBox.Show("Especifique a retirada");
                textDiscriminar.Select();
            }
            else if (cbFornecedor.Text == "contas de consumo" && textDiscriminar.Text == "")
            {
                MessageBox.Show("Especifique a retirada");
                textDiscriminar.Select();
            }
            else
            {
                if (cbFornecedor.Text == "outros" || cbFornecedor.Text == "contas de consumo")
                {
                    descricao = textDiscriminar.Text;
                }
                else
                {
                    descricao = cbFornecedor.Text;
                }
                decimal valor = Convert.ToDecimal(textValor.Text);
                if (valor > saldo)
                {
                    MessageBox.Show("Saldo indisponível");
                }
                else
                {
                    
                    DialogResult result = MessageBox.Show("Confirma retirada de: " + textValor.Text, "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        Fluxo_caixa fluxo = new Fluxo_caixa();
                        fluxo.Grupo = grupo;
                        MessageBox.Show(grupo);
                        fluxo.Descricao = descricao;
                        fluxo.Id_forma_pag = 1;
                        fluxo.Entrada = 0;
                        fluxo.Saida = valor;
                        fluxo.Usuario = login.Usuario;
                        Fluxo_caixaDb.insere(fluxo);
                        this.Close();
                    }
                }
            }           
       }       
           
        private void textValor_KeyUp(object sender, KeyEventArgs e)
        {
            {

                try
                {

                    //formata com o ponto de milhar

                    string virgula = ",";
                    //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                    //por isso na proxima linha conto quantos caractes tem no textbox
                    string dinheiro = textValor.Text;
                    int cont = textValor.Text.Length;
                    //Aqui eu coloco o cursor sempre depois do ultimo caractere
                    switch (cont)
                    {
                        case 3:
                            string posicao1 = dinheiro.Substring(0, 1);
                            string posicao2 = dinheiro.Substring(1, 1);
                            string posicao3 = dinheiro.Substring(2, 1);
                            textValor.Text = posicao1 + virgula + posicao2 + posicao3;
                            textValor.SelectionStart = textValor.Text.Length;
                            break;

                        case 5:
                            //virgula = dinheiro.Substring(1, 1); ;
                            posicao1 = dinheiro.Substring(0, 1);
                            posicao2 = dinheiro.Substring(2, 1);
                            posicao3 = dinheiro.Substring(3, 1);
                            string posicao4 = dinheiro.Substring(4, 1);
                            textValor.Text = posicao1 + posicao2 + virgula + posicao3 + posicao4;
                            textValor.SelectionStart = textValor.Text.Length;
                            //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                            break;
                        case 6:
                            //virgula = dinheiro.Substring(1, 1); ;
                            posicao1 = dinheiro.Substring(0, 1);
                            posicao2 = dinheiro.Substring(1, 1);
                            posicao3 = dinheiro.Substring(3, 1);
                            posicao4 = dinheiro.Substring(4, 1);
                            string posicao5 = dinheiro.Substring(5, 1);

                            textValor.Text = posicao1 + posicao2 + posicao3 + virgula + posicao4 + posicao5;
                            textValor.SelectionStart = textValor.Text.Length;
                            //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                            break;
                        case 7:
                            posicao1 = dinheiro.Substring(0, 1);
                            posicao2 = dinheiro.Substring(1, 1);
                            posicao3 = dinheiro.Substring(2, 1);
                            posicao4 = dinheiro.Substring(4, 1);
                            posicao5 = dinheiro.Substring(5, 1);
                            string posicao6 = dinheiro.Substring(6, 1);
                            textValor.Text = posicao1 + posicao2 + posicao3 + posicao4 + virgula + posicao5 + posicao6;
                            textValor.SelectionStart = textValor.Text.Length;
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

                            textValor.Text = posicao1 + posicao2 + posicao3 + posicao4 + posicao5 + virgula + posicao6 + posicao7;
                            textValor.SelectionStart = textValor.Text.Length;
                            //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void textValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                textValor.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == 13))
            {

                btnConfirmar.Select();
            }
        }
    }
}
