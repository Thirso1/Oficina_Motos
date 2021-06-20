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
    class PedidoDb
    {
        string data = DateTime.Today.ToString("yyyy-MM-dd");
        int idPedido = 0;
        DataTable dtVenda = new DataTable();
        public int geraNumPedido()
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM pedido ORDER BY id DESC LIMIT 1";
                MySqlCommand objMeio = new MySqlCommand(sql_num, conn);
                idPedido = Convert.ToInt32(objMeio.ExecuteScalar());
                idPedido += 1;
                return idPedido;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return idPedido;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }



        public void insere(Pedido pedido)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `pedido`(`id`, `data`, `valor`, `status`, `id_usuario`, `id_fornecedor`) values(?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = pedido.Id;
                objcmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = pedido.Data;
                objcmd.Parameters.Add("@valor", MySqlDbType.Decimal, 8).Value = pedido.Valor;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 25).Value = pedido.Status;
                objcmd.Parameters.Add("@id_usuario", MySqlDbType.Int32, 11).Value = pedido.Id_usuario;
                objcmd.Parameters.Add("@id_fornecedor", MySqlDbType.Int32, 11).Value = pedido.Id_fornecedor;


                //executa a inserção
                objcmd.ExecuteNonQuery();
                Conect.fecharConexao();
                MessageBox.Show("Pedido salvo");
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

        public void atualiza(Pedido pedido)
        {
            string data_hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela       
                string sql = "UPDATE `pedido` SET `data`= @data,`valor`= @valor,`status`= @status,`id_usuario`= @id_usuario,`id_fornecedor`=@id_fornecedor WHERE id = " + pedido.Id;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = data_hora;
                objcmd.Parameters.Add("@valor", MySqlDbType.Decimal, 8).Value = pedido.Valor;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 25).Value = pedido.Status;
                objcmd.Parameters.Add("@id_usuario", MySqlDbType.Int32, 11).Value = pedido.Id_usuario;
                objcmd.Parameters.Add("@id_fornecedor", MySqlDbType.Int32, 11).Value = pedido.Id_fornecedor;

                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Pedido atualizado com sucesso.");
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

        public decimal consultaValorPorStatus(string status)
        {
            decimal valor;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT SUM(valor) FROM consultapedidos WHERE status = '" + status + "'";

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

        public DataTable consultaPorIdFornecedor(int id)
        {
            string sqlCliente = "SELECT * FROM `consultapedidos` WHERE id_fornecedor =" + id;
            DataTable ReturPedidos = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(ReturPedidos);
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
            return ReturPedidos;            
        }

        public DataTable consultaPorStatus(string status)
        {
            string sql = "SELECT * FROM `consultapedidos` WHERE status ='" + status +"'";

            DataTable ReturPedidos = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(ReturPedidos);
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
            return ReturPedidos;
        }

        public DataTable consultaPorId(int id)
        {
            string sqlCliente = "SELECT * FROM `consultapedidos` WHERE id =" + id;
            DataTable ReturPedidos = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(ReturPedidos);
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
            return ReturPedidos;
        }

        public Pedido constroiPedido(int id)
        {
            Pedido pedido = new Pedido();
            DataTable dtPedido = new DataTable();
            dtPedido = consultaPorId(id);
            pedido.Id = id;
            pedido.Data = dtPedido.Rows[0][0].ToString();
            pedido.Valor = Convert.ToDecimal(dtPedido.Rows[0][2]);
            pedido.Status = dtPedido.Rows[0][5].ToString();
            pedido.Id_usuario = Convert.ToInt32(dtPedido.Rows[0][7]);
            pedido.Id_fornecedor = Convert.ToInt32(dtPedido.Rows[0][8]);

            return pedido;

        }

        public DataTable consultaPorData(DateTime dataIni, DateTime dataFim)
        {
            DataTable ReturPedidos = new DataTable();

            string inicial = dataIni.ToString("yyyy-MM-dd");
            string final = dataFim.ToString("yyyy-MM-dd");

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_datas = "SELECT * FROM consultapedidos WHERE `data` >='" + inicial + "' AND `data` <= '" + final + "'";

                MySqlCommand objorc = new MySqlCommand(sql_datas, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(ReturPedidos);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return ReturPedidos;
            }
            finally
            {
                Conect.fecharConexao();
            }
            return ReturPedidos;
        }

        public DataTable consultaPorStatusData(string status, DateTime dataIni, DateTime dataFim)
        {
            DataTable ReturPedidos = new DataTable();

            string inicial = dataIni.ToString("yyyy-MM-dd");
            string final = dataFim.ToString("yyyy-MM-dd");

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_datas = "SELECT * FROM consultapedidos WHERE `data` >='" + inicial + "' AND `data` <= '" + final + "' AND `status` = '"+ status+"'";
                //MessageBox.Show(sql_datas);

                MySqlCommand objorc = new MySqlCommand(sql_datas, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(ReturPedidos);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return ReturPedidos;
            }
            finally
            {
                Conect.fecharConexao();
            }
            return ReturPedidos;
        }

        public DataTable consultaStatusFornecedor(string status, int id_fornecedor)
        {
            DataTable ReturPedidos = new DataTable();

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT * FROM consultapedidos WHERE id_fornecedor = '" + id_fornecedor + "' AND status = '" + status + "'";
                MySqlCommand objorc = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(ReturPedidos);
                return ReturPedidos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return ReturPedidos;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaTodosFornecedor(int id_fornecedor)
        {
            DataTable ReturPedidos = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT * FROM consultapedidos WHERE id_fornecedor = '" + id_fornecedor + "'";
                MySqlCommand objorc = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(ReturPedidos);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return ReturPedidos;
            }
            finally
            {
                Conect.fecharConexao();
            }
            return ReturPedidos;
        }

    }
}
