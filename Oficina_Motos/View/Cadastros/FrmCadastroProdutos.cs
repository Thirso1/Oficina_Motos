using MySql.Data.MySqlClient;
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
using Oficina_Motos.View.Cadastros;

namespace Oficina_Motos.View
{
    public partial class FrmCadastroProdutos : Form
    {
        Produto produto = new Produto();
        ProdutoDb produtoDb = new ProdutoDb();
        Estoque estoque = new Estoque();
        EstoqueDb estoqueDb = new EstoqueDb();
        Fornecedor fornecedor = new Fornecedor();
        FornecedorDb fornecedorDb = new FornecedorDb();
        DataTable dtFornecedores = new DataTable();

        int id_produto = 0;
        int id_estoque = 0;

        private bool gravouProduto = false;
        private bool gravouEstoque = false;

        Categoria_ProdutoDb categoriaDb = new Categoria_ProdutoDb();

        string[] motos = new string[79] {
            "ADV 150",
            "America Classic",
            "BIZ 100",
            "BIZ 110i",
            "BIZ 125",
            "C 100 Dream",
            "CB 1000R",
            "CB 1300",
            "CB 300R",
            "CB 400",
            "CB 450",
            "CB 500",
            "CB 600 (Hornet)",
            "CB 650",
            "CB 750",
            "CB 900",
            "CB Twister",
            "CBR 1000",
            "CBR 1100",
            "CBR 250R",
            "CBR 450",
            "CBR 500",
            "CBR 600",
            "CBR 650",
            "CBR 900",
            "CBR 929",
            "CBR 954",
            "CBX 150",
            "CBX 200",
            "CBX 250",
            "CBX 750",
            "CG 125",
            "CG 150",
            "CG 160",
            "CH 125 R",
            "CRF",
            "CRF 1000",
            "CTX 700",
            "Elite 125",
            "Gold Wing",
            "LEAD",
            "Magna 750",
            "ML 125",
            "NC 700X",
            "NC 750X",
            "NX 150",
            "NX 200",
            "NX 350",
            "NX 4 Falcon",
            "NXR 125",
            "NXR 150",
            "NXR 160",
            "PCX",
            "POP",
            "SH",
            "Shadow",
            "Shadow Am",
            "Shadow Vt",
            "Silver Wing",
            "Super Hawk",
            "TRX (Quadriciclo)",
            "Valkyrie",
            "VFR",
            "VT 600",
            "VTX",
            "X-ADV",
            "XL 1000",
            "XL 125",
            "Xl 250",
            "XL 350",
            "XL 700V",
            "XLR 125",
            "XLX 250",
            "XLX 350",
            "XR 200",
            "XR 250",
            "XR 650",
            "XRE 190",
            "XRE 300",
            };

        string[] motosYamaha = new string[76] {
            "Axis 90",
            "Bws 50",
            "Crypton",
            "Crypton 100",
            "Drag Star 1100",
            "Drag Star 650",
            "Drag Star Xvs 650",
            "Dt 180 Z",
            "Dt 200",
            "Fazer 250 ie",
            "Fjr 1300",
            "Fz 6 600",
            "Fz1",
            "Fz6",
            "Fz6 s",
            "Fzr 1000",
            "Fzr 600",
            "Grizzly",
            "Jog 50",
            "Jog Teen 50",
            "Magesty",
            "MT 01",
            "MT 03",
            "MT 07",
            "MT 09",
            "Neo",
            "NMax",
            "Rd 125",
            "Rd 135",
            "Rd 350",
            "Rdz 125",
            "Rdz 135",
            "Royal Star 1300",
            "Tdm 225",
            "Tdm 850",
            "Tdm 900",
            "Tdr 180",
            "Tmax",
            "Trx 850",
            "TT-R",
            "V Max 1200",
            "V Max 1700",
            "V Star 1100 Classic",
            "Virago 750",
            "Wr",
            "Xj6 F",
            "Xj6 N",
            "Xjr 1200",
            "XT 1200Z",
            "XT 225",
            "XT 600",
            "XT 660",
            "Xtz 125 E",
            "Xtz 125 K",
            "Xtz 125 X",
            "Xtz 150 Crosser",
            "Xtz 250 Lander",
            "Xtz 250 Tenere",
            "Xtz 750",
            "Xv 1100",
            "Xv 250 (Virago)",
            "Xv 535",
            "Xvs Midnight",
            "YBR 125",
            "YBR 125 Factor",
            "YBR 150 Factor",
            "YFM",
            "YS 150 Fazer",
            "YS 250 Fazer",
            "YZ",
            "YZF 1000",
            "YZF 600",
            "YZF 750",
            "YZF R1",
            "YZF R3",
            "YZF R6",
            };


        public void insere()
        {
            for (int i=0; i < 76; i++)
            {
                try
                {
                    MySqlConnection conn = Conect.obterConexao();
                    //string de inserção na tabela 
                    MySqlCommand objcmd = new MySqlCommand("INSERT INTO `marca_motos` (`marca`, `moto`) values(?, ?)", conn);
                    objcmd.Parameters.Add("@marca", MySqlDbType.VarChar, 30).Value = "Yamaha";
                    objcmd.Parameters.Add("@moto", MySqlDbType.VarChar, 30).Value = motosYamaha[i];


                    //executa a inserção
                    int linhasAfetadas = objcmd.ExecuteNonQuery();
   
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
                finally
                {
                    Conect.fecharConexao();
                }
            }
           
        }
 
        public FrmCadastroProdutos(int id_produto)
        {
            InitializeComponent();
            this.id_produto = id_produto;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }
        
        private void FrmCadastroProdutos_Load(object sender, EventArgs e)
        {
            loadCategoria();
            if(id_produto > 0)
            {
                loadAtualizacao();
            }
            else if(id_produto == 0)
            {
                loadCadastro();
            }
            povoaGridHonda();
            povoaGridYamaha();

            tabControl2.Visible = false;
        }

        public DataTable consultaMotos(string marca)
        {
            string sql = "SELECT * FROM `marca_motos` WHERE `marca` = '"+ marca + "' ORDER BY `marca_motos`.`id` ASC";
            DataTable parcelas = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(parcelas);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            finally
            {
                Conect.fecharConexao();
            }
            //
            if (parcelas.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Registro!");
                return null;
            }
            else
            {
                return parcelas;
            }
        }

        void povoaGridYamaha()
        {
            int passo = 8;
            DataTable dtMotos = new DataTable();
            dtMotos = consultaMotos("Yamaha");

            //constroi a tabela pra guardar os dados
            dgYamaha.Columns.Add("0", "1");
            dgYamaha.Columns.Add("1", "1");
            dgYamaha.Columns.Add("2", "1");
            dgYamaha.Columns.Add("3", "1");
            dgYamaha.Columns.Add("4", "1");
            dgYamaha.Columns.Add("5", "1");
            dgYamaha.Columns.Add("6", "1");
            dgYamaha.Columns.Add("7", "1");

            for (int u = 0; u < 10; u++)
            {


                for (int x = passo - 8; x < passo && x < 76;)
                {
                    // cria uma linha
                    DataGridViewRow row = new DataGridViewRow();
                    // seta os valores
                    row.CreateCells(dgYamaha);
                    for (int i = 0; i < 8; i++)
                    {
                        if (x < 76)
                        {
                            row.Cells[i].Value = dtMotos.Rows[x][2];
                            x++;
                        }
                        passo += 8;
                    }
                    dgYamaha.Rows.Add(row);

                }
            }

        }


        void povoaGridHonda()
        {
            int limit = 0;
            int passo = 8;
            DataTable dtMotos = new DataTable();
            dtMotos = consultaMotos("Honda");

            //constroi a tabela pra guardar os dados
            dgHonda.Columns.Add("0", "1");
            dgHonda.Columns.Add("1", "1");
            dgHonda.Columns.Add("2", "1");
            dgHonda.Columns.Add("3", "1");
            dgHonda.Columns.Add("4", "1");
            dgHonda.Columns.Add("5", "1");
            dgHonda.Columns.Add("6", "1");
            dgHonda.Columns.Add("7", "1");

            for (int u = 0; u < 10; u++)
            {
              

                for (int x = passo - 8; x < passo && x < 79;)
                {
                    // cria uma linha
                    DataGridViewRow row = new DataGridViewRow();
                    // seta os valores
                    row.CreateCells(dgHonda);
                    for (int i = 0; i < 8; i++)
                    {
                        if (x < 79)
                        {
                            row.Cells[i].Value = dtMotos.Rows[x][2];
                            x++;
                        }
                         passo += 8;
                    }
                    dgHonda.Rows.Add(row);

                }
            }

        }

        //private void ofuscaFundo()
        //{
        //    this.BackColor = Color.Blue;
        //    foreach (Control control in this.Controls)
        //    {
        //        if ((control is TextBox) ||
        //          (control is RichTextBox) ||
        //          (control is ComboBox) ||
        //          (control is Button) ||
        //          (control is DataGridView) ||
        //          (control is TabControl) ||
        //          (control is MaskedTextBox))
        //        {
        //            control.BackColor = Color.Blue;
        //        }
        //    }
        //}

        private void loadCadastro()
        {
            produto.Id = produtoDb.geraCodProduto();
            estoque.Id = estoqueDb.geraCodEstoque();
            txtCod.Text = produto.Id.ToString();
            txtDesconto.Text = "0,00";
            txtMargemLucro.Text = "0,00";
            cbUniVenda.Text = "Unid";
            cbStatus.Text = "Ativo";
            btnAtualizar.Visible = false;
            btnSalvar.Visible = true;
            cbStatus.TabIndex = 0;
        }

        private void loadAtualizacao()
        {            
            //troca os botoes de salvar por atualizar
            btnAtualizar.Visible = true;
            btnSalvar.Visible = false;

            //trago os dados do produto nessa datatable
            produto = produtoDb.consultaPorId(id_produto);
            //passa os dados para os campos do form direto da datatable
            txtCod.Text = produto.Id.ToString();
            txtCodBar.Text = produto.Cod_barras;
            txtDescricao.Text = produto.Descricao;
            txtMarca.Text = produto.Marca;
            txtCodMarca.Text = produto.Cod_marca;        
            txtPrecoCusto.Text = produto.Preco_custo.ToString();
            txtMargemLucro.Text = produto.Margem_lucro.ToString();
            txtPrecoVenda.Text = produto.Preco_venda.ToString();
            txtDesconto.Text = produto.Desconto.ToString();
            txtImg.Text = produto.Imagem;
            cbStatus.Text = produto.Status;

            //busca a cateoria
            txtCat.Text = categoriaDb.retornaDescricaoPorId(produto.Id_categoria).ToString();
            //traz os dados de estoque nessa datatable
            estoque = estoqueDb.consultaPorId(produto.Id);

            //preenche os campos do form direto da datatable
            cbUniVenda.Text = estoque.Unid_venda;
            txtEstoqueMin.Text = estoque.Estoque_min.ToString();
            txtEstoqueAtual.Text = estoque.Estoque_atual.ToString();
            txtEstoqueMax.Text = estoque.Estoque_max.ToString();

            //localização
            string localizacao = estoque.Localizacao;
            string gondola = localizacao.Substring(0,1);
            string prateleira = localizacao.Substring(1, 1);
            string gaveta = localizacao.Substring(2, 1);

            cbGondola.Text = gondola;
            cbPrateleira.Text = prateleira;
            cbGaveta.Text = gaveta;
            //
            povoa_fornecedores(id_produto);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //o parametro tipo: '1' para salvar, '2' para atualizar
            valida(1);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //o parametro tipo: '1' para salvar, '2' para atualizar
            valida(2);
        }

        private void valida(int tipo)//o parametro tipo: '1' para salvar, '2' para atualizar
        {

            if (txtCat.Text == "")
            {
                MessageBox.Show("Selecione a categoria");
                txtCat.BackColor = Color.Tomato;
                tabControl1.SelectedIndex = 0;
                txtCat.Select();
            }
            else if (txtCodBar.Text == "")
            {
                MessageBox.Show("Preencha o código de barras");
                txtCodBar.BackColor = Color.Tomato;
                tabControl1.SelectedIndex = 0;
                txtCodBar.Select();
            }
            else if (txtDescricao.Text == "")
            {
                MessageBox.Show("PREENCHA A DESCRIÇÃO!");
                txtDescricao.BackColor = Color.Tomato;
                tabControl1.SelectedIndex = 0;
                txtDescricao.Select();
            }
            else if (txtPrecoCusto.Text == "")
            {
                MessageBox.Show("PREENCHA O PREÇO DE CUSTO");
                txtPrecoCusto.BackColor = Color.Tomato;
                tabControl1.SelectedIndex = 1;
                txtPrecoCusto.Select();
            }
            else if (txtPrecoVenda.Text == "")
            {
                MessageBox.Show("PREENCHA PREÇO DE VENDA!");
                txtPrecoVenda.BackColor = Color.Tomato;
                tabControl1.SelectedIndex = 1;
                txtPrecoVenda.Select();

            }
            else if (cbGondola.Text == "")
            {
                MessageBox.Show("PREENCHA A LOCALIZAÇÃO.");
                tabControl1.SelectedIndex = 2;
                cbGondola.Select();
            }
            else
            {
                salvar(tipo);
            }
        }

        private void montaProduto()
        {
            if (txtDesconto.Text == "")
            {
                txtDesconto.Text = "0,00";
            }
            if (txtEstoqueMax.Text == "")
            {
                txtEstoqueMax.Text = "10";
            }
            if (txtEstoqueMin.Text == "")
            {
                txtEstoqueMin.Text = "1";
            }
            if (txtEstoqueAtual.Text == "")
            {
                txtEstoqueAtual.Text = "0";
            }
            //monta o objeto produto
            produto.Id = Convert.ToInt32(txtCod.Text);
            produto.Cod_barras = txtCodBar.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Marca = txtMarca.Text;
            produto.Cod_marca = txtCodMarca.Text;
            produto.Preco_custo = Convert.ToDecimal(txtPrecoCusto.Text);
            produto.Margem_lucro = Convert.ToDecimal(txtMargemLucro.Text);
            produto.Preco_venda = Convert.ToDecimal(txtPrecoVenda.Text);
            produto.Desconto = Convert.ToDecimal(txtDesconto.Text);
            produto.Imagem = txtImg.Text;
            produto.Id_categoria = categoriaDb.retornaIdPorDescricao(txtCat.Text);
            produto.Status = cbStatus.Text;

            //monta o objeto estoque
            estoque.Unid_venda = cbUniVenda.Text;
            estoque.Estoque_min = Convert.ToInt32(txtEstoqueMin.Text);
            estoque.Estoque_max = Convert.ToInt32(txtEstoqueMax.Text);
            estoque.Estoque_atual = Convert.ToInt32(txtEstoqueAtual.Text);
            estoque.Localizacao = cbGondola.Text + cbPrateleira.Text + cbGaveta.Text;
            estoque.Id_produto = produto.Id;
        }

        //private bool verificaFornecedor()
        //{
        //    if(fornecedorDb.verificaOcorrencia())

        //    return true;
        //}


        private void insereFornecedor()
        {

            ////insere o produto na tabela produtos de orcamento
            //string inserItens = "INSERT INTO `parcela`(`id`,`id_crediario`,`num_parcela`, `qtde_parcelas`, `valor`,`vencimento`,`valor_recebido`, `status`) VALUES(NULL,?,?,?,?,?,?,?)";
            //MySqlConnection conn = Conect.obterConexao();
            //MySqlCommand objcmd = new MySqlCommand(inserItens, conn);

            //for (int i = 0; i < dgFornecedores.Rows.Count; i++)
            //{
            //    int id_fornecedor = Convert.ToInt32(dgFornecedores.Rows[i].Cells[0].Value);
            //    int id_produto = Convert.ToInt32(dgFornecedores.Rows[i].Cells[1].Value);

            //    if (fornecedorDb.verificaOcorrencia(id_fornecedor, id_produto))
            //    {
            //        insereFornecedor();
            //    }
            //    objcmd.Parameters.Add("@id_crediario", MySqlDbType.Int32, 11).Value = crediario.Id;
            //    objcmd.Parameters.Add("@num_parcela", MySqlDbType.Int32, 11).Value = dtParcelas.Rows[i]["num_parcela"];
            //    objcmd.Parameters.Add("@qtde_parcelas", MySqlDbType.Int32, 11).Value = dtParcelas.Rows[i]["qtde_parcela"];
            //    objcmd.Parameters.AddWithValue("@valor", dataGridView1.Rows[i].Cells[1].Value);
            //    string dataBarra = dataGridView1.Rows[i].Cells[2].Value.ToString() + " 00:00:00";
            //    DateTime date = new DateTime();
            //    date = Convert.ToDateTime(dataBarra);
            //    date.ToString("yyyy-MM-dd");

            //    objcmd.Parameters.Add("@vencimento", MySqlDbType.Date).Value = date;
            //    objcmd.Parameters.Add("@_valorRecebido", MySqlDbType.Decimal, 8).Value = 0.00;
            //    objcmd.Parameters.Add("@_status", MySqlDbType.Int32, 11).Value = 0;
            //    try
            //    {
            //        //executa a inserção
            //        objcmd.ExecuteNonQuery();

            //    }
            //    catch (Exception erro)
            //    {
            //        string teste = erro.ToString();
            //        MessageBox.Show(teste);
            //    }
            //    objcmd.Parameters.Clear();
            
        //}
    }

        private void salvar(int tipo)
        {


            if (tipo == 1)
            {
                montaProduto();
                produtoDb.insere(produto);
                estoqueDb.insere(estoque);

                DialogResult result = MessageBox.Show("Cadastrar novo produto?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    loadCadastro();
                    limpCampProd();
                    tabControl1.SelectTab(0);
                    txtCat.Select();
                }         
            }
            if (tipo == 2)
            {
                montaProduto();

                estoqueDb.atualiza(estoque);
                produtoDb.atualiza(produto);
                this.Close();
            }
        }

        private void limpCampProd()
        {
            txtCat.Text = string.Empty;
            txtCodBar.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtPrecoCusto.Text = string.Empty;
            txtPrecoVenda.Text = string.Empty;
            txtMargemLucro.Text = string.Empty;
            txtCodMarca.Text = string.Empty;
            txtDesconto.Text = string.Empty;
            cbUniVenda.Text = string.Empty;
            txtEstoqueMin.Text = string.Empty;
            cbGondola.Text = string.Empty;
            cbGaveta.Text = string.Empty;
            cbPrateleira.Text = string.Empty;

            txtEstoqueAtual.Text = string.Empty;
            txtEstoqueMax.Text = string.Empty;

        }           
  
        private void loadCategoria()
        {
            DataTable categoria = new DataTable();
            categoria = categoriaDb.consultaTodos();
            if (categoria != null)
            {
                //Carrrega itens do DataTable para a ComboBox
                for (int i = 0; i < categoria.Rows.Count; i++)
                {
                    txtCat.Items.Add(categoria.Rows[i]["descricao"].ToString());
                }
            }
            txtCat.TabIndex = 0;
        }

        //private void loadCategoria()
        //{
        //    DataTable categoria = new DataTable();
        //    categoria = categoriaDb.consultaTodos();
        //    if (categoria != null)
        //    {
        //        //Carrrega itens do DataTable para a ComboBox
        //        for (int i = 0; i < categoria.Rows.Count; i++)
        //        {
        //            txtCat.Items.Add(categoria.Rows[i]["descricao"].ToString());
        //        }
        //    }
        //}

        private void txtPrecoCusto_KeyUp_1(object sender, KeyEventArgs e)
        {
            txtPrecoCusto.Text = MascaraDecimal.mascara(txtPrecoCusto.Text);
            int cont = txtPrecoCusto.Text.Length;
            txtPrecoCusto.SelectionStart = cont + 1;
        }

        private void txtPrecoVenda_KeyUp_1(object sender, KeyEventArgs e)
        {
            txtPrecoVenda.Text = MascaraDecimal.mascara(txtPrecoVenda.Text);
            int cont = txtPrecoVenda.Text.Length;
            txtPrecoVenda.SelectionStart = cont + 1;
        }

        private void txtDesconto_KeyUp_1(object sender, KeyEventArgs e)
        {
            txtDesconto.Text = MascaraDecimal.mascara(txtDesconto.Text);
            int cont = txtDesconto.Text.Length;
            txtDesconto.SelectionStart = cont + 1;
        }

        private void txtPrecoCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtPrecoCusto.Text = "";
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtPrecoCusto.Text = "";
            }
          
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                txtPrecoVenda.Select();
            }
        }

        private void txtPrecoVenda_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtPrecoVenda.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtPrecoVenda.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                if (txtPrecoCusto.Text == "")
                {
                }
                else if (txtPrecoVenda.Text == "")
                {
                }
                else
                {
                    txtMargemLucro.Text = "0,00";
                    calculaValores("venda");
                    txtMargemLucro.Select();
                }
            }
        }

        private void txtDesconto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtDesconto.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {

            }
        }

        private void txtPrecoVenda_Leave(object sender, EventArgs e)
        {
            if (txtPrecoCusto.Text == "")
            {
            }
            else if (txtPrecoVenda.Text == "")
            {
            }
            else
            {
                txtMargemLucro.Text = "0,00";
                calculaValores("venda");
            }
        }

        private void txtMargemLucro_Leave(object sender, EventArgs e)
        {
            if (txtPrecoCusto.Text == "")
            {
            }
            else if (txtMargemLucro.Text == "")
            {
            }
            else
            {
                txtPrecoVenda.Text = "0,00";
                calculaValores("lucro");
            }
        }

        private void txtMargemLucro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtDesconto.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            if (e.KeyChar == 13)
            {
                txtPrecoVenda.Text = "0,00";
                calculaValores("lucro");
                txtDesconto.Select();
            }
        }

        void calculaValores(string tipo)
        {

            decimal custo = Convert.ToDecimal(txtPrecoCusto.Text);
            decimal venda = Convert.ToDecimal(txtPrecoVenda.Text);
            decimal lucro = Convert.ToDecimal(txtMargemLucro.Text);
            if (tipo == "venda")
            {
                lucro = ((venda - custo) / custo) * 100;
                lucro = Math.Round(lucro, 2);
                txtMargemLucro.Text = lucro.ToString();
            }
            if (tipo == "lucro")
            {
                venda = custo + ((custo / 100) * lucro);
                venda = Math.Round(venda, 2);
                txtPrecoVenda.Text = venda.ToString();
            }
        }

        private void txtEstoqueMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtDesconto.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {

            }
        }

        private void txtEstoqueMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtDesconto.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {

            }
        }

        private void txtEstoqueAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtDesconto.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {

            }
        }


        private void txtCodBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                txtDesconto.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                txtDesconto.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {

            }
        }        

        private void cbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 09)
            {
                tabControl1.SelectTab(1);
                txtPrecoCusto.Select();
            }
        }

        private void btnListarFornecedores_Click(object sender, EventArgs e)
        {
            //ofuscaFundo();
            FrmInsereFornecedor c = new FrmInsereFornecedor(produto.Id);
            c.ShowDialog();
            povoa_fornecedores(id_produto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpCampProd();
        }

        private void dgMotos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgHonda.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            string valorCelula = dgHonda.CurrentCell.Value.ToString();
            txtMarca.Text += " /" + valorCelula;
        }

        private void btnOkMotos_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = false;
        }

        private void dgYamaha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgYamaha.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            string valorCelula = dgYamaha.CurrentCell.Value.ToString();
            txtMarca.Text += " /" + valorCelula;
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {
        }

        private void povoa_fornecedores(int id_produto)
        {
            dtFornecedores.Rows.Clear();
            dtFornecedores = fornecedorDb.fornecedorPorProduto(produto.Id);
            dgFornecedores.DataSource = dtFornecedores;
        }

        private void txtCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodBar.Select();
        }

        private void txtMarca_Enter(object sender, EventArgs e)
        {
            tabControl2.Visible = true;
        }
    }
}
