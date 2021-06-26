using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Model;

//thiago maquinas
namespace Oficina_Motos.Controler
{
    public class ClienteDb
    {
        DataTable returNomes = new DataTable();
        DataTable dtCliente = new DataTable();
        ContatoDb contatoDb = new ContatoDb();
        EnderecoDb enderecoDb = new EnderecoDb();
        Cliente cliente = new Cliente();
        string sqlCliente;


        public int geraCodCliente()
        {
            string sqlCodCliente = "SELECT * FROM cliente ORDER BY id DESC LIMIT 1";
            int numCliente = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcodClie = new MySqlCommand(sqlCodCliente, conn);
                numCliente = Convert.ToInt32(objcodClie.ExecuteScalar());
                numCliente += 1;
                return numCliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return numCliente;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        //
        //
        public void insere(Cliente cliente)
        {
            string data;
            DateTime date = new DateTime();
            if (cliente.Data_nasc == "  /  /")
            {
                data = DateTime.Today.ToString("yyyy-MM-dd");
            }
            else
            {
                
                date = Convert.ToDateTime(cliente.Data_nasc);
                data = date.ToString("yyyy-MM-dd");
            }

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `cliente` (`id`, `nome`, `sexo`, `rg`, `cpf`, `data_nasc`, `status`, `id_contato`, `id_endereco`) values(?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@nm_id", MySqlDbType.Int32, 11).Value = cliente.Id;
                objcmd.Parameters.Add("@nm_nome", MySqlDbType.VarChar, 100).Value = cliente.Nome;
                objcmd.Parameters.Add("@nm_sexo", MySqlDbType.VarChar, 50).Value = cliente.Sexo;
                objcmd.Parameters.Add("@nm_rg", MySqlDbType.VarChar, 20).Value = cliente.Rg;
                objcmd.Parameters.Add("@nm_cpf", MySqlDbType.VarChar, 20).Value = cliente.Cpf;
                objcmd.Parameters.Add("@nm_data_nasc", MySqlDbType.Date).Value = data;
                objcmd.Parameters.Add("@nm_status", MySqlDbType.VarChar, 50).Value = cliente.Status;
                objcmd.Parameters.Add("@nm_contato", MySqlDbType.Int32, 11).Value = cliente.Contato.Id;
                objcmd.Parameters.Add("@nm_endereco", MySqlDbType.Int32, 11).Value = cliente.Endereco.Id;

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
        //
        //
        public void atualiza(Cliente cliente)
        {
            string data;
            DateTime date = new DateTime();
            if (cliente.Data_nasc == "  /  /")
            {
                data = DateTime.Today.ToString("yyyy-MM-dd");
            }
            else
            {

                date = Convert.ToDateTime(cliente.Data_nasc);
                data = date.ToString("yyyy-MM-dd");
            }
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `cliente` SET nome=@_nome, sexo=@_sexo, rg=@_rg, cpf = @_cpf, data_nasc=@_data_nasc, id_contato=@_contato, id_endereco=@_endereco WHERE id =" + cliente.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@_nome", MySqlDbType.VarChar, 100).Value = cliente.Nome;
            objcmd.Parameters.Add("@_sexo", MySqlDbType.VarChar, 50).Value = cliente.Sexo;
            objcmd.Parameters.Add("@_rg", MySqlDbType.VarChar, 20).Value = cliente.Rg;
            objcmd.Parameters.Add("@_cpf", MySqlDbType.VarChar, 14).Value = cliente.Cpf;
            objcmd.Parameters.Add("@_data_nasc", MySqlDbType.Date, 20).Value = data;
            objcmd.Parameters.Add("@_status", MySqlDbType.VarChar, 20).Value = cliente.Status;
            objcmd.Parameters.Add("@_contato", MySqlDbType.Int32, 11).Value = cliente.Contato.Id;
            objcmd.Parameters.Add("@_endereco", MySqlDbType.Int32, 11).Value = cliente.Endereco.Id;

            try
            {
                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Cliente atualizado com sucesso.");
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

        //
        //
        //public void exclui(Cliente cliente)
        //{
        //    string sqlDeleta = "DELETE FROM `clientes` WHERE id_cliente =" + cliente.IdCliente;
        //    try
        //    {
        //        MySqlConnection conn = Conect.obterConexao();
        //        //executa a romoção
        //        MySqlCommand objcomand = new MySqlCommand(sqlDeleta, conn);
        //        objcomand.ExecuteNonQuery();
        //        MessageBox.Show("Cliente excluído.");
        //    }
        //    catch (MySqlException erro)
        //    {
        //        MessageBox.Show(erro.ToString());
        //    }
        //    finally
        //    {
        //        Conect.fecharConexao();
        //    }
        //}
        ////
        ////
        public DataTable consultaNome(string nome)
        {
            DataTable returClientes = new DataTable();
            string sqlCliente = "SELECT * FROM `nome_cpf` WHERE nome LIKE '" + nome + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returClientes);
                return returClientes;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returClientes;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }
        ////
        ////
        /// <summary>

        public DataTable consultaFormatada(int id, string nome, string cpf)
        {
            if (id > 0)
            {
                sqlCliente = "SELECT `id`,`nome`,`cpf` FROM `cliente` WHERE id = " +id;
            }
            else if(nome != "")
            {
               sqlCliente = "SELECT `id`,`nome`,`cpf` FROM `cliente` WHERE nome LIKE '%" + nome + "%'";
            }
            else if (cpf != "")
            {
                sqlCliente = "SELECT `id`,`nome`,`cpf` FROM `cliente` WHERE cpf LIKE '%" + cpf + "%'";

            }
            DataTable returClientes = new DataTable();
            MySqlConnection conn = Conect.obterConexao();
            MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
            try
            {
                
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returClientes);
                return returClientes;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returClientes;
            }
            finally
            {
                Conect.fecharConexao();
            }
        
        }
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente consultaPorId(int id)
        {
            MySqlDataReader rdr = null;
            string sqlCliente = "SELECT * FROM `cliente` WHERE id =" + id;
            DataTable ReturClientes = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                rdr = objcomand.ExecuteReader();
                //define o total de registros como zero
                //int nuReg = 0;
                //percorre o leitor 
                while (rdr.Read())
                {
                    cliente.Id = Convert.ToInt32(id);
                    cliente.Nome = rdr["nome"].ToString();
                    cliente.Sexo = rdr["sexo"].ToString();
                    cliente.Rg = rdr["rg"].ToString();
                    cliente.Cpf = rdr["cpf"].ToString();
                    cliente.Data_nasc = rdr["data_nasc"].ToString();
                    cliente.Status = rdr["status"].ToString();
                    cliente.Contato = contatoDb.consultaPorId(Convert.ToInt32(rdr["id_contato"]));
                    cliente.Endereco = enderecoDb.consultaPorId(Convert.ToInt32(rdr["id_endereco"]));
                }
                return cliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return cliente;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorCpf(string cpf)
        {
            string sqlCliente = "SELECT * FROM `cliente` WHERE `cpf`= '"+cpf+"'";
            DataTable dtClientes = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtClientes);
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
            if (dtClientes.Rows.Count == 0)
            {
                return dtClientes;
            }
            else
            {
                return dtClientes;
            }
        }

        public bool cpfJaCadastrado(string cpf)
        {
            bool existeCpf;
            DataTable dtcpf = new DataTable();
            dtcpf = consultaPorCpf(cpf);
            if (dtcpf.Rows.Count > 0)
            {
                existeCpf = true;
            }
            else
            {
                existeCpf = false;

            }
            return existeCpf;
        }

        public DataTable consultaPorCnpj(string cnpj)
        {
            string sqlCliente = "SELECT * FROM `cliente` WHERE `cpf`= '" + cnpj + "'";
            DataTable dtClientes = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtClientes);
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
            if (dtClientes.Rows.Count == 0)
            {
                return dtClientes;
            }
            else
            {
                return dtClientes;
            }
        }

        public bool cnpjJaCadastrado(string cnpj)
        {
            bool existeCpf;
            DataTable dtcpf = new DataTable();
            dtcpf = consultaPorCpf(cnpj);
            if (dtcpf.Rows.Count > 0)
            {
                existeCpf = true;
            }
            else
            {
                existeCpf = false;

            }
            return existeCpf;
        }



    }
}
