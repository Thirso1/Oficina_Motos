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
    public partial class FrmConsultaOrdemServico : Form
    {
        public FrmConsultaOrdemServico()
        {
            InitializeComponent();
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        string data_hora = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
        Usuario usuario = new Usuario();
        UsuarioDb usuarioDb = new UsuarioDb();
        OrcamentoDb orcamentoDb = new OrcamentoDb();
        Ordem_ServicoDb ordem_servicoDb = new Ordem_ServicoDb();
        Login login = new Login();

        DataTable dtCliente = new DataTable();
        ClienteDb clienteDb = new ClienteDb();
        DataTable orcamento = new DataTable();
        bool clicado;
        int numOrc;
        int indice;
        string id_clie;
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

        private void FrmConsultaOrdemServico_Load(object sender, EventArgs e)
        {
            login = LoginDb.caixa_login();
            usuario = usuarioDb.consultaPorID(login.Id_usuario);

            comboBox1.SelectedIndex = 0;
            textNome.Enabled = true;
            textNome.Select();
            txtcpf.Enabled = false;
            textNumero.Enabled = false;
            textVeiculo.Enabled = false;
            textPlaca.Enabled = false;
            btnCancelar.Enabled = false;
            btnNome.Enabled = true;
            btnVisualizar.Enabled = false;
            dgResultClie.Visible = false;
            dpFim.Enabled = false;
            dpInicio.Enabled = false;
        }

        void enableBotoesPorStatus(string status)
        {
            switch (status)
            {
                case "Em Andamento":
                case "Iniciada":
                    btnVisualizar.Enabled = true;
                    btnSuspender.Enabled = true;
                    btnConcluir.Enabled = true;
                    btnReceber.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = true;
                    break;
                case "Suspensa":
                    btnVisualizar.Enabled = true;
                    btnSuspender.Enabled = false;
                    btnConcluir.Enabled = true;
                    btnReceber.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = true;
                    break;
                case "Concluída - Não Pago":
                    btnVisualizar.Enabled = true;
                    btnSuspender.Enabled = false;
                    btnConcluir.Enabled = false;
                    btnReceber.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = true;
                    break;
                case "Finalizada":
                    btnVisualizar.Enabled = false;
                    btnSuspender.Enabled = false;
                    btnConcluir.Enabled = false;
                    btnReceber.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    break;
                case "Cancelada":
                    btnVisualizar.Enabled = false;
                    btnSuspender.Enabled = false;
                    btnConcluir.Enabled = false;
                    btnReceber.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = true;
                    break;
                default:
                    btnVisualizar.Enabled = false;
                    btnSuspender.Enabled = false;
                    btnConcluir.Enabled = false;
                    btnReceber.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    break;
            }
        }

        void enableCampos(string consulta)
        {

        }

        private void textNome_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void dgResultClie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultClie.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_clie = dgResultClie.Rows[indice].Cells[0].Value.ToString();
            dtCliente = clienteDb.consultaPorId(id_clie);

            if (dtCliente.Rows.Count > 0)
            {
                //preenche os campos cliente
                textNome.Text = dtCliente.Rows[0]["nome"].ToString();
            }
            dgResultClie.Visible = false;
        }



















        private void textNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            string dataInicial = dpInicio.Text;
            string inicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
            string dataFim = dpFim.Text;
            string fim = dataFim.Substring(6, 4) + "-" + dataFim.Substring(3, 2) + "-" + dataFim.Substring(0, 2);
            orcamento.Rows.Clear();
            orcamento = ordem_servicoDb.consultaPorData(inicial, fim);
            //if (orcamento.Columns.Count < 11)
            //{
            //    orcamento.Columns.Add("Usuario");
            //}

            //for (int i = 0; i <= orcamento.Rows.Count - 1; i++)
            //{
            //    orcamento.Rows[i]["Usuario"] = usuarioDb.retornaLoginPorID(Convert.ToInt32(orcamento.Rows[i][9]));
            //}

            dgOrcamentos.DataSource = orcamento;
            dgOrcamentos.ClearSelection();
        }

        void povoaGridOrcamento(string id_clie)
        {
            string consulta = comboBox1.Text;
            switch (consulta)
            {
                case "":
                    MessageBox.Show("Selecione o tipo de consulta.");
                    break;
                case "Cliente":
                    orcamento.Rows.Clear();
                    orcamento = ordem_servicoDb.consultaPorCliente(id_clie);

                    //if (orcamento.Columns.Count < 11)
                    //{
                    //    orcamento.Columns.Add("Usuario");
                    //}

                    //for (int i = 0; i <= orcamento.Rows.Count - 1; i++)
                    //{
                    //    orcamento.Rows[i]["Usuario"] = usuarioDb.retornaLoginPorID(Convert.ToInt32(orcamento.Rows[i][7]));
                    //}

                    dgOrcamentos.DataSource = orcamento;
                    dgOrcamentos.ClearSelection();
                    dgOrcamentos.DataSource = orcamento;
                    break;
                case "CPF":
                    orcamento.Rows.Clear();
                    orcamento = ordem_servicoDb.consultaPorCpf(txtcpf.Text);
                    //if (orcamento.Columns.Count < 11)
                    //{
                    //    orcamento.Columns.Add("Usuario");
                    //}

                    //for (int i = 0; i <= orcamento.Rows.Count - 1; i++)
                    //{
                    //    orcamento.Rows[i]["Usuario"] = usuarioDb.retornaLoginPorID(Convert.ToInt32(orcamento.Rows[i][8]));
                    //}

                    dgOrcamentos.DataSource = orcamento;
                    dgOrcamentos.ClearSelection();
                    dgOrcamentos.DataSource = orcamento;
                    break;
                case "N° Orçamento":
                    orcamento.Rows.Clear();
                    orcamento = ordem_servicoDb.consultaPorNumero(textNumero.Text);
                    //if (orcamento.Columns.Count < 11)
                    //{
                    //    orcamento.Columns.Add("Usuario");
                    //}

                    //for (int i = 0; i <= orcamento.Rows.Count - 1; i++)
                    //{
                    //    orcamento.Rows[i]["Usuario"] = usuarioDb.retornaLoginPorID(Convert.ToInt32(orcamento.Rows[i][8]));
                    //}

                    dgOrcamentos.DataSource = orcamento;
                    dgOrcamentos.ClearSelection();
                    dgOrcamentos.DataSource = orcamento;
                    break;
                case "Veículo":
                    orcamento.Rows.Clear();
                    orcamento = ordem_servicoDb.consultaPorVeiculo(textVeiculo.Text);
                    //if (orcamento.Columns.Count < 11)
                    //{
                    //    orcamento.Columns.Add("Usuario");
                    //}

                    //for (int i = 0; i <= orcamento.Rows.Count - 1; i++)
                    //{
                    //    orcamento.Rows[i]["Usuario"] = usuarioDb.retornaLoginPorID(Convert.ToInt32(orcamento.Rows[i][8]));
                    //}

                    dgOrcamentos.DataSource = orcamento;
                    dgOrcamentos.ClearSelection();
                    dgOrcamentos.DataSource = orcamento;
                    break;
                case "Placa":
                    orcamento.Rows.Clear();
                    orcamento = ordem_servicoDb.consultaPorPlaca(textPlaca.Text);
                    //if (orcamento.Columns.Count < 11)
                    //{
                    //    orcamento.Columns.Add("Usuario");
                    //}

                    //for (int i = 0; i <= orcamento.Rows.Count - 1; i++)
                    //{
                    //    orcamento.Rows[i]["Usuario"] = usuarioDb.retornaLoginPorID(Convert.ToInt32(orcamento.Rows[i][8]));
                    //}

                    dgOrcamentos.DataSource = orcamento;
                    dgOrcamentos.ClearSelection();
                    dgOrcamentos.DataSource = orcamento;
                    break;
                case "Datas":
                    string dataInicial = dpInicio.Text;
                    string inicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    string dataFim = dpFim.Text;
                    string fim = dataFim.Substring(6, 4) + "-" + dataFim.Substring(3, 2) + "-" + dataFim.Substring(0, 2);
                    orcamento.Rows.Clear();
                    orcamento = ordem_servicoDb.consultaPorData(inicial, fim);
                    //if (orcamento.Columns.Count < 11)
                    //{
                    //    orcamento.Columns.Add("Usuario");
                    //}

                    //for (int i = 0; i <= orcamento.Rows.Count - 1; i++)
                    //{
                    //    orcamento.Rows[i]["Usuario"] = usuarioDb.retornaLoginPorID(Convert.ToInt32(orcamento.Rows[i][9]));
                    //}

                    dgOrcamentos.DataSource = orcamento;
                    dgOrcamentos.ClearSelection();
                    break;
            }
        }


        private void dgOrcamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgOrcamentos.CurrentRow;
            // vamos exibir o índice da linha atual
            indice = linhaAtual.Index;

            numOrc = Convert.ToInt32(dgOrcamentos.Rows[indice].Cells[2].Value);
            //pega o valor da celula
            string valorCelula = dgOrcamentos.Rows[indice].Cells[9].Value.ToString();

            enableBotoesPorStatus(valorCelula);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            povoaGridOrcamento(id_clie);
            dgOrcamentos.ClearSelection();
        }

        private void textNome_Leave(object sender, EventArgs e)
        {
            dgResultClie.Visible = false;
        }

        private void FrmConsultaOrdemServico_Click(object sender, EventArgs e)
        {
            dgResultClie.Visible = false;
        }
        int previousRow;

        private void dgResultClie_MouseMove(object sender, MouseEventArgs e)
        {
            //int previousRow;

            DataGridView.HitTestInfo testInfo = dgResultClie.HitTest(e.X, e.Y);

            //Need to check to make sure that the row index is 0 or greater as the first
            //row is a zero and where there is no rows the row index is a -1
            if (testInfo.RowIndex >= 0 && testInfo.RowIndex != previousRow)
            {
                dgResultClie.Rows[previousRow].Selected = false;
                dgResultClie.Rows[testInfo.RowIndex].Selected = true;
                previousRow = testInfo.RowIndex;
            }
        }
        int previousRow2;

        private void dgOrcamentos_MouseMove(object sender, MouseEventArgs e)
        {
            //int previousRow;
            if (clicado == false)
            {
                DataGridView.HitTestInfo testInfo = dgOrcamentos.HitTest(e.X, e.Y);

                //Need to check to make sure that the row index is 0 or greater as the first
                //row is a zero and where there is no rows the row index is a -1
                if (testInfo.RowIndex >= 0 && testInfo.RowIndex != previousRow2)
                {
                    dgOrcamentos.Rows[previousRow2].Selected = false;
                    dgOrcamentos.Rows[testInfo.RowIndex].Selected = true;
                    previousRow2 = testInfo.RowIndex;
                }
            }
        }

        private void textConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite Numeros Apenas
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

     


        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (numOrc > 0)
            {
                clicado = false;
                FrmOrdemServico o = new FrmOrdemServico(numOrc);
                o.ShowDialog();
                dgOrcamentos.ClearSelection();
                numOrc = 0;
            }
        }

        private void textNome_KeyUp_1(object sender, KeyEventArgs e)
        {
            dgResultClie.Visible = true;
            dgResultClie.BringToFront();

            ClienteDb consulta = new ClienteDb();
            dgResultClie.DataSource = consulta.consultaNome(textNome.Text);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Cliente":
                    textNome.Enabled = true;
                    textNome.Select();
                    txtcpf.Enabled = false;
                    textNumero.Enabled = false;
                    textVeiculo.Enabled = false;
                    textPlaca.Enabled = false;
                    txtcpf.Text = "";
                    textNumero.Text = "";
                    textVeiculo.Text = "";
                    textPlaca.Text = "";
                    btnCancelar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    break;
                case "CPF":
                    textNome.Enabled = false;
                    txtcpf.Enabled = true;
                    txtcpf.Select();
                    textNumero.Enabled = false;
                    textVeiculo.Enabled = false;
                    textPlaca.Enabled = false;
                    textNome.Text = "";
                    textNumero.Text = "";
                    textVeiculo.Text = "";
                    textPlaca.Text = "";
                    btnCancelar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    break;
                case "N° Orçamento":
                    textNome.Enabled = false;
                    txtcpf.Enabled = false;
                    textNumero.Enabled = true;
                    textNumero.Select();
                    textVeiculo.Enabled = false;
                    textPlaca.Enabled = false;
                    textNome.Text = "";
                    txtcpf.Text = "";
                    textVeiculo.Text = "";
                    textPlaca.Text = "";
                    btnCancelar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    break;
                case "Datas":
                    textNome.Enabled = false;
                    txtcpf.Enabled = false;
                    textNumero.Enabled = false;
                    textVeiculo.Enabled = false;
                    textPlaca.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = true;
                    dpInicio.Enabled = true;
                    textNome.Text = "";
                    txtcpf.Text = "";
                    textNumero.Text = "";
                    textVeiculo.Text = "";
                    textPlaca.Text = "";
                    break;
                case "Veículo":
                    textNome.Enabled = false;
                    txtcpf.Enabled = false;
                    textNumero.Enabled = false;
                    textVeiculo.Enabled = true;
                    textVeiculo.Select();
                    textPlaca.Enabled = false;
                    textNome.Text = "";
                    txtcpf.Text = "";
                    textNumero.Text = "";
                    textPlaca.Text = "";
                    btnCancelar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    break;
                case "Placa":
                    textNome.Enabled = false;
                    txtcpf.Enabled = false;
                    textNumero.Enabled = false;
                    textVeiculo.Enabled = false;
                    textPlaca.Enabled = true;
                    textPlaca.Select();
                    textNome.Text = "";
                    txtcpf.Text = "";
                    textNumero.Text = "";
                    textVeiculo.Text = "";
                    btnCancelar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    break;
            }
        }

        private void btnNome_Click_1(object sender, EventArgs e)
        {
            povoaGridOrcamento(id_clie);
            dgOrcamentos.ClearSelection();
            clicado = false;
            enableBotoesPorStatus("");

        }

        private void dgOrcamentos_MouseLeave(object sender, EventArgs e)
        {
            clicado = false;
        }

        private void btnVisualizar_Click_1(object sender, EventArgs e)
        {
            FrmOrdemServico o = new FrmOrdemServico(numOrc);
            o.ShowDialog();
            dgOrcamentos.ClearSelection();
            enableBotoesPorStatus("");
            clicado = false;
            povoaGridOrcamento(id_clie);
            enableBotoesPorStatus("");
         }

        private void btnSuspender_Click(object sender, EventArgs e)
        {
            Ordem_ServicoDb ordem_servicoSb = new Ordem_ServicoDb();
            Ordem_Servico ordem_servico = new Ordem_Servico();
            ordem_servico.Id = numOrc;
            ordem_servico.Data_hora_fim = data_hora;
            ordem_servico.Status = "Suspensa";
            ordem_servicoSb.atualiza(ordem_servico);
            //
            povoaGridOrcamento(id_clie);
            enableBotoesPorStatus("");
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            Ordem_ServicoDb ordem_servicoSb = new Ordem_ServicoDb();
            Ordem_Servico ordem_servico = new Ordem_Servico();
            ordem_servico.Id = numOrc;
            ordem_servico.Data_hora_fim = data_hora;
            ordem_servico.Status = "Concluída - Não Pago";
            ordem_servicoSb.atualiza(ordem_servico);
            //
            povoaGridOrcamento(id_clie);
            enableBotoesPorStatus("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja cancelar a Ordem de Serviço?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                Ordem_ServicoDb ordem_servicoSb = new Ordem_ServicoDb();
                Ordem_Servico ordem_servico = new Ordem_Servico();
                ordem_servico.Id = numOrc;
                ordem_servico.Data_hora_fim = data_hora;
                ordem_servico.Status = "Cancelada";
                ordem_servicoSb.atualiza(ordem_servico);
            }
            //
            povoaGridOrcamento(id_clie);
            enableBotoesPorStatus("");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimeOS impressoes = new ImprimeOS();
            impressoes.imprimeOs(numOrc);
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            clicado = false;
            decimal valor = Convert.ToDecimal(dgOrcamentos.Rows[indice].Cells[2].Value);
            string id_cliente = dgOrcamentos.Rows[indice].Cells[5].Value.ToString();

            if (LoginDb.caixaAberto() == true)
            {
                FrmRecebimento recebimento = new FrmRecebimento(numOrc, 222, valor, id_cliente);
                recebimento.ConsultaOs = this;
                recebimento.ShowDialog();
            }
            else
            {
                FrmAberturaCaixa1 abrirCaixa = new FrmAberturaCaixa1();
                abrirCaixa.ShowDialog();
                if (LoginDb.caixaAberto() == true)
                {
                    FrmRecebimento recebimento = new FrmRecebimento(numOrc, 222, valor, id_cliente);
                    recebimento.ConsultaOs = this;
                    recebimento.ShowDialog();
                }
            }

            if (Confirma_pagamento == true)
            {
                Ordem_Servico ordem_servico = new Ordem_Servico();
                ordem_servico.Id = numOrc;
                ordem_servico.Data_hora_fim = data_hora;
                ordem_servico.Status = "Finalizada";
                ordem_servicoDb.atualiza(ordem_servico);
            }
            //
            povoaGridOrcamento(id_clie);
            enableBotoesPorStatus("");
        }

        private void textNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgResultClie.Select();
                dgResultClie.Rows[0].Selected = true;
            }
        }
        private void dgResultClie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgResultClie.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;
                id_clie = dgResultClie.Rows[indice].Cells[0].Value.ToString();
                dtCliente = clienteDb.consultaPorId(id_clie);

                if (dtCliente.Rows.Count > 0)
                {
                    //preenche os campos cliente
                    textNome.Text = dtCliente.Rows[0]["nome"].ToString();
                }
                dgResultClie.Visible = false;
                btnNome.Select();
            }
        }
    }
}