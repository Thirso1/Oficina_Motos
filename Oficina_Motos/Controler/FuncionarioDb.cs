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
    public class FuncionarioDb
    {
        DataTable dtFuncionario = new DataTable();

        public int geraCodFuncionario()
        {
            string sqlCodFuncionario = "SELECT * FROM funcionario ORDER BY id DESC LIMIT 1";
            int numFunc = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcodFun = new MySqlCommand(sqlCodFuncionario, conn);
                numFunc = Convert.ToInt32(objcodFun.ExecuteScalar());
                numFunc += 1;
                return numFunc;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return numFunc;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Funcionario funcionario)
        {
            string data;
            DateTime date = new DateTime();
            if (funcionario.Data_nasc == "  /  /")
            {
                data = DateTime.Today.ToString("yyyy-MM-dd");
            }
            else
            {

                date = Convert.ToDateTime(funcionario.Data_nasc);
                data = date.ToString("yyyy-MM-dd");
            }

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `funcionario` (`id`, `nome`, `sexo`, `rg`, `cpf`, `data_nasc`, `status`, `id_contato`, `id_endereco`) values(?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@nm_id", MySqlDbType.Int32, 11).Value = funcionario.Id;
                objcmd.Parameters.Add("@nm_nome", MySqlDbType.VarChar, 100).Value = funcionario.Nome;
                objcmd.Parameters.Add("@nm_sexo", MySqlDbType.VarChar, 50).Value = funcionario.Sexo;
                objcmd.Parameters.Add("@nm_rg", MySqlDbType.VarChar, 20).Value = funcionario.Rg;
                objcmd.Parameters.Add("@nm_cpf", MySqlDbType.VarChar, 20).Value = funcionario.Cpf;
                objcmd.Parameters.Add("@nm_data_nasc", MySqlDbType.Date).Value = data;
                objcmd.Parameters.Add("@nm_status", MySqlDbType.VarChar, 50).Value = funcionario.Status;
                objcmd.Parameters.Add("@nm_contato", MySqlDbType.Int32, 11).Value = funcionario.Id_contato;
                objcmd.Parameters.Add("@nm_endereco", MySqlDbType.Int32, 11).Value = funcionario.Id_endereco;


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

        public void atualiza(Funcionario funcionario)
        {
            string data;
            DateTime date = new DateTime();
            if (funcionario.Data_nasc == "  /  /")
            {
                data = DateTime.Today.ToString("yyyy-MM-dd");
            }
            else
            {

                date = Convert.ToDateTime(funcionario.Data_nasc);
                data = date.ToString("yyyy-MM-dd");
            }
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `funcionario` SET nome=@_nome, sexo=@_sexo, rg=@_rg, cpf = @_cpf, data_nasc=@_data_nasc, id_contato=@_contato, id_endereco=@_endereco, status=@_status WHERE id =" + funcionario.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@_nome", MySqlDbType.VarChar, 100).Value = funcionario.Nome;
            objcmd.Parameters.Add("@_sexo", MySqlDbType.VarChar, 50).Value = funcionario.Sexo;
            objcmd.Parameters.Add("@_rg", MySqlDbType.VarChar, 20).Value = funcionario.Rg;
            objcmd.Parameters.Add("@_cpf", MySqlDbType.VarChar, 14).Value = funcionario.Cpf;
            objcmd.Parameters.Add("@_data_nasc", MySqlDbType.Date, 20).Value = data;
            objcmd.Parameters.Add("@_contato", MySqlDbType.Int32, 11).Value = funcionario.Id_contato;
            objcmd.Parameters.Add("@_endereco", MySqlDbType.Int32, 11).Value = funcionario.Id_endereco;
            objcmd.Parameters.Add("@_status", MySqlDbType.VarChar, 20).Value = funcionario.Status;

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

        public DataTable consultaTodos()
        {
            string sqlUsuario = "SELECT * FROM `funcionario`";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFuncionario);
                return dtFuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtFuncionario;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaPorId(string id)
        {
            string sqlCliente = "SELECT * FROM `funcionario` WHERE id =" + id;
            DataTable ReturClientes = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(ReturClientes);
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
            if (ReturClientes.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Registro!");
                return ReturClientes;
            }
            else
            {
                return ReturClientes;
            }
        }

        public DataTable consultaPorNome(string nome)
        {
            string sqlUsuario = "SELECT * FROM `funcionario` WHERE `nome` LIKE '%" + nome + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFuncionario);
                return dtFuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtFuncionario;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable funcionariosAtivos()
        {
            string sqlUsuario = "SELECT * FROM `funcionariosativos`";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFuncionario);
                return dtFuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtFuncionario;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaPorCpf(string cpf)
        {
            string sqlFuncionario = "SELECT * FROM `funcionario` WHERE `cpf`= '" + cpf + "'";
            DataTable dtFuncionarios = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlFuncionario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFuncionarios);
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
            if (dtFuncionarios.Rows.Count == 0)
            {
                return dtFuncionarios;
            }
            else
            {
                return dtFuncionarios;
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
    }
}
