using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina_Motos.Controler
{
    class Categoria_ProdutoDb
    {
        DataTable dtCategoria = new DataTable();

        public int retornaIdPorDescricao(string descricao)
        {
            string sql = "SELECT * FROM `categoria_produto` WHERE `descricao` = '"+descricao+"'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtCategoria);
                if(dtCategoria.Rows.Count > 0)
                {
                    return Convert.ToInt32(dtCategoria.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public int retornaDescricaoPorId(int id)
        {
            string sql = "SELECT `descricao` FROM `categoria_produto` WHERE  `id`= '" + id + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtCategoria);
                if (dtCategoria.Rows.Count > 0)
                {
                    return Convert.ToInt32(dtCategoria.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaTodos()
        {
            string sqlUsuario = "SELECT * FROM `categoria_produto`";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtCategoria);
                return dtCategoria;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtCategoria;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

    
    }
}
