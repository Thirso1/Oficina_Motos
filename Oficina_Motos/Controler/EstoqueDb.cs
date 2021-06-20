using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Model;
using Oficina_Motos.View;

namespace Oficina_Motos.Controler
{
    class EstoqueDb
    {
        public int geraCodEstoque()
        {
            string sqlCod = "SELECT * FROM estoque ORDER BY id DESC LIMIT 1";
            int cod = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcodClie = new MySqlCommand(sqlCod, conn);
                cod = Convert.ToInt32(objcodClie.ExecuteScalar());
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

        public void insere(Estoque estoque)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `estoque` (`id`, `unid_venda`, `estoque_min`, `estoque_max`, `estoque_atual`, `localizacao`,`id_produto`) values(?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = estoque.Id;
                objcmd.Parameters.Add("@unid_venda", MySqlDbType.VarChar, 30).Value = estoque.Unid_venda;
                objcmd.Parameters.Add("@estoque_min", MySqlDbType.Int32, 11).Value = estoque.Estoque_min;
                objcmd.Parameters.Add("@estoque_max", MySqlDbType.Int32, 11).Value = estoque.Estoque_max;
                objcmd.Parameters.Add("@estoque_atual", MySqlDbType.Int32, 11).Value = estoque.Estoque_atual;
                objcmd.Parameters.Add("@localizacao", MySqlDbType.VarChar, 30).Value = estoque.Localizacao;
                objcmd.Parameters.Add("@id_produto", MySqlDbType.Int32, 11).Value = estoque.Id_produto;

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

        public Estoque consultaPorId(int id_produto)
        {
            Estoque estoque = new Estoque();
            string sql = "SELECT * FROM `estoque` WHERE id_produto =" + id_produto;
            DataTable dtEstoque = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtEstoque);
                if (dtEstoque.Rows.Count > 0)
                {
                    estoque.Id = Convert.ToInt32(dtEstoque.Rows[0][0]);
                estoque.Unid_venda = dtEstoque.Rows[0][1].ToString();
               estoque.Estoque_min = Convert.ToInt32(dtEstoque.Rows[0][2]);
                estoque.Estoque_max = Convert.ToInt32(dtEstoque.Rows[0][3]);
                estoque.Estoque_atual = Convert.ToInt32(dtEstoque.Rows[0][4]);
                estoque.Localizacao = dtEstoque.Rows[0][5].ToString();
                return estoque;
                }
                else
                {
                    estoque.Id = 0;
                return estoque;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return estoque;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void atualiza(Estoque estoque)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "UPDATE `estoque` SET `unid_venda`=@unid_venda,`estoque_min`=@estoque_min,`estoque_max`=@estoque_max,`estoque_atual`=@estoque_atual,`localizacao`=@localizacao WHERE `id` = " + estoque.Id;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@unid_venda", MySqlDbType.VarChar, 20).Value = estoque.Unid_venda;
                objcmd.Parameters.Add("@estoque_min", MySqlDbType.Int32, 11).Value = estoque.Estoque_min;
                objcmd.Parameters.Add("@estoque_max", MySqlDbType.Int32, 11).Value = estoque.Estoque_max;
                objcmd.Parameters.Add("@estoque_atual", MySqlDbType.Int32, 11).Value = estoque.Estoque_atual;
                objcmd.Parameters.Add("@localizacao", MySqlDbType.VarChar, 30).Value = estoque.Localizacao;

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

        public void debita_credita_Qtde(int id_produto, int qtde)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "UPDATE `estoque` SET `estoque_atual`= `estoque_atual` + "+qtde+" WHERE `id_produto` = " + id_produto;
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

        public DataTable consultaEstoqueZerado()
        {
            string sqlItens = "SELECT * FROM `estoquezerado`";

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

        public DataTable consultaEstoqueBaixo()
        {
            string sqlItens = "SELECT * FROM `estoquebaixo`";

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

        public void atualizaPedidoEmAndamento(int id_produto, bool v)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sql = "UPDATE `estoque` SET `pedido_em_andamento`= " + v + " WHERE `id_produto` = " + id_produto;
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

        public int contaItensZeradoBaixo(string status)
        {
            int valor;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //
                string sql_num = "SELECT COUNT(id) FROM "+ status;

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
