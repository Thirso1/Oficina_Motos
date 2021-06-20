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
    public partial class FrmConsultaServico : Form
    {
        ServicoDb servicoDb = new ServicoDb();
        Servico servico = new Servico();
        int id_servico = 0;
        bool clicado = false;

        public FrmConsultaServico()
        {
            InitializeComponent();
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        private void FrmConsultaServico_Load(object sender, EventArgs e)
        {
            dgServicos.ClearSelection();
            btnAbrir.Enabled = false;
        }

        private void txtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            clicado = false;
            DataTable dtServico = new DataTable();
            dgServicos.DataSource = servicoDb.consultaNome(txtBusca.Text);
        }

        private void dgServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgServicos.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;
                id_servico = Convert.ToInt32(dgServicos.Rows[indice].Cells[0].Value);
                btnAbrir.Enabled = true;
            
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            FrmCadastroServico cadServ = new FrmCadastroServico(id_servico);
            cadServ.ShowDialog();
            dgServicos.ClearSelection();
            btnAbrir.Enabled = false;
            clicado = false;
        }

        private void dgServicos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (clicado == false)
            {
                dgServicos.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgServicos.Rows[e.RowIndex].Selected = true;
                }
            }
        }
    }
}
