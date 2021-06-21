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
    public partial class FrmConsultaOrcamento : Form
    {
        public FrmConsultaOrcamento(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }
        Usuario usuario = new Usuario();
        UsuarioDb usuarioDb = new UsuarioDb();
        Orcamento orcamento = new Orcamento();
        OrcamentoDb orcamentoDb = new OrcamentoDb();
        DataTable dtCliente = new DataTable();
        ClienteDb clienteDb = new ClienteDb();
        DataTable dtOrcamento = new DataTable();

        bool clicado = false;
        int numOrc;
        string id_clie;
        int indice;

        private void FrmConsultaOrcamento_Load(object sender, EventArgs e)
        {
            dgResultClie.Visible = false;
            comboBox1.Text = "Cliente";
            textNome.Select();
            btnEditar.Enabled = false;
            btnVisualizar.Enabled = false;
            btnSuspender.Enabled = false;
            btnConcluir.Enabled = false;
            btnAprovar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            povoaGridOrcamento(id_clie);
            clicado = false;
        }

        private void textNome_KeyUp_1(object sender, KeyEventArgs e)
        {
            dgResultClie.Visible = true;
            dgResultClie.BringToFront();

            ClienteDb consulta = new ClienteDb();
            dgResultClie.DataSource = consulta.consultaNome(textNome.Text);
            dgResultClie.ClearSelection();
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

        void enableBotoes(string consulta)
        {
            switch (consulta)
            {
                case "Cliente":
                    textNome.Enabled = true;
                    textNome.Select();
                    txtcpf.Enabled = false;
                    textNumero.Enabled = false;
                    textVeiculo.Enabled = false;
                    textPlaca.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = false;
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
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = false;
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
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = false;
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
                    btnEditar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = true;
                    dpInicio.Enabled = true;
                    break;
                case "Equipamento":
                    textNome.Enabled = false;
                    txtcpf.Enabled = false;
                    textNumero.Enabled = false;
                    textVeiculo.Enabled = true;
                    textVeiculo.Select();
                    textPlaca.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    break;
                case "N° Serie":
                    textNome.Enabled = false;
                    txtcpf.Enabled = false;
                    textNumero.Enabled = false;
                    textVeiculo.Enabled = false;
                    textPlaca.Enabled = true;
                    textPlaca.Select();
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnNome.Enabled = true;
                    btnVisualizar.Enabled = false;
                    dgResultClie.Visible = false;
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    break;
            }

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
                    dtOrcamento.Rows.Clear();
                    if (textNome.Text != "")
                    {
                        dtOrcamento = orcamentoDb.consultaPorCliente(id_clie);
                        if (dtOrcamento.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Orçamento!");
                        }
                        else
                        {
                            texto_status();
                            dgOrcamentos.DataSource = dtOrcamento;
                        }
                    }              
                    enableBotoes("Cliente");
                    break;
                case "CPF":
                    dtOrcamento.Rows.Clear();
                    dtOrcamento = orcamentoDb.consultaPorCpf(txtcpf.Text);
                    if (dtOrcamento.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Orçamento!");
                    }
                    else
                    {
                        texto_status();
                        dgOrcamentos.DataSource = dtOrcamento;
                    }
                    enableBotoes("CPF");
                    break;
                case "N° Orçamento":
                    dtOrcamento.Rows.Clear();
                    if (textNumero.Text != "")
                    {
                        dtOrcamento = orcamentoDb.consultaPorNumero(textNumero.Text);
                        if (dtOrcamento.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Orçamento!");
                        }
                        else
                        {
                            texto_status();
                            dgOrcamentos.DataSource = dtOrcamento;
                        }
                    }
                    enableBotoes("Orçamento");
                    break;
                case "Equipamento":
                    dtOrcamento.Rows.Clear();
                    if (textVeiculo.Text != "")
                    {
                        dtOrcamento = orcamentoDb.consultaPorVeiculo(textVeiculo.Text);
                        if (dtOrcamento.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Orçamento!");
                        }
                        else
                        {
                            texto_status();
                            dgOrcamentos.DataSource = dtOrcamento;
                        }
                    }
                    enableBotoes("Equipamento");
                    break;
                case "N° Serie":
                    dtOrcamento.Rows.Clear();
                    if (textPlaca.Text != "")
                    {
                        dtOrcamento = orcamentoDb.consultaPorPlaca(textPlaca.Text);
                        if (dtOrcamento.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Orçamento!");
                        }
                        else
                        {
                            texto_status();
                            dgOrcamentos.DataSource = dtOrcamento;
                        }
                    }
                    enableBotoes("N° Serie");
                    break;
                case "Datas":
                    DateTime dataInicial = dpInicio.Value;
                    DateTime dataFim = dpFim.Value;

                    dtOrcamento.Rows.Clear();
                    dtOrcamento = orcamentoDb.consultaPorData(dataInicial, dataFim);
                    if (dtOrcamento.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Orçamento!");
                    }
                    else
                    {
                        texto_status();
                        dgOrcamentos.DataSource = dtOrcamento;
                    }
                    dgOrcamentos.ClearSelection();
                    enableBotoes("Datas");

                    break;
            }
        }

        private void texto_status()
        {
            for (int i = 0; i <= dtOrcamento.Rows.Count - 1; i++)
            {
                string status = dtOrcamento.Rows[i]["status"].ToString();
                switch (status)
                {
                    case "Aprovado":
                        dtOrcamento.Rows[i]["status"] = "Aprovado (OS Aberta)";
                    break;
                    case "Concluído":
                        dtOrcamento.Rows[i]["status"] = "Concluído (Aprovação Pendente)";
                    break;
                }
            }
        }

        private void dgOrcamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgOrcamentos.CurrentRow;
            // vamos exibir o índice da linha atual
            indice = linhaAtual.Index;
            numOrc = Convert.ToInt32(dgOrcamentos.Rows[indice].Cells[1].Value);
            //pega o valor da celula
            string valorCelula = dgOrcamentos.Rows[indice].Cells[8].Value.ToString();

            switch (valorCelula)
            {
                     case "Suspenso":
                        btnEditar.Enabled = true;
                        btnVisualizar.Enabled = true;
                        btnSuspender.Enabled = false;
                        btnConcluir.Enabled = true;
                        btnAprovar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnImprimir.Enabled = true;
                        break;
                    case "Em Análise":
                        btnEditar.Enabled = true;
                        btnVisualizar.Enabled = true;
                        btnSuspender.Enabled = true;
                        btnConcluir.Enabled = true;
                        btnAprovar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnImprimir.Enabled = true;
                        break;
                    case "Aprovado (OS Aberta)":
                        btnEditar.Enabled = false;
                        btnVisualizar.Enabled = true;
                        btnSuspender.Enabled = false;
                        btnConcluir.Enabled = false;
                        btnAprovar.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnImprimir.Enabled = true;
                        break;
                    case "Concluído (Aprovação Pendente)":
                        btnEditar.Enabled = true;
                        btnVisualizar.Enabled = true;
                        btnSuspender.Enabled = true;
                        btnConcluir.Enabled = false;
                        btnAprovar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnImprimir.Enabled = true;
                        break;
                    case "Cancelado":
                        btnEditar.Enabled = false;
                        btnVisualizar.Enabled = true;
                        btnSuspender.Enabled = false;
                        btnConcluir.Enabled = false;
                        btnAprovar.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnImprimir.Enabled = true;
                        break;
                }
            }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (numOrc > 0)
            {
                FrmOrcamento o = new FrmOrcamento(usuario, numOrc);
                o.ShowDialog();
                povoaGridOrcamento(id_clie);
                dgOrcamentos.ClearSelection();
                numOrc = 0;
                enableBotoes("Cliente");
                clicado = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (numOrc > 0)
            {
                DialogResult result = MessageBox.Show("Deseja Cancelar o Orçamento?", "Cancelar Orçamento", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    orcamentoDb.atualizaStatus(numOrc, "Cancelado");
                    povoaGridOrcamento(id_clie);
                    dgOrcamentos.ClearSelection();
                    numOrc = 0;
                    enableBotoes("Cliente");
                }
            }
            clicado = false;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (numOrc > 0)
            {
                FrmOrcamento o = new FrmOrcamento(usuario, numOrc);
                o.ShowDialog();
                povoaGridOrcamento(id_clie);
                dgOrcamentos.ClearSelection();
                numOrc = 0;
                enableBotoes("Cliente");
                clicado = false;
            }
        }

        private void dgOrcamentos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (clicado == false)
            {
                dgOrcamentos.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgOrcamentos.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void btnNome_Click_1(object sender, EventArgs e)
        {
            povoaGridOrcamento(id_clie);
            dgOrcamentos.ClearSelection();
            clicado = false;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Cliente":
                    enableBotoes("Cliente");
                    limpaCampos();
                    break;
                case "CPF":
                    enableBotoes("CPF");
                    limpaCampos();
                    break;
                case "Datas":
                    enableBotoes("Datas");
                    limpaCampos();
                    break;
                case "N° Orçamento":
                    enableBotoes("N° Orçamento");
                    limpaCampos();
                    break;
                case "Equipamento":
                    enableBotoes("Equipamento");
                    limpaCampos();
                    break;
                case "N° Serie":
                    enableBotoes("N° Serie");
                    limpaCampos();
                    break;
            }
        }
        private void limpaCampos()
        {
            textNome.Text = "";
            txtcpf.Text = "";
            textNumero.Text = "";
            textVeiculo.Text = "";
            textPlaca.Text = "";
        }

        private void dgOrcamentos_Click(object sender, EventArgs e)
        {
            clicado = true;
        }

        private void dgOrcamentos_MouseLeave(object sender, EventArgs e)
        {
            clicado = false;
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            Orcamento orcamento = new Orcamento();
            orcamento = orcamentoDb.constroiOrcamento(Convert.ToInt32(dgOrcamentos.Rows[indice].Cells[1].Value));

            if (orcamento.Valor == 0)
            {
                MessageBox.Show("O Orçamento não pode ser aprovado com Valor 0,00");
            }
            else if (orcamento.Valor > 0)
            {
                DialogResult result = MessageBox.Show("Abrir Ordem de Serviço?", "Não", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    orcamentoDb.atualizaStatus(orcamento.Id, "Aprovado");
                    Ordem_Servico os = new Ordem_Servico();
                    Ordem_ServicoDb osDb = new Ordem_ServicoDb();
                    os.Id = orcamento.Id; ;
                    //os.Data_hora_fim = "2020-01-01 07:00:00";
                    os.Valor = orcamento.Valor;
                    os.Status = "Em Andamento";
                    os.Id_cliente = orcamento.Id_cliente;
                    os.Id_veiculo = orcamento.Id_veiculo;
                    osDb.insere(os);

                    //abre o form de OS
                    FrmOrdemServico o = new FrmOrdemServico(os.Id);
                    o.ShowDialog();
                }
                dtOrcamento.Rows.Clear();
                povoaGridOrcamento(id_clie);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimeOrcamento impressoes = new ImprimeOrcamento();
            impressoes.imprimeOrcamento(numOrc);
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

        private void textNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgResultClie.Select();
                dgResultClie.Rows[0].Selected = true;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}