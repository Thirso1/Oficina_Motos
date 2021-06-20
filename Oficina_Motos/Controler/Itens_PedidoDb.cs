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
    class Itens_PedidoDb
    {
        public void insere(Itens_Pedido itens)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "INSERT INTO `itens_pedido` (`id`, `id_pedido`, `id_produto`, `descricao`, `aplicacao`,`valor_uni`, `qtde`, `total_item`) values(NULL, ?, ?, ?, ?, ?, ?, ?)";
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@id_pedido", MySqlDbType.Int32, 11).Value = itens.Id_pedido;
                objcmd.Parameters.Add("@id_produto", MySqlDbType.Int32, 11).Value = itens.Id_produto;

                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = itens.Descricao;
                objcmd.Parameters.Add("@aplicacao", MySqlDbType.VarChar, 100).Value = itens.Aplicacao;

                objcmd.Parameters.Add("@valor_uni", MySqlDbType.Decimal, 8).Value = itens.Valor_uni;
                objcmd.Parameters.Add("@qtde", MySqlDbType.Int32, 11).Value = itens.Qtde;

                objcmd.Parameters.Add("@total_item", MySqlDbType.Decimal, 8).Value = itens.Total_item;

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

        public DataTable consultaPorIdPedido(int id)
        {
            string sqlItens = "SELECT * FROM `itens_pedido` WHERE id_pedido =" + id;

            DataTable ReturItens = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlItens, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(ReturItens);
                return ReturItens;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return ReturItens;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void atualiza(Itens_Pedido itens)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string updateItens = "UPDATE `itens_pedido` SET valor_uni=@valor_uni, qtde=@qtde, total_item = @total_item WHERE id =" + itens.Id;

                //string sqlitens = "UPDATE `itens_orcamento` SET valor_uni=@valor_uni, qtde=@qtde, desconto=@desconto, sub_total=@sub_total WHERE id = " + itens.Id;
                MySqlCommand objcmd = new MySqlCommand(updateItens, conn);

                objcmd.Parameters.Add("@valor_uni", MySqlDbType.Decimal, 8).Value = itens.Valor_uni;
                objcmd.Parameters.Add("@qtde", MySqlDbType.Int32, 11).Value = itens.Qtde;
                objcmd.Parameters.Add("@total_item", MySqlDbType.Decimal, 8).Value = itens.Total_item;


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

        public void delete(Itens_Pedido itens)
        {
            string sqlDeleta = "DELETE FROM `itens_pedido` WHERE id =" + itens.Id;
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

        public void deleteTodos(int id_pedido)
        {
            string sqlDeleta = "DELETE FROM `itens_pedido` WHERE id_pedido =" + id_pedido;
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

        public decimal totalPecas(int id)
        {
            decimal total_pecas;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT SUM(`sub_total`) FROM `itens_venda` WHERE `id_venda` ='" + id + "'";

                MySqlCommand obj = new MySqlCommand(sql, conn);
                if (obj.ExecuteScalar() != DBNull.Value)
                {
                    total_pecas = Convert.ToDecimal(obj.ExecuteScalar());

                    return total_pecas;
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
