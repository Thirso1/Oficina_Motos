using System;
using System.Windows.Forms;
using Oficina_Motos.Controler;
using Oficina_Motos.Model;

namespace Oficina_Motos.View
{
    public partial class FrmDiversos : Form
    {
        int tipo;
        int id;
        //o primeiro inteiro indica se é venda ou orcamento, o segundo o id da venda ou orcamen
        public FrmDiversos(int tipo, int id)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.id = id;
        }

        Itens_Venda itens_venda = new Itens_Venda();
        Itens_VendaDb itens_VendaDb = new Itens_VendaDb();
        Itens_Orcamento itens_orcamento = new Itens_Orcamento();
        Itens_OrcamentoDb itens_orcamentoDb = new Itens_OrcamentoDb();

        private void executa_insercao()
        {
            // 1 para venda
            if (tipo == 1)
            {
                itens_venda.Id_venda = id;
                itens_venda.Id_produto = 99999;
                itens_venda.Descricao = txtDescricao.Text;
                itens_venda.Valor_uni = Convert.ToDecimal(txtValor.Text);
                itens_venda.Qtde = 1;
                itens_venda.Sub_total = itens_venda.Valor_uni;

                itens_VendaDb.insere(itens_venda);
            }
            // 2 para orcamento
            if (tipo == 2)
            {
                itens_orcamento.Id_orcamento = id;
                itens_orcamento.Id_produto = 99999;
                itens_orcamento.Id_servico = 0;
                itens_orcamento.Descricao = txtDescricao.Text;
                itens_orcamento.Valor_uni = Convert.ToDecimal(txtValor.Text);
                itens_orcamento.Qtde = 1;
                itens_orcamento.Desconto = 0;
                itens_orcamento.Sub_total = itens_orcamento.Valor_uni;
                itens_orcamentoDb.insere(itens_orcamento);
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
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
            if (e.KeyChar == 13)
            {
                if (txtValor.Text == "")
                {
                    MessageBox.Show("Preencha o campo");
                    txtValor.Focus();
                    txtValor.Select();
                }
                else if (txtValor.Text == "")
                {
                    MessageBox.Show("Informe a Quantidade.");
                    txtValor.Focus();
                    txtValor.Select();
                }
                else
                {
                    executa_insercao();
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "")
            {
                MessageBox.Show("Preencha o campo");
                txtValor.Focus();
                txtValor.Select();
            }
            else if (txtValor.Text == "")
            {
                MessageBox.Show("Informe a Quantidade.");
                txtValor.Focus();
                txtValor.Select();
            }
            else
            {
                executa_insercao();
                this.Close();
            }
        }

        private void txtValor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //formata com o ponto de milhar
                string virgula = ",";
                //Toda vez que digita após adicionar o ponto de milhar o cursor volta pro inicio do textbox
                //por isso na proxima linha conto quantos caractes tem no textbox
                string dinheiro = txtValor.Text;
                int cont = txtValor.TextLength;
                //Aqui eu coloco o cursor sempre depois do ultimo caractere
                switch (cont)
                {
                    case 3:
                        string posicao1 = dinheiro.Substring(0, 1);
                        string posicao2 = dinheiro.Substring(1, 1);
                        string posicao3 = dinheiro.Substring(2, 1);
                        txtValor.Text = posicao1 + virgula + posicao2 + posicao3;
                        txtValor.SelectionStart = cont + 1;
                        break;

                    case 5:
                        //virgula = dinheiro.Substring(1, 1); ;
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(2, 1);
                        posicao3 = dinheiro.Substring(3, 1);
                        string posicao4 = dinheiro.Substring(4, 1);
                        txtValor.Text = posicao1 + posicao2 + virgula + posicao3 + posicao4;
                        txtValor.SelectionStart = cont + 2;
                        string verifica = txtValor.Text;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;
                    case 6:
                        //virgula = dinheiro.Substring(1, 1); ;
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(1, 1);
                        posicao3 = dinheiro.Substring(3, 1);
                        posicao4 = dinheiro.Substring(4, 1);
                        string posicao5 = dinheiro.Substring(5, 1);

                        txtValor.Text = posicao1 + posicao2 + posicao3 + virgula + posicao4 + posicao5;
                        txtValor.SelectionStart = cont + 3;
                        verifica = txtValor.Text;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;
                    case 7:
                        posicao1 = dinheiro.Substring(0, 1);
                        posicao2 = dinheiro.Substring(1, 1);
                        posicao3 = dinheiro.Substring(2, 1);
                        posicao4 = dinheiro.Substring(4, 1);
                        posicao5 = dinheiro.Substring(5, 1);
                        string posicao6 = dinheiro.Substring(6, 1);
                        txtValor.Text = posicao1 + posicao2 + posicao3 + posicao4 + virgula + posicao5 + posicao6;
                        txtValor.SelectionStart = cont + 4;
                        verifica = txtValor.Text;
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

                        txtValor.Text = posicao1 + posicao2 + posicao3 + posicao4 + posicao5 + virgula + posicao6 + posicao7;
                        txtValor.SelectionStart = cont + 4;
                        verifica = txtValor.Text;
                        //txtPrecoVenda.Text = conta_ocorrencias(',', txtPrecoVenda.Text);
                        break;

                }
            }
            catch (Exception)
            {
            }
        }

        private void FrmDiversos_Load(object sender, EventArgs e)
        {

        }
    }
}