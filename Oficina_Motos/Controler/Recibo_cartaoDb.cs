using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Model;

namespace Oficina_Motos.Controler
{
    class Recibo_cartaoDb
    {
        public static void insere(Recibo_cartao recibo)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `recibos_cartao` (`cartao`, `valor`, `aut`) values(?, ?, ?)", conn);
                objcmd.Parameters.Add("@cartao", MySqlDbType.VarChar, 20).Value = recibo.Cartao;
                objcmd.Parameters.Add("@valor", MySqlDbType.Decimal, 8).Value = recibo.Valor;
                objcmd.Parameters.Add("@aut", MySqlDbType.VarChar, 20).Value = recibo.Aut;

                //executa a inserção
                objcmd.ExecuteNonQuery();
                Conect.fecharConexao();
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
    }
}
