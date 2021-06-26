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
    public partial class FrmPdv : Form
    {
        Login login = new Login();

        Produto p = new Produto();
        ProdutoDb produtoDb = new ProdutoDb();
        DataTable dtProduto = new DataTable();

        ClienteDb clienteDb = new ClienteDb();
        DataTable dtCliente = new DataTable();
        Cliente cliente = new Cliente();

        Venda venda = new Venda();
        VendaDb vendaDb = new VendaDb();
        DataTable dtVenda = new DataTable();

        Itens_Venda itens_venda = new Itens_Venda();
        Itens_VendaDb itens_vendaDb = new Itens_VendaDb();

        EstoqueDb estoqueDb = new EstoqueDb();

        bool busca_peca_clicado = false;
        bool peca_clicado = false;

        //int id_estoque;
        int qtde = 1;
        string ProdDescricao;
        string ProdAplicacao;
        decimal valor_venda = 0;
        int estoqueAtual = 0;
        string localizacao;
        decimal total_item = 0;
        int id_peca;
        int id_venda;
        decimal desconto = 0;
        decimal desconto_item = 0;
        private int forma_pag = 0;
        public int Forma_pag
        {
            get
            {
                return forma_pag;
            }

            set
            {
                forma_pag = value;
            }
        }

        private bool confirma_pagamento = false;
        public bool Confirma_pagamento
        {
            get
            {
                return confirma_pagamento;
            }

            set
            {
                confirma_pagamento = value;
            }
        }

        public FrmPdv(int id_venda)
        {
            InitializeComponent();
            this.id_venda = id_venda;
            //esse metodo muda a cor dos botoes no hover
            //RegisterFocusEvents(this.Controls);
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }
        private void FrmPdv_Load(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            lblLocalData.Text = "Itamogi, "+ thisDay.ToString("D");

            login = LoginDb.caixa_login();

            if (id_venda == 0)
            {
                loadNovaVenda();
            }
            else
            {
                loadEditarVenda(id_venda);
            }

            dgPecas.Visible = false;
            dgResultCliente.Visible = false;
            textConfirmaProd.Visible = false;
            btnInserir.Enabled = false;
            btnEditarIten.Enabled = false;
            btnExcluirItem.Enabled = false;
        }

        //essas instancias do form1 para manipular o 'visible' dos paineis
        private Form1 form_1;
        public Form1 Form_1
        {
            get
            {
                return form_1;
            }

            set
            {
                form_1 = value;
            }
        }

        private void loadNovaVenda()
        {
            id_venda = vendaDb.geraNumVenda();
            lblNumVenda.Text = id_venda.ToString();

            //vamos criar um objeto vazio e gravar no banco
            venda.Id = id_venda;
            venda.Valor_total = valor_venda;
            venda.Data_hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            venda.Desconto = total_desconto();
            venda.Status = "Em Andamento";
            venda.Id_usuario = login.Id_usuario;
            venda.Id_cliente = 0;
            cliente = clienteDb.consultaPorId(0);
            vendaDb.insere(venda);
            preencheCliente(cliente);
        }

        private void loadEditarVenda(int id_venda)
        {
            lblNumVenda.Text = id_venda.ToString();
            venda = vendaDb.constroiVenda(id_venda);

            cliente = clienteDb.consultaPorId(venda.Id_cliente);
            preencheCliente(cliente);
            povoaGridPecas();
            totais();

        }

        private void preencheCliente(Cliente cliente)
        {
            Endereco endereco = new Endereco();
            EnderecoDb enderecoDb = new EnderecoDb();
            Contato contato = new Contato();
            ContatoDb contatoDb = new ContatoDb();

            //preenche os campos cliente
            txtCliente.Text = cliente.Nome;
            txtCpf.Text = cliente.Cpf;
            txtRg.Text = cliente.Rg;

            txtTelefone.Text = cliente.Contato.Telefone_1;
            txtTelefone_2.Text = contato.Telefone_2;
            //preenche o endereço
            string logradouro = cliente.Endereco.Logradouro;
            string nome_rua = cliente.Endereco.Nome;
            string numero = cliente.Endereco.Numero;
            string bairro = cliente.Endereco.Bairro;
            string cidade = cliente.Endereco.Cidade;
            string cep = cliente.Endereco.Cep;

            txtEndereco.Text = logradouro + " " + nome_rua + " " + numero;
            txtBairro.Text = bairro;
            txtCidade.Text = cidade;
            txtCep.Text = cep;
        }

        private void txtCliente_KeyUp(object sender, KeyEventArgs e)
        {
            dgResultCliente.Visible = true;
            this.dgResultCliente.CellBorderStyle = DataGridViewCellBorderStyle.None;
            string nome = txtCliente.Text;

            dtCliente = clienteDb.consultaNome(nome);

            dgResultCliente.DataSource = dtCliente;

            dgResultCliente.BringToFront();
        }

        private void dgResultCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtCliente_Click(object sender, EventArgs e)
        {
            txtCliente.Text = string.Empty;
        }

        private void dgResultCliente_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgResultCliente.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgResultCliente.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgResultCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultCliente.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;

            cliente.Id = Convert.ToInt32(dgResultCliente.Rows[indice].Cells[0].Value);
            //preenche os campos cliente
            venda.Id_cliente = cliente.Id;
            cliente = clienteDb.consultaPorId(cliente.Id);
            preencheCliente(cliente);
            atualizaVenda("Em Andamento");

            dgResultCliente.Visible = false;
            textBuscaProduto.Select();
        }

        private void textBuscaProduto_KeyUp(object sender, KeyEventArgs e)
        {
            //dimensiona automaticamente a altura do datagrid
            //int rows = dgPecas.Rows.Count + 1;
            //dgPecas.Height = rows * 22;
            if (textBuscaProduto.Text.Length >= 3)
            {
                dgPecas.Visible = true;
                dgPecas.BringToFront();
                dtProduto = produtoDb.consultaRapidaDescricao(textBuscaProduto.Text);
                dgPecas.DataSource = dtProduto;
                dgPecas.ClearSelection();
            }
            else
            {
                dgPecas.Visible = false;
            }
        }

        private void textConfirmaProd_Click(object sender, EventArgs e)
        {
            textConfirmaProd.Visible = false;
            textBuscaProduto.Text = textConfirmaProd.Text;
            textBuscaProduto.Visible = true;
            textBuscaProduto.SelectionStart = textBuscaProduto.TextLength;
            textBuscaProduto.Select();
        }

        private void dgPecas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBuscaProduto.Visible = false;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgPecas.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;

            id_peca = Convert.ToInt32(dgPecas.Rows[indice].Cells[0].Value);
            //
            seleciona(id_peca);
        }

        private void seleciona(int id_peca)
        {
            //
            dtProduto = produtoDb.consultaPdv(id_peca);
            //
            ProdDescricao = dtProduto.Rows[0][1].ToString() + " " + dtProduto.Rows[0][2].ToString();
            //MessageBox.Show(dtProduto.Rows[0][1].ToString());
            //MessageBox.Show(dtProduto.Rows[0][2].ToString());

            ProdAplicacao = dtProduto.Rows[0][2].ToString();
            valor_venda = Convert.ToDecimal(dtProduto.Rows[0][3]);
            estoqueAtual = Convert.ToInt32(dtProduto.Rows[0][5]);
            localizacao = dtProduto.Rows[0][6].ToString();
            desconto_item = Convert.ToDecimal(dtProduto.Rows[0][4]);
            //id_estoque = Convert.ToInt32(dtProduto.Rows[0][7]);
            textConfirmaProd.Text = ProdDescricao;
            textConfirmaProd.Visible = true;
            dgPecas.Visible = false;
            btnInserir.Enabled = true;
            textQtde.Text = "1";
            textQtde.Select();
        }

        private void atualiza_estoque(int id_produto, int qtde)
        {
            estoqueDb.debita_credita_Qtde(id_produto, qtde);
        }

        private void dgProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            peca_clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgProdutos.CurrentRow;
            int indice = linhaAtual.Index;

            itens_venda.Id = Convert.ToInt32(dgProdutos.Rows[indice].Cells[0].Value);
            itens_venda.Id_venda = Convert.ToInt32(dgProdutos.Rows[indice].Cells[1].Value);

            itens_venda.Id_produto = Convert.ToInt32(dgProdutos.Rows[indice].Cells[2].Value);//mas ta dando esse erro
            itens_venda.Descricao = dgProdutos.Rows[indice].Cells[3].Value.ToString();
            itens_venda.Valor_uni = Convert.ToDecimal(dgProdutos.Rows[indice].Cells[5].Value);
            itens_venda.Qtde = Convert.ToInt32(dgProdutos.Rows[indice].Cells[6].Value);
            itens_venda.Desconto = Convert.ToDecimal(dgProdutos.Rows[indice].Cells[7].Value);
            itens_venda.Sub_total = Convert.ToDecimal(dgProdutos.Rows[indice].Cells[8].Value);
            btnEditarIten.Enabled = true;
            btnExcluirItem.Enabled = true;
        }
        //
        //botões 
        //
        private void btnInserir_Click(object sender, EventArgs e)
        {
            //montar o objeto Itens_venda
            itens_venda.Id_venda = id_venda;
            itens_venda.Id_produto = Convert.ToInt32(id_peca);
            itens_venda.Descricao = ProdDescricao.ToString();
            itens_venda.Marca = ProdAplicacao.ToString();
            itens_venda.Valor_uni = valor_venda;
            itens_venda.Qtde = qtde;
            itens_venda.Desconto = desconto_item;

            inserir(itens_venda);
        }

        private void inserir(Itens_Venda itens_venda)
        {

            if (textConfirmaProd.Text == "")
            {
                MessageBox.Show("insira uma peça!"); //caso o usuario nãi inclua uma peça, aparece esse aviso
                textBuscaProduto.Select();
            }
            else
            {
                if (textQtde.Text == "")// caso o usuario tente incluir um produto sem qtde, aparece esse aviso
                {
                    textQtde.Text = "1";
                }
                qtde = Convert.ToInt32(textQtde.Text);//converte inteiro o que foi digitado no campo qtde
                int qtde_neg = -Math.Abs(qtde); // converte para negativo

                if (estoqueAtual < qtde)
                {
                    string valores = string.Format("Quantidade indisponível! " + "{0}" + " " + "{0}" + "Unidades em estoque: " + estoqueAtual, Environment.NewLine);
                    textQtde.Text = "1";
                }
                else
                {
                    atualiza_estoque(id_peca, qtde_neg);
                    //
                    total_item = qtde * valor_venda;
                    //
                    itens_venda.Qtde = qtde;
                    itens_venda.Sub_total = total_item;

                    itens_vendaDb.insere(itens_venda);
                    //
                    textConfirmaProd.Visible = false;
                    textBuscaProduto.Text = "";
                    textBuscaProduto.Visible = true;
                    //textBuscaProduto.Select();

                    povoaGridPecas();
                    totais();
                    textQtde.Text = "1";
                    btnInserir.Enabled = false;
                }
            }
            peca_clicado = false;
        }

        private void btnEditarIten_Click(object sender, EventArgs e)
        {
            FrmEditaItemVenda editar = new FrmEditaItemVenda(itens_venda);
            editar.ShowDialog();
            povoaGridPecas();
            totais();
            peca_clicado = false;
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            atualiza_estoque(itens_venda.Id_produto, qtde);

            itens_vendaDb.delete(itens_venda);
            povoaGridPecas();
            totais();
            peca_clicado = false;
        }

        private void btnSuspender_Click(object sender, EventArgs e)
        {
            if (valor_venda == 0)
            {
                itens_vendaDb.deleteTodos(venda);
                vendaDb.delete(venda);
                this.Close();
            }
            else
            {
                atualizaVenda("Suspensa");
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cancelar essa venda?", "Não", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                itens_vendaDb.deleteTodos(venda);
                atualizaVenda("Cancelada");
                //estorna_todos_itens();
                this.Close();
            }
        }

        private void estorna_todos_itens()
        {
            for(int i= 0; i<dgProdutos.Rows.Count; i++)
            {
                Produto produto = new Produto();

                produto = produtoDb.consultaPorId(Convert.ToInt32(dgProdutos.Rows[i].Cells[2].Value));
                int qtde = Convert.ToInt32(dgProdutos.Rows[i].Cells[6].Value);
                atualiza_estoque(produto.Id, qtde);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgProdutos.Rows.Count == 0)
            {
                MessageBox.Show("Insira um produto");
                textBuscaProduto.Select();
            }
            else
            {
                DialogResult result = MessageBox.Show("Confirma finalizar venda?", "Finalizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                                                                      //num da venda, se é venda ou os, valor
                    FrmRecebimento frmRecebimento = new FrmRecebimento(venda.Id, 1, valor_venda, venda.Id_cliente);
                    frmRecebimento.Pdv = this;
                    frmRecebimento.ShowDialog();

                    if (Confirma_pagamento == true)
                    {
                        atualizaVenda("finalizada");
                        dgResultCliente.Visible = false;
                        dgPecas.Visible = false;
                        ImprimeVenda impressoes = new ImprimeVenda();
                        impressoes.imprimeVenda(venda.Id);
                        DialogResult result1 = MessageBox.Show("Nova venda?", "Não", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result1.Equals(DialogResult.Yes))
                        {
                            loadNovaVenda();
                            povoaGridPecas();
                        }
                        else
                        {
                            this.Close();

                        }
                    }
                }
            }
        }

        private void btnDiversos_Click(object sender, EventArgs e)
        {
            FrmDiversos diverso = new FrmDiversos(1, id_venda);
            diverso.ShowDialog();
            textConfirmaProd.Visible = false;
            textBuscaProduto.Text = "";
            //textBuscaProduto.Select();
            textQtde.Text = "";
            povoaGridPecas();
            totais();
            dgPecas.Visible = false;

        }
        //chama cadastro produtos
        private void btnCadastroProd_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos c = new FrmCadastroProdutos( 0);
            c.ShowDialog();
        }

        //metodos


        private void povoaGridPecas()
        {
            //alimenta o grid de peças 
            DataTable dtItens = new DataTable();
            dtItens = itens_vendaDb.consultaPorIdVenda(id_venda);
            dgProdutos.DataSource = dtItens;
            dgProdutos.ClearSelection();
            btnEditarIten.Enabled = false;
            btnExcluirItem.Enabled = false;
            dgProdutos.ClearSelection();
        }

        private void totais()
        {
            valor_venda = dgProdutos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Column18"].Value));
            txtTotal.Text = valor_venda.ToString("N2");
        }
        private decimal total_desconto()
        {
            desconto = dgProdutos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Column16"].Value));
            return desconto;
        }



        //esse metodo atualiza a venda de acordo com os valores no momento
        //somente o parametro status deve ser passado
        private void atualizaVenda(string status)
        {
            venda.Id = id_venda;
            venda.Id_cliente = cliente.Id;
            venda.Valor_total = valor_venda;
            venda.Data_hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            venda.Desconto = total_desconto();
            venda.Status = status;
            venda.Id_usuario = login.Id_usuario;

            vendaDb.atualiza(venda);
        }

        private void dgPecas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!busca_peca_clicado)
            {
                dgPecas.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgPecas.Rows[e.RowIndex].Selected = true;
                }
            }          
        }

        private void dgProdutos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!peca_clicado)
            {
                dgProdutos.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgProdutos.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void FrmPdv_Click(object sender, EventArgs e)
        {
            dgPecas.Visible = false;
        }

        private void textBuscaProduto_Enter(object sender, EventArgs e)
        {
            dgProdutos.ClearSelection();
        }

        private void dgProdutos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                //montar o objeto Itens_venda
                itens_venda.Id_venda = id_venda;
                itens_venda.Id_produto = Convert.ToInt32(id_peca);
                itens_venda.Descricao = ProdDescricao.ToString();
                itens_venda.Marca = ProdAplicacao.ToString();
                itens_venda.Valor_uni = valor_venda;
                itens_venda.Qtde = qtde;
                itens_venda.Desconto = desconto_item;

                inserir(itens_venda);
                textBuscaProduto.Select();
            }
        }

        private void textBuscaProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                dgPecas.Visible = false;
            }
            if (e.KeyChar == 13)
            {
                if (!VerificaString(textBuscaProduto.Text))
                {
                    
                    Produto produto = new Produto();
                    produto = produtoDb.consultaPorCodBarras(textBuscaProduto.Text);
 
                    if (produto.Id == 0)
                    {
                        MessageBox.Show("Produto não encontrado");
                        textBuscaProduto.Text = "";
                        textBuscaProduto.Select();
                    }
                    else
                    {
                        id_peca = produto.Id;
                        dtProduto = produtoDb.consultaPdv(produto.Id);

                        ProdDescricao = produto.Descricao + " " + produto.Marca;
                        //valor_venda = produto.Preco_venda;
                        estoqueAtual = Convert.ToInt32(dtProduto.Rows[0][5]);
                        localizacao = dtProduto.Rows[0][6].ToString();
                        desconto_item = produto.Desconto;
                        //id_estoque = produto.Id_estoque;

                        textConfirmaProd.Text = ProdDescricao;
                        textConfirmaProd.Visible = true;
                        dgPecas.Visible = false;
                        btnInserir.Enabled = true;
                        textQtde.Text = "1";

                        //montar o objeto Itens_venda
                        itens_venda.Id_venda = id_venda;
                        itens_venda.Id_produto = produto.Id;
                        itens_venda.Descricao = produto.Descricao;
                        itens_venda.Marca = produto.Marca;
                        itens_venda.Valor_uni = produto.Preco_venda;
                        itens_venda.Desconto = produto.Desconto;
                        inserir(itens_venda);
                    }
                    
                }
            }
        }

        public bool VerificaString(string str)
        {
            char[] c = str.ToCharArray();
            char le = ' ';
            for (int cont = 0; cont < c.Length; cont++)
            {
                le = c[cont];
                if (char.IsLetter(le) || char.IsPunctuation(le))
                    return true;
            }
            return false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgResultCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgPecas.Select();
                dgPecas.Rows[0].Selected = true;
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgResultCliente.Select();
                dgResultCliente.Rows[0].Selected = true;
            }
        }



        private void dgPecas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataGridViewRow linha = dgPecas.CurrentRow;
                int indice = linha.Index;
                id_peca = Convert.ToInt32(dgPecas.Rows[indice].Cells[0].Value);
                seleciona(id_peca);

            }
        }

        private void dgResultCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgResultCliente.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;

                cliente.Id = Convert.ToInt32(dgResultCliente.Rows[indice].Cells[0].Value);
                //preenche os campos cliente
                venda.Id_cliente = cliente.Id;
                cliente = clienteDb.consultaPorId(cliente.Id);
                preencheCliente(cliente);
                atualizaVenda("Em Andamento");

                dgResultCliente.Visible = false;
                textBuscaProduto.Select();
            }
        }
    }
}