using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Model;

//thiago
namespace Oficina_Motos.Controler
{
    public class ContatoDb
    {

        public int geraCodContato()
        {
            string sqlCodContato = "SELECT * FROM contato ORDER BY id DESC LIMIT 1";
            int numContato = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcod = new MySqlCommand(sqlCodContato, conn);
                numContato = Convert.ToInt32(objcod.ExecuteScalar());
                numContato += 1;
                return numContato;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return numContato;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Contato contato)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `contato` (`id`, `telefone_1`, `telefone_2`, `email`) values(?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = contato.Id;
                objcmd.Parameters.Add("@telefone_1", MySqlDbType.VarChar, 20).Value = contato.Telefone_1;
                objcmd.Parameters.Add("@telefone_2", MySqlDbType.VarChar, 20).Value = contato.Telefone_2;
                objcmd.Parameters.Add("@email", MySqlDbType.VarChar, 30).Value = contato.Email;

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

        public Contato consultaPorId(int id)
        {
            MySqlDataReader rdr = null;
            Contato contato = new Contato();
            string sqlContato = "SELECT * FROM `contato` WHERE id =" + id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlContato, conn);
                rdr = objcomand.ExecuteReader();
                //cria o objeto
                while (rdr.Read())
                {
                    contato.Id = id;
                    contato.Telefone_1 = rdr["telefone_1"].ToString();
                    contato.Telefone_2 = rdr["telefone_2"].ToString();
                    contato.Email = rdr["email"].ToString();
                }
                return contato;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return contato;
            }
            finally
            {
                Conect.fecharConexao();
            }         
        }

        public void atualiza(Contato contato)
        {
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `contato` SET telefone_1=@_telefone_1, telefone_2=@_telefone_2, email=@_email WHERE id =" + contato.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@_telefone_1", MySqlDbType.VarChar, 50).Value = contato.Telefone_1;
            objcmd.Parameters.Add("@_telefone_2", MySqlDbType.VarChar, 50).Value = contato.Telefone_2;
            objcmd.Parameters.Add("@_email", MySqlDbType.VarChar, 20).Value = contato.Email;

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
