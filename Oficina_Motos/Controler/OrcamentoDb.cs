using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Model;

namespace Oficina_Motos.Controler
{
    class OrcamentoDb
    {
        string data = DateTime.Today.ToString("yyyy-MM-dd");
        string sql_status;

        public int geraNumOrcamento()
        {
            int numOrcamento = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM orcamento ORDER BY id DESC LIMIT 1";
                MySqlCommand objMeio = new MySqlCommand(sql_num, conn);
                numOrcamento = Convert.ToInt32(objMeio.ExecuteScalar());
                numOrcamento += 1;
                return numOrcamento;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return numOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Orcamento orcamento)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `orcamento`(`id`, `valor`, `data`, `hora`, `status`, `id_usuario`, `id_cliente`, `id_veiculo`) values(?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = orcamento.Id;
                objcmd.Parameters.Add("@valor", MySqlDbType.Decimal, 8).Value = orcamento.Valor;
                objcmd.Parameters.Add("@data", MySqlDbType.Date).Value = orcamento.Data;
                objcmd.Parameters.Add("@hora", MySqlDbType.Time).Value = orcamento.Hora;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = orcamento.Status;
                objcmd.Parameters.Add("@id_usuario", MySqlDbType.Int32, 11).Value = orcamento.Id_usuario;
                objcmd.Parameters.Add("@id_cliente", MySqlDbType.Int32, 11).Value = orcamento.Id_cliente;
                objcmd.Parameters.Add("@id_veiculo", MySqlDbType.Int32, 11).Value = orcamento.Id_veiculo;

                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Orcamento salvo com sucesso!");
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

        public void atualiza(Orcamento orcamento)
        {

            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `orcamento` SET valor=@valor, status=@status, id_usuario=@id_usuario, id_cliente = @id_cliente, id_veiculo=@id_veiculo WHERE id =" + orcamento.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@valor", MySqlDbType.Decimal, 8).Value = orcamento.Valor;
            objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 50).Value = orcamento.Status;
            objcmd.Parameters.Add("@id_usuario", MySqlDbType.Int32, 11).Value = orcamento.Id_usuario;
            objcmd.Parameters.Add("@id_cliente", MySqlDbType.Int32, 11).Value = orcamento.Id_cliente;
            objcmd.Parameters.Add("@id_veiculo", MySqlDbType.Int32, 11).Value = orcamento.Id_veiculo;

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

        public Orcamento constroiOrcamento(int id)
        {
            Orcamento orcamento = new Orcamento();
            DataTable dtOrcamento = new DataTable();
            dtOrcamento = consultaPorId(id.ToString());

            orcamento.Id = Convert.ToInt32(dtOrcamento.Rows[0][0]);
            orcamento.Valor = Convert.ToDecimal(dtOrcamento.Rows[0][1]);
            orcamento.Data = dtOrcamento.Rows[0][2].ToString();
            orcamento.Hora = TimeSpan.Parse(dtOrcamento.Rows[0][3].ToString());
            orcamento.Status = dtOrcamento.Rows[0][4].ToString();
            orcamento.Id_usuario = Convert.ToInt32(dtOrcamento.Rows[0][5]);
            orcamento.Id_cliente = Convert.ToInt32(dtOrcamento.Rows[0][6]);
            orcamento.Id_veiculo = Convert.ToInt32(dtOrcamento.Rows[0][7]);

            return orcamento;
        }

        public void atualizaStatus(int id_orcamento, string status)
        {

            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `orcamento` SET `status`= '"+ status +"' WHERE `id`= " + id_orcamento;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);

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


        public DataTable consultaPorId(string num)
        {
            DataTable dtOrcamento = new DataTable();

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM orcamento WHERE id = " + num;
                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrcamento);
                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorNumero(string num)
        {
            DataTable dtOrcamento = new DataTable();

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM consultaorcamentos WHERE id = " + num;
                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrcamento);
                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorCliente(string id_cliente)
        {
            DataTable dtOrcamento = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM consultaorcamentos WHERE id_cliente = '" + id_cliente +"'";
                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrcamento);
                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }


        public void delete(string num)
        {
            string sqlDeleta = "DELETE FROM `orcamento` WHERE id =" + num;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //executa a romoção
                MySqlCommand objcomand = new MySqlCommand(sqlDeleta, conn);
                objcomand.ExecuteNonQuery();
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

        public DataTable consultaPorCpf(string cpf)
        {
            DataTable dtOrcamento = new DataTable();

            string sqlCliente = "SELECT * FROM `consultaorcamentos` WHERE cpf = '" + cpf + "'";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtOrcamento);
                //MessageBox.Show( veiculos.Rows[0][0].ToString());              

                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorPlaca(string placa)
        {
            DataTable dtOrcamento = new DataTable();

            string sqlVeiculo = "SELECT * FROM `consultaorcamentos` WHERE placa LIKE '%" + placa + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlVeiculo, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtOrcamento);

                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorVeiculo(string veiculo)
        {
            DataTable dtOrcamento = new DataTable();

            string sqlVeiculo = "SELECT * FROM `consultaorcamentos` WHERE descricao LIKE '%" + veiculo + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlVeiculo, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtOrcamento);
                //MessageBox.Show( veiculos.Rows[0][0].ToString());

                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaPorData(DateTime dataIni, DateTime dataFim)
        {
            DataTable dtOrcamento = new DataTable();

            string inicial = dataIni.ToString("yyyy-MM-dd");
            string final = dataFim.ToString("yyyy-MM-dd");

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_datas = "SELECT * FROM consultaorcamentos WHERE data >='" + inicial + "' AND `data` <= '" + final + "'";

                MySqlCommand objorc = new MySqlCommand(sql_datas, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrcamento);
                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        //public DataTable emAnalise()
        //{

        //}

        //public DataTable concluido()
        //{

        //}

        public DataTable analiseAndConcluido()
        {
            DataTable dtOrcamento = new DataTable();

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_datas = "SELECT * FROM agendaorcamento_2";
                MySqlCommand objorc = new MySqlCommand(sql_datas, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrcamento);
                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consulta(string status)
        {
            DataTable dtOrcamento = new DataTable();

            switch (status)
            {
                case "Suspenso":
                case "Em Análise":
                case "Concluído":
                     sql_status = "SELECT * FROM consultaorcamentos WHERE status = '" + status + "'";
                    break;
                case "Cancelado":
                case "Aprovado":
                    sql_status = "SELECT * FROM consultaorcamentos WHERE status = '" + status + "' AND data >= '" + data + "'";
                    break;
            }
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objorc = new MySqlCommand(sql_status, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtOrcamento);
                return dtOrcamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtOrcamento;
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
                string sql_num = "SELECT SUM(valor) FROM consultaorcamentos WHERE status = '" + status + "'";
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
                string sql_num = "SELECT SUM(valor) FROM consultaorcamentos WHERE status = '" + status + "' AND data >= '" + data + "'";

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
                string sql_num = "SELECT COUNT(id) FROM `consultaorcamentos` WHERE `status` = '" + status + "'";

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
                string sql_num = "SELECT COUNT(id) FROM `consultaorcamentos` WHERE `status` = '" + status + "' AND data >= '" + data + "'";

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
    }
}