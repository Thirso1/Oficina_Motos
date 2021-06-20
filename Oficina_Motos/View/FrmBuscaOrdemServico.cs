using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina_Motos.View
{
    public partial class FrmBuscaOrdemServico : Form
    {
        public FrmBuscaOrdemServico(int tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }
        int tipo;
        private void FrmResultConsultaOrdemServico_Load(object sender, EventArgs e)
        {
            dpInicial.Visible = false;
            dpFim.Visible = false;
            btnBuscarDatas.Visible = false;
            lblFim.Visible = false;
            lblInicio.Visible = false;



            switch (tipo)
            {
                case 1:
                    textTitulo.Text = "Digite o Nome:";
                    break;
                case 2:
                    textTitulo.Text = "Digite o CPF:";
                    break;
                case 3:
                    textTitulo.Text = "Digite o N° Ordem Serviço:";
                    break;
                case 4:
                    textTitulo.Text = "Selecione as Datas:";
                    textDados.Visible = false;
                    btnBuscar.Visible = false;
                    dpInicial.Visible = true;
                    dpFim.Visible = true;
                    btnBuscarDatas.Visible = true;
                    lblFim.Visible = true;
                    lblInicio.Visible = true;

                    break;
                case 5:
                    textTitulo.Text = "Digite o Veículo:";
                    break;
                case 6:
                    textTitulo.Text = "Digite o N° da placa:";
                    break;
            }
        }
    }
}
