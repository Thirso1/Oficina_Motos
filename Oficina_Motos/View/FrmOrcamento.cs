using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Controler;
using Oficina_Motos.Model;

namespace Oficina_Motos.View
{
    public partial class FrmOrcamento : Form
    {
        public FrmOrcamento(Usuario usuario, int pega_Id)
        {
            InitializeComponent();
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
            this.usuario = usuario;
            this.pega_id = pega_Id;
        }

        //OrcamentoDb o = new OrcamentoDb();
        Usuario usuario = new Usuario();
        Cliente cliente = new Cliente();
        ClienteDb clienteDb = new ClienteDb();
       
        VeiculoDb veiculoDb = new VeiculoDb();
        Veiculo veiculo = new Veiculo();
        ProdutoDb produtoDb = new ProdutoDb();
        Produto produto = new Produto();
        DataTable dtProduto = new DataTable();
        ServicoDb servicoDb = new ServicoDb();
        DataTable dtServico = new DataTable();
        Servico servico = new Servico();
        Ordem_Servico os = new Ordem_Servico();
        Orcamento orcamento = new Orcamento();
        OrcamentoDb orcamentoDb = new OrcamentoDb();
        DataTable dtOrcamento = new DataTable();
        Itens_Orcamento itens_orcamento = new Itens_Orcamento();
        Itens_OrcamentoDb itens_orcamentoDb = new Itens_OrcamentoDb();
        EstoqueDb estoqueDb = new EstoqueDb();

        private int tipoImpressao;
        int pega_id;
        int numOrc;
        int numVeiculo;
        int id_peca = 0;
        int estoqueAtual = 0;
        int id_estoque = 0;
        int qtdeServico;
        int qtdePeca;

        decimal preco_venda = 0;
        decimal descontoPeca = 0;
        decimal total_item = 0;     
        decimal sub_totalPeca;
        decimal total_pecas;
        decimal total_servicos;
        decimal total_orcamento;
        decimal precoServico;
        decimal descontoServico;
        decimal sub_totalServico;

        int id_cliente;
        string id_servico;
        string descricaoPeca;
        string descricaoServico;
       
        bool peca_clicado = false;
        bool servico_clicado = false;

        public int TipoImpressao
        {
            get
            {
                return tipoImpressao;
            }

            set
            {
                tipoImpressao = value;
            }
        }

        private void FrmOrcamento_Load(object sender, EventArgs e)
        {
            //se o numOrc for 0 significa que é um novo orçamento
            if (pega_id == 0)
            {
                numOrc = orcamentoDb.geraNumOrcamento();
                numVeiculo = veiculoDb.geraNumVeiculo();
                lblNumOrcamento.Text = "Orcamento N°: " + numOrc;

                //preenche os campos
                textNome.Select();
                dgResultCliente.Visible = false;
                dgResultPecas.Visible = false;
                dgResultServicos.Visible = false;
                textPecasQtde.Text = "1";
                textServicosQtde.Text = "1";
                textTotalPecas.Text = "0,00";
                textTotal.Text = "0,00";
                textTotalServicos.Text = "0,00";
                btnSalvar.Visible = true;
                btnAtualizar.Visible = false;
                comboBox1.SelectedIndex = 0;
                //btnSair.Enabled = false;
            }
            //se o numOrc for maior que 0 significa que esta editando um orçamento existente
            else if (pega_id > 0)
            {
                numOrc = pega_id;
                btnSalvar.Visible = true;
                btnAtualizar.Visible = false;
                editar();
            }
        }

        private void enableCampos(string status)
        {
            switch (orcamento.Status)
            {
                case "Cancelado":
                case "Aprovado":
                    btnAtualizar.Visible = false;
                    btnSalvar.Visible = false;
                    iBtnCancelar.Visible = false;
                    //btnSuspender.Visible = false;
                    btnVeiculosLimpar.Visible = false;
                    btnClienteLimpar.Visible = false;
                    button9.Visible = false;
                    button11.Visible = false;

                    btnSair.Enabled = true;
                    comboBox1.Text = orcamento.Status;
                    comboBox1.Enabled = false;
                    textDescricao.Enabled = false;
                    textCor.Enabled = false;
                    textMarca.Enabled = false;
                    textModelo.Enabled = false;
                    textAno.Enabled = false;
                    textKm.Enabled = false;
                    textPlaca.Enabled = false;
                    textDefeito.Enabled = false;
                    textProblemaVerificado.Enabled = false;
                    textObs.Enabled = false;
                    textNome.Enabled = false;
                    btnCadastrar.Enabled = false;
                    textPeca.Enabled = false;
                    textPecasQtde.Enabled = false;
                    textServico.Enabled = false;
                    textServicosQtde.Enabled = false;
                    dgPecas.Enabled = false;
                    dgServicos.Enabled = false;

                    break;
                case "Suspenso":
                case "Em Análise":
                case "Concluído":
                    comboBox1.Text = orcamento.Status;
                    btnAtualizar.Visible = true;
                    btnSalvar.Visible = false;
                    iBtnCancelar.Visible = true;
                    //btnSuspender.Visible = true;

                    break;
            }
        }
        private void editar()
        {
            dtOrcamento = orcamentoDb.consultaPorId(numOrc);
            //MessageBox.Show(dtOrcamento.Rows[0][2].ToString());
            orcamento.Status = dtOrcamento.Rows[0]["status"].ToString();
            enableCampos(orcamento.Status);
            id_cliente = Convert.ToInt32(dtOrcamento.Rows[0]["id_cliente"]);

                preencheCliente(id_cliente);

                //preenche os campos do veiculo
                numVeiculo = Convert.ToInt32(dtOrcamento.Rows[0]["id_veiculo"]);
                veiculo = veiculoDb.constroiVeiculo(numVeiculo.ToString());
                textDescricao.Text = veiculo.Descricao;
                textMarca.Text = veiculo.Marca;
                textModelo.Text = veiculo.Modelo;
                textAno.Text = veiculo.Ano;
                textCor.Text = veiculo.Cor;
                textPlaca.Text = veiculo.Placa;
                textKm.Text = veiculo.Km;

                textDefeito.Text = veiculo.Defeito;
                textProblemaVerificado.Text = veiculo.Problema_verificado;
                textObs.Text = veiculo.Observacao;
                
                lblNumOrcamento.Text = "Orcamento N°: " + numOrc;
                dgResultCliente.Visible = false;
                dgResultPecas.Visible = false;
                dgResultServicos.Visible = false;
                textPecasQtde.Text = "1";
                textServicosQtde.Text = "1";
                
                //preencher grid peças
                povoaGridPecas();

                //preencher grid servicos
                povoaGridServicos();

                totais();
        }


        private void textNome_KeyUp(object sender, KeyEventArgs e)
        {
            dgResultCliente.Visible = true;
            dgResultCliente.BringToFront();

            ClienteDb consulta = new ClienteDb();
            dgResultCliente.DataSource = consulta.consultaNome(textNome.Text);
            dgResultCliente.ClearSelection();
        }


        private void dgResultCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultCliente.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;

            id_cliente = Convert.ToInt32(dgResultCliente.Rows[indice].Cells[0].Value);

            preencheCliente(id_cliente);
            dgResultCliente.Visible = false;
            btnClienteAvancar.Select();
        }

        private void preencheCliente(int id_clie)
        {
            //preenche os campos cliente
            cliente = clienteDb.consultaPorId(id_clie);
            //MessageBox.Show(cliente.Nome);
            //MessageBox.Show(cliente.Contato.Telefone_1);
            //MessageBox.Show(cliente.Endereco.Nome);

            textNome.Text = cliente.Nome;
                textCpf.Text = cliente.Cpf;
                //preenche os telefone              
                textTelefone.Text = cliente.Contato.Telefone_1;
                //preenche o endereço               
                string logradouro = cliente.Endereco.Logradouro;
                string nome_rua = cliente.Endereco.Nome;
                string numero = cliente.Endereco.Numero;
                textEndereco.Text = logradouro + " " + nome_rua + " " + numero;
                textBairro.Text = cliente.Endereco.Bairro;
                textCidade.Text = cliente.Endereco.Cidade;
                textCep.Text = cliente.Endereco.Cep;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastroCliente novoCliente = new FrmCadastroCliente(0);
            novoCliente.ShowDialog();
        }

        //botoes avançar
        private void btnClienteAvancar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void btnVeiculosAvancar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            textMarca.Select();

        }
        private void btnPecasAvancar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            textServico.Select();

        }
        private void btnServAvancar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            dgResultCliente.Visible = false;

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
            dgResultPecas.Visible = false;
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {
            dgResultServicos.Visible = false;
        }

        private void textAno_KeyUp(object sender, KeyEventArgs e)
        {
            if(textAno.TextLength > 4)
            {
                MessageBox.Show("máximo 4 dígitos");
                textAno.Text = "";
            }
        }

        private void btnClienteLimpar_Click(object sender, EventArgs e)
        {
            dgResultCliente.Visible = false;
            limpaCamposCliente();
        }

        private void textNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27)) //ESC
            {
                dgResultCliente.Visible = false;
                limpaCamposCliente();
            }
            if (e.KeyCode == Keys.Down)
            {
                dgResultCliente.Select();
                dgResultCliente.Rows[0].Selected = true;
            }
        }

        void limpaCamposCliente()
        {
            textNome.Text = "";
            textCpf.Text = "";
            textEndereco.Text = "";
            textBairro.Text = "";
            textCidade.Text = "";
            textCep.Text = "";
            textTelefone.Text = "";

        }

        private void btnVeiculosLimpar_Click(object sender, EventArgs e)
        {
            textDescricao.Text = "";
            textMarca.Text = "";
            textModelo.Text = "";
            textCor.Text = "";
            textPlaca.Text = "";
            textDefeito.Text = "";
            textObs.Text = "";
            textAno.Text = "";

        }

        private void textPeca_KeyUp(object sender, KeyEventArgs e)
        {
            if (textPeca.Text.Length >= 3)
            {
                dgResultPecas.Visible = true;
                dgResultPecas.BringToFront();
                dgResultPecas.DataSource = produtoDb.consultaRapidaDescricaoMarca(textPeca.Text, textAplicacao.Text);
                dgResultPecas.ClearSelection();
            }
            else
            {
                dgResultPecas.Visible = false;
            }         
        }

        private void textPeca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                dgResultPecas.Visible = false;
            }
            if (e.KeyChar == 13)
            {
                if (!VerificaString(textPeca.Text))
                {

                    Produto produto = new Produto();
                    produto = produtoDb.consultaPorCodBarras(textPeca.Text);

                    if (produto.Id == 0)
                    {
                        MessageBox.Show("Produto não encontrado");
                    }
                    else
                    {
                        id_peca = produto.Id;  
                        dtProduto = produtoDb.consultaPdv(id_peca);
                        //
                        descricaoPeca = produto.Descricao;
                        descontoPeca = produto.Desconto;
                        textPeca.Text = descricaoPeca;// + "   " + preco_venda.ToString();

                        estoqueAtual = Convert.ToInt32(dtProduto.Rows[0][5]);
                        id_estoque = Convert.ToInt32(dtProduto.Rows[0][7]);
                        dgResultPecas.Visible = false;
                        btnPecasIncluir.Enabled = true;
                        textPecasQtde.Select();

                        //montar o objeto Itens_venda
                        itens_orcamento.Id_orcamento = numOrc;
                        itens_orcamento.Id_produto = produto.Id;
                        itens_orcamento.Descricao = produto.Descricao;
                        itens_orcamento.Valor_uni = produto.Preco_venda;
                        itens_orcamento.Desconto = produto.Desconto;

                        inserir(itens_orcamento);
                        povoaGridPecas();
                    }
                }
            }
        }

        private void textConfirmaPeca_Click(object sender, EventArgs e)
        {
            textPeca.Text = "";
            textPeca.Select();
            //textPeca.SelectionStart = textPeca.TextLength;
        }

        private void dbResultPecas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            peca_clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultPecas.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;

            id_peca = Convert.ToInt32(dgResultPecas.Rows[indice].Cells[0].Value);
            produto = produtoDb.consultaPorId(id_peca);
            //
            dtProduto = produtoDb.consultaPdv(id_peca);
            //
            descricaoPeca = produto.Descricao;
            descontoPeca = produto.Desconto;
            preco_venda = produto.Preco_venda;
            textPeca.Text = descricaoPeca;// + "   " + preco_venda.ToString();
           
            estoqueAtual = Convert.ToInt32(dtProduto.Rows[0][5]);
            id_estoque = Convert.ToInt32(dtProduto.Rows[0][7]);
            dgResultPecas.Visible = false;
            btnPecasIncluir.Enabled = true;
            textPecasQtde.Select();
        }


        private void btnPecasIncluir_Click(object sender, EventArgs e)
        {
                //cria o objeto itens_orcamento
                itens_orcamento.Id_orcamento = numOrc;
                itens_orcamento.Id_produto = id_peca;
                itens_orcamento.Id_servico = 0;
                itens_orcamento.Descricao = descricaoPeca;
                itens_orcamento.Valor_uni = preco_venda;
                //itens_orcamento.Qtde = qtdePeca;
                itens_orcamento.Sub_total = sub_totalPeca;
                itens_orcamento.Desconto = descontoPeca;

            //insere na tabela
            inserir(itens_orcamento);
            povoaGridPecas();
        }

        private void inserir(Itens_Orcamento itens_orcamento)
        {
            if (textPeca.Text == "")
            {
                MessageBox.Show("insira uma peça!"); //caso o usuario nãi inclua uma peça, aparece esse aviso
                textPeca.Select();
            }
            else
            {
                if (textPecasQtde.Text == "")// caso o usuario tente incluir um produto sem qtde, aparece esse aviso
                {
                    textPecasQtde.Text = "1";
                }
                qtdePeca = Convert.ToInt32(textPecasQtde.Text);//converte inteiro o que foi digitado no campo qtde

                int qtde_neg = -Math.Abs(qtdePeca); // converte para negativo

                if (estoqueAtual < qtdePeca)
                {
                    string valores = string.Format("Quantidade indisponível! " + "{0}" + " " + "{0}" + "Unidades em estoque: " + estoqueAtual , Environment.NewLine);

                    MessageBox.Show(valores);
                    textPecasQtde.Text = "1";
                }
                else
                {
                    atualiza_estoque(id_peca, qtde_neg);
                    //
                    total_item = qtdePeca * preco_venda;
                    //
                    itens_orcamento.Qtde = qtdePeca;
                    itens_orcamento.Sub_total = total_item;

                    itens_orcamentoDb.insere(itens_orcamento);
                    //
                    textPeca.Text = "";
                    //textBuscaProduto.Select();

                    povoaGridPecas();
                    totais();
                    textPecasQtde.Text = "1";
                    btnPecasIncluir.Enabled = false;
                }
            }
            peca_clicado = false;
        }
    
        private void dgPecas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgPecas.CurrentRow;
            int indice = linhaAtual.Index;

            itens_orcamento.Id = Convert.ToInt32(dgPecas.Rows[indice].Cells[0].Value);
            itens_orcamento.Id_orcamento = Convert.ToInt32(dgPecas.Rows[indice].Cells[1].Value);
            itens_orcamento.Id_produto = Convert.ToInt32(dgPecas.Rows[indice].Cells[2].Value);
            itens_orcamento.Descricao = dgPecas.Rows[indice].Cells[4].Value.ToString();
            itens_orcamento.Valor_uni = Convert.ToDecimal(dgPecas.Rows[indice].Cells[5].Value);
            itens_orcamento.Qtde = Convert.ToInt32(dgPecas.Rows[indice].Cells[6].Value);
            itens_orcamento.Desconto = Convert.ToDecimal(dgPecas.Rows[indice].Cells[7].Value);
            itens_orcamento.Sub_total = Convert.ToDecimal(dgPecas.Rows[indice].Cells[8].Value);

            // vamos obter a linha da célula selecionada
            string valorCelula = dgPecas.CurrentCell.Value.ToString();
            if (valorCelula == "Editar")
            {
                FrmEditaItemOrcamento editar = new FrmEditaItemOrcamento(itens_orcamento);
                editar.ShowDialog();
                povoaGridPecas();
            }
            if (valorCelula == "Excluir")
            {
                itens_orcamentoDb.delete(itens_orcamento);
                atualiza_estoque(itens_orcamento.Id_produto, itens_orcamento.Qtde);
                povoaGridPecas();
            }
            dgPecas.ClearSelection();
        }

        private void limpaTextPecas()
        {
            textPeca.Text = "";
            textPeca.Select();
            dgResultPecas.Visible = false;
        }

        private void povoaGridPecas()
        {
            //alimenta o grid de peças 
            DataTable dtItens = new DataTable();
            dtItens = itens_orcamentoDb.consultaPorIdOrcamento(numOrc, "produto");
            if (dtItens.Columns.Count < 11)
            {
                dtItens.Columns.Add("Excluir");
                dtItens.Columns.Add("Editar");
            }
            for (int i = 0; i <= dtItens.Rows.Count - 1; i++)
            {
                dtItens.Rows[i]["Excluir"] = "Excluir";
                dtItens.Rows[i]["Editar"] = "Editar";
            }
            dgPecas.DataSource = dtItens;

            limpaTextPecas();
            dgPecas.ClearSelection();        
            totais();
        }
        //serviços
        //cadastrar novo serviço
        private void button12_Click(object sender, EventArgs e)
        {
            FrmCadastroServico cadServ = new FrmCadastroServico(0);
            cadServ.ShowDialog();
        }

        private void btnServicosLimpar_Click(object sender, EventArgs e)
        {

        }
        private void povoaGridServicos()
        {
            //alimenta o grid de peças 
            DataTable dtItens = new DataTable();
            dtItens = itens_orcamentoDb.consultaPorIdOrcamento(numOrc, "servico");
            if (dtItens.Columns.Count < 10)
            {
                dtItens.Columns.Add("Excluir");
            }
            for (int i = 0; i <= dtItens.Rows.Count - 1; i++)
            {
                dtItens.Rows[i]["Excluir"] = "Excluir";
            }
            dgServicos.DataSource = dtItens;
            limpaTextServicos();
            totais();
            dgServicos.ClearSelection();
        }

        private void textServico_KeyUp(object sender, KeyEventArgs e)
        {
            if (textServico.Text.Length >= 3)
            {
                servico_clicado = false;
                dgResultServicos.Visible = true;
                dgResultServicos.BringToFront();

                dtServico = servicoDb.consultaNome(textServico.Text);
                dgResultServicos.DataSource = dtServico;
                dgResultServicos.ClearSelection();
            }
        }

        private void dgServicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgServicos.CurrentRow;
            int indice = linhaAtual.Index;

            itens_orcamento.Id = Convert.ToInt32(dgServicos.Rows[indice].Cells[1].Value);
            itens_orcamento.Id_orcamento = Convert.ToInt32(dgServicos.Rows[indice].Cells[2].Value);
            itens_orcamento.Id_servico = Convert.ToInt32(dgServicos.Rows[indice].Cells[4].Value);
            itens_orcamento.Descricao = dgServicos.Rows[indice].Cells[5].Value.ToString();
            itens_orcamento.Valor_uni = Convert.ToDecimal(dgServicos.Rows[indice].Cells[6].Value);
            itens_orcamento.Qtde = Convert.ToInt32(dgServicos.Rows[indice].Cells[7].Value);
            itens_orcamento.Desconto = Convert.ToDecimal(dgServicos.Rows[indice].Cells[8].Value);
            itens_orcamento.Sub_total = Convert.ToDecimal(dgServicos.Rows[indice].Cells[9].Value);

            // vamos obter a linha da célula selecionada
            string valorCelula = dgServicos.CurrentCell.Value.ToString();

            if (valorCelula == "Excluir")
            {
                itens_orcamentoDb.delete(itens_orcamento);
                povoaGridServicos();
            }
            dgServicos.ClearSelection();
        }

        private void btnServicosIncluir_Click(object sender, EventArgs e)
        {
            insereMaoObra();
        }

        private void insereMaoObra()
        {
            if (textServico.Text == "")
            {
                MessageBox.Show("insira uma Serviço!");
                textServico.Select();
            }
            else
            {
                //cria o objeto itens_orcamento
                qtdeServico = Convert.ToInt32(textServicosQtde.Text);
                sub_totalServico = precoServico * qtdeServico;
                itens_orcamento.Id_orcamento = numOrc;
                itens_orcamento.Id_produto = 0;
                itens_orcamento.Id_servico = Convert.ToInt32(id_servico);
                itens_orcamento.Descricao = descricaoServico;
                itens_orcamento.Valor_uni = precoServico;
                itens_orcamento.Qtde = qtdeServico;
                itens_orcamento.Sub_total = sub_totalServico;
                itens_orcamento.Desconto = descontoServico;

                //insere na tabela
                itens_orcamentoDb.insere(itens_orcamento);

                //alimenta o grid de peças 
                povoaGridServicos();

                totais();
                limpaTextServicos();
                dgResultServicos.Visible = false;
            }
        }

        private void limpaTextServicos()
        {
            textServico.Text = "";
            textServico.Select();
            dgResultServicos.Visible = false;
        }

        private void dgResultServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            servico_clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultServicos.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_servico = dgResultServicos.Rows[indice].Cells[1].Value.ToString();
            servico = servicoDb.consultaPorId(Convert.ToInt32(id_servico));
            descricaoServico = servico.Descricao;
            precoServico = servico.Preco;
            descontoServico = servico.Desconto;
            textServico.Text = "Cod: " + id_servico + "    " + descricaoServico + "   " + precoServico.ToString();
            dgResultServicos.Visible = false;
        }

        private void totais()
        {
            total_pecas = dgPecas.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["sub_total"].Value));
            total_servicos = dgServicos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["sub_total_servicos"].Value));
            textTotalPecas.Text = "R$" + total_pecas.ToString("N2");
            textTotalServicos.Text = "R$" + total_servicos.ToString("N2");
            total_orcamento = total_pecas + total_servicos;
            textTotal.Text = "R$" + total_orcamento.ToString("N2");
        }

        private void atualiza_estoque(int id_produto, int qtde)
        {
            estoqueDb.debita_credita_Qtde(id_produto, qtde);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            lblNome.Text = textNome.Text;
            lblTelefone.Text = textTelefone.Text;
            lblCpf.Text = textCpf.Text;
            lblEndereco.Text = textEndereco.Text;
            lblVeiculo.Text = textDescricao.Text;
            lblMarca.Text = textMarca.Text;
            lblModelo.Text = textModelo.Text;
            lblSerie.Text = textPlaca.Text;
            lblDefeito.Text = textDefeito.Text;
            lblDefeitoVerificado.Text = textProblemaVerificado.Text;

        }
        
        private bool validaCampos()
        {
            if (textNome.Text.Length < 8 )
            {
                MessageBox.Show("Informe o Cliente");
                tabControl1.SelectedIndex = 0;
                textNome.Select();
                return false;
            }
            else if (textDescricao.Text == "")
            {
                MessageBox.Show("Informe a Moto.");
                tabControl1.SelectedIndex = 1;
                textDescricao.Select();
                return false;
            }
            else if (textMarca.Text == "")
            {
                MessageBox.Show("Informe a marca");
                tabControl1.SelectedIndex = 1;
                textMarca.Select();
                return false;
            }
            else if (textDefeito.Text == "")
            {
                MessageBox.Show("Informe o problema informado.");
                tabControl1.SelectedIndex = 1;
                textDefeito.Select();
                return false;
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Defina o Status");
                tabControl1.SelectedIndex = 4;
                comboBox1.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validaCliente()
        {
            if (textNome.Text == "")
            {
                return false;
            }
            else if (textCpf.Text =="")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validaVeiculo()
        {
            if (textDescricao.Text == "")
            {
                return false;
            }
            else if (textMarca.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void atualizaOrcamento(string status)
        {
            totais();
            orcamento.Id = numOrc;
            orcamento.Valor = total_orcamento;
            orcamento.Status = status;
            orcamento.Id_usuario = usuario.Id;
            orcamento.Id_cliente = cliente.Id;
            orcamento.Id_veiculo = numVeiculo;

            veiculo.Id = numVeiculo;
            veiculo.Descricao = textDescricao.Text;
            veiculo.Marca = textMarca.Text;
            veiculo.Modelo = textModelo.Text;
            veiculo.Ano = textAno.Text;
            veiculo.Cor = textCor.Text;
            veiculo.Placa = textPlaca.Text;
            veiculo.Defeito = textDefeito.Text;
            veiculo.Problema_verificado = textProblemaVerificado.Text;
            veiculo.Observacao = textObs.Text;
            veiculo.Km = textKm.Text;

            try
            {
                orcamentoDb.atualiza(orcamento);
                veiculoDb.atualiza(veiculo);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            if (comboBox1.Text == "Aprovado")
            {
                Ordem_ServicoDb osDb = new Ordem_ServicoDb();
                bool existe_os = osDb.existe_os(numOrc);
                if (existe_os == false)
                {
                    os.Id = numOrc;
                    //os.Data_hora_fim = "2020-01-01 07:00:00";
                    os.Valor = orcamento.Valor;
                    os.Status = "Em Andamento";
                    os.Id_cliente = cliente.Id;
                    os.Id_veiculo = veiculo.Id;
                    osDb.insere(os);
                }             
            }
            this.Close();
        }
        private void salvaOrcamento(string status)
        {
            orcamento = criaObjetoOrcamento(status);
            veiculo = criaObjetoVeiculo();
            try
            {
                orcamentoDb.insere(orcamento);
                veiculoDb.insere(veiculo);
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            if (comboBox1.Text == "Aprovado")
            {
                Ordem_ServicoDb osDb = new Ordem_ServicoDb();
                os.Id = numOrc;
                //os.Data_hora_fim = "2020-01-01 07:00:00";
                os.Valor = orcamento.Valor;
                os.Status = "Iniciada";
                os.Id_cliente = cliente.Id;
                os.Id_veiculo = veiculo.Id;
                os.Id_usuario = orcamento.Id_usuario;

                osDb.insere(os);
            }
         this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaCampos() == true)
            {
                totais();
                switch (comboBox1.Text)
                {
                    case "Concluído":
                        if (total_pecas == 0 || total_servicos == 0)
                        {
                            MessageBox.Show("Insira Peças e Serviços.");
                            tabControl1.SelectedIndex = 2;
                            textPeca.Select();
                        }
                        else
                        {
                            salvaOrcamento(comboBox1.Text);
                        }
                        break;
                    case "Aprovado":
                        if (total_pecas == 0 && total_servicos == 0)
                        {
                            MessageBox.Show("Insira Peças e Serviços.");
                            tabControl1.SelectedIndex = 2;
                            textPeca.Select();
                        }
                        else if (textProblemaVerificado.Text == "")
                        {
                            MessageBox.Show("Insira o problema verificado");
                            tabControl1.SelectedIndex = 1;
                            textProblemaVerificado.Select();
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Transformar em Ordem de Serviço?", "Não", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (result.Equals(DialogResult.OK))
                            {
                                salvaOrcamento(comboBox1.Text);
                            }
                        }
                        break;
                    case "Em Análise":
                        salvaOrcamento(comboBox1.Text);
                        break;
                }
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (validaCampos() == true)
            {
                totais();
                switch (comboBox1.Text)
                {
                    case "Concluído":
                        if (total_pecas == 0 || total_servicos == 0)
                        {
                            MessageBox.Show("Insira Peças e Serviços.");
                        }
                        else
                        {
                            atualizaOrcamento(comboBox1.Text);
                        }
                        break;
                    case "Aprovado":
                        if (total_pecas == 0 && total_servicos == 0)
                        {
                            MessageBox.Show("Insira Peças e Serviços.");
                        }
                        else if (textProblemaVerificado.Text == "")
                        {
                            MessageBox.Show("Insira o problema verificado");
                            tabControl1.SelectedIndex = 1;
                            textProblemaVerificado.Select();
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Transformar em Ordem de Serviço?", "Não", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (result.Equals(DialogResult.OK))
                            {
                                atualizaOrcamento(comboBox1.Text);
                            }
                        }
                        break;
                    case "Em Análise":
                        atualizaOrcamento(comboBox1.Text);
                        break;
                    case "Suspenso":
                        atualizaOrcamento(comboBox1.Text);
                        break;
                }
                
            }
        }

        private Orcamento criaObjetoOrcamento(string status)
        {
            totais();
            orcamento.Id = numOrc;
            orcamento.Valor = total_orcamento;
            orcamento.Data = DateTime.Today.ToString("yyyy-MM-dd");
            orcamento.Hora = TimeSpan.FromHours(DateTime.Now.Hour);
            MessageBox.Show(orcamento.Hora.ToString());
            orcamento.Status = status;
            orcamento.Id_usuario = usuario.Id;
            orcamento.Id_cliente = cliente.Id;
            orcamento.Id_veiculo = numVeiculo;

            return orcamento;
        }

        private Veiculo criaObjetoVeiculo()
        {
            veiculo.Id = numVeiculo;
            veiculo.Descricao = textDescricao.Text;
            veiculo.Marca = textMarca.Text;
            veiculo.Modelo = textModelo.Text;
            veiculo.Ano = textAno.Text;
            veiculo.Cor = textCor.Text;
            veiculo.Placa = textPlaca.Text;
            veiculo.Defeito = textDefeito.Text;
            veiculo.Problema_verificado = textProblemaVerificado.Text;
            veiculo.Observacao = textObs.Text;
            veiculo.Km = textKm.Text;

            return veiculo;
        }

        //diversos
        private void button2_Click(object sender, EventArgs e)
        {
            FrmDiversos diverso = new FrmDiversos(2, numOrc);
            diverso.ShowDialog();
            povoaGridPecas();
            totais();
        }
        //cadastrar novo produto
        private void button10_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos cadProd = new FrmCadastroProdutos(0);
            cadProd.ShowDialog();
        }     

       
        //verifica se a entrada é string ou inteiro
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

        private void dgResultCliente_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgResultCliente.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgResultCliente.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgPecas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {       
            dgPecas.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgPecas.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dbResultPecas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgResultPecas.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgResultPecas.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgResultServicos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgResultServicos.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgResultServicos.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgServicos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
             dgServicos.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgServicos.Rows[e.RowIndex].Selected = true;
            }
        }

        private void textPecasQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //cria o objeto itens_orcamento
                itens_orcamento.Id_orcamento = numOrc;
                itens_orcamento.Id_produto = id_peca;
                itens_orcamento.Id_servico = 0;
                itens_orcamento.Descricao = descricaoPeca;
                itens_orcamento.Valor_uni = preco_venda;
                //itens_orcamento.Qtde = qtdePeca;
                itens_orcamento.Sub_total = sub_totalPeca;
                itens_orcamento.Desconto = descontoPeca;

                //insere na tabela
                inserir(itens_orcamento);
                povoaGridPecas();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgResultCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgResultCliente.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;
                id_cliente = Convert.ToInt32(dgResultCliente.Rows[indice].Cells[0].Value);
                preencheCliente(id_cliente);
                dgResultCliente.Visible = false;
                btnClienteAvancar.Select();
            }
        }

        private void textPeca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgResultPecas.Select();
                dgResultPecas.Rows[0].Selected = true;
            }

        }

        private void dbResultPecas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgResultPecas.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;
                id_peca = Convert.ToInt32(dgResultPecas.Rows[indice].Cells[0].Value);
                produto = produtoDb.consultaPorId(id_peca);
                //
                dtProduto = produtoDb.consultaPdv(id_peca);
                //
                descricaoPeca = produto.Descricao;
                descontoPeca = produto.Desconto;
                preco_venda = produto.Preco_venda;
                textPeca.Text = descricaoPeca;// + "   " + preco_venda.ToString();

                estoqueAtual = Convert.ToInt32(dtProduto.Rows[0][5]);
                id_estoque = Convert.ToInt32(dtProduto.Rows[0][7]);
                dgResultPecas.Visible = false;
                btnPecasIncluir.Enabled = true;
                textPecasQtde.Select();
            }
        }

        private void textServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgResultServicos.Select();
                dgResultServicos.Rows[0].Selected = true;
            }
        }

        private void dgResultServicos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgResultServicos.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;

                id_servico = dgResultServicos.Rows[indice].Cells[1].Value.ToString();

                servico = servicoDb.consultaPorId(Convert.ToInt32(id_servico));

                descricaoServico = servico.Descricao;
                precoServico = servico.Preco;
                descontoServico = servico.Desconto;

                textServico.Text = "Cod: " + id_servico + "    " + descricaoServico + "   " + precoServico.ToString();
                dgResultServicos.Visible = false;
                textServicosQtde.Select();
            }
        }

        private void textServicosQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                insereMaoObra();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                textNome.Select();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                textDescricao.Select();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                textPeca.Select();
            }
            if (tabControl1.SelectedIndex == 3)
            {
                textServico.Select();
            }

        }

        private void FrmOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);

            }
        }
        //imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (validaCampos() == true)
            {
                if (pega_id == 0)
                {
                    salvaOrcamento(comboBox1.Text);
                    ImprimeOrcamento impressoes = new ImprimeOrcamento();
                    impressoes.imprimeOrcamento(numOrc);
                }
                else
                {
                    atualizaOrcamento(comboBox1.Text);
                    ImprimeOrcamento impressoes = new ImprimeOrcamento();
                    impressoes.imprimeOrcamento(numOrc);
                }

            }
        }

        private void btnSair_1_Click(object sender, EventArgs e)
        {
                       
        }

        private void iBtnSair_Click(object sender, EventArgs e)
        {
            if (validaCliente() == true && validaVeiculo() == true)
            {
                if (pega_id == 0)
                {
                    salvaOrcamento("Suspenso");
                }
                else
                {
                    atualizaOrcamento(orcamento.Status);
                }
            }
            else
            {
                orcamentoDb.delete(numOrc.ToString());
                itens_orcamentoDb.deleteTodos(numOrc);
                veiculoDb.delete(veiculo.Id.ToString());
                this.Close();
            }
        }

        private void iBtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja cancelar o orçamento?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                orcamentoDb.atualizaStatus(numOrc, "Cancelado");
                itens_orcamentoDb.deleteTodos(numOrc);
                veiculoDb.delete(veiculo.Id.ToString());
                this.Close();
            }
        }
    }
}
