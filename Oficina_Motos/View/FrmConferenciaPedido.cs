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
    public partial class FrmConferenciaPedido : Form
    {

        PedidoDb pedidoDb = new PedidoDb();
        FornecedorDb fornecedorDb = new FornecedorDb();
        Itens_PedidoDb itens_pedidoDb = new Itens_PedidoDb();
        EstoqueDb estoqueDb = new EstoqueDb();
        ProdutoDb produtoDb = new ProdutoDb();
        Pedido pedido = new Pedido();

        int id_pedido = 0;
        decimal total_pedido;

        public FrmConferenciaPedido(int id_pedido)
        {
            InitializeComponent();
            this.id_pedido = id_pedido;
        }

        private void FrmConferenciaPedido_Load(object sender, EventArgs e)
        {
            lblNumero.Text += id_pedido.ToString();
            criaColunas();
            carregaPedido(id_pedido);
            pedido = pedidoDb.constroiPedido(id_pedido);
            totais();
        }

        private void criaColunas()
        {
            DataGridViewColumn menos = new DataGridViewButtonColumn();
            DataGridViewColumn mais = new DataGridViewButtonColumn();
            DataGridViewColumn check = new DataGridViewCheckBoxColumn();

            dgProdutos.Columns.Add("id_item", "id_item");      //0
            dgProdutos.Columns.Add("id_produto", "id_produto");//1
            dgProdutos.Columns.Add("descricao", "descricao");  //2
            dgProdutos.Columns.Add("aplicacao", "aplicacao");  //3
            dgProdutos.Columns.Add("valor_uni", "Valor Uni");  //4
            //dgProdutos.Columns.Add(menos);                   //
            dgProdutos.Columns.Add("qtde", "Qte");             //5
            //dgProdutos.Columns.Add(mais);                    //
            dgProdutos.Columns.Add("total_item", "Total Item");//6   
            dgProdutos.Columns.Add(check);                   //7

            dgProdutos.Columns[0].Width = 50;
            dgProdutos.Columns[1].Width = 50;
            dgProdutos.Columns[2].Width = 350;
            dgProdutos.Columns[3].Width = 250;
            dgProdutos.Columns[4].Width = 80;
            dgProdutos.Columns[5].Width = 30;
            dgProdutos.Columns[6].Width = 80;
            dgProdutos.Columns[7].Width = 80;
            //dgProdutos.Columns[8].Width = 80;
            //dgProdutos.Columns[9].Width = 80;

            dgProdutos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProdutos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgProdutos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgProdutos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgProdutos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  

         
        }

        private void carregaPedido(int id_pedido)
        {
            Pedido pedido = new Pedido();
            Fornecedor fornecedor = new Fornecedor();

            pedido = pedidoDb.constroiPedido(id_pedido);
            fornecedor = fornecedorDb.consultaPorId(pedido.Id_fornecedor);
            txtNome.Text = fornecedor.Nome;
            txtCnpj.Text = fornecedor.Cnpj;
            txtVendedor.Text = fornecedor.Vendedor;
            txtCelVendedor.Text = fornecedor.Cel_vendedor;

            DataTable itensPedido = new DataTable();
            itensPedido = itens_pedidoDb.consultaPorIdPedido(id_pedido);
            //MessageBox.Show(itensPedido.Rows[0][3].ToString());
            for (int i = 0; i < itensPedido.Rows.Count; i++)
            {
                // cria uma linha
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgProdutos);
                // seta os valores
                //row.Cells[0].Value = id_pedido;
                row.Cells[0].Value = Convert.ToInt32(itensPedido.Rows[i][0]);
                row.Cells[1].Value = Convert.ToInt32(itensPedido.Rows[i][2]);
                row.Cells[2].Value = itensPedido.Rows[i][3].ToString();
                row.Cells[3].Value = itensPedido.Rows[i][4].ToString();
                row.Cells[4].Value = Convert.ToDecimal(itensPedido.Rows[i][5]);
                //row.Cells[4].Value = "-";
                row.Cells[5].Value = Convert.ToInt32(itensPedido.Rows[i][6]);
                //row.Cells[6].Value = "+";
                row.Cells[6].Value = Convert.ToDecimal(itensPedido.Rows[i][7]);
                //row.Cells[8].Value = "excluir";


                // adiciona na grid
                dgProdutos.Rows.Add(row);
            }
            for (int i = 0; i < itensPedido.Rows.Count; i++)
            {
                dgProdutos.Rows[i].Cells[7].Value = true;
            }
        }

        private decimal totais()
        {
            total_pedido = dgProdutos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[6].Value));
            textTotal.Text = total_pedido.ToString("N2");
            return total_pedido;
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }

        private void dgProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgProdutos.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            decimal valor_uni = Convert.ToDecimal(dgProdutos.Rows[indice].Cells[4].Value);
            int qtde = Convert.ToInt32(dgProdutos.Rows[indice].Cells[5].Value);
            decimal total_item = valor_uni * qtde;

            dgProdutos.Rows[indice].Cells[6].Value = total_item;
            totais();
        }

        private void btnConferir_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Inserir itens no estoque?", "Inserir Estoque", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1.Equals(DialogResult.Yes))
            {
                for (int i = 0; i < dgProdutos.Rows.Count; i++)
                {

                    bool checado = Convert.ToBoolean(dgProdutos.Rows[i].Cells[7].Value);
                    if (checado)
                    {
                        int id_produto = Convert.ToInt32(dgProdutos.Rows[i].Cells[1].Value);
                        decimal custo = Convert.ToDecimal(dgProdutos.Rows[i].Cells[4].Value);
                        int qtde = Convert.ToInt32(dgProdutos.Rows[i].Cells[5].Value);

                        Produto produto = new Produto();
                        produto = produtoDb.consultaPorId(id_produto);
                        decimal lucro = (custo / 100) * produto.Margem_lucro;
                        decimal preco_venda = custo + lucro;
                        estoqueDb.debita_credita_Qtde(produto.Id, qtde);
                        produtoDb.atualizaPreço(id_produto, custo, preco_venda);
                    }
                }
                pedido.Valor = totais();
                pedido.Status = "Recebido";
                pedidoDb.atualiza(pedido);

                MessageBox.Show("conferido");
                this.Close();
            }
        }
    }
}
