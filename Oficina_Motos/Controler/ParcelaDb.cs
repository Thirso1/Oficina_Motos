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
    class ParcelaDb
    {
        public DataTable consultaPorId(int id)
        {
            string sql = "SELECT * FROM `parcela` WHERE `id_crediario` = '" + id + "' ORDER BY `parcela`.`id` ASC";
            DataTable parcelas = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(parcelas);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            finally
            {
                Conect.fecharConexao();
            }
            //
            if (parcelas.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Registro!");
                return null;
            }
            else
            {
                return parcelas;
            }
        }

        public void atualizaStatus(Parcela parcela)
        {
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `parcela` SET valor_recebido=@valor_recebido,status=@status WHERE id =" + parcela.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@valor_recebido", MySqlDbType.Decimal, 8).Value = parcela.Valor_recebido;
            objcmd.Parameters.Add("@status", MySqlDbType.Int32, 11).Value = parcela.Status;

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
    }
}