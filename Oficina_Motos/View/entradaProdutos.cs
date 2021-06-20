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
    public partial class entradaProdutos : Form
    {
        Produto produto = new Produto();
        ProdutoDb produtoDb = new ProdutoDb();
        Estoque estoque = new Estoque();
        EstoqueDb estoqueDb = new EstoqueDb();
        int id_produto;
        bool clicado = false;

        public entradaProdutos()
        {
            InitializeComponent();
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        private void entradaProdutos_Load(object sender, EventArgs e)
        {
            dgPecas.Visible = false;

        }
        //buscar
        private void button3_Click(object sender, EventArgs e)
        {
            if(txtCodBarras.Text == "" && txtDescricao.Text == "")
            {
                id_produto = Convert.ToInt32(txtId.Text);
                buscaProduto(id_produto, "");
            }
            else if (txtId.Text == "" && txtDescricao.Text == "")
            {
                buscaProduto(0, txtCodBarras.Text);
            }
        }

        private void txtId_Enter(object sender, EventArgs e)
        {
            txtCodBarras.Text = "";
            txtDescricao.Text = "";
            dgPecas.Visible = false;
        }

        private void txtCodBarras_Enter(object sender, EventArgs e)
        {
            txtDescricao.Text = "";
            txtId.Text = "";
            dgPecas.Visible = false;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtCodBarras.Text = "";
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                id_produto = Convert.ToInt32(txtId.Text);
                buscaProduto(id_produto, "");
            }
        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                buscaProduto(0, txtCodBarras.Text);
            }
        }

        private void buscaProduto(int id, string cod_barras)
        {
            if (id == 0)//consulta pelo cod_barras
            {
                produto = produtoDb.consultaPorCodBarras(cod_barras);
                if (produto.Id == 0)
                {
                    MessageBox.Show("Produto não encontrado");
                    txtCodBarras.Text = "";
                    txtCodBarras.Select();
                }
                else
                {
                    preencheProduto(produto);
                }
            }
            else//consulta pelo id
            {
                produto = produtoDb.consultaPorId(id);
                if (produto.Id == 0)
                {
                    MessageBox.Show("Produto não encontrado");
                    txtId.Text = "";
                    txtId.Select();
                }
                preencheProduto(produto);
            }
        }

        private void preencheProduto(Produto produto)
        {
            estoque = estoqueDb.consultaPorId(produto.Id);

            txtAtual.Text = estoque.Estoque_atual.ToString();
            txtMax.Text = estoque.Estoque_max.ToString();
            txtMin.Text = estoque.Estoque_min.ToString();
            txtDescricao.Text = produto.Descricao;
            txtId.Text = produto.Id.ToString();
            txtCodBarras.Text = produto.Cod_barras;
        }

        private void txtDescricao_KeyUp(object sender, KeyEventArgs e)
        {
            dgPecas.Visible = true;
            dgPecas.BringToFront();
            dgPecas.DataSource = produtoDb.consultaRapidaDescricao(txtDescricao.Text);
        }

        private void dgPecas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = false;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgPecas.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;

            id_produto = Convert.ToInt32(dgPecas.Rows[indice].Cells[0].Value);
            buscaProduto(id_produto, "");
            dgPecas.Visible = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            atualiza_max_min();
        }

        private void atualiza_max_min()
        {
            estoque.Estoque_min = Convert.ToInt32(txtMin.Text);
            estoque.Estoque_max = Convert.ToInt32(txtMax.Text);
            estoqueDb.atualiza(estoque);
        }

        private void atualiza_atual()
        {
            estoque.Estoque_atual += Convert.ToInt32(txtSuprir.Text);
            estoqueDb.atualiza(estoque);
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                atualiza_max_min();
            }
        }

        private void txtMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                atualiza_max_min();
            }
        }

        private void txtSuprir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                atualiza_atual();
                buscaProduto(id_produto, "");
                MessageBox.Show("Estoque Atualizado");
            }
        }

        private void btnSuprir_Click(object sender, EventArgs e)
        {
            if(txtSuprir.Text != "")
            {
                atualiza_atual();
                buscaProduto(produto.Id, "");
                MessageBox.Show("Estoque Atualizado");
            }            
        }

        private void dgPecas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!clicado)
            {
                dgPecas.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgPecas.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void dgPecas_Click(object sender, EventArgs e)
        {
            clicado = true;
        }
    }
}
