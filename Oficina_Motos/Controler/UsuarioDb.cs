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
    class UsuarioDb
    {
        Usuario usuario = new Usuario();

        public int geraCodUsuario()
        {
            string sqlCodUsuario = "SELECT * FROM usuario ORDER BY id DESC LIMIT 1";
            int numCliente = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcodClie = new MySqlCommand(sqlCodUsuario, conn);
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

        public void insere(Usuario usuario)
        {

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `usuario` (`login`, `senha`, `id_funcionario`, `perfil`, `status`) values(?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@login", MySqlDbType.VarChar, 100).Value = usuario.Login;
                objcmd.Parameters.Add("@senha", MySqlDbType.VarChar, 50).Value = usuario.Senha;
                objcmd.Parameters.Add("@id_funcionario", MySqlDbType.Int32, 11).Value = usuario.Id_funcionario;
                objcmd.Parameters.Add("@perfil", MySqlDbType.VarChar, 20).Value = usuario.Perfil;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = usuario.Status;

                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Usuário cadastrado com sucesso!");

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

        public void atualiza(Usuario usuario)
        {
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `usuario` SET login=@login, senha = @senha, perfil=@perfil, status=@status WHERE id =" + usuario.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@login", MySqlDbType.VarChar, 100).Value = usuario.Login;
            objcmd.Parameters.Add("@senha", MySqlDbType.VarChar, 50).Value = usuario.Senha;
            objcmd.Parameters.Add("@perfil", MySqlDbType.VarChar, 20).Value = usuario.Perfil;
            objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = usuario.Status;

            try
            {
                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Usuário atualizado.");
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

        public void delete(int id)
        {
            string sqlDeleta = "DELETE FROM `usuario` WHERE id_funcionario =" + id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //executa a romoção
                MySqlCommand objcomand = new MySqlCommand(sqlDeleta, conn);
                objcomand.ExecuteNonQuery();
                MessageBox.Show("Usuário Excluído");
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.ToString());
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public Usuario consultaPorNome(string nome)
        {
            DataTable dtUsuario = new DataTable();
            string sqlUsuario = "SELECT * FROM `usuario` WHERE `login` = '"+nome+"'" ;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtUsuario);

                if (dtUsuario.Rows.Count > 0)
                {
                    usuario = constroi_usuario(dtUsuario);
                    return usuario;
                }
                else
                {
                    MessageBox.Show("Usuario não encontrado");
                    return usuario;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return usuario;
            }
            finally
            {
                Conect.fecharConexao();
            }            
        }

        public DataTable consultaNomeUsuario(string nome)
        {
            DataTable dtUsuario = new DataTable();
            string sqlUsuario = "SELECT `login` FROM `usuario` WHERE `login` = '" + nome + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtUsuario);
                return dtUsuario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtUsuario;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaLikeUsuario(string nome)
        {
            DataTable dtUsuario = new DataTable();
            string sqlUsuario = "SELECT `login` FROM `usuario` WHERE `login` LIKE '" + nome + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtUsuario);
                return dtUsuario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtUsuario;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }
        public DataTable consultaTodos()
        {
            DataTable dtUsuario = new DataTable();
            string sqlUsuario = "SELECT * FROM `usuarios`";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtUsuario);
                return dtUsuario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtUsuario;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }


        public Usuario consultaPorID(int id)
        {
            DataTable dtUsuario = new DataTable();
            string sqlUsuario = "SELECT * FROM `usuario` WHERE `id` = '" + id + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtUsuario);

                if (dtUsuario.Rows.Count > 0)
                {
                    usuario = constroi_usuario(dtUsuario);
                    return usuario;
                }
                else
                {
                    MessageBox.Show("Usuario não encontrado");
                    return usuario;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return usuario;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public string retornaLoginPorID(int id)
        {
            string login;
            string sqlUsuario = "SELECT `login` FROM `usuario` WHERE `id` = '" + id + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                login = objcomand.ExecuteScalar().ToString();

                return login;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return "";
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaIdFuncionario(int id)
        {
            DataTable dtUsuario = new DataTable();
            string sqlUsuario = "SELECT * FROM `usuarios` WHERE `id_funcionario` = '" + id + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlUsuario, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtUsuario);
                return dtUsuario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtUsuario;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public Usuario constroi_usuario(DataTable dtUsuario)
        {
            usuario.Id = Convert.ToInt32(dtUsuario.Rows[0]["id"]);
            usuario.Login = dtUsuario.Rows[0]["login"].ToString();
            usuario.Senha = dtUsuario.Rows[0]["senha"].ToString();
            usuario.Status = dtUsuario.Rows[0]["status"].ToString();
            usuario.Id_funcionario = Convert.ToInt32(dtUsuario.Rows[0]["id_funcionario"]);
            usuario.Perfil = dtUsuario.Rows[0]["perfil"].ToString();
            return usuario;
        }
    }
}

//
