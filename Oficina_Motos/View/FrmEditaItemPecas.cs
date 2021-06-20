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
    public partial class FrmEditaItemPecas : Form
    {
        public FrmEditaItemPecas(Itens_Orcamento itens_orcamento)
        {
            InitializeComponent();
            this.itens_orcamento = itens_orcamento;
        }

        Itens_Orcamento itens_orcamento = new Itens_Orcamento();

        private void FrmEditaItemPecas_Load(object sender, EventArgs e)
        {
            textDescricao.Text = itens_orcamento.Descricao; 
            textValorUni.Text = itens_orcamento.Valor_uni.ToString();
            textQtde.Text = itens_orcamento.Qtde.ToString();
            textDesconto.Text = itens_orcamento.Desconto.ToString();
            textSubTotal.Text = itens_orcamento.Sub_total.ToString();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int qtde = Convert.ToInt32(textQtde.Text);
            decimal sub_total = Convert.ToDecimal(textSubTotal.Text);

            itens_orcamento.Valor_uni = Convert.ToDecimal(textValorUni.Text);
            itens_orcamento.Qtde = qtde;
            itens_orcamento.Desconto = Convert.ToDecimal(textDesconto.Text);
            itens_orcamento.Sub_total = sub_total;

            Itens_OrcamentoDb itensDb = new Itens_OrcamentoDb();
            itensDb.atualiza(itens_orcamento);

            this.Close();
        }

        private void textQtde_KeyUp(object sender, KeyEventArgs e)
        {
            int qtde;
            if (textQtde.Text == "")
            {
                qtde = 0;
            }
            else
            {
                qtde = Convert.ToInt32(textQtde.Text);

            }
            decimal valor_uni = Convert.ToDecimal(textValorUni.Text);          

            decimal sub_total = qtde*valor_uni;
            textSubTotal.Text = sub_total.ToString();
        }

        private void textDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            int qtde = Convert.ToInt32(textQtde.Text);
            decimal sub_total = Convert.ToDecimal(textSubTotal.Text);
            decimal desconto;
            if (textDesconto.Text == "")
            {
                desconto = 0;
            }
            else
            {
                desconto = Convert.ToDecimal(textDesconto.Text);

            }
            decimal valor_uni = Convert.ToDecimal(textValorUni.Text);

            sub_total = qtde * valor_uni - desconto;
            textSubTotal.Text = sub_total.ToString();
        }
    }
}
