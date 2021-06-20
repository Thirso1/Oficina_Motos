using MySql.Data.MySqlClient;
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
    public partial class teste : Form
    {
        CrediarioDb crediarioDb = new CrediarioDb();
        public teste()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();

                DataTable returProdutos = new DataTable();
                string sqlProduto = "SELECT * FROM `produto`";

                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);

                MessageBox.Show(returProdutos.Rows.Count.ToString());



                for (int i = 0; i < returProdutos.Rows.Count; i++)
                {

                    //string de inserção na tabela       
                    string sql = "UPDATE `produto` SET `imagem`=@imagem, `id_categoria`=@id_categoria WHERE id = " + returProdutos.Rows[i][0];
                    MySqlCommand objcmd = new MySqlCommand(sql, conn);

                    objcmd.Parameters.Add("@imagem", MySqlDbType.VarChar, 100).Value = "imagem";
                    objcmd.Parameters.Add("@id_categoria", MySqlDbType.Int32, 11).Value = 1;
                    objcmd.ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        private void teste_Load(object sender, EventArgs e)
        {

        }
    }
}
