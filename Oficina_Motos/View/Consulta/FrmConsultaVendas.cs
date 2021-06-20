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
    public partial class FrmConsultaVendas : Form
    {
        public FrmConsultaVendas()
        {
            InitializeComponent();
        }

        Usuario usuario = new Usuario();
        VendaDb vendaDb = new VendaDb();
        DataTable dtCliente = new DataTable();
        ClienteDb clienteDb = new ClienteDb();
        DataTable dtVenda = new DataTable();

        int numVenda;
        string id_clie;
        bool gridVendasClicado = false;
        bool gridClienteClicado = false;


        private void FrmConsultaVendas_Load(object sender, EventArgs e)
        {
            dgResultClie.Visible = false;
            comboBox1.Text = "Cliente";
            textNome.Enabled = true;
            txtcpf.Enabled = false;
            textNumero.Enabled = false;
            dpInicio.Enabled = false;
            dpFim.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnVisualizar.Enabled = false;
            btnNome.Enabled = true;

            textNome.Select();
        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            povoaGridVenda(id_clie);
        }

        private void textNome_KeyUp(object sender, KeyEventArgs e)
        {
            gridClienteClicado = false;
            dgResultClie.Visible = true;

            ClienteDb consulta = new ClienteDb();
            dgResultClie.DataSource = consulta.consultaNome(textNome.Text);
            btnNome.Enabled = true;
        }

        private void dgResultClie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridClienteClicado = true;

            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultClie.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_clie = dgResultClie.Rows[indice].Cells[0].Value.ToString();
            dtCliente = clienteDb.consultaPorId(id_clie);

            if (dtCliente.Rows.Count > 0)
            {
                //preenche os campos cliente
                textNome.Text = dtCliente.Rows[0]["nome"].ToString();
            }
            dgResultClie.Visible = false;
        }

        private void textNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }

        private void txtcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero");
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            
        }

        private void disableBotoes()
        {
            textNome.Enabled = true;
            txtcpf.Enabled = false;
            textNumero.Enabled = false;
            dpInicio.Enabled = false;
            dpFim.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnVisualizar.Enabled = false;
            btnNome.Enabled = true;
        }


        //criar metodo que limpa os campos qdo troca de opção
        void povoaGridVenda(string id_clie)
        {
            string data = "";
            string consulta = comboBox1.Text;
            switch (consulta)
            {
                case "":
                    MessageBox.Show("Selecione o tipo de consulta.");
                    break;
                case "Cliente":
                    dtVenda.Rows.Clear();
                    if(textNome.Text != "")
                    {
                        dtVenda = vendaDb.consultaPorCliente(id_clie);
                        for (int i = 0; i < dtVenda.Rows.Count; i++)
                        {
                            data = dtVenda.Rows[i][0].ToString();
                            dtVenda.Rows[i][0] = data.Substring(0, 10);
                        }

                        dgVendas.DataSource = dtVenda;
                        dgVendas.ClearSelection();
                    }                
                    break;
                case "CPF":
                    dtVenda.Rows.Clear();
                    if (txtcpf.Text != "")
                    {
                        dtVenda = vendaDb.consultaPorCpf(txtcpf.Text);
                        for (int i = 0; i < dtVenda.Rows.Count; i++)
                        {
                            data = dtVenda.Rows[i][0].ToString();
                            dtVenda.Rows[i][0] = data.Substring(0, 10);
                        }

                        dgVendas.DataSource = dtVenda;
                        dgVendas.ClearSelection();
                    }
                    break;
                case "N° Venda":
                    dtVenda.Rows.Clear();
                    if (txtcpf.Text != "")
                    {
                        dtVenda = vendaDb.consultaPorId(Convert.ToInt32(textNumero.Text));
                        for (int i = 0; i < dtVenda.Rows.Count; i++)
                        {
                            data = dtVenda.Rows[i][0].ToString();
                            dtVenda.Rows[i][0] = data.Substring(0, 10);
                        }
                        dgVendas.DataSource = dtVenda;
                        dgVendas.ClearSelection();
                    }                 
                    break;
                case "Data":
                    dtVenda.Rows.Clear();
                    string dataInicial = dpInicio.Text;
                    string inicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    string dataFim = dpFim.Text;
                    string fim = dataFim.Substring(6, 4) + "-" + dataFim.Substring(3, 2) + "-" + dataFim.Substring(0, 2);

                    dgVendas.DataSource = vendaDb.consultaPorData(inicial, fim);
                    break;

            }
        }

     private void limpaCampos()
        {
            textNome.Text = "";
            txtcpf.Text = "";
            textNumero.Text = "";
            dpInicio.Text = "";
            dpFim.Text = "";
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Cliente")
            {
                limpaCampos();
                textNome.Enabled = true;
                txtcpf.Enabled = false;
                textNumero.Enabled = false;
                dpInicio.Enabled = false;
                dpFim.Enabled = false;

                textNome.Select();
            }
            else if (comboBox1.Text == "CPF")
            {
                limpaCampos();
                textNome.Enabled = false;
                txtcpf.Enabled = true;
                textNumero.Enabled = false;
                dpInicio.Enabled = false;
                dpFim.Enabled = false;
                txtcpf.Select();
            }
            else if (comboBox1.Text == "N° Venda")
            {
                limpaCampos();
                textNome.Enabled = false;
                txtcpf.Enabled = false;
                textNumero.Enabled = true;
                dpInicio.Enabled = false;
                dpFim.Enabled = false;
                textNumero.Select();
            }
            else
            {
                limpaCampos();
                textNome.Enabled = false;
                txtcpf.Enabled = false;
                textNumero.Enabled = false;
                dpInicio.Enabled = true;
                dpFim.Enabled = true;
                textNumero.Select();
            }
        }

        private void dgVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridVendasClicado = true;
            if (dgVendas.Rows.Count > 0)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgVendas.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;
                numVenda = Convert.ToInt32(dgVendas.Rows[indice].Cells[1].Value);
                //pega o valor da celula
                string valorCelula = dgVendas.Rows[indice].Cells[5].Value.ToString();


                switch (valorCelula)
                {
                    case "Suspensa":
                        btnEditar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnVisualizar.Enabled = false;
                        btnNome.Enabled = false;
                        break;
                    case "Em Andamento":
                        btnEditar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnVisualizar.Enabled = false;
                        btnNome.Enabled = false;
                        break;
                    case "finalizada":
                        btnEditar.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnVisualizar.Enabled = true;
                        btnNome.Enabled = false;
                        break;
                    case "Cancelada":
                        btnEditar.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnVisualizar.Enabled = true;
                        btnNome.Enabled = false;
                        break;
                }
            }     
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (LoginDb.caixaAberto() == true)
            {
                FrmPdv pdv = new FrmPdv(numVenda);
                pdv.ShowDialog();
            }
            else
            {
                DialogResult result = MessageBox.Show("Caixa fechado! Deseja abrir?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    FrmAberturaCaixa1 ab = new FrmAberturaCaixa1();
                    ab.ShowDialog();
                    if (LoginDb.caixaAberto() == true)
                    {
                        FrmPdv pdv = new FrmPdv(numVenda);
                        pdv.ShowDialog();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textNome_Click(object sender, EventArgs e)
        {
            btnNome.Enabled = true;
        }

        private void txtcpf_Click(object sender, EventArgs e)
        {
            btnNome.Enabled = true;
        }

        private void textNumero_Click(object sender, EventArgs e)
        {
            btnNome.Enabled = true;
        }

        private void dpInicio_MouseEnter(object sender, EventArgs e)
        {
            btnNome.Enabled = true;
        }

        private void txtcpf_KeyUp(object sender, KeyEventArgs e)
        {
            btnNome.Enabled = true;
        }

        private void textNumero_KeyUp(object sender, KeyEventArgs e)
        {
            btnNome.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja cancelar a Venda  " + numVenda + "?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                VendaDb vendaDb = new VendaDb();
                Itens_VendaDb itens_vendaDb = new Itens_VendaDb();
                Venda venda = new Venda();

                venda = vendaDb.constroiVenda(numVenda);
                MessageBox.Show(venda.Valor_total.ToString());
                itens_vendaDb.deleteTodos(venda);
                venda.Status = "Cancelada";
                vendaDb.atualiza(venda);
            }
            povoaGridVenda(id_clie);
            disableBotoes();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {

        }

        private void dgVendas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(gridVendasClicado == false)
            {
                dgVendas.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgVendas.Rows[e.RowIndex].Selected = true;
                }
            }
           
        }

        private void dgResultClie_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgResultClie.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgResultClie.Rows[e.RowIndex].Selected = true;
            }
        }

        private void textNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgResultClie.Select();
                dgResultClie.Rows[0].Selected = true;
            }

        }

        private void dgResultClie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgResultClie.CurrentRow;
                // vamos exibir o índice da linha atual
                int indice = linhaAtual.Index;
                id_clie = dgResultClie.Rows[indice].Cells[0].Value.ToString();
                dtCliente = clienteDb.consultaPorId(id_clie);

                if (dtCliente.Rows.Count > 0)
                {
                    //preenche os campos cliente
                    textNome.Text = dtCliente.Rows[0]["nome"].ToString();
                }
                dgResultClie.Visible = false;
                btnNome.Select();
            }
        }
    }
}