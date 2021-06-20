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
    public partial class FrmCadastroServico : Form
    {
        int codServico;
        ServicoDb servicoDb = new ServicoDb();
        Servico servico = new Servico();

        public FrmCadastroServico(int cod)
        {
            InitializeComponent();
            this.codServico = cod;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        private void FrmCadastroServico_Load(object sender, EventArgs e)
        {
            if (codServico == 0)
            {
                novo();
            }
            else
            {
                atualizazao();
            }
        }

        private void novo()
        {
            codServico = servicoDb.geraCodProduto();
            txtCod.Text = codServico.ToString();
            btnSalvar.Visible = true;
            btnAtualizar.Visible = false;
            txtDesconto.Text = "0,00";
        }

        private void atualizazao()
        {
            txtCod.Text = codServico.ToString();
            btnSalvar.Visible = false;
            btnAtualizar.Visible = true;
            servico = servicoDb.consultaPorId(codServico);
            txtCod.Text = codServico.ToString();
            txtDescricao.Text = servico.Descricao;
            txtValor.Text = servico.Preco.ToString();
            txtDesconto.Text = servico.Desconto.ToString();
            txtImg.Text = servico.Imagem;

            //calculo para extrair o tempo em horas e minutos
            int totalMinutos = servico.Tempo_minutos;
            string total = (totalMinutos / 60).ToString();
            decimal hora = Decimal.Parse(total);
            hora = decimal.Floor(hora);
            int minutos_restantes = totalMinutos - ((int)hora * 60);
            //exibindo nos comboboxes
            comboBox1.Text = hora.ToString();
            comboBox2.Text = minutos_restantes.ToString();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                servico.Id = Convert.ToInt32(txtCod.Text);
                servico.Descricao = txtDescricao.Text;
                servico.Preco = Convert.ToDecimal(txtValor.Text);
                servico.Desconto = Convert.ToDecimal(txtDesconto.Text);
                servico.Imagem = txtImg.Text;
                int horas = Convert.ToInt32(comboBox1.Text);
                int minutos_hora = horas * 60;
                int tempo_minutos = minutos_hora + Convert.ToInt32(comboBox2.Text);
                servico.Tempo_minutos = tempo_minutos;
                servicoDb.atualiza(servico);
                this.Close();
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                servico.Id = Convert.ToInt32(txtCod.Text);
                servico.Descricao = txtDescricao.Text;
                servico.Preco = Convert.ToDecimal(txtValor.Text);
                servico.Desconto = Convert.ToDecimal(txtDesconto.Text);
                servico.Imagem = txtImg.Text;
                int horas = Convert.ToInt32(comboBox1.Text);
                int minutos_hora = horas * 60;
                int tempo_minutos = minutos_hora + Convert.ToInt32(comboBox2.Text);
                servico.Tempo_minutos = tempo_minutos;

                servicoDb.insere(servico);
                limpa();
            }

        }

        private bool validaCampos()
        {
            if (txtDescricao.Text == "")
            {
                txtDescricao.Select();
                return false;
            }
            else if (txtValor.Text == "")
            {
                txtValor.Select();
                return false;
            }
            else if (comboBox1.Text == "" && comboBox2.Text == "")
            {
                MessageBox.Show("Insira um tempo aproximado!");
                comboBox1.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limpa()
        {
            codServico = servicoDb.geraCodProduto();
            txtCod.Text = codServico.ToString();
            txtDescricao.Text = "";
            txtValor.Text = "";
            txtDesconto.Text = "";
            txtImg.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }


        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
                //deleta tudo pelo backspace
                if (e.KeyChar == 8)
                {
                    txtDesconto.Text = "";
                }
                //evita duas virgulas no campo
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                    txtDesconto.Text = "";
                }
                //dispara evento na tecla enter
                if (e.KeyChar == 13)
                {
                    comboBox1.Select();
                }
            }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtValor.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtValor.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                txtDesconto.Select();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                comboBox2.Select();
            }
        }

        private void txtValor_KeyUp(object sender, KeyEventArgs e)
        {
            txtValor.Text = MascaraDecimal.mascara(txtValor.Text);
            txtValor.SelectionStart = txtValor.Text.Length + 1;
        }

        private void txtDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            txtDesconto.Text = MascaraDecimal.mascara(txtDesconto.Text);
            txtDesconto.SelectionStart = txtDesconto.Text.Length + 1;
        }
    }
}
