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
    public partial class FrmCrediarioPorCliente : Form
    {
        CrediarioDb crediarioDb = new CrediarioDb();
        int id_crediario;
        int status = 0;
        bool clicado = false;
        string nome;
        bool cliente_clicado = false;
        string id_clie;
        DataTable dtCliente = new DataTable();
        DataTable dtCrediarios = new DataTable();
        ClienteDb clienteDb = new ClienteDb();


        public FrmCrediarioPorCliente()
        {
            InitializeComponent();
        }

        private void FrmCrediarioPorCliente_Load(object sender, EventArgs e)
        {
            cbTipoPesquisa.SelectedIndex = 0;
            txtNome.Enabled = true;
            txtCpf.Enabled = false;
            btnAbrir.Enabled = false;
        }

        private void cbTipoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPesquisa.SelectedIndex == 0)
            {
                txtNome.Enabled = true;
                txtCpf.Text = "";
                txtCpf.Enabled = false;
                txtNome.Select();
            }
            else if (cbTipoPesquisa.SelectedIndex == 1)
            {
                txtNome.Text = "";
                txtNome.Enabled = false;
                txtCpf.Enabled = true;
                txtCpf.Select();
            }
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            cliente_clicado = false;
            dgResultCliente.Visible = true;
            dgResultCliente.BringToFront();

            ClienteDb clienteDb = new ClienteDb();
            dgResultCliente.DataSource = clienteDb.consultaNome(txtNome.Text);

        }

        private void povoaGrid()
        {
            if (dtCrediarios.Rows.Count > 0)
            {
                dtCrediarios.Rows.Clear();
            }
            switch (cbTipoPesquisa.Text)
            {

                case "Nome":
                    dtCrediarios = crediarioDb.consultaNome(txtNome.Text);
                    if (dtCrediarios.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Crediário");
                    }
                    else
                    {
                        dgCrediarios.DataSource = dtCrediarios;
                        dgCrediarios.ClearSelection();
                    }                    
                    break;
                case "CPF":
                    dtCrediarios = crediarioDb.consultaPorCpf(txtCpf.Text);
                    if (dtCrediarios.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Crediário");
                    }
                    else
                    {
                        dgCrediarios.DataSource = dtCrediarios;
                        dgCrediarios.ClearSelection();
                    }
                    break;
            }
        }
            //for (int i = 0; i < dgCrediarios.Rows.Count; i++)
            //{
            //    status = Convert.ToInt32(dgCrediarios.Rows[i].Cells[8].Value);
            //    MessageBox.Show(status.ToString());
            //    switch (status)
            //    {
            //        case 1:
            //            dgCrediarios.Rows[i].Cells[8].Value = "Pago";
            //            break;
            //        case 0:
            //            dgCrediarios.Rows[i].Cells[8].Value = "Não Pago";
            //            break;
            //        case 2:
            //            dgCrediarios.Rows[i].Cells[8].Value = "Parcialmente Pago";
            //            break;
            //    }
            //}
        

        private void dgCrediarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgCrediarios.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_crediario = Convert.ToInt32(dgCrediarios.Rows[indice].Cells[0].Value);
            btnAbrir.Enabled = true;

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            FrmExibeCrediario exibe = new FrmExibeCrediario(id_crediario);
            exibe.ShowDialog();
            btnAbrir.Enabled = false;

            povoaGrid();
        }

        private void dgResultCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultCliente.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_clie = dgResultCliente.Rows[indice].Cells[0].Value.ToString();
            dtCliente = clienteDb.consultaPorId(id_clie);

            if (dtCliente.Rows.Count > 0)
            {
                //preenche os campos cliente
                txtNome.Text = dtCliente.Rows[0]["nome"].ToString();
            }
            dgResultCliente.Visible = false;
        }

        private void FrmCrediarioPorCliente_Click(object sender, EventArgs e)
        {
            dgResultCliente.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            clicado = false;
            if(cbTipoPesquisa.Text == "")
            {
                MessageBox.Show("Selesione o tipo de pesquisa");
                cbTipoPesquisa.Select();
            }else
            {
                povoaGrid();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                clicado = false;

                if (cbTipoPesquisa.Text == "")
                {
                    MessageBox.Show("Selesione o tipo de pesquisa");
                    cbTipoPesquisa.Select();
                }
                else
                {
                    povoaGrid();
                }
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                clicado = false;

                if (cbTipoPesquisa.Text == "")
                {
                    MessageBox.Show("Selesione o tipo de pesquisa");
                    cbTipoPesquisa.Select();
                }
                else
                {
                    povoaGrid();
                }
            }
        }

        private void dgResultCliente_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgResultCliente.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgResultCliente.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgCrediarios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!clicado)
            {
                dgCrediarios.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgCrediarios.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgResultCliente.Select();
                dgResultCliente.Rows[0].Selected = true;
            }

        }

        private void dgResultCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgResultCliente.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;
                id_clie = dgResultCliente.Rows[indice].Cells[0].Value.ToString();
                dtCliente = clienteDb.consultaPorId(id_clie);

                if (dtCliente.Rows.Count > 0)
                {
                    //preenche os campos cliente
                    txtNome.Text = dtCliente.Rows[0]["nome"].ToString();
                }
                dgResultCliente.Visible = false;
                btnBuscar.Select();
            }
        }
    }
}
