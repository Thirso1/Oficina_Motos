using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina_Motos.Controler
{
   public class Conect
    {
        // vamos nos conectar ao SQL Server Express e à base de dados
        // locadora usando Windows Authentication                                                                    
        private static string connString = "server = localhost;port=3306;user id=root;database=zoinho_motos;password=wiUsRU0cMo6ZVsip";

        // representa a conexão com o banco
        private static MySqlConnection conn = null;

        // método que permite obter a conexão
        public static MySqlConnection obterConexao()
        {
            // vamos criar a conexão
            conn = new MySqlConnection(connString);

            // a conexão foi feita com sucesso?
            try
            {
                // abre a conexão e a devolve ao chamador do método
                conn.Open();
                return conn;
            }
            catch (MySqlException erro)
            {
                conn = null;
                MessageBox.Show("Ops! Verifique se o Wamp Server está Aberto!");
                // uma boa idéia aqui é gravar a exceção em um arquivo de log
            }
            return conn;

        }

        public static void fecharConexao()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }

}