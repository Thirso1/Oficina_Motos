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

namespace Oficina_Motos.View.Cadastros
{
    public partial class FrmInsereFornecedor : Form
    {
        bool clicado = false;
        int id_fornecedor = 0;
        int id_produto = 0;
        public FrmInsereFornecedor(int id_produto)
        {
            InitializeComponent();
            this.id_produto = id_produto;
        }

        private void FrmInsereFornecedor_Load(object sender, EventArgs e)
        {
            FornecedorDb fornecedorDb = new FornecedorDb();
            dgFornecedores.DataSource = fornecedorDb.consultaTodos();
            btnInserir.Enabled = false;
        }

        private void dgFornecedores_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!clicado)
            {
                dgFornecedores.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgFornecedores.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void dgFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgFornecedores.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;

            id_fornecedor = Convert.ToInt32(dgFornecedores.Rows[indice].Cells[0].Value);
            MessageBox.Show(id_fornecedor.ToString());
            btnInserir.Enabled = true;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            FornecedorDb fornecedorDb = new FornecedorDb();
            fornecedorDb.insereFornecedorPorProduto(id_fornecedor, id_produto);
        }
    }
}
