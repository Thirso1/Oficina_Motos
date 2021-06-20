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
    public partial class FrmCartao : Form
    {
        public FrmCartao(int tipo, decimal valor)
        {
            InitializeComponent();
            this.valor = valor;
            this.tipo = tipo;
        }

        int tipo;
        decimal valor;
        decimal dinheiro;
        string deb_cred;
        Login login = new Login();
        Recibo_cartao recibo_cartao = new Recibo_cartao();

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

        private void FrmCartao_Load(object sender, EventArgs e)
        {
            textTotal.Text = valor.ToString();
            textAut.Select();
            login = LoginDb.caixa_login();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Recebimento.Recebido = false;
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
        }

        private void textAut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnConfirmar.Select();
            }
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {

            if (textAut.Text.Length != 6)
            {
                MessageBox.Show("N° Aut inválido!");
            }
            else if (rdCredito.Checked == false && rdDebito.Checked == false)
            {
                MessageBox.Show("Selecione o tipo de cartão!");
            }
            else
            {
                if (rdCredito.Checked == true)
                {
                    recibo_cartao.Cartao = "credito";
                }
                else
                {
                    recibo_cartao.Cartao = "debito";
                }

                recibo_cartao.Valor = valor;
                recibo_cartao.Aut = textAut.Text;

                try
                {
                    Recibo_cartaoDb.insere(recibo_cartao);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }

                Fluxo_caixa fluxo = new Fluxo_caixa();
                fluxo.Grupo = TipoRecebimento(tipo);
                fluxo.Descricao = TipoRecebimento(tipo);
                fluxo.Id_forma_pag = 2;
                fluxo.Entrada = valor;
                fluxo.Saida = 0;
                fluxo.Usuario = login.Usuario;

                try
                {
                    Fluxo_caixaDb.insere(fluxo);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }

                Recebimento.Recebido = true;
                this.Close();
            }
        }

        private void rdDebito_CheckedChanged(object sender, EventArgs e)
        {
            textAut.Select();
        }

        private void rdCredito_CheckedChanged(object sender, EventArgs e)
        {
            textAut.Select();
        }
    }
}
