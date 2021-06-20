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
    public partial class FrmVendasSuspensas : Form
    {
        VendaDb vendaDb = new VendaDb();
        DataTable dtVenda = new DataTable();
        UsuarioDb usuarioDb = new UsuarioDb();
        Itens_VendaDb itens = new Itens_VendaDb();
        int id_venda;
        string status;
        bool clicado = false;
        public FrmVendasSuspensas(string status)
        {
            InitializeComponent();
            this.status = status;
        }

        private void FrmVendasSuspensas_Load(object sender, EventArgs e)
        {
            povoaGrid();
            dgVendas.ClearSelection();
            disabeBotoes();
        }

        void povoaGrid()
        {
            dtVenda.Clear();
            switch (status)
            {
                case "Suspensa":
                    dtVenda = vendaDb.consultaStatus(status);
                    break;
                case "Finalizada":
                case "Cancelada":
                    dtVenda = vendaDb.consultaStatusHoje(status);
                    break;
            }
            dgVendas.DataSource = dtVenda;

        }


        private void btnAbrir_Click(object sender, EventArgs e)
        {
            clicado = false;

            if (LoginDb.caixaAberto() == true)
            {
                FrmPdv pdv = new FrmPdv(id_venda);
                pdv.ShowDialog();
                povoaGrid();
                disabeBotoes();
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
                        FrmPdv recuperar = new FrmPdv(id_venda);
                        recuperar.ShowDialog();
                        povoaGrid();
                        disabeBotoes();
                    }
                }
            }
        }

        private void dgVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgVendas.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_venda = Convert.ToInt32(dgVendas.Rows[indice].Cells[1].Value);
            //muda o enable dos botoes conforme o status da venda
            string valorCelula = dgVendas.Rows[indice].Cells[5].Value.ToString();
            enableBotoes(valorCelula);

            }

        private void enableBotoes(string valorCelula)
        {
            switch (valorCelula)
            {
                case "Suspensa":
                    btnAbrir.Enabled = true;
                    btnVisualizar.Enabled = false;
                    btnCancelar.Enabled = true;
                    break;
                case "finalizada":
                case "Cancelada":
                    btnAbrir.Enabled = false;
                    btnVisualizar.Enabled = true;
                    btnCancelar.Enabled = false;
                    break;
            }
        }
        private void disabeBotoes()
        {
            btnAbrir.Enabled = false;
            btnVisualizar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            clicado = false;

            System.Diagnostics.Process.Start(@"C:\Relatorios\Venda\Venda N°"+ id_venda + ".pdf");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clicado = false;

            DialogResult result = MessageBox.Show("Deseja cancelar a Venda  "+ id_venda + "?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                VendaDb vendaDb = new VendaDb();
                Itens_VendaDb itens_vendaDb= new Itens_VendaDb();
                Venda venda = new Venda();

                venda = vendaDb.constroiVenda(id_venda);
               itens_vendaDb.deleteTodos(venda);
                venda.Status = "Cancelada";                
                vendaDb.atualiza(venda);
            }
            povoaGrid();
            disabeBotoes();
        }

        private void dgVendas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (clicado == false)
            {
                dgVendas.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgVendas.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void dgVendas_MouseLeave(object sender, EventArgs e)
        {
            clicado = false;
        }

        private void dgVendas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                // vamos obter a linha da célula selecionada
                DataGridViewRow linhaAtual = dgVendas.CurrentRow;
                int indice = linhaAtual.Index;
                id_venda = Convert.ToInt32(dgVendas.Rows[indice].Cells[1].Value);
                status = dgVendas.Rows[indice].Cells[5].Value.ToString();
                enableBotoes(status);
            }
        }
    }
}