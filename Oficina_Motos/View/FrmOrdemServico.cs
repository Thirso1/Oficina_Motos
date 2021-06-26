using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Controler;
using Oficina_Motos.Model;

namespace Oficina_Motos.View
{
    public partial class FrmOrdemServico : Form
    {
        public FrmOrdemServico(int os)
        {
            InitializeComponent();
            this.idOs = os;
        }
        OrcamentoDb orcamento = new OrcamentoDb();
        DataTable dtOrcamento = new DataTable();

        Usuario usuario = new Usuario();

        Cliente cliente = new Cliente();
        ClienteDb clienteDb = new ClienteDb();

        ContatoDb contatoDb = new ContatoDb();
        Contato contato = new Contato();

        EnderecoDb enderecoDb = new EnderecoDb();
        Endereco endereco = new Endereco();

        VeiculoDb veiculoDb = new VeiculoDb();
        Veiculo veiculo = new Veiculo();
        DataTable dtVeiculo = new DataTable();

        Ordem_ServicoDb osDb = new Ordem_ServicoDb();
        Ordem_Servico ordem_servico = new Ordem_Servico();
        //DataTable dtOs = new DataTable();

        OrcamentoDb orcamentoDb = new OrcamentoDb();

        Itens_Orcamento itens_orcamento = new Itens_Orcamento();
        Itens_OrcamentoDb itens_orcamentoDb = new Itens_OrcamentoDb();
        DataTable dtItens_Orcamento = new DataTable();
        decimal totalPecas;
        decimal totalServicos;
        int idOs;
        int id_cliente;
        string data_hora = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");

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

        private void FrmOrdemServico_Load(object sender, EventArgs e)
        {
            ordem_servico = osDb.constroiOs(idOs);
            //ordem_servico.Id = idOs;
            //ordem_servico.Data_hora_inicio = dtOs.Rows[0][1].ToString();
            //ordem_servico.Data_hora_fim = dtOs.Rows[0][2].ToString();
            //ordem_servico.Valor = Convert.ToDecimal(dtOs.Rows[0][3]);
            //ordem_servico.Status = dtOs.Rows[0][4].ToString();

            string str_idOs = idOs.ToString();
            if (str_idOs.Length == 1)
            {
                textNumOs.Text = "0000" + str_idOs;
            }
            else if (str_idOs.Length == 2)
            {
                textNumOs.Text = "000" + str_idOs;
            }
            else if (str_idOs.Length == 3)
            {
                textNumOs.Text = "00" + str_idOs;
            }
            else if (str_idOs.Length == 4)
            {
                textNumOs.Text = "0" + str_idOs;
            }
            else
            {
                textNumOs.Text = str_idOs;
            }

            lblData.Text = ordem_servico.Data_hora_inicio;
            cbStatus.Text = ordem_servico.Status;

            dtOrcamento = orcamentoDb.consultaPorId(idOs);
            id_cliente = Convert.ToInt32(dtOrcamento.Rows[0]["id_cliente"]);
            cliente = clienteDb.consultaPorId(id_cliente);
            //preenche os campos cliente
            string nome = cliente.Nome;
            string cpf = cliente.Cpf;
            lblNome.Text = nome;
            lblCpf.Text = cpf;

            //preenche os telefone
            lblTel_1.Text = cliente.Contato.Telefone_1;
            lblTel_2.Text = cliente.Contato.Telefone_2;

            //preenche o endereço
            string logradouro = cliente.Endereco.Logradouro;
            string nome_rua = cliente.Endereco.Nome;
            string numero = cliente.Endereco.Numero;
            string bairro = cliente.Endereco.Bairro;

            lblEndereco.Text = logradouro + " " + nome_rua + " " + numero + "  -  Bairro: " + bairro;
            string cidade = cliente.Endereco.Cidade;
            string cep = cliente.Endereco.Cep;
            lblCidCep.Text = "Cidade: " + cidade + "   -   Cep: " + cep;

            //preenche os campos do veiculo
            int id_veiculo = Convert.ToInt32(dtOrcamento.Rows[0]["id_veiculo"]);
            dtVeiculo = veiculoDb.consultaPorId(id_veiculo.ToString());
            string veiculo = dtVeiculo.Rows[0]["descricao"].ToString();
            string marca = dtVeiculo.Rows[0]["marca"].ToString();
            string modelo = dtVeiculo.Rows[0]["modelo"].ToString();
            string ano = dtVeiculo.Rows[0]["ano"].ToString();
            string cor = dtVeiculo.Rows[0]["cor"].ToString();
            string placa = dtVeiculo.Rows[0]["placa"].ToString();
            string km = dtVeiculo.Rows[0]["km"].ToString();


            lblVeiculo.Text = veiculo;
            lblMarca.Text = marca;
            lblModelo.Text = modelo;
            //LblAno.Text = ano;
            lblCor.Text = cor;
            lblPlaca.Text = placa;
            //lblKm.Text = km;

            lblProblemaRelatado.Text = dtVeiculo.Rows[0]["problema_informado"].ToString();
            lblProblemaVerificado.Text = dtVeiculo.Rows[0]["problema_verificado"].ToString();
            lblObs.Text = dtVeiculo.Rows[0]["observacao"].ToString();




            dtItens_Orcamento = itens_orcamentoDb.consultaPorIdOrcamento(idOs, "produto");
            dtItens_Orcamento.Columns.Remove("id");
            dtItens_Orcamento.Columns.Remove("id_orcamento");
            dtItens_Orcamento.Columns.Remove("id_servico");
            dtItens_Orcamento.Columns.Remove("desconto");

            dgPecas.DataSource = dtItens_Orcamento;

            dtItens_Orcamento = itens_orcamentoDb.consultaPorIdOrcamento(idOs, "servico");
            dtItens_Orcamento.Columns.Remove("id");
            dtItens_Orcamento.Columns.Remove("id_orcamento");
            dtItens_Orcamento.Columns.Remove("id_produto");
            dtItens_Orcamento.Columns.Remove("desconto");

            dgServicos.DataSource = dtItens_Orcamento;

            totalServicos = dgServicos.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Column10"].Value));
            textTotalServicos.Text = totalServicos.ToString();
            totalPecas = dgPecas.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["Column5"].Value));
            textTotalPecas.Text = totalPecas.ToString();
            textTotal.Text = (totalPecas + totalServicos).ToString();

            //funcão que inibe o botao "receber" dependendo do status
            verificaStatus();
            dgPecas.ClearSelection();
            dgServicos.ClearSelection();

        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ordem_servico.Id = idOs;
            ordem_servico.Data_hora_fim = data_hora;
            ordem_servico.Status = cbStatus.Text;
            osDb.atualiza(ordem_servico);
            this.Close();
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            if (LoginDb.caixaAberto() == true)
            {
                FrmRecebimento r = new FrmRecebimento(idOs, 2, ordem_servico.Valor, id_cliente);
                r.Os = this;
                r.ShowDialog();
                if (Confirma_pagamento == true)
                {
                    ordem_servico.Status = "Finalizada";
                    osDb.atualiza(ordem_servico);
                    this.Close();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Caixa fechado! Deseja abrir?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    FrmAberturaCaixa1 ab = new FrmAberturaCaixa1();
                    ab.ShowDialog();
                    if (LoginDb.caixaAberto() == true)
                    {
                        FrmRecebimento r = new FrmRecebimento(idOs, 2, ordem_servico.Valor, id_cliente);
                        r.Os = this;
                        r.ShowDialog();
                        if (Confirma_pagamento == true)
                        {
                            ordem_servico.Status = "Finalizada";
                            osDb.atualiza(ordem_servico);
                            this.Close();
                        }
                    }
                }
            }
         
        }

        private void verificaStatus()
        {
            switch (cbStatus.Text)
            {
                case "Concluída - Não Pago":
                    btnReceber.Enabled = true;
                    cbStatus.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = false;
                    break;
                case "Finalizada":
                case "Cancelada":
                    btnReceber.Enabled = false;
                    cbStatus.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
                case "Aguardando Peças":
                case "Em Andamento":
                    btnReceber.Enabled = false;
                    break;
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificaStatus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja cancelar a Ordem de Serviço?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                ordem_servico.Id = idOs;
                ordem_servico.Data_hora_fim = data_hora;
                ordem_servico.Status = "Cancelada";
                osDb.atualiza(ordem_servico);
            }
        }
        //imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimeOS impressoes = new ImprimeOS();
            impressoes.imprimeOs(idOs);
        }
    }
}
 