using System;
using System.Windows.Forms;
using Oficina_Motos.Controler;
using Oficina_Motos.Model;

namespace Oficina_Motos.View
{
    public partial class FrmEditaItemOrcamento : Form
    {
        public FrmEditaItemOrcamento(Itens_Orcamento itens_orcamento)
        {
            InitializeComponent();
            this.itens_orcamento = itens_orcamento;
        }

        Itens_Orcamento itens_orcamento = new Itens_Orcamento();
        Produto produto = new Produto();
        ProdutoDb produtoDb = new ProdutoDb();
        EstoqueDb estoqueDb = new EstoqueDb();
        Estoque estoque = new Estoque();
        int estoque_banco = 0;
        int qtde_original = 0;


        private void FrmEditaItemPecas_Load(object sender, EventArgs e)
        {
            textDescricao.Text = itens_orcamento.Descricao; 
            textValorUni.Text = itens_orcamento.Valor_uni.ToString();
            textQtde.Text = itens_orcamento.Qtde.ToString();
            textDesconto.Text = itens_orcamento.Desconto.ToString();
            textSubTotal.Text = itens_orcamento.Sub_total.ToString();

            produto = produtoDb.consultaPorId(itens_orcamento.Id_produto);
            estoque = estoqueDb.consultaPorId(itens_orcamento.Id_produto);
            estoque_banco = estoque.Estoque_atual;
            qtde_original = itens_orcamento.Qtde;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int nova_qtde;
            if (textQtde.Text == "")
            {
                textQtde.Text = "0";
            }
            if (textDesconto.Text == "")
            {
                textDesconto.Text = "0";
            }

            nova_qtde = Convert.ToInt32(textQtde.Text);

            if ((estoque_banco + qtde_original) < nova_qtde)
            {
                MessageBox.Show("Quantidade indisponível, " + estoque.Estoque_atual + " unidades");
                textQtde.Select();
            }
            else if ((estoque_banco + qtde_original) >= nova_qtde) //quando a nova qtde é menor que a qtde_original
            {
                if (qtde_original > nova_qtde)
                {
                    int estorno = qtde_original - nova_qtde;
                    estoqueDb.debita_credita_Qtde(produto.Id, estorno);

                }
                else if (qtde_original < nova_qtde)
                {
                    int debito = qtde_original - nova_qtde;
                    estoqueDb.debita_credita_Qtde(produto.Id, debito);
                }

                decimal sub_total = nova_qtde * itens_orcamento.Valor_uni;

                itens_orcamento.Qtde = nova_qtde;
                itens_orcamento.Desconto = Convert.ToDecimal(textDesconto.Text);
                itens_orcamento.Sub_total = sub_total - itens_orcamento.Desconto;

                Itens_OrcamentoDb itensDb = new Itens_OrcamentoDb();
                itensDb.atualiza(itens_orcamento);

                this.Close();
            }

           
        }
        private void textQtde_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void textDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            textDesconto.Text = MascaraDecimal.mascara(textDesconto.Text);
            textDesconto.SelectionStart = textDesconto.TextLength + 1;
        }

        private void textQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                textQtde.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                textQtde.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
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
                decimal sub_total = qtde * valor_uni;
                textSubTotal.Text = sub_total.ToString();
                btnSalvar.Select();
            }
        }

        private void textDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                textDesconto.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                textDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
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
                if (desconto > valor_uni)
                {
                    MessageBox.Show("Desconto não aprovado!");
                    textDesconto.Text = "";
                    textDesconto.Select();
                }
                else
                {
                    sub_total = qtde * valor_uni - desconto;
                    textSubTotal.Text = sub_total.ToString();
                    btnSalvar.Select();
                }
            }
        }        
    }
}
