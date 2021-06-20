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
    public partial class FrmConsultaProduto : Form
    {
        public FrmConsultaProduto()
        {
            InitializeComponent();
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }
        int id_produto;
        bool clicado;
        ProdutoDb produtoDb = new ProdutoDb();
        DataTable dtProduto = new DataTable();

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescricao_KeyUp(object sender, KeyEventArgs e)
        {
            clicado = false;
            dtProduto = produtoDb.consultaRapidaDescricao(txtDescricao.Text);
            dataGridView1.DataSource = dtProduto;

        }    

        private void FrmConsultaProduto_Load(object sender, EventArgs e)
        {
            btnAbrir.Enabled = false;
            txtDescricao.Select();
        }
        int previousRow;

        //private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    //int previousRow;
        //    if (clicado == false)
        //    {
        //        DataGridView.HitTestInfo testInfo = dataGridView1.HitTest(e.X, e.Y);

        //        //Need to check to make sure that the row index is 0 or greater as the first
        //        //row is a zero and where there is no rows the row index is a -1
        //        if (testInfo.RowIndex >= 0 && testInfo.RowIndex != previousRow)
        //        {
        //            dataGridView1.Rows[previousRow].Selected = false;
        //            dataGridView1.Rows[testInfo.RowIndex].Selected = true;
        //            previousRow = testInfo.RowIndex;
        //        }
        //    }
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            btnAbrir.Enabled = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_produto = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
            
        }

        private void btnAbrir_Click_1(object sender, EventArgs e)
        {
            FrmCadastroProdutos c = new FrmCadastroProdutos(id_produto);
            c.ShowDialog();
            clicado = false;
            btnAbrir.Enabled = false;
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(clicado == false)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            btnAbrir.Enabled = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_produto = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
            FrmCadastroProdutos c = new FrmCadastroProdutos(id_produto);
            c.ShowDialog();
            clicado = false;
            btnAbrir.Enabled = false;
        }
    }
}
