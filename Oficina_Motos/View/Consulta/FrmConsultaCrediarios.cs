using System;
using System.Collections;
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
    public partial class FrmConsultaCrediarios : Form
    {
        int status; // 0 para (pago), 1 para (a vencer), 2 para(parcialmente pagos), 3 para(atrasados)
        CrediarioDb crediarioDb = new CrediarioDb();
        DataTable crediarios = new DataTable();
        int id_crediario;
        bool clicado = false;
        //essas instancias do form1 para manipular o 'visible' dos paineis
        private Form1 form_1;
        public Form1 Form_1
        {
            get
            {
                return form_1;
            }

            set
            {
                form_1 = value;
            }
        }

        DataTable result = new DataTable();
        DataColumn dc1 = new DataColumn("Num_crediario");
        DataColumn dc2 = new DataColumn("Data");
        DataColumn dc3 = new DataColumn("Numero");
        DataColumn dc4 = new DataColumn("Referencia");
        DataColumn dc5 = new DataColumn("Entrada");
        DataColumn dc6 = new DataColumn("Valor Parcelado");
        DataColumn dc7 = new DataColumn("Cliente");
        DataColumn dc8 = new DataColumn("CPF");
        DataColumn dc9 = new DataColumn("Status");


        public FrmConsultaCrediarios(int status)
        {
            InitializeComponent();
            this.status = status;
        }

        private void FrmConsultaCrediarios_Load(object sender, EventArgs e)
        {
            btnAbrir.Enabled = false;

            switch (status)
            {
                case 0:

                    break;
                case 1:
                    crediarios_a_vencer();
                    lblTitulo.Text = "Crediarios a Vencer";
                    break;
                case 2:
                   
                    break;
                case 3:
                    crediarios_atrasados();
                    lblTitulo.Text = "Crediarios Atrasados";
                    break;

            }
        }

        private void crediarios_a_vencer()
        {
            List<int> cred = new List<int>();

            //crediarios que tiveram 0,00 de pagamento
            result.Columns.Add(dc1);
            result.Columns.Add(dc2);
            result.Columns.Add(dc3);
            result.Columns.Add(dc4);
            result.Columns.Add(dc5);
            result.Columns.Add(dc6);
            result.Columns.Add(dc7);
            result.Columns.Add(dc8);
            result.Columns.Add(dc9);

            DataTable credi = new DataTable();

            //crediario que estao em atraso
            cred = crediarioDb.crediarios_a_vencer();
            for (int i = 0; i <= cred.Count - 1; i++)
            {

                credi = crediarioDb.consultaPorId(Convert.ToInt32(cred[i]));
                for (int j = 0; j <= 8; j++)
                {
                    DataRow row = result.NewRow();
                    result.Rows.Add(row);
                    result.Rows[i][j] = credi.Rows[0][j];
                }
            }

            //loop para colocar texto de status no lugar de inteiros
            //for (int i = 0; i <= result.Rows.Count - 1; i++)
            //{
            //    string status = result.Rows[i][8].ToString();
            //        if (status == "1")
            //    {
            //        result.Rows[i][8] = "Não Pago";
            //    }
            //    if (status == "0")
            //    {
            //        result.Rows[i][8] = "Pago";
            //    }
            //}
            dgCrediarios.DataSource = result;

           
                //for (int k = 0; k <= dgCrediarios.Rows.Count - 1; k++)
                //    {
                //    if (dgCrediarios.Rows[k].Cells[0].Value == null)
                //    {
                //        dgCrediarios.Rows.RemoveAt(k);
                //        dgCrediarios.Refresh();
                //    }                   
                //    }

                dgCrediarios.ClearSelection();
        }

        private void crediarios_atrasados()
        {
            List<int> cred = new List<int>();

            //crediarios que tiveram 0,00 de pagamento
            result.Columns.Add(dc1);
            result.Columns.Add(dc2);
            result.Columns.Add(dc3);
            result.Columns.Add(dc4);
            result.Columns.Add(dc5);
            result.Columns.Add(dc6);
            result.Columns.Add(dc7);
            result.Columns.Add(dc8);
            result.Columns.Add(dc9);

            DataTable credi = new DataTable();

            //crediario que estao em atraso
            cred = crediarioDb.crediarios_atrasados();
   
            for (int i = 0; i <= cred.Count - 1; i++)
            {

                credi = crediarioDb.consultaPorId(Convert.ToInt32(cred[i]));
                for (int j = 0; j <= 8; j++)
                {
                    DataRow row = result.NewRow();
                    result.Rows.Add(row);
                    result.Rows[i][j] = credi.Rows[0][j];
                }
            }

            dgCrediarios.DataSource = result;

            //for (int k = 0; k <= dgCrediarios.Rows.Count - 1; k++)
            //    {
            //    if (dgCrediarios.Rows[k].Cells[0].Value == null)
            //    {
            //        dgCrediarios.Rows.RemoveAt(k);
            //        dgCrediarios.Refresh();
            //    }                   
            //    }

            dgCrediarios.ClearSelection();
        }

        private void dgCrediarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgCrediarios.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            if (dgCrediarios.Rows[indice].Cells[2].Value.ToString() != "")
            {
                id_crediario = Convert.ToInt32(dgCrediarios.Rows[indice].Cells[0].Value);
                btnAbrir.Enabled = true;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            FrmExibeCrediario exibe = new FrmExibeCrediario(id_crediario);
            exibe.ShowDialog();
            btnAbrir.Enabled = false;
            clicado = false;
        }

        private void dgCrediarios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(clicado == false)
            {
                dgCrediarios.ClearSelection();
                if (e.RowIndex > -1)
                {
                    dgCrediarios.Rows[e.RowIndex].Selected = true;
                }
            }         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgCrediarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clicado = true;
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgCrediarios.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            if (dgCrediarios.Rows[indice].Cells[2].Value.ToString() != "")
            {
                id_crediario = Convert.ToInt32(dgCrediarios.Rows[indice].Cells[0].Value);
                btnAbrir.Enabled = true;
            }
            FrmExibeCrediario exibe = new FrmExibeCrediario(id_crediario);
            exibe.ShowDialog();
            btnAbrir.Enabled = false;
            clicado = false;
        }
    }
}






