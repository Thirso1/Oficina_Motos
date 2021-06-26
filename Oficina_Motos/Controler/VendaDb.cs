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
    class VendaDb
    {
        string data = DateTime.Today.ToString("yyyy-MM-dd");
        int numVenda = 0;
        DataTable dtVenda = new DataTable();

        public int geraNumVenda()
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM venda ORDER BY id DESC LIMIT 1";
                MySqlCommand objMeio = new MySqlCommand(sql_num, conn);
                numVenda = Convert.ToInt32(objMeio.ExecuteScalar());
                numVenda += 1;
                return numVenda;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return numVenda;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Venda venda)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `venda`(`id`, `valor`, `data_hora`, `desconto`, `status`, `id_usuario`, `id_cliente`) values(?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = venda.Id;
                objcmd.Parameters.Add("@valor", MySqlDbType.Decimal, 8).Value = venda.Valor_total;
                objcmd.Parameters.Add("@data_hora", MySqlDbType.DateTime).Value = venda.Data_hora;
                objcmd.Parameters.Add("@desconto", MySqlDbType.Decimal, 8).Value = venda.Desconto;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = venda.Status;
                objcmd.Parameters.Add("@id_usuario", MySqlDbType.Int32, 11).Value = venda.Id_usuario;
                objcmd.Parameters.Add("@id_cliente", MySqlDbType.Int32, 11).Value = venda.Id_cliente;


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

        public void atualiza(Venda venda)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "UPDATE `venda` SET `valor`=@valor,`desconto`=@desconto,`status`=@status,`id_usuario`=@id_usuario,`id_cliente`=@id_cliente WHERE `id` = " + venda.Id;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@valor", MySqlDbType.Decimal, 8).Value = venda.Valor_total;
                objcmd.Parameters.Add("@desconto", MySqlDbType.Decimal, 8).Value = venda.Desconto;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = venda.Status;
                objcmd.Parameters.Add("@id_usuario", MySqlDbType.Int32, 11).Value = venda.Id_usuario;
                objcmd.Parameters.Add("@id_cliente", MySqlDbType.Int32, 11).Value = venda.Id_cliente;

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

        public void delete(Venda venda)
        {

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "DELETE FROM venda WHERE `id` = " + venda.Id;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
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

        public DataTable consultaPorId(int id)
        {
            string sql = "SELECT * FROM `consultavendas` WHERE id =" + id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtVenda);
                if(dtVenda.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhuma Venda!");
                }
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
            if (dtVenda.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Registro!");
                return dtVenda;
            }
            else
            {
                return dtVenda;
            }
        }

        public Venda constroiVenda(int id_venda)
        {
            Venda venda = new Venda();
            DataTable dtVenda = new DataTable();
            dtVenda = consultaPorId(id_venda);

            venda.Id = id_venda;
            venda.Valor_total = Convert.ToDecimal(dtVenda.Rows[0][2]);
            venda.Data_hora = dtVenda.Rows[0][0].ToString();
            venda.Desconto = 0;
            venda.Status = dtVenda.Rows[0][6].ToString();
            venda.Id_usuario = Convert.ToInt32(dtVenda.Rows[0][6]);
            venda.Id_cliente = Convert.ToInt32(dtVenda.Rows[0][7]);

            return venda;
        }

        public DataTable consultaSuspensas()
        {
            string sql = "SELECT * FROM `vendassuspensas`" ;
            DataTable venda = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(venda);
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
            if (venda.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Registro!");
                return venda;
            }
            else
            {
                return venda;
            }
        }

        public decimal valorPorStatus(string status)
        {
            decimal valor;
            try
            {

                //AND data_hora > '"+data+" 00:00:00'
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT SUM(valor) FROM venda WHERE status = '" + status + "'";

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
                string sql_num = "SELECT SUM(valor) FROM venda WHERE status = '" + status + "' AND data_hora > '" + data + " 00:00:00'";

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
                string sql_num = "SELECT COUNT(id) FROM `venda` WHERE `status` = '" + status + "'";

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
                string sql_num = "SELECT COUNT(id) FROM `venda` WHERE `status` = '" + status + "' AND data_hora > '" + data + " 00:00:00'";

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

        public DataTable consultaPorData(string dataIni, string dataFim)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_datas = "SELECT * FROM consultavendas WHERE `data` >= '" + dataIni + " 00:00:00' AND `data` <= '" + dataFim + " 23:59:59'";

                MySqlCommand objorc = new MySqlCommand(sql_datas, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtVenda);
                if (dtVenda.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhuma Venda!");
                }
                return dtVenda;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtVenda;
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
                string sql_num = "SELECT * FROM consultavendas WHERE id_cliente = " + id_cliente;
                MySqlCommand objorc = new MySqlCommand(sql_num, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objorc);
                objadp.Fill(dtVenda);
                if (dtVenda.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhuma Venda!");
                }
                return dtVenda;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtVenda;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaPorCpf(string cpf)
        {
            string sqlCliente = "SELECT * FROM `consultavendas` WHERE cpf = '" + cpf + "'";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtVenda);
                if (dtVenda.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhuma Venda!");
                }
                return dtVenda;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtVenda;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaStatus(string status)
        {
            string sql = "SELECT * FROM `consultavendas` WHERE `status` = '" + status + "'";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtVenda);
                //MessageBox.Show( veiculos.Rows[0][0].ToString());              

                return dtVenda;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtVenda;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

    public DataTable consultaStatusHoje(string status)
    {
        string sql = "SELECT * FROM `consultavendas` WHERE `status` = '" + status + "' AND data > '" + data + " 00:00:00'";

            try
        {
            MySqlConnection conn = Conect.obterConexao();
            MySqlCommand objcomand = new MySqlCommand(sql, conn);
            MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
            objadp.Fill(dtVenda);
            //MessageBox.Show( veiculos.Rows[0][0].ToString());              

            return dtVenda;
        }
        catch (Exception erro)
        {
            MessageBox.Show(erro.ToString());
            return dtVenda;
        }
        finally
        {
            Conect.fecharConexao();
        }
    }

        public void atualizaCliente(int venda, int id_cliente)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "UPDATE `venda` SET `id_cliente`=@id_cliente WHERE `id` = " + venda;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);

                objcmd.Parameters.Add("@id_cliente", MySqlDbType.Int32, 11).Value = id_cliente;

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

    }
}