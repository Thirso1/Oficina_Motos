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
    public class EnderecoDb
    {
        public int geraCodEndereco()
        {
            string sqlCodEndereco = "SELECT * FROM endereco ORDER BY id DESC LIMIT 1";
            int numEndereco = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcod = new MySqlCommand(sqlCodEndereco, conn);
                numEndereco = Convert.ToInt32(objcod.ExecuteScalar());
                numEndereco += 1;
                return numEndereco;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return numEndereco;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Endereco endereco)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `endereco` (`id`, `logradouro`, `nome`,`numero`,`complemento`,`referencia`,`bairro`,`cidade`,`uf`,`cep`) values(?,?,?,?,?,?,?,?,?,?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = endereco.Id;
                objcmd.Parameters.Add("@logradouro", MySqlDbType.VarChar, 20).Value = endereco.Logradouro;
                objcmd.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = endereco.Nome;
                objcmd.Parameters.Add("@numero", MySqlDbType.VarChar, 14).Value = endereco.Numero;
                objcmd.Parameters.Add("@complemento", MySqlDbType.VarChar, 50).Value = endereco.Complemento;
                objcmd.Parameters.Add("@referencia", MySqlDbType.VarChar, 50).Value = endereco.Referencia;
                objcmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = endereco.Bairro;
                objcmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = endereco.Cidade;
                objcmd.Parameters.Add("@uf", MySqlDbType.VarChar, 2).Value = endereco.Uf;
                objcmd.Parameters.Add("@cep", MySqlDbType.VarChar, 14).Value = endereco.Cep;


                //executa a inserção
                objcmd.ExecuteNonQuery();
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

        public void atualiza(Endereco endereco)
        {
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `endereco` SET `logradouro`=@logradouro, nome=@nome, numero=@numero, complemento=@complemento, referencia=@referencia, bairro=@bairro, cidade=@cidade, cep=@cep, uf=@uf WHERE id =" + endereco.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@logradouro", MySqlDbType.VarChar, 20).Value = endereco.Logradouro;
            objcmd.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = endereco.Nome;
            objcmd.Parameters.Add("@numero", MySqlDbType.VarChar, 14).Value = endereco.Numero;
            objcmd.Parameters.Add("@complemento", MySqlDbType.VarChar, 50).Value = endereco.Complemento;
            objcmd.Parameters.Add("@referencia", MySqlDbType.VarChar, 50).Value = endereco.Referencia;
            objcmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = endereco.Bairro;
            objcmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = endereco.Cidade;
            objcmd.Parameters.Add("@uf", MySqlDbType.VarChar, 2).Value = endereco.Uf;
            objcmd.Parameters.Add("@cep", MySqlDbType.VarChar, 14).Value = endereco.Cep;

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
        public Endereco consultaPorId(int id)
        {
            Endereco endereco = new Endereco();
            MySqlDataReader rdr = null;
            string sqlContato = "SELECT * FROM `endereco` WHERE id =" + id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlContato, conn);
                rdr = objcomand.ExecuteReader();
                //define o total de registros como zero
                //int nuReg = 0;
                //percorre o leitor 
                while (rdr.Read())
                {
                    endereco.Id = id;
                    endereco.Logradouro = rdr["logradouro"].ToString();
                    endereco.Nome = rdr["nome"].ToString();
                    endereco.Numero = rdr["numero"].ToString();
                    endereco.Complemento = rdr["complemento"].ToString();
                    endereco.Referencia = rdr["referencia"].ToString();
                    endereco.Bairro = rdr["bairro"].ToString();
                    endereco.Cidade = rdr["cidade"].ToString();
                    endereco.Cep = rdr["cep"].ToString();
                }
                return endereco;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return endereco;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

    }
}
