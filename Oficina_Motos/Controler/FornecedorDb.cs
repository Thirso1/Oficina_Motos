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
    class FornecedorDb
    {
        Fornecedor fornecedor = new Fornecedor();
        DataTable dtFornecedor = new DataTable();
        string data = DateTime.Today.ToString("yyyy-MM-dd");

        public int geraCodFornecedor()
        {
            string sqlCod = "SELECT * FROM fornecedor ORDER BY id DESC LIMIT 1";
            int cod = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcod = new MySqlCommand(sqlCod, conn);
                cod = Convert.ToInt32(objcod.ExecuteScalar());
                cod += 1;
                return cod;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return cod;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Fornecedor fornecedor)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `fornecedor` (`id`, `nome`, `cnpj`, `vendedor`, `cel_vendedor`, `id_contato`, `id_endereco`,`status`, `site`) values(?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = fornecedor.Id;
                objcmd.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = fornecedor.Nome;
                objcmd.Parameters.Add("@cnpj", MySqlDbType.VarChar, 20).Value = fornecedor.Cnpj;
                objcmd.Parameters.Add("@vendedor", MySqlDbType.VarChar, 50).Value = fornecedor.Vendedor;
                objcmd.Parameters.Add("@cel_vendedor", MySqlDbType.VarChar, 15).Value = fornecedor.Cel_vendedor;
                objcmd.Parameters.Add("@id_contato", MySqlDbType.Int32, 11).Value = fornecedor.Id_contato;
                objcmd.Parameters.Add("@id_endereco", MySqlDbType.Int32, 11).Value = fornecedor.Id_endereco;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 30).Value = fornecedor.Status;
                objcmd.Parameters.Add("@site", MySqlDbType.VarChar, 30).Value = fornecedor.Site;


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

        public Fornecedor consultaPorId(int id)
        {
            string sql = "SELECT * FROM `fornecedor` WHERE id =" + id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFornecedor);
                //cria o objeto
                fornecedor.Id = Convert.ToInt32(dtFornecedor.Rows[0]["id"]);
                fornecedor.Nome = dtFornecedor.Rows[0]["nome"].ToString();
                fornecedor.Cnpj = dtFornecedor.Rows[0]["cnpj"].ToString();
                fornecedor.Id_contato = Convert.ToInt32(dtFornecedor.Rows[0]["id_contato"]);
                fornecedor.Id_endereco = Convert.ToInt32(dtFornecedor.Rows[0]["id_endereco"]);
                fornecedor.Status = dtFornecedor.Rows[0]["status"].ToString();
                fornecedor.Vendedor = dtFornecedor.Rows[0]["vendedor"].ToString();
                fornecedor.Cel_vendedor = dtFornecedor.Rows[0]["cel_vendedor"].ToString();
                fornecedor.Site = dtFornecedor.Rows[0]["site"].ToString();


                return fornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return fornecedor;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void atualiza(Fornecedor fornecedor)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "UPDATE `fornecedor` SET `nome`=@nome,`cnpj`=@cnpj,`vendedor`=@vendedor,`cel_vendedor`=@cel_vendedor,`id_contato`=@id_contato,`id_endereco`=@id_endereco,`status`=@status,`site`=@site WHERE `id` = " + fornecedor.Id;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = fornecedor.Nome;
                objcmd.Parameters.Add("@cnpj", MySqlDbType.VarChar, 20).Value = fornecedor.Cnpj;
                objcmd.Parameters.Add("@vendedor", MySqlDbType.VarChar, 50).Value = fornecedor.Vendedor;
                objcmd.Parameters.Add("@cel_vendedor", MySqlDbType.VarChar, 15).Value = fornecedor.Cel_vendedor;
                objcmd.Parameters.Add("@id_contato", MySqlDbType.Int32, 11).Value = fornecedor.Id_contato;
                objcmd.Parameters.Add("@id_endereco", MySqlDbType.Int32, 11).Value = fornecedor.Id_endereco;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 30).Value = fornecedor.Status;
                objcmd.Parameters.Add("@site", MySqlDbType.VarChar, 30).Value = fornecedor.Site;

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

        public DataTable consultaTodos()
        {
            string sql = "SELECT * FROM `fornecedor`";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFornecedor);
                return dtFornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtFornecedor;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public bool verificaOcorrencia(int id_fornecedor, int id_produto)
        {
            string sql = "SELECT COUNT(*) FROM fornecedoredeprodutos WHERE id_produto = " + id_produto + " AND `id_fornecedor` = " + id_fornecedor + " > 0";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                bool resulVerifica = Convert.ToBoolean(objcomand.ExecuteScalar());
                return resulVerifica;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return false;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable fornecedorPorProduto(int id_produto)
        {
            string sql = "SELECT * FROM `fornecedoredeprodutos` WHERE id_produto = "+id_produto;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFornecedor);
                return dtFornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtFornecedor;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaNome(string nome)
        {
            DataTable dtFornecedor = new DataTable();
            string sqlCliente = "SELECT * FROM `fornecedor` WHERE nome LIKE '" + nome + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFornecedor);
                return dtFornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtFornecedor;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public Fornecedor retornaFornecedorPorNome(string nome)
        {
            Fornecedor fornecedor = new Fornecedor();
            DataTable dtFornecedor = new DataTable();
            string sqlCliente = "SELECT * FROM `fornecedor` WHERE nome = '" + nome + "'";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFornecedor);

                //cria o objeto
                fornecedor.Id = Convert.ToInt32(dtFornecedor.Rows[0]["id"]);
                fornecedor.Nome = dtFornecedor.Rows[0]["nome"].ToString();
                fornecedor.Cnpj = dtFornecedor.Rows[0]["cnpj"].ToString();
                fornecedor.Id_contato = Convert.ToInt32(dtFornecedor.Rows[0]["id_contato"]);
                fornecedor.Id_endereco = Convert.ToInt32(dtFornecedor.Rows[0]["id_endereco"]);
                fornecedor.Status = dtFornecedor.Rows[0]["status"].ToString();
                fornecedor.Vendedor = dtFornecedor.Rows[0]["vendedor"].ToString();
                fornecedor.Cel_vendedor = dtFornecedor.Rows[0]["cel_vendedor"].ToString();
                fornecedor.Site = dtFornecedor.Rows[0]["site"].ToString();

                return fornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return fornecedor;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public void insereFornecedorPorProduto(int id_fornecedor, int id_produto)
        {
            
                try
                {
                    MySqlConnection conn = Conect.obterConexao();
                    //string de inserção na tabela 
                    MySqlCommand objcmd = new MySqlCommand("INSERT INTO `fornecedores_has_produtos`(`id_fornecedor`, `id_produto`) values(?, ?)", conn);
                    objcmd.Parameters.Add("@id_fornecedor", MySqlDbType.Int32, 11).Value = id_fornecedor;
                    objcmd.Parameters.Add("@id_produto", MySqlDbType.Int32, 11).Value = id_produto;
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
            //}           
        }
    }
}