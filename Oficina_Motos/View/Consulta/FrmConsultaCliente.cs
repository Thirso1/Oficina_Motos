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
    public partial class FrmConsultaCliente : Form
    {
        public FrmConsultaCliente()
        {
            InitializeComponent();
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        Cliente cliente = new Cliente();
        ClienteDb clienteDb = new ClienteDb();
        DataTable dtCliente = new DataTable();
        int id = 0;

        private void FrmConsultaCliente_Load(object sender, EventArgs e)
        {
            cbTipoPesquisa.SelectedIndex = 0;
           
        }

        private void cbTipoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoPesquisa.SelectedIndex == 0)
            {
                txtNome.Text = "";
                txtCod.Text = "";
                txtCpf.Text = "";
                txtNome.Enabled = true;
                txtCpf.Enabled = false;
                txtCod.Enabled = false;
                txtNome.Select();
            }
            else if (cbTipoPesquisa.SelectedIndex == 1)
            {
                txtNome.Text = "";
                txtCod.Text = "";
                txtCpf.Text = "";
                txtNome.Enabled = false;
                txtCpf.Enabled = true;
                txtCod.Enabled = false;
                txtCpf.Select();
            }
            else if (cbTipoPesquisa.SelectedIndex == 2)
            {
                txtNome.Text = "";
                txtCod.Text = "";
                txtCpf.Text = "";
                txtNome.Enabled = false;
                txtCpf.Enabled = false;
                txtCod.Enabled = true;
                txtCod.Select();
            }
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            dtCliente = clienteDb.consultaFormatada(id, txtNome.Text, "");
            dtCliente.Columns.Add("Atualizar");

            for (int i = 0; i <= dtCliente.Rows.Count - 1; i++)
            {
                dtCliente.Rows[i][3] = "Atualizar";
            }
            dataGridView1.DataSource = dtCliente;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dataGridView1.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            string valorCelula = dataGridView1.CurrentCell.Value.ToString();

            if(valorCelula == "Atualizar")
            {
                int id_clie = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
                FrmCadastroCliente c = new FrmCadastroCliente(id_clie);
                c.ShowDialog();
            }
           

        }

        private void txtCod_KeyUp_1(object sender, KeyEventArgs e)
        {
            if(txtCod.Text != "")
            {
                id = Convert.ToInt32(txtCod.Text);
                dtCliente = clienteDb.consultaFormatada(id, "", "");
                dtCliente.Columns.Add("Atualizar");

                for (int i = 0; i <= dtCliente.Rows.Count - 1; i++)
                {
                    dtCliente.Rows[i][3] = "Atualizar";
                }
                dataGridView1.DataSource = dtCliente;
            }       
        }

        private void mascaraCpf(string cpf)
        {
            if(cpf.Length == 3)
            {
                txtCpf.Text = cpf + ".";
                txtCpf.SelectionStart = cpf.Length+1;
            }
            if (cpf.Length == 7)
            {
                txtCpf.Text = cpf + ".";
                txtCpf.SelectionStart = cpf.Length+1;
            }
            if (cpf.Length == 11)
            {
                txtCpf.Text = cpf + "-";
                txtCpf.SelectionStart = cpf.Length+1;
            }
        }

        private void txtCpf_KeyUp(object sender, KeyEventArgs e)
        {
            mascaraCpf(txtCpf.Text);
            dtCliente = clienteDb.consultaFormatada(id, "", txtCpf.Text);
            dtCliente.Columns.Add("Atualizar");

            for (int i = 0; i <= dtCliente.Rows.Count - 1; i++)
            {
                dtCliente.Rows[i][3] = "Atualizar";
            }
            dataGridView1.DataSource = dtCliente;
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            if (e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
