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
    public partial class FrmEtiquetas : Form
    {
        ProdutoDb produtoDb = new ProdutoDb();
        public FrmEtiquetas()
        {
            InitializeComponent();
        }

        private void FrmEtiquetas_Load(object sender, EventArgs e)
        {
            dgPecas.Visible = false;
        }

        private void textBuscaProduto_KeyUp(object sender, KeyEventArgs e)
        {
            //dimensiona automaticamente a altura do datagrid
            //int rows = dgPecas.Rows.Count + 1;
            //dgPecas.Height = rows * 22;
            if (textBuscaProduto.Text.Length >= 3)
            {
                dgPecas.Visible = true;
                dgPecas.BringToFront();
                dgPecas.DataSource = produtoDb.consultaRapidaDescricao(textBuscaProduto.Text);
                dgPecas.ClearSelection();
            }
            else
            {
                dgPecas.Visible = false;
            }
        }

        private void textBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgPecas.Select();
                dgPecas.Rows[0].Selected = true;
            }
        }

        private void textBuscaProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                dgPecas.Visible = false;
            }
            if (e.KeyChar == 13)
            {
            }
        }
    }
}
