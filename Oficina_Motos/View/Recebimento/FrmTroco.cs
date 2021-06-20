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
    public partial class FrmTroco : Form
    {
        public FrmTroco(int tipo, decimal valor)
        {
            InitializeComponent();
            this.valor = valor;
            this.tipo = tipo;
        }

        int tipo;
        decimal valor;
        decimal dinheiro;
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

        private void FrmTroco_Load(object sender, EventArgs e)
        {
            textTotal.Text = valor.ToString();
            texdinheiro.Select();
            login = LoginDb.caixa_login();
        }

        private FrmRecebimento recebimento;
        public FrmRecebimento Recebimento
        {
            get { return recebimento; }
            set { recebimento = value; }
        }

        private void texdinheiro_KeyUp(object sender, KeyEventArgs e)
        {
            texdinheiro.Text = MascaraDecimal.mascara(texdinheiro.Text);
            texdinheiro.SelectionStart = texdinheiro.TextLength + 1;
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
                    texdinheiro.Text = "";
                }
        }

         void texdinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                //deleta tudo pelo backspace
                if (e.KeyChar == 8)
                {
                    texdinheiro.Text = "";
                }
                //evita duas virgulas no campo
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                }
                btnConfirmar.Select();
                if (texdinheiro.Text == "")
                {
                    texdinheiro.Text = "0,00";
                }
                dinheiro = Convert.ToDecimal(texdinheiro.Text);
                decimal troco;

                if (dinheiro < valor)
                {
                    
                    texdinheiro.Text = "";
                    textroco.Text = "0,00";
                    texdinheiro.Select();
                }
                else if (dinheiro >= valor)
                {
                    troco = dinheiro - valor;
                    textroco.Text = troco.ToString();
                }
            }
        }

         private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Fluxo_caixa fluxo = new Fluxo_caixa();
            fluxo.Grupo = TipoRecebimento(tipo);
            fluxo.Descricao = TipoRecebimento(tipo);
            fluxo.Id_forma_pag = 1;
            fluxo.Entrada = valor;
            fluxo.Saida = 0;
            fluxo.Usuario = login.Usuario;
            Fluxo_caixaDb.insere(fluxo);

            Recebimento.Recebido = true;
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Recebimento.Recebido = false;
            this.Close();
        }
    }
}
