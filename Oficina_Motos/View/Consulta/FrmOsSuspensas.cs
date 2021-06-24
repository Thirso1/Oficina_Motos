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
    public partial class FrmOsSuspensas : Form
    {
        public FrmOsSuspensas(string status)
        {
            InitializeComponent();
            this.status = status;
        }
        string data_hora = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
        string status;
        Ordem_ServicoDb ordem_servicoDb = new Ordem_ServicoDb();
        DataTable dtOs = new DataTable();
        int id_os = 0;
        int indice = 0;
        bool clicado = false;
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

        private void FrmOsSuspensas_Load(object sender, EventArgs e)
        {
            povoaGrid();
            enableBotoes("");
        }

        void povoaGrid()
        {
            dtOs.Rows.Clear();
            dtOs = ordem_servicoDb.consultaPorStatus(status);
            dgOrcamentos.DataSource = dtOs;
            dgOrcamentos.ClearSelection();
        }

        void conta_os()
        {
            if(dgOrcamentos.Rows.Count == 0)
            {
                this.Close();
            }                
        }

        void enableBotoes(string status)
        {
            switch (status)
            {
                case "Em Andamento":
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

        private void dgOrcamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgOrcamentos.CurrentRow;
            // vamos exibir o índice da linha atual
            indice = linhaAtual.Index;
            id_os = Convert.ToInt32(dgOrcamentos.Rows[indice].Cells[2].Value);   
            //pega o valor da celula
            string valorCelula = dgOrcamentos.Rows[indice].Cells[9].Value.ToString();
            enableBotoes(valorCelula);
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            FrmOrdemServico o = new FrmOrdemServico(id_os);
            o.ShowDialog();
            dgOrcamentos.ClearSelection();
            enableBotoes("");
            clicado = false;
            povoaGrid();
            conta_os();
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

        private void btnSuspender_Click(object sender, EventArgs e)
        {
            Ordem_ServicoDb ordem_servicoSb = new Ordem_ServicoDb();
            Ordem_Servico ordem_servico = new Ordem_Servico();
            ordem_servico.Id = id_os;
            ordem_servico.Data_hora_fim = data_hora;
            ordem_servico.Status = "Suspensa";
            ordem_servicoSb.atualiza(ordem_servico);
            //
            povoaGrid();
            enableBotoes("");
            conta_os();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            Ordem_ServicoDb ordem_servicoSb = new Ordem_ServicoDb();
            Ordem_Servico ordem_servico = new Ordem_Servico();
            ordem_servico.Id = id_os;
            ordem_servico.Data_hora_fim = data_hora;
            ordem_servico.Status = "Concluída - Não Pago";
            ordem_servicoSb.atualiza(ordem_servico);
            //
            povoaGrid();
            enableBotoes("");
            conta_os();
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            clicado = false;
            decimal valor = Convert.ToDecimal(dgOrcamentos.Rows[indice].Cells[3].Value);
            string id_cliente = dgOrcamentos.Rows[indice].Cells[10].Value.ToString();

            FrmRecebimento recebimento = new FrmRecebimento(id_os, 22, valor, id_cliente);
            recebimento.OsSuspensas = this;
            recebimento.ShowDialog();

            if (Confirma_pagamento == true)
            {
                Ordem_Servico ordem_servico = new Ordem_Servico();
                ordem_servico.Id = id_os;
                ordem_servico.Data_hora_fim = data_hora;
                ordem_servico.Status = "Finalizada";
                ordem_servicoDb.atualiza(ordem_servico);
            }
            povoaGrid();
            enableBotoes("");
            conta_os();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja cancelar a Ordem de Serviço?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                Ordem_ServicoDb ordem_servicoDb = new Ordem_ServicoDb();
                Ordem_Servico ordem_servico = new Ordem_Servico();
                ordem_servico.Id = id_os;
                ordem_servico.Data_hora_fim = data_hora;
                ordem_servico.Status = "Cancelada";
                ordem_servicoDb.atualiza(ordem_servico);
            }
            //
            povoaGrid();
            enableBotoes("");
            conta_os();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimeOS impressoes = new ImprimeOS();
            impressoes.imprimeOs(id_os);
        }

        private void dgOrcamentos_MouseLeave(object sender, EventArgs e)
        {
            clicado = false;
        }

        private void dgOrcamentos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgOrcamentos.CurrentRow;
                indice = linhaAtual.Index;
                id_os = Convert.ToInt32(dgOrcamentos.Rows[indice].Cells[2].Value);
                status = dgOrcamentos.Rows[indice].Cells[9].Value.ToString();
                enableBotoes(status);
            }
        }
    }
}