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

namespace Oficina_Motos.View
{
    public partial class FrmCrediario : Form
    {                        //numero da venda ou OS, tipo se é venda ou OS, total
        public FrmCrediario(int numero, int tipo, decimal total, decimal valor_a_parcelar, decimal entrada, string id_cliente)
        {
            InitializeComponent();
            this.Numero = numero;
            this.tipo = tipo;
            this.total = total;
            this.valor_a_parcelar = valor_a_parcelar;
            this.entrada = entrada;
            this.id_cliente = id_cliente;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        public string hora = DateTime.Now.ToString("HH:mm:ss ");
        public string data = DateTime.Today.ToString("dd-MM-yyyy");
        int Numero;
        string id_cliente;
        int tipo;
        int num_parcelas;
        decimal total;
        decimal valor_a_parcelar;
        decimal entrada;


        string referencia;
        Cliente cliente = new Cliente();
        DataTable dtParcelas = new DataTable();
        ClienteDb clienteDb = new ClienteDb();
        DataTable dtCliente = new DataTable();
        DataTable dtCliente2 = new DataTable();
        CrediarioDb crediarioDb = new CrediarioDb();
        Crediario crediario = new Crediario();
        private FrmRecebimento recebimento;
        public FrmRecebimento Recebimento
        {
            get { return recebimento; }
            set { recebimento = value; }
        }

        private void FrmCrediario_Load(object sender, EventArgs e)
        {

            if (tipo == 1)
            {
                txtNumVendaOS.Text = Numero.ToString();
                referencia = "VENDA";

            }
            else if (tipo == 2 || tipo == 22 || tipo == 222)//todos esses significam que é uma ordem de serviço, mas chamadas de forms diferentes
            {
                txtNumVendaOS.Text = Numero.ToString();
                referencia = "ORDEM SERVIÇO";

            }
            txtTotal.Text = total.ToString("N2");
            txtValorAParcelar.Text = valor_a_parcelar.ToString("N2");
            txtReferencia.Text = referencia;
            txtNumVendaOS.Text = Numero.ToString();
            txtValorEntrada.Text = entrada.ToString();
            dgResultCliente.Visible = false;

            //preenche o cliente
            preencheCliente(id_cliente);
            cbPeriodo.Select();
        }        

        private void preencheCliente(string id_cliente)
        {
            Endereco endereco = new Endereco();
            EnderecoDb enderecoDb = new EnderecoDb();
            Contato contato = new Contato();
            ContatoDb contatoDb = new ContatoDb();

            cliente = clienteDb.constroiCliente(id_cliente);

            //preenche os campos cliente
            txtCliente.Text = cliente.Nome;
            txtCpf.Text = cliente.Cpf;
            txtRg.Text = cliente.Rg;

            contato = contatoDb.consultaPorId(cliente.Id_contato.ToString());
            txtTel_1.Text = contato.Telefone_1;
            txtTel_2.Text = contato.Telefone_2;
            //preenche o endereço
            endereco = enderecoDb.consultaPorId(cliente.Id_endereco.ToString());
            string logradouro = endereco.Logradouro;
            string nome_rua = endereco.Nome;
            string numero = endereco.Numero;
            string bairro = endereco.Bairro;
            string cidade = endereco.Cidade;
            string cep = endereco.Cep;

            txtEndereco.Text = logradouro + " " + nome_rua + " " + numero;
            txtBairro.Text = bairro;
            txtCidade.Text = cidade;
        }

        private void txtNumParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        public void insere()
        {
            //insere o produto na tabela produtos de orcamento
            string inserItens = "INSERT INTO `parcela`(`id`,`id_crediario`,`num_parcela`, `qtde_parcelas`, `valor`,`vencimento`,`valor_recebido`, `status`) VALUES(NULL,?,?,?,?,?,?,?)";
            MySqlConnection conn = Conect.obterConexao();
            MySqlCommand objcmd = new MySqlCommand(inserItens, conn);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                objcmd.Parameters.Add("@id_crediario", MySqlDbType.Int32, 11).Value = crediario.Id;
                objcmd.Parameters.Add("@num_parcela", MySqlDbType.Int32, 11).Value = dtParcelas.Rows[i]["num_parcela"];
                objcmd.Parameters.Add("@qtde_parcelas", MySqlDbType.Int32, 11).Value = dtParcelas.Rows[i]["qtde_parcela"];
                objcmd.Parameters.AddWithValue("@valor", dataGridView1.Rows[i].Cells[1].Value);
                string dataBarra = dataGridView1.Rows[i].Cells[2].Value.ToString()+" 00:00:00";
                DateTime date = new DateTime();
                date = Convert.ToDateTime(dataBarra);
                date.ToString("yyyy-MM-dd");

                objcmd.Parameters.Add("@vencimento", MySqlDbType.Date).Value = date;
                objcmd.Parameters.Add("@_valorRecebido", MySqlDbType.Decimal, 8).Value = 0.00;
                objcmd.Parameters.Add("@_status", MySqlDbType.Int32, 11).Value = 0;
                try
                {
                    //executa a inserção
                    objcmd.ExecuteNonQuery();

                }
                catch (Exception erro)
                {
                    string teste = erro.ToString();
                    MessageBox.Show(teste);
                }
                objcmd.Parameters.Clear();
            }
        }

        private void txtValorAParcelar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recebimento.Recebido = false;
            this.Close();
        }

        private void txtCliente_KeyUp_1(object sender, KeyEventArgs e)
        {
            dgResultCliente.Visible = true;
            dgResultCliente.BringToFront();
            this.dgResultCliente.CellBorderStyle = DataGridViewCellBorderStyle.None;
            string nome = txtCliente.Text;

            dtCliente = clienteDb.consultaNome(nome);

            dgResultCliente.DataSource = dtCliente;

            dgResultCliente.Columns[1].Width = 300;
            dgResultCliente.Columns[2].Width = 100;
    }

        private void dgResultCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultCliente.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_cliente = dgResultCliente.Rows[indice].Cells[0].Value.ToString();
            preencheCliente(id_cliente);
            dgResultCliente.Visible = false;
            txtNumParcelas.Select();
        }

        private void btnCalculaParcelas_Click_1(object sender, EventArgs e)
        {
            //limpa a tabela e grid
            dtParcelas.Columns.Clear();
            dataGridView1.Columns.Clear();
            if (txtNumParcelas.Text == "")
            {
                MessageBox.Show("Insira o numero de parcelas.");
                txtNumParcelas.FindForm();
            }
            else if (cbPeriodo.Text == "")
            {
                MessageBox.Show("Insira o período.");
                txtNumParcelas.FindForm();
            }
            else
            {
                //constroi a tabela pra guardar os dados
                dtParcelas.Columns.Add("num_parcela");
                dtParcelas.Columns.Add("qtde_parcela");


                //valor_a_parcelar = total;
                decimal valor_parcela;
                num_parcelas = Convert.ToInt32(txtNumParcelas.Text);
                valor_parcela = valor_a_parcelar / num_parcelas;

                int periodo = Convert.ToInt32(cbPeriodo.Text);
                DateTime data = dateTimePicker1.Value;
                data = data.AddDays(periodo);
                //data = data.AddDays(periodo);
                //MessageBox.Show(data.ToString());


                int parc_1 = 1;
                dataGridView1.Columns.Add("parcela", "Parcelas");
                dataGridView1.Columns.Add("valor_parcelas", "valor");
                dataGridView1.Columns.Add("venc_1", "vencimento");
                //dataGridView1.Columns.Add("status", "status");

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


                for (int i = 0; i < num_parcelas; i++)
                {
                    // cria uma linha
                    DataGridViewRow row = new DataGridViewRow();

                    DataRow dtRow = dtParcelas.NewRow();
                    dtParcelas.Rows.Add(dtRow);

                    row.CreateCells(dataGridView1);
                    // seta os valores
                    dtParcelas.Rows[i]["num_parcela"] = parc_1;
                    dtParcelas.Rows[i]["qtde_parcela"] = num_parcelas;
                    row.Cells[0].Value = parc_1 + "/" + num_parcelas;
                    row.Cells[1].Value = valor_parcela;
                    row.Cells[2].Value = data.ToString("d");

                    // adiciona na grid
                    dataGridView1.Rows.Add(row);
                    parc_1++;
                    data = data.AddDays(periodo);

                }
                dataGridView1.Columns[1].DefaultCellStyle.Format = "N2";
                this.dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.Columns[0].Width = 140;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 140;

                dataGridView1.ClearSelection();

            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            if (cliente.Id == 0)
            {
                MessageBox.Show("informe o Cliente!");
            }
            else if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Calcule as parcelas!");
            }
            else
            {
                DialogResult result1 = MessageBox.Show("Confirma?", "Não", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result1.Equals(DialogResult.OK))
                {
                    if (tipo == 1)
                    {
                        VendaDb vendaDb = new VendaDb();
                        vendaDb.atualizaCliente(Numero, id_cliente);
                    }

                    crediario.Id = crediarioDb.geraCodCrediario();
                    crediario.Id_cliente = Convert.ToInt32(id_cliente);
                    crediario.Referencia = referencia;
                    crediario.Num_referencia = Numero;
                    crediario.Entrada = total - valor_a_parcelar;
                    crediario.Valor_parcelado = valor_a_parcelar;
                    crediario.Num_parcelas = num_parcelas;
                    crediario.Data = DateTime.Today.ToString("yyyy-MM-dd");
                    //status: 0 não pago, 1 pago, 2 parcialmente pago
                    if (crediario.Entrada > 0)
                    {
                        crediario.Status = "Parcialmente Pago";
                    }
                    else
                    {
                        crediario.Status = "Não Pago";
                    }
                    insere();

                    crediarioDb.insere(crediario);
                    Recebimento.Recebido = true;
                    ImprimeCrediario impressoes = new ImprimeCrediario();
                    impressoes.imprimeCrediario(crediario.Id, referencia, Numero);
                    this.Close();
                }
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

        private void dgResultCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgResultCliente.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;
                id_cliente = dgResultCliente.Rows[indice].Cells[0].Value.ToString();
                preencheCliente(id_cliente);
                dgResultCliente.Visible = false;
                txtNumParcelas.Select();
            }
        }
    }
}
