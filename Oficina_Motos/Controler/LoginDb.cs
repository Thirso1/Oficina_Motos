using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Model;

namespace Oficina_Motos.Controler
{
    public class LoginDb
    {
        public static Login login = new Login();

        public static Login caixa_login()
        {
            DataTable caixa = new DataTable();
            string sql = "SELECT * FROM `login` WHERE id = 1";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(caixa);


                login.Id = 1;
                login.Caixa_aberto = Convert.ToBoolean(caixa.Rows[0][1]);
                login.Usuario = caixa.Rows[0][2].ToString();
                login.Id_usuario = Convert.ToInt32(caixa.Rows[0][3]);
                return login;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return login;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public static void atualiza(int id, bool caixa_aberto, string usuario, int id_usuario)
        {
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `login` SET caixa_aberto=@caixa_aberto, usuario=@usuario, id_usuario=@id_usuario WHERE id ="+id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@caixa_aberto", MySqlDbType.Int16).Value = caixa_aberto;
            objcmd.Parameters.Add("@usuario", MySqlDbType.VarChar, 50).Value = usuario;
            objcmd.Parameters.Add("@id_usuario", MySqlDbType.VarChar, 20).Value = id_usuario;

            try
            {
                //executa a inserção
                objcmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                //MessageBox.Show("Erro ao gravar orçamento");
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public static bool caixaAberto()
        {
            login = caixa_login();
            if(login.Caixa_aberto)
            {
                return true;
            }
            else if(!login.Caixa_aberto)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

    }
}