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

namespace Oficina_Motos.View
{
    public partial class FrmConsultaFuncionario : Form
    {
        bool clicado;
        public FrmConsultaFuncionario()
        {
            InitializeComponent();
        }

        FuncionarioDb funcionarioDb = new FuncionarioDb();

        private void FrmConsultaFuncionario_Load(object sender, EventArgs e)
        {
            DataTable dtFuncionarios = new DataTable();
            dtFuncionarios = funcionarioDb.consultaTodos();
            dtFuncionarios.Columns.Remove("sexo");
            dtFuncionarios.Columns.Remove("rg");
            dtFuncionarios.Columns.Remove("cpf");
            dtFuncionarios.Columns.Remove("data_nasc");
            dtFuncionarios.Columns.Remove("id_contato");
            dtFuncionarios.Columns.Remove("id_endereco");

            dtFuncionarios.Columns.Add("Atualizar");
            dtFuncionarios.Columns.Add("Excluir");
            for (int i = 0; i <= dtFuncionarios.Rows.Count - 1; i++)
            {
                dtFuncionarios.Rows[i][3] = "Atualizar";
                dtFuncionarios.Rows[i][4] = "Excluir";
            }
            dataGridView1.DataSource = dtFuncionarios;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            int indice = linhaAtual.Index;
            int id_funcionario = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
            // vamos obter a linha da célula selecionada
            string valorCelula = dataGridView1.CurrentCell.Value.ToString();
            if (valorCelula == "Atualizar")
            {
                FrmCadastroFuncionarios c = new FrmCadastroFuncionarios(id_funcionario);
                c.ShowDialog();
            }
        }
        int previousRow;

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            //int previousRow;
            if (clicado == false)
            {
                DataGridView.HitTestInfo testInfo = dataGridView1.HitTest(e.X, e.Y);

                //Need to check to make sure that the row index is 0 or greater as the first
                //row is a zero and where there is no rows the row index is a -1
                if (testInfo.RowIndex >= 0 && testInfo.RowIndex != previousRow)
                {
                    dataGridView1.Rows[previousRow].Selected = false;
                    dataGridView1.Rows[testInfo.RowIndex].Selected = true;
                    previousRow = testInfo.RowIndex;
                }
            }
        }
    }
}



