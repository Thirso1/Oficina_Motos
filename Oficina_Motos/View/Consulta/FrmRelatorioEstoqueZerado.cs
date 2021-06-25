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

namespace Oficina_Motos.View.Consulta
{
    public partial class FrmRelatorioEstoqueZerado : Form
    {
        EstoqueDb estoqueDb = new EstoqueDb();
        ProdutoDb produtoDb = new ProdutoDb();
        PedidoDb pedidoDb = new PedidoDb();
        Itens_PedidoDb itens_pedidoDb = new Itens_PedidoDb();
        FornecedorDb fornecedorDb = new FornecedorDb();
        int id_usuario;
        int id_pedido;
        int id_fornecedor;
        int tipo;

        public FrmRelatorioEstoqueZerado(int tipo)//0 para zerado, 1 para estoque baixo
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void FrmRelatorioEstoque_Load(object sender, EventArgs e)
        {
            criaColunas();
            carregaPedido();
            Login login = LoginDb.caixa_login();
            id_usuario = login.Id_usuario;
            dgFornecedor.DataSource = fornecedorDb.consultaTodos();
            pnFornecedor.Visible = false;
            dgPedido.DataSource = pedidoDb.consultaPorStatus("Suspenso");
            pnPedidos.Visible = false;
    }

        private void criaColunas()
        {
            DataGridViewColumn menos = new DataGridViewButtonColumn();
            DataGridViewColumn mais = new DataGridViewButtonColumn();
            DataGridViewColumn check = new DataGridViewCheckBoxColumn();

            dgProdutos.Columns.Add("id_produto", "Cód");      //0
            dgProdutos.Columns.Add("cod_barras", "Cód Barras");//1
            dgProdutos.Columns.Add("descricao", "Descricao");  //2
            dgProdutos.Columns.Add("aplicacao", "Aplicacao");  //3
            dgProdutos.Columns.Add("preco_custo", "Preco Custo");  //4
            dgProdutos.Columns.Add(menos);                   //5
            dgProdutos.Columns.Add("estoque_atual", "Estoque Atual"); //6
            dgProdutos.Columns.Add(mais);                    //7
            dgProdutos.Columns.Add("total_item", "Total Item");//8
            dgProdutos.Columns.Add("em_andamento", "Em Pedido");//9


            dgProdutos.Columns[0].Width = 50;
            dgProdutos.Columns[1].Width = 110;
            dgProdutos.Columns[2].Width = 350;
            dgProdutos.Columns[3].Width = 200;
            dgProdutos.Columns[4].Width = 80;
            dgProdutos.Columns[5].Width = 20;
            dgProdutos.Columns[6].Width = 50;
            dgProdutos.Columns[7].Width = 20;
            dgProdutos.Columns[8].Width = 80;
            dgProdutos.Columns[9].Width = 80;

            dgProdutos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgProdutos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgProdutos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProdutos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProdutos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void carregaPedido()
        {
            DataTable itensEstoque = new DataTable();
            if(tipo == 0)
            {
                itensEstoque = estoqueDb.consultaEstoqueZerado();
            }
            else if(tipo == 1)
            {
                itensEstoque = estoqueDb.consultaEstoqueBaixo();
            }
            //MessageBox.Show(itensPedido.Rows[0][3].ToString());
            for (int i = 0; i < itensEstoque.Rows.Count; i++)
            {
                // cria uma linha
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgProdutos);
                // seta os valores
                //row.Cells[0].Value = id_pedido;
                row.Cells[0].Value = Convert.ToInt32(itensEstoque.Rows[i][0]);
                row.Cells[1].Value = itensEstoque.Rows[i][1].ToString();
                row.Cells[2].Value = itensEstoque.Rows[i][2].ToString();
                row.Cells[3].Value = itensEstoque.Rows[i][3].ToString();
                row.Cells[4].Value = Convert.ToDecimal(itensEstoque.Rows[i][4]);
                row.Cells[5].Value = "-";
                row.Cells[6].Value = Convert.ToInt32(itensEstoque.Rows[i][5]);
                row.Cells[7].Value = "+";
                row.Cells[8].Value = 0;//Convert.ToDecimal(itensPedido.Rows[i][7]);
                if(Convert.ToInt64(itensEstoque.Rows[i][6]) == 0)
                {
                    row.Cells[9].Value = "Não";
                }
                if (Convert.ToInt64(itensEstoque.Rows[i][6]) == 1)
                {
                    row.Cells[9].Value = "Sim";
                }
                // adiciona na grid
                dgProdutos.Rows.Add(row);
            }
        }

        private void negrito(int linha)
        {
            dgProdutos.Rows[linha].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);

        }

        private void dgProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgProdutos.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            decimal valor_uni = Convert.ToDecimal(dgProdutos.Rows[indice].Cells[4].Value);
            int qtde = Convert.ToInt32(dgProdutos.Rows[indice].Cells[6].Value);
            decimal total_item = valor_uni * qtde;

            dgProdutos.Rows[indice].Cells[8].Value = total_item;
            negrito(indice);
        
            //totais();
        }

        private void dgProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgProdutos.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            string acao = dgProdutos.CurrentCell.Value.ToString();
            //int id_item = Convert.ToInt32(dgProdutos.Rows[indice].Cells[0].Value);
            decimal valor_uni = Convert.ToDecimal(dgProdutos.Rows[indice].Cells[4].Value);
            int qtde = Convert.ToInt32(dgProdutos.Rows[indice].Cells[6].Value);

            if (acao == "-")
            {
                if (qtde > 0)
                {
                    qtde -= 1;
                    dgProdutos.Rows[indice].Cells[6].Value = qtde;
                }
                decimal total_item = valor_uni * qtde;
                dgProdutos.Rows[indice].Cells[8].Value = total_item;
                negrito(indice);
                //totais();
            }
            else if (acao == "+")
            {
                qtde += 1;
                dgProdutos.Rows[indice].Cells[6].Value = qtde;
                decimal total_item = valor_uni * qtde;
                dgProdutos.Rows[indice].Cells[8].Value = total_item;
                negrito(indice);
                //totais();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            pnFornecedor.Visible = true;
            dgFornecedor.ClearSelection();
            btnAberto.Enabled = false;          
        }

        private void dgFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgFornecedor.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_fornecedor = Convert.ToInt32(dgFornecedor.Rows[indice].Cells[0].Value);
            //
            DialogResult result1 = MessageBox.Show("confirma?", "Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1.Equals(DialogResult.Yes))
            {
                //montar o objeto Pedido
                id_pedido = pedidoDb.geraNumPedido();
                Pedido pedido = new Pedido();
                pedido.Id = id_pedido;
                pedido.Data = DateTime.Today.ToString("yyyy-MM-dd");
                pedido.Valor = dgProdutos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[8].Value));
                pedido.Status = "Suspenso";
                pedido.Id_fornecedor = id_fornecedor;
                pedido.Id_usuario = id_usuario;
                pedidoDb.insere(pedido);
                //
                for (int i = 0; i < dgProdutos.Rows.Count; i++)
                {

                    int qtde = Convert.ToInt32(dgProdutos.Rows[i].Cells[6].Value);
                    if (qtde > 0)
                    {
                        Itens_Pedido itens_pedido = new Itens_Pedido();
                        int id_produto = Convert.ToInt32(dgProdutos.Rows[i].Cells[0].Value);
                        decimal custo = Convert.ToDecimal(dgProdutos.Rows[i].Cells[4].Value);

                        //montar o objeto Itens
                        itens_pedido.Id_pedido = id_pedido;
                        itens_pedido.Id_produto = Convert.ToInt32(dgProdutos.Rows[i].Cells[0].Value);
                        itens_pedido.Descricao = dgProdutos.Rows[i].Cells[2].Value.ToString();
                        itens_pedido.Aplicacao = dgProdutos.Rows[i].Cells[3].Value.ToString();
                        itens_pedido.Valor_uni = Convert.ToDecimal(dgProdutos.Rows[i].Cells[4].Value);
                        itens_pedido.Qtde = Convert.ToInt32(dgProdutos.Rows[i].Cells[6].Value);
                        itens_pedido.Total_item = Convert.ToDecimal(dgProdutos.Rows[i].Cells[8].Value);
                        //insere os itens
                        itens_pedidoDb.insere(itens_pedido);
                        //infirma que o item esta em pedido, inserindo true na tabela 'estoque', campo 'pedido_em_andamento'
                        estoqueDb.atualizaPedidoEmAndamento(itens_pedido.Id_produto, true);
                    }
                }

                MessageBox.Show("Pedido Iniciado, Consulte.");
                this.Close();
            }
        }

        private void dgFornecedor_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgFornecedor.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgFornecedor.Rows[e.RowIndex].Selected = true;
            }
        }

        //botao de fechar o panel fornecedor
        private void button1_Click(object sender, EventArgs e)
        {
            pnFornecedor.Visible = false;
            btnAberto.Enabled = true;
        }
        //botao de fechar o panel pedido
        private void button2_Click(object sender, EventArgs e)
        {
            pnPedidos.Visible = false;
            btnNovo.Enabled = true;
        }

        private void dgPedido_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgPedido.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgPedido.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgPedido.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_pedido = Convert.ToInt32(dgPedido.Rows[indice].Cells[1].Value);
            //
            DialogResult result1 = MessageBox.Show("confirma?", "Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1.Equals(DialogResult.Yes))
            {
                for (int i = 0; i < dgProdutos.Rows.Count; i++)
                {

                    int qtde = Convert.ToInt32(dgProdutos.Rows[i].Cells[6].Value);
                    if (qtde > 0)
                    {
                        Itens_Pedido itens_pedido = new Itens_Pedido();
                        int id_produto = Convert.ToInt32(dgProdutos.Rows[i].Cells[0].Value);
                        decimal custo = Convert.ToDecimal(dgProdutos.Rows[i].Cells[4].Value);

                        //montar o objeto Itens
                        itens_pedido.Id_pedido = id_pedido;
                        itens_pedido.Id_produto = Convert.ToInt32(dgProdutos.Rows[i].Cells[0].Value);
                        itens_pedido.Descricao = dgProdutos.Rows[i].Cells[2].Value.ToString();
                        itens_pedido.Aplicacao = dgProdutos.Rows[i].Cells[3].Value.ToString();
                        itens_pedido.Valor_uni = Convert.ToDecimal(dgProdutos.Rows[i].Cells[4].Value);
                        itens_pedido.Qtde = Convert.ToInt32(dgProdutos.Rows[i].Cells[6].Value);
                        itens_pedido.Total_item = Convert.ToDecimal(dgProdutos.Rows[i].Cells[8].Value);

                        itens_pedidoDb.insere(itens_pedido);
                        //
                        estoqueDb.atualizaPedidoEmAndamento(itens_pedido.Id_produto, true);
                    }
                }
                MessageBox.Show("Itens incluídos no Pedido N° "+id_pedido +", Consulte.");
                this.Close();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            RelatorioEstoque impressoes = new RelatorioEstoque();
            impressoes.relatorioEstoque(tipo);
        }
    }
}
