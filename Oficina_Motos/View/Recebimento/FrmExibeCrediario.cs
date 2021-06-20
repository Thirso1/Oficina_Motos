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
    public partial class FrmExibeCrediario : Form
    {
        int id_crediario;
        Crediario crediario = new Crediario();
        CrediarioDb crediarioDb = new CrediarioDb();
        ParcelaDb parcelaDb = new ParcelaDb();
        Parcela parcela = new Parcela();
        DataTable dtParcelas = new DataTable();
        Cliente cliente = new Cliente();
        ClienteDb clienteDb = new ClienteDb();
        Endereco endereco = new Endereco();
        EnderecoDb enderecoDb = new EnderecoDb();
        Contato contato = new Contato();
        ContatoDb contatoDb = new ContatoDb();

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

        decimal valor_parcela;
        decimal valor_recebido;
        int qtde_parcelas;
        int num_parcela;
        int id_parcela;
        string vencimento;
        int status;

        public FrmExibeCrediario(int id_crediario)
        {
            InitializeComponent();
            this.id_crediario = id_crediario;
        }

        private void FrmExibeCrediario_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Crediário N° " + id_crediario;
            preencheCrediario();
            povoaGridParcelas();
            preencheCliente();
            btnReceber.Enabled = false;
            dataGridView1.ClearSelection();
        }

        private void preencheCliente()
        {
            cliente = clienteDb.constroiCliente(crediario.Id_cliente.ToString());
            contato = contatoDb.consultaPorId(cliente.Id_contato.ToString());
            endereco = enderecoDb.consultaPorId(cliente.Id_endereco.ToString());

            txtCliente.Text = cliente.Nome;
            txtCpf.Text = cliente.Cpf;
            txtRG.Text = cliente.Rg;
            txtTel_1.Text = contato.Telefone_1;
            txtTel_2.Text = contato.Telefone_2;
            txtEndereco.Text = endereco.Logradouro + endereco.Nome + endereco.Numero;
            txtBairro.Text = endereco.Bairro;
            txtCidade.Text = endereco.Cidade;
            txtUf.Text = endereco.Uf;
            txtCep.Text = endereco.Cep;
        }

        private void preencheCrediario()
        {
            crediario = crediarioDb.retornaPorId(id_crediario);
            txtReferencia.Text = crediario.Referencia;
            txtNumReferencia.Text = crediario.Num_referencia.ToString();
            txtTotal.Text = (crediario.Entrada + crediario.Valor_parcelado).ToString();
            txtValorEntrada.Text = crediario.Entrada.ToString();
            txtValorParcelado.Text = crediario.Valor_parcelado.ToString();
            txtDataEntrada.Text = crediario.Data;
            txtNumParcelas.Text = crediario.Num_parcelas.ToString();
        }

        private void povoaGridParcelas()
        {
            dtParcelas = parcelaDb.consultaPorId(id_crediario);
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("parcela", "Parcela");
            dataGridView1.Columns.Add("num_parcela", "N° Parcela");
            dataGridView1.Columns.Add("de", "de");
            dataGridView1.Columns.Add("qtde_parcelas", "qtde parcelas");
            dataGridView1.Columns.Add("valor_parcelas", "valor");
            dataGridView1.Columns.Add("venc", "vencimento");
            dataGridView1.Columns.Add("valor_recebido", "Valor Recebido");
            dataGridView1.Columns.Add("status", "status");

            for (int i = 0; i < dtParcelas.Rows.Count; i++)
            {
                //valor_a_parcelar = total;
                id_parcela = Convert.ToInt32(dtParcelas.Rows[i][0]);
                num_parcela = Convert.ToInt32(dtParcelas.Rows[i][2]);
                qtde_parcelas = Convert.ToInt32(dtParcelas.Rows[i][3]);
                valor_parcela = Convert.ToDecimal(dtParcelas.Rows[i][4]);
                vencimento = dtParcelas.Rows[i][5].ToString();
                valor_recebido = Convert.ToDecimal(dtParcelas.Rows[i][6]);
                status = Convert.ToInt32(dtParcelas.Rows[i][7]);



                // cria uma linha
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                // seta os valores
                row.Cells[0].Value = id_parcela;
                row.Cells[1].Value = "Parcela";
                row.Cells[2].Value = num_parcela;
                row.Cells[3].Value = "de";
                row.Cells[4].Value = qtde_parcelas;
                row.Cells[5].Value = valor_parcela;
                row.Cells[6].Value = vencimento;
                row.Cells[7].Value = valor_recebido;
                if (status == 1)
                {
                    row.Cells[8].Value = "Pago";
                }
                if (status == 0)
                {
                    row.Cells[8].Value = "Não Pago";
                }
                // adiciona na grid
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 30;
            dataGridView1.Columns[3].Width = 30;
            dataGridView1.Columns[4].Width = 30;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 110;
            dataGridView1.Columns[6].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.Columns[8].Width = 80;

            dataGridView1.ClearSelection();
            coloreLinhasGrid();
        }

        private void coloreLinhasGrid()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string status = dataGridView1.Rows[i].Cells[8].Value.ToString();
                switch (status)
                {
                    case "Pago":
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                        break;
                    case "Não Pago":
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        break;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnReceber.Enabled = true;

            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            parcela.Id = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
            parcela.Valor = Convert.ToDecimal(dataGridView1.Rows[indice].Cells[5].Value);
            string status = dataGridView1.Rows[indice].Cells[8].Value.ToString();

            if (status == "Não Pago")
            {
                btnReceber.Enabled = true;
            }
            else
            {
                btnReceber.Enabled = false;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //verificar se a parcela esta paga
            if (LoginDb.caixaAberto() == true)
            {
                FrmRecebimento recebimento = new FrmRecebimento(crediario.Num_referencia, 3, valor_parcela, cliente.Id.ToString());
                recebimento.Crediario = this;//passa esse proprio form como parametro
                recebimento.ShowDialog();
            }
            else
            {
                DialogResult result = MessageBox.Show("Caixa fechado! Deseja abrir?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    FrmAberturaCaixa1 abrir = new FrmAberturaCaixa1();
                    abrir.ShowDialog();
                    //
                    FrmRecebimento recebimento = new FrmRecebimento(crediario.Num_referencia, 3, valor_parcela, cliente.Id.ToString());
                    recebimento.Crediario = this;//passa esse proprio form como parametro
                    recebimento.ShowDialog();
                }
            }
            //criar os metodos pra returnar se esta tudo pago
            if (Confirma_pagamento == true)
                {
                    parcela.Valor_recebido = parcela.Valor;
                    parcela.Status = 1;
                    parcelaDb.atualizaStatus(parcela);
                    //busca se todas as parcelas estao pagas 
                    int pago = crediarioDb.status_crediario(id_crediario);
                    if (pago == 1)
                    {
                        crediario.Status = "Não Pago";
                    }
                if (pago == 2)
                {
                    crediario.Status = "Parcialmente Pago";
                }
                if (pago == 0)
                {
                    crediario.Status = "Pago";
                }

                crediarioDb.atualizaStatus(crediario);

            }
            dataGridView1.Columns.Clear();
                povoaGridParcelas();
            }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
