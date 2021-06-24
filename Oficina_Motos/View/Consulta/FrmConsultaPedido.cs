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

namespace Oficina_Motos.View.Consulta
{
    public partial class FrmConsultaPedido : Form
    {
        PedidoDb pedidoDb = new PedidoDb();
        DataTable dtPedido = new DataTable();
        FornecedorDb fornecedorDb = new FornecedorDb();
        int id_fornecedor = 0;
        int id_pedido = 0;
        bool clicado = false;

        public FrmConsultaPedido()
        {
            InitializeComponent();
        }

        private void FrmConsultaPedido_Load(object sender, EventArgs e)
        {
            //povoaGrid();
            enableTexbox("");
            comboBox1.SelectedIndex = 0;
            btnBuscar.Enabled = false;
        }

        private void disableBotoes()
        {
            btnImprimir.Enabled = false;
            btnConferir.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnBuscar.Enabled = true;
            dgResultClie.Visible = false;
        }

        private void limpaCampos()
        {
            textFornecedor.Text = "";
            textNumero.Text = "";
        }

        private void enableBotoes(string status)
        {

            switch (status)
            {
                case "Não Recebido":
                case "Suspenso":
                    btnImprimir.Enabled = true;
                    btnConferir.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEditar.Enabled = true;
                    btnBuscar.Enabled = false;
                    break;
                case "Recebido":
                case "Cancelado":
                    btnImprimir.Enabled = true;
                    btnConferir.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnBuscar.Enabled = false;
                    break;
            }
        }

        private void enableTexbox(string consulta)
        {
            switch (consulta)
            {
                case "Fornecedor":
                    textFornecedor.Enabled = true;
                    textFornecedor.Select();
                    textNumero.Enabled = false;
                    btnCancelar.Enabled = false;
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    disableBotoes();
                    break;
                case "N° Pedido":
                    textFornecedor.Enabled = false;
                    textNumero.Enabled = true;
                    textNumero.Select();
                    disableBotoes();
                    dpFim.Enabled = false;
                    dpInicio.Enabled = false;
                    break;
                case "Datas":
                    textFornecedor.Enabled = false;
                    textNumero.Enabled = false;
                    disableBotoes();

                    dpFim.Enabled = true;
                    dpInicio.Enabled = true;
                    break;
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Fornecedor":
                    enableTexbox("Fornecedor");
                    limpaCampos();
                    break;
                case "Datas":
                    enableTexbox("Datas");
                    limpaCampos();
                    break;
                case "N° Pedido":
                    enableTexbox("N° Pedido");
                    limpaCampos();
                    break;
            }
        }

        private void textNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if(e.KeyChar == 13)
            {
                povoaGrid();
            }
        }

        private void povoaGrid()
        {
            string consulta = comboBox1.Text;
            switch (consulta)
            {
                case "":
                    MessageBox.Show("Selecione o tipo de consulta.");
                    break;
                case "Fornecedor":
                    dtPedido.Rows.Clear();
                    if (textFornecedor.Text != "")
                    {
                        dtPedido = pedidoDb.consultaPorIdFornecedor(id_fornecedor);
                        if (dtPedido.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Pedido!");
                        }
                        else
                        {
                            dgPedidos.DataSource = dtPedido;
                        }
                    }
                    dgPedidos.ClearSelection();
                    enableTexbox("Fornecedor");
                    break;
                case "N° Pedido":
                    dtPedido.Rows.Clear();
                    if (textNumero.Text != "")
                    {
                        id_pedido = Convert.ToInt32(textNumero.Text);
                        dtPedido = pedidoDb.consultaPorId(id_pedido);
                        if (dtPedido.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Pedido!");
                        }
                        else
                        {
                            dgPedidos.DataSource = dtPedido;
                        }
                    }
                    dgPedidos.ClearSelection();
                    enableTexbox("N° Pedido");
                    break;
                case "Datas":
                    DateTime dataInicial = dpInicio.Value;
                    DateTime dataFim = dpFim.Value;

                    dtPedido.Rows.Clear();
                    dtPedido = pedidoDb.consultaPorData(dataInicial, dataFim);
                    if (dtPedido.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Pedido aqui!");
                    }
                    else
                    {
                        dgPedidos.DataSource = dtPedido;
                    }
                    dgPedidos.ClearSelection();
                    enableTexbox("Datas");
                    break;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            povoaGrid();
        }

        private void textFornecedor_KeyUp(object sender, KeyEventArgs e)
        {
            dgResultClie.Visible = true;
            dgResultClie.DataSource = fornecedorDb.consultaNome(textFornecedor.Text);
            btnBuscar.Enabled = true;
        }

        private void dgResultClie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgResultClie.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_fornecedor = Convert.ToInt32(dgResultClie.Rows[indice].Cells[0].Value);
            textFornecedor.Text = dgResultClie.Rows[indice].Cells[1].Value.ToString(); 
            dgResultClie.Visible = false;
        }

        private void dgResultClie_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgResultClie.ClearSelection();
            if (e.RowIndex > -1)
            {
                dgResultClie.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgPedidos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (clicado == false)
            {
                dgPedidos.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgPedidos.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void dgPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgPedidos.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_pedido = Convert.ToInt32(dgPedidos.Rows[indice].Cells[2].Value);

            //pega o valor da celula
            string status = dgPedidos.Rows[indice].Cells[6].Value.ToString();
            enableBotoes(status);
        }

        private void radioFiltro(string filtro)
        {
            switch (comboBox1.Text)
            {
                case "Fornecedor":
                    dtPedido.Rows.Clear();
                    dtPedido = pedidoDb.consultaStatusFornecedor(filtro, id_fornecedor);
                        if (dtPedido.Rows.Count == 0)
                        {
                            MessageBox.Show("Nenhum Pedido!");
                        }
                        else
                        {
                            dgPedidos.DataSource = dtPedido;
                        }
                    dgPedidos.ClearSelection();
                    enableTexbox("Fornecedor");
                    break;
                case "Datas":
                    dtPedido.Rows.Clear();
                    DateTime dataInicial = dpInicio.Value;
                    DateTime dataFim = dpFim.Value;
                    dtPedido = pedidoDb.consultaPorStatusData(filtro, dataInicial, dataFim);
                    if (dtPedido.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Pedido!");
                    }
                    else
                    {
                        dgPedidos.DataSource = dtPedido;
                    }
                    dgPedidos.ClearSelection();
                    enableTexbox("Fornecedor");
                    break;
                case "N° Pedido":
                    enableTexbox("N° Pedido");
                    limpaCampos();
                    break;
                case "":
                    MessageBox.Show("Informe o Tipo de Busca");
                    comboBox1.Select();
                    break;

            }
        }

        private void radioFiltroTodos()
        {
            switch (comboBox1.Text)
            {
                case "Fornecedor":
                    dtPedido.Rows.Clear();
                    dtPedido = pedidoDb.consultaTodosFornecedor(id_fornecedor);
                    if (dtPedido.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Pedido!");
                    }
                    else
                    {
                        dgPedidos.DataSource = dtPedido;
                    }
                    dgPedidos.ClearSelection();
                    enableTexbox("Fornecedor");
                    break;
                case "Datas":
                    DateTime dataInicial = dpInicio.Value;
                    DateTime dataFim = dpFim.Value;

                    dtPedido.Rows.Clear();
                    dtPedido = pedidoDb.consultaPorData(dataInicial, dataFim);
                    if (dtPedido.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum Pedido entre as datas!");
                    }
                    else
                    {
                        dgPedidos.DataSource = dtPedido;
                    }
                    dgPedidos.ClearSelection();
                    enableTexbox("Datas");
                    break;
                case "N° Pedido":
                    enableTexbox("N° Pedido");
                    limpaCampos();
                    break;
                case "":
                    MessageBox.Show("Informe o Tipo de Busca");
                    comboBox1.Select();
                    break;

            }
        }

        //radio todos
        private void radioTodos_Click(object sender, EventArgs e)
        {
            radioFiltroTodos();
        }

        private void radioCancelados_Click(object sender, EventArgs e)
        {
            radioFiltro("Cancelado");
        }

        private void radioRecebidos_Click(object sender, EventArgs e)
        {
            radioFiltro("Recebido");
        }

        private void radioNaoRecebidos_Click(object sender, EventArgs e)
        {
            radioFiltro("Não Recebido");
        }

        private void radioSuspensos_Click(object sender, EventArgs e)
        {
            radioFiltro("Suspenso");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmPedido pedido = new FrmPedido(id_pedido);
            pedido.ShowDialog();
        }

        private void dgPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgPedidos.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_pedido = Convert.ToInt32(dgPedidos.Rows[indice].Cells[2].Value);

            //pega o valor da celula
            string status = dgPedidos.Rows[indice].Cells[6].Value.ToString();
            if(status == "Suspenso" || status == "Não Recebido")
            {
                FrmPedido pedido = new FrmPedido(id_pedido);
                pedido.ShowDialog();
            }            
        }

        private void btnConferir_Click(object sender, EventArgs e)
        {
            FrmConferenciaPedido a = new FrmConferenciaPedido(id_pedido);
            a.ShowDialog();
            //
            povoaGrid();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimePedido impressoes = new ImprimePedido();
            impressoes.imprimePedido(id_pedido);
        }

        private void textFornecedor_KeyDown(object sender, KeyEventArgs e)
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
                id_fornecedor = Convert.ToInt32(dgResultClie.Rows[indice].Cells[0].Value);
                textFornecedor.Text = dgResultClie.Rows[indice].Cells[1].Value.ToString();
                dgResultClie.Visible = false;
                btnBuscar.Select();
            }
        }

        private void FrmConsultaPedido_Click(object sender, EventArgs e)
        {
            dgResultClie.Visible = false;
        }
    }
}

