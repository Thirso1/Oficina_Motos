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
    class Ordem_ServicoDb
    {
        DataTable dtOrdem_servico = new DataTable();
        Ordem_Servico ordem_servico = new Ordem_Servico();
        string data_hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string data = DateTime.Today.ToString("yyyy-MM-dd");

        public void insere(Ordem_Servico os)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `ordem_servico` (`id`, `valor`, `status`,`id_cliente`,`id_veiculo`, `id_usuario`) values(?, ?, ?, ?, ?, ?)", conn);


                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = os.Id;
                //objcmd.Parameters.Add("@data_hora_fim", MySqlDbType.DateTime).Value = os.Data_hora_fim;
                objcmd.Parameters.Add("@valor", MySqlDbType.Decimal, 8).Value = os.Valor;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = os.Status;
                objcmd.Parameters.Add("@id_cliente", MySqlDbType.Int32, 11).Value = os.Id_cliente;
                objcmd.Parameters.Add("@id_veiculo", MySqlDbType.Int32, 11).Value = os.Id_veiculo;
                objcmd.Parameters.Add("@id_usuario", MySqlDbType.Int32, 11).Value = os.Id_usuario;


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

        public void atualiza(Ordem_Servico os)
        {
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `ordem_servico` SET data_hora_fim = @data_hora_fim, status = @status  WHERE id = '" + os.Id+"'";
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@data_hora_fim", MySqlDbType.DateTime).Value = data_hora;
            objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = os.Status;

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

        public DataTable consultaPorId(int id)
        {
            string sql = "SELECT * FROM `ordem_servico` WHERE id =" + id;
            DataTable dtOs = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtOs);
                return dtOs;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOs;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public bool existe_os(int id)
        {
            DataTable dtOs = new DataTable();
            dtOs = consultaPorId(id);

            if(dtOs.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Ordem_Servico constroiOs(int id)
        {
            dtOrdem_servico = consultaPorId(id);
            ordem_servico.Id = Convert.ToInt32(dtOrdem_servico.Rows[0][0]);
            ordem_servico.Data_hora_inicio = dtOrdem_servico.Rows[0][1].ToString();
            ordem_servico.Data_hora_fim = dtOrdem_servico.Rows[0][2].ToString();
            ordem_servico.Valor = Convert.ToDecimal(dtOrdem_servico.Rows[0][3]);
            ordem_servico.Status = dtOrdem_servico.Rows[0][4].ToString();
            ordem_servico.Id_cliente = Convert.ToInt32(dtOrdem_servico.Rows[0][5]);
            ordem_servico.Id_veiculo = Convert.ToInt32(dtOrdem_servico.Rows[0][6]);
            ordem_servico.Id_usuario = Convert.ToInt32(dtOrdem_servico.Rows[0][7]);
            return ordem_servico;
        }

        public DataTable consultaPorData(string dataIni, string dataFim)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_datas = "SELECT * FROM consultaordemservico WHERE `data` > '" + dataIni + " 00:00:00' AND `data` < '" + dataFim + " 23:59:59' ORDER BY id ASC";
                MySqlCommand objorc = new MySqlCommand(sql_datas, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrdem_servico);
                return dtOrdem_servico;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrdem_servico;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorCliente(int id_cliente)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM consultaordemservico WHERE id_cliente = " + id_cliente;

                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrdem_servico);
                return dtOrdem_servico;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrdem_servico;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorCpf(string cpf)
        {
            string sqlCliente = "SELECT * FROM `consultaordemservico` WHERE cpf = '" + cpf + "'";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtOrdem_servico);
                //MessageBox.Show( veiculos.Rows[0][0].ToString());              

                return dtOrdem_servico;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrdem_servico;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorNumero(string num)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM consultaordemservico WHERE id = " + num;
                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrdem_servico);
                return dtOrdem_servico;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrdem_servico;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorPlaca(string placa)
        {
            string sqlVeiculo = "SELECT * FROM `consultaordemservico` WHERE placa LIKE '%" + placa + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlVeiculo, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtOrdem_servico);

                return dtOrdem_servico;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrdem_servico;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorVeiculo(string veiculo)
        {
            string sqlVeiculo = "SELECT * FROM `consultaordemservico` WHERE descricao LIKE '%" + veiculo + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlVeiculo, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtOrdem_servico);
                //MessageBox.Show( veiculos.Rows[0][0].ToString());

                return dtOrdem_servico;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrdem_servico;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public decimal valorPorStatus(string status)
        {
            decimal valor;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT SUM(valor) FROM consultaordemservico WHERE status = '" + status + "'";
                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                if (objorc.ExecuteScalar() != DBNull.Value)
                {
                     valor = Convert.ToDecimal(objorc.ExecuteScalar());
                    return valor;
                }
                else
                {
                    return 0;
                }                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public decimal valorPorStatusData(string status)
        {
            decimal valor;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //SELECT COUNT(id) FROM `venda` WHERE `status` = 'Suspensa'
                string sql_num = "SELECT SUM(valor) FROM consultaordemservico WHERE status = '" + status + "' AND data > '" + data + " 00:00:00'";

                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                if (objorc.ExecuteScalar() != DBNull.Value)
                {
                    valor = Convert.ToDecimal(objorc.ExecuteScalar());
                    return valor;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public int contaRegistros(string status)
        {
            int valor;
            try
            {


                MySqlConnection conn = Conect.obterConexao();
                //
                string sql_num = "SELECT COUNT(id) FROM `consultaordemservico` WHERE `status` = '" + status + "'";

                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                if (objorc.ExecuteScalar() != DBNull.Value)
                {
                    valor = Convert.ToInt32(objorc.ExecuteScalar());
                    return valor;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public int contaRegistrosHoje(string status)
        {
            int valor;
            try
            {


                MySqlConnection conn = Conect.obterConexao();
                //
                string sql_num = "SELECT COUNT(id) FROM `ordem_servico` WHERE `status` = '" + status + "' AND `data_hora_fim` > '" + data + " 00:00:00'";

                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                if (objorc.ExecuteScalar() != DBNull.Value)
                {
                    valor = Convert.ToInt32(objorc.ExecuteScalar());
                    return valor;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return 0;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorStatus(string status)
        {
                string sql = "SELECT * FROM `consultaordemservico` WHERE status = '" + status + "'";
                try
                {
                    MySqlConnection conn = Conect.obterConexao();
                    MySqlCommand objcomand = new MySqlCommand(sql, conn);
                    MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                    objadp.Fill(dtOrdem_servico);
                    //MessageBox.Show( veiculos.Rows[0][0].ToString());

                    return dtOrdem_servico;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrdem_servico;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }
    }
}
