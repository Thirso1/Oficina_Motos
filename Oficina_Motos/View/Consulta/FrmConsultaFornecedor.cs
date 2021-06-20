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

namespace Oficina_Motos.View.Consulta
{
    public partial class FrmConsultaFornecedor : Form
    {
        public FrmConsultaFornecedor()
        {
            InitializeComponent();
        }
        FornecedorDb fornecedorDb = new FornecedorDb();
        bool clicado = false;
        DataTable dtFuncionarios = new DataTable();

        private void FrmConsultaFornecedor_Load(object sender, EventArgs e)
        {
            povoaGrid();
        }

        private void povoaGrid()
        {
            dtFuncionarios.Rows.Clear();

            dtFuncionarios = fornecedorDb.consultaTodos();
            dtFuncionarios.Columns.Remove("id_contato");
            dtFuncionarios.Columns.Remove("id_endereco");
            dataGridView1.DataSource = dtFuncionarios;
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            if (e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

 
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            int indice = linhaAtual.Index;
            int id_fornecedor = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
            FrmCadastroFornecedor c = new FrmCadastroFornecedor(id_fornecedor);
            c.ShowDialog();
            povoaGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            
            string link = dataGridView1.Rows[indice].Cells[6].Value.ToString();

            Uri uriResult;
            bool result = Uri.TryCreate(link, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result)
            {
                System.Diagnostics.Process.Start(link);
            }
        }
    }
}
