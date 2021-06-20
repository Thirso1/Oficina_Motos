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
    public partial class FrmOrcamentosSuspensos : Form
    {
        public FrmOrcamentosSuspensos(string status)
        {
            InitializeComponent();
            this.status = status;
        }
        string status;
        OrcamentoDb orcamentoDb = new OrcamentoDb();
        DataTable dtOrcamento = new DataTable();
        UsuarioDb usuarioDb = new UsuarioDb();
        Itens_OrcamentoDb itens = new Itens_OrcamentoDb();
        Usuario usuario = new Usuario();
        Login login = new Login();
        int id_orcamento = 0;
        int indice = 0;
        bool clicado = false;

        private void FrmOrcamentosSuspensos_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Orçamentos " + status + "s";
            povoaGrid();
            enableBotoes("");
            login = LoginDb.caixa_login();
            usuario.Id = login.Id;
            usuario.Login = login.Usuario;

        }

        void conta_orcamentos()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                this.Close();
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

        void enableBotoes(string status)
        {
            switch (status)
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
                default:
                    btnEditar.Enabled = false;
                    btnVisualizar.Enabled = false;
                    btnSuspender.Enabled = false;
                    btnConcluir.Enabled = false;
                    btnAprovar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    break;
            }
        }

        private void povoaGrid()
        {
            dtOrcamento.Rows.Clear();
            dtOrcamento = orcamentoDb.consulta(status);
            texto_status();
            dataGridView1.DataSource = dtOrcamento;
            dataGridView1.ClearSelection();           
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            indice = linhaAtual.Index;
            id_orcamento = Convert.ToInt32(dataGridView1.Rows[indice].Cells[2].Value);
            status = dataGridView1.Rows[indice].Cells[9].Value.ToString();

            enableBotoes(status);
            clicado = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           FrmOrcamento orc = new FrmOrcamento(usuario, id_orcamento);
            orc.ShowDialog();
            povoaGrid();
            clicado = false;
            dataGridView1.ClearSelection();
            enableBotoes("");
            conta_orcamentos();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Impressoes impressoes = new Impressoes();
            impressoes.imprimeOrcamento(id_orcamento);
            clicado = false;
            dataGridView1.ClearSelection();
            enableBotoes("");
            conta_orcamentos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Impressoes impressoes = new Impressoes();
            impressoes.imprimeOrcamento(id_orcamento);
            clicado = false;
            dataGridView1.ClearSelection();
            enableBotoes("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Itens_OrcamentoDb itens_orcamentoDb = new Itens_OrcamentoDb();
            DialogResult result = MessageBox.Show("Deseja cancelar o orçamento?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                orcamentoDb.atualizaStatus(id_orcamento, "Cancelado");
                itens_orcamentoDb.deleteTodos(id_orcamento);

            }
            povoaGrid();
            clicado = false;
            dataGridView1.ClearSelection();
            enableBotoes("");
            conta_orcamentos();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            Orcamento orcamento = new Orcamento();
            orcamento = orcamentoDb.constroiOrcamento(Convert.ToInt32(dataGridView1.Rows[indice].Cells[2].Value));

            if (orcamento.Valor == 0)
            {
                MessageBox.Show("O Orçamento não pode ser Concluído com Valor 0,00");
            }
            else if (orcamento.Valor > 0)
            {
                orcamentoDb.atualizaStatus(orcamento.Id, "Concluído");
                MessageBox.Show("Orçamento N°" +id_orcamento+" Concluído");
            }
            povoaGrid();
            clicado = false;
            dataGridView1.ClearSelection();
            enableBotoes("");
            conta_orcamentos();
        }
        //botão de aprovar
        private void button3_Click(object sender, EventArgs e)
        {
            Orcamento orcamento = new Orcamento();
            orcamento = orcamentoDb.constroiOrcamento(Convert.ToInt32(dataGridView1.Rows[indice].Cells[2].Value));

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
                povoaGrid();
                clicado = false;
                dataGridView1.ClearSelection();
                enableBotoes("");
                conta_orcamentos();
            }
        }

        private void btnSuspender_Click(object sender, EventArgs e)
        {
            orcamentoDb.atualizaStatus(id_orcamento, "Suspenso");
            MessageBox.Show("Orçamento N°" + id_orcamento + " em Suspenção");
            povoaGrid();
            clicado = false;
            dataGridView1.ClearSelection();
            enableBotoes("");
            conta_orcamentos();
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (clicado == false)
            {
                dataGridView1.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            clicado = false;
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
                indice = linhaAtual.Index;
                id_orcamento = Convert.ToInt32(dataGridView1.Rows[indice].Cells[2].Value);
                status = dataGridView1.Rows[indice].Cells[9].Value.ToString();
                enableBotoes(status);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
