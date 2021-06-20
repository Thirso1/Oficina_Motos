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
    public partial class FrmPedido : Form
    {
        DataTable dtProduto = new DataTable();
        ProdutoDb produtoDb = new ProdutoDb();
        PedidoDb pedidoDb = new PedidoDb();
        Pedido pedido = new Pedido();
        Fornecedor fornecedor = new Fornecedor();
        FornecedorDb fornecedorDb = new FornecedorDb();
        Itens_PedidoDb itens_pedidoDb = new Itens_PedidoDb();
        EstoqueDb estoqueDb = new EstoqueDb();
        int estoqueAtual;
        int id_pedido = 0;
        int id_usuario = 0;
        string id_peca = "0";
        string ProdDescricao;
        string ProdAplicacao;
        string localizacao;
        decimal preco_custo;
        decimal desconto_item;
        decimal total_pedido;
        bool novoPedido = false;



        public FrmPedido(int id_pedido)
        {
            InitializeComponent();
            this.id_pedido = id_pedido;
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            Login login = LoginDb.caixa_login();
            id_usuario = login.Id_usuario;

            dgBuscaPecas.Visible = false;
            textConfirmaProd.Visible = false;
            textBuscaProduto.Select();
            loadComboBox();
            criaColunas();
            //
            if (id_pedido == 0)
            {
                novoPedido = true;
                novo();
            }
            else
            {
                novoPedido = false;
                carregaPedido(id_pedido);
            }


        }

        private void novo()
        {
            id_pedido = pedidoDb.geraNumPedido();
            lblNumPedido.Text += id_pedido.ToString();
        }

        private void carregaPedido(int id_pedido)
        {
            pedido = pedidoDb.constroiPedido(id_pedido);
            lblNumPedido.Text += id_pedido.ToString();
            fornecedor = fornecedorDb.consultaPorId(pedido.Id_fornecedor);
            cbFornecedor.Text = fornecedor.Nome;

            DataTable itensPedido = new DataTable();
            itensPedido = itens_pedidoDb.consultaPorIdPedido(id_pedido);
            //MessageBox.Show(itensPedido.Rows[0][3].ToString());
            for (int i = 0; i < itensPedido.Rows.Count; i++)
            {
                //for (int j = 0; j < itensPedido.Rows.Count; j++)
                //{
                //    MessageBox.Show(itensPedido.Rows[i][0].ToString());
                //    MessageBox.Show(itensPedido.Rows[i][1].ToString());
                //    MessageBox.Show(itensPedido.Rows[i][2].ToString());
                //    MessageBox.Show(itensPedido.Rows[i][3].ToString());
                //    MessageBox.Show(itensPedido.Rows[i][4].ToString());
                //    MessageBox.Show(itensPedido.Rows[i][5].ToString());

                //}
                // cria uma linha
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgProdutos);
                // seta os valores
                //row.Cells[0].Value = id_pedido;
                row.Cells[0].Value = Convert.ToInt32(itensPedido.Rows[i][2]);//cod Produto
                row.Cells[1].Value = itensPedido.Rows[i][3].ToString();      //descrição
                row.Cells[2].Value = itensPedido.Rows[i][4].ToString();     //aplicação
                row.Cells[3].Value = Convert.ToDecimal(itensPedido.Rows[i][5]);//valor
                row.Cells[4].Value = "-";
                row.Cells[5].Value = Convert.ToInt32(itensPedido.Rows[i][6]);//qtde
                row.Cells[6].Value = "+";
                row.Cells[7].Value = Convert.ToDecimal(itensPedido.Rows[i][7]);//total
                row.Cells[8].Value = "excluir";


                // adiciona na grid
                dgProdutos.Rows.Add(row);
            }
            totais();
        }

        private void criaColunas()
        {
            DataGridViewColumn menos = new DataGridViewButtonColumn();
            DataGridViewColumn mais = new DataGridViewButtonColumn();
            DataGridViewColumn excluir = new DataGridViewButtonColumn();

            //dgProdutos.Columns.Add("id_pedido", "id_pedido");
            dgProdutos.Columns.Add("id_produto", "id_produto");
            dgProdutos.Columns.Add("descricao", "descricao");
            dgProdutos.Columns.Add("aplicacao", "aplicacao");
            dgProdutos.Columns.Add("valor_uni", "Valor Uni");
            dgProdutos.Columns.Add(menos);
            dgProdutos.Columns.Add("qtde", "Qte");
            dgProdutos.Columns.Add(mais);
            dgProdutos.Columns.Add("total_item", "Total Item");

            dgProdutos.Columns.Add(excluir);

            dgProdutos.Columns[0].Width = 50;
            dgProdutos.Columns[1].Width = 350;
            dgProdutos.Columns[2].Width = 250;
            dgProdutos.Columns[3].Width = 80;
            dgProdutos.Columns[4].Width = 20;
            dgProdutos.Columns[5].Width = 30;
            dgProdutos.Columns[6].Width = 20;
            dgProdutos.Columns[7].Width = 80;
            dgProdutos.Columns[8].Width = 80;

            dgProdutos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProdutos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProdutos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProdutos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void textBuscaProduto_KeyUp(object sender, KeyEventArgs e)
        {
            textConfirmaProd.Visible = false;
            //dimensiona automaticamente a altura do datagrid
            //int rows = dgPecas.Rows.Count + 1;
            //dgPecas.Height = rows * 22;
            dgBuscaPecas.Visible = true;
            dgBuscaPecas.BringToFront();
            dtProduto = produtoDb.consultaRapidaDescricao(textBuscaProduto.Text);
            //dtProduto.Columns.Add("Atualizar");

            //for (int i = 0; i <= dtProduto.Rows.Count - 1; i++)
            //{
            //    dtProduto.Rows[i][3] = "Atualizar";
            //}
            dgBuscaPecas.DataSource = dtProduto;
        }

        private void dgBuscaPecas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBuscaProduto.Visible = false;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgBuscaPecas.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_peca = dgBuscaPecas.Rows[indice].Cells[0].Value.ToString();
            //
            dtProduto = produtoDb.consultaParaPedido(id_peca);

            ProdDescricao = dtProduto.Rows[0][1].ToString();// + " " + dtProduto.Rows[0][2].ToString();
            ProdAplicacao = dtProduto.Rows[0][2].ToString();
            preco_custo = Convert.ToDecimal(dtProduto.Rows[0][3]);
            desconto_item = Convert.ToDecimal(dtProduto.Rows[0][4]);
            estoqueAtual = Convert.ToInt32(dtProduto.Rows[0][5]);
            localizacao = dtProduto.Rows[0][6].ToString();

            textConfirmaProd.Visible = true;
            textConfirmaProd.Text = ProdDescricao;
            textConfirmaProd.Visible = true;
            dgBuscaPecas.Visible = false;
            btnInserir.Enabled = true;
            textQtde.Text = "1";
            textQtde.Select();
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgProdutos.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            string acao = dgProdutos.CurrentCell.Value.ToString();
            //int id_item = Convert.ToInt32(dgProdutos.Rows[indice].Cells[0].Value);
            decimal valor_uni = Convert.ToDecimal(dgProdutos.Rows[indice].Cells[3].Value);
            int qtde = Convert.ToInt32(dgProdutos.Rows[indice].Cells[5].Value);

            //MessageBox.Show(dgProdutos.Rows[indice].Cells[6].Value.ToString());

            if (acao == "-")
            {
                if (qtde > 0)
                {
                    qtde -= 1;
                    dgProdutos.Rows[indice].Cells[5].Value = qtde;
                }
                decimal total_item = valor_uni * qtde;
                dgProdutos.Rows[indice].Cells[7].Value = total_item;
                totais();
            }
            else if (acao == "+")
            {
                qtde += 1;
                dgProdutos.Rows[indice].Cells[5].Value = qtde;
                decimal total_item = valor_uni * qtde;
                dgProdutos.Rows[indice].Cells[7].Value = total_item;
                totais();
            }
            else if (acao == "excluir")
            {
                dgProdutos.Rows.RemoveAt(dgProdutos.CurrentRow.Index);
                totais();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (textQtde.Text == "")
            {
                textQtde.Text = "1";
            }

            int qtde = Convert.ToInt32(textQtde.Text);
            decimal total_item = 0;
            total_item = qtde * preco_custo;
            // cria uma linha
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgProdutos);
            // seta os valores
            //row.Cells[0].Value = id_pedido;
            row.Cells[0].Value = Convert.ToInt32(id_peca);
            row.Cells[1].Value = ProdDescricao;
            row.Cells[2].Value = ProdAplicacao;
            row.Cells[3].Value = preco_custo;
            row.Cells[4].Value = "-";
            row.Cells[5].Value = qtde;
            row.Cells[6].Value = "+";
            row.Cells[7].Value = total_item;
            row.Cells[8].Value = "excluir";

            // adiciona na grid
            dgProdutos.Rows.Add(row);
            totais();
            //
            textConfirmaProd.Visible = false;
            textBuscaProduto.Text = "";
            textBuscaProduto.Visible = true;
            textBuscaProduto.Select();
            textQtde.Text = "1";
        }

        private void povoaGridPecas()
        {
            //alimenta o grid de peças 
            DataTable dtItens = new DataTable();
            dtItens = itens_pedidoDb.consultaPorIdPedido(id_pedido);

            dtItens.Columns.Add("Excluir");

            for (int i = 0; i <= dtItens.Rows.Count - 1; i++)
            {
                dtItens.Rows[i][10] = "excluir";
            }

            dgProdutos.DataSource = dtItens;
            dgProdutos.ClearSelection();
            //btnEditarIten.Enabled = false;
            //btnExcluirItem.Enabled = false;
            dgProdutos.ClearSelection();


        }

        private bool validaCampos()
        {
            if (cbFornecedor.Text == "")
            {
                MessageBox.Show("Epecifique o Fornecedor");
                cbFornecedor.Select();
                return false;
            }
            else if (textTotal.Text == "0,00")
            {
                MessageBox.Show("insira uma peça");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void atualiza(string status)
        {

            for (int i = 0; i <= dgProdutos.Rows.Count - 1; i++)
            {
                Itens_Pedido itens_pedido = new Itens_Pedido();

                //montar o objeto Itens
                itens_pedido.Id_pedido = id_pedido;
                itens_pedido.Id_produto = Convert.ToInt32(dgProdutos.Rows[i].Cells[0].Value);
                itens_pedido.Descricao = dgProdutos.Rows[i].Cells[1].Value.ToString();
                itens_pedido.Aplicacao = dgProdutos.Rows[i].Cells[2].Value.ToString();
                itens_pedido.Valor_uni = Convert.ToDecimal(dgProdutos.Rows[i].Cells[3].Value);
                itens_pedido.Qtde = Convert.ToInt32(dgProdutos.Rows[i].Cells[5].Value);
                itens_pedido.Total_item = Convert.ToDecimal(dgProdutos.Rows[i].Cells[7].Value);

                itens_pedidoDb.insere(itens_pedido);
            }

            Pedido pedido = new Pedido();
            pedido.Id = id_pedido;
            pedido.Data = DateTime.Today.ToString("yyyy-MM-dd");
            pedido.Valor = dgProdutos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[7].Value));
            MessageBox.Show(pedido.Valor.ToString());
            pedido.Status = status;
            pedido.Id_usuario = id_usuario;
            pedido.Id_fornecedor = fornecedor.Id;

            pedidoDb.atualiza(pedido);
        }

        private void salva(string status)
        {
            for (int i = 0; i <= dgProdutos.Rows.Count - 1; i++)
            {
                Itens_Pedido itens_pedido = new Itens_Pedido();

                //montar o objeto Itens
                itens_pedido.Id_pedido = id_pedido;
                itens_pedido.Id_produto = Convert.ToInt32(dgProdutos.Rows[i].Cells[0].Value);
                itens_pedido.Descricao = dgProdutos.Rows[i].Cells[1].Value.ToString();
                itens_pedido.Aplicacao = dgProdutos.Rows[i].Cells[2].Value.ToString();
                itens_pedido.Valor_uni = Convert.ToDecimal(dgProdutos.Rows[i].Cells[3].Value);
                itens_pedido.Qtde = Convert.ToInt32(dgProdutos.Rows[i].Cells[5].Value);
                itens_pedido.Total_item = Convert.ToDecimal(dgProdutos.Rows[i].Cells[7].Value);

                itens_pedidoDb.insere(itens_pedido);
                //
                estoqueDb.atualizaPedidoEmAndamento(itens_pedido.Id_produto, true);
            }

            Pedido pedido = new Pedido();
            pedido.Id = id_pedido;
            pedido.Data = DateTime.Today.ToString("yyyy-MM-dd");
            pedido.Valor = dgProdutos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[7].Value));
            pedido.Status = status;
            pedido.Id_usuario = id_usuario;
            pedido.Id_fornecedor = fornecedor.Id;

            pedidoDb.insere(pedido);
        }

        private void textConfirmaProd_Click(object sender, EventArgs e)
        {
            textConfirmaProd.Visible = false;
            textBuscaProduto.Text = textConfirmaProd.Text;
            textBuscaProduto.Visible = true;
            textBuscaProduto.Select();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos cad = new FrmCadastroProdutos(0);
            cad.ShowDialog();
        }

        private void dgProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgProdutos.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            decimal valor_uni = Convert.ToDecimal(dgProdutos.Rows[indice].Cells[3].Value);
            int qtde = Convert.ToInt32(dgProdutos.Rows[indice].Cells[5].Value);
            decimal total_item = valor_uni * qtde;

            dgProdutos.Rows[indice].Cells[7].Value = total_item;
            totais();
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
            }
        }

        private void totais()
        {
            total_pedido = dgProdutos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[7].Value));
            textTotal.Text = total_pedido.ToString("N2");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                if (novoPedido == true)
                {
                    salva("Suspenso");
                    this.Close();
                }
                else
                {
                    itens_pedidoDb.deleteTodos(id_pedido);
                    //
                    atualiza("Suspenso");
                    this.Close();
                }

            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                DialogResult result1 = MessageBox.Show("Fechar Pedido?", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result1.Equals(DialogResult.Yes))
                {
                    if (novoPedido == true)
                        {
                            salva("Não Recebido");
                            this.Close();
                        }
                        else
                        {
                            itens_pedidoDb.deleteTodos(id_pedido);
                            //
                            atualiza("Não Recebido");
                            this.Close();
                        }
                    
                }
            }
        }

        private void cbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFornecedor.Text != "")
            {
                string nome_fornededor = cbFornecedor.Text;
                fornecedor = fornecedorDb.retornaFornecedorPorNome(nome_fornededor);
                pedido.Id_fornecedor = fornecedor.Id;
            }
        }

        private void dgProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Cancelar Pedido?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1.Equals(DialogResult.Yes))
            {
                for (int i = 0; i < dgProdutos.Rows.Count; i++)
                {
                    int id_produto = Convert.ToInt32(dgProdutos.Rows[i].Cells[0].Value);
                    estoqueDb.atualizaPedidoEmAndamento(id_produto, false);
                }

                itens_pedidoDb.deleteTodos(id_pedido);
                atualiza("Cancelado");
                this.Close();
            }
        }
    }
}

