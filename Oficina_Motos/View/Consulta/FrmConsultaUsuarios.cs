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
    public partial class FrmConsultaUsuarios : Form
    {
        bool clicado = false;
        int indice;
        int id_usuario = 0;
        int id_funcionario = 0;

        public FrmConsultaUsuarios()
        {
            InitializeComponent();
        }

        private void FrmConsultaUsuarios_Load(object sender, EventArgs e)
        {
            povoaGrid();
        }

        private void povoaGrid()
        {
            UsuarioDb usuarioDb = new UsuarioDb();        
            dgUsuarios.DataSource = usuarioDb.consultaTodos();
            dgUsuarios.ClearSelection();
        }

        private void dgUsuarios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(clicado == false)
            {
                dgUsuarios.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgUsuarios.Rows[e.RowIndex].Selected = true;
                }
            }           
        }

        private void dgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;

            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgUsuarios.CurrentRow;
            // vamos exibir o índice da linha atual
            indice = linhaAtual.Index;
            id_usuario  = Convert.ToInt32(dgUsuarios.Rows[indice].Cells[0].Value);
            id_funcionario = Convert.ToInt32(dgUsuarios.Rows[indice].Cells[3].Value);

        }

        private void dgUsuarios_MouseLeave(object sender, EventArgs e)
        {
            clicado = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if(id_usuario != 0)
            {
                clicado = false;
                FrmCadastroUsuarios frm = new FrmCadastroUsuarios();
                frm.ShowDialog();
            }

        }
    }
}
