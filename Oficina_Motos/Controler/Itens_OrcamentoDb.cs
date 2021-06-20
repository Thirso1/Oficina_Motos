
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
    class Itens_OrcamentoDb
    {
        string sqlItens;
        ProdutoDb produtoDb = new ProdutoDb();
        EstoqueDb estoqueDb = new EstoqueDb();

        public void insere(Itens_Orcamento itens)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `itens_orcamento` (`id`, `id_orcamento`, `id_produto`, `id_servico`, `descricao`, `valor_uni`, `qtde`, `desconto`, `sub_total`) values(NULL, ?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id_orcamento", MySqlDbType.Int32, 11).Value = itens.Id_orcamento;
                objcmd.Parameters.Add("@id_produto", MySqlDbType.Int32, 11).Value = itens.Id_produto;
                objcmd.Parameters.Add("@id_servico", MySqlDbType.Int32, 11).Value = itens.Id_servico;
                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = itens.Descricao;
                objcmd.Parameters.Add("@valor_uni", MySqlDbType.Decimal, 8).Value = itens.Valor_uni;
                objcmd.Parameters.Add("@qtde", MySqlDbType.Int32, 11).Value = itens.Qtde;
                objcmd.Parameters.Add("@desconto", MySqlDbType.Decimal, 8).Value = itens.Desconto;
                objcmd.Parameters.Add("@sub_total", MySqlDbType.Decimal, 8).Value = itens.Sub_total;


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

        public DataTable consultaPorIdOrcamento(int id, string tipoConsulta)
        {
            if (tipoConsulta == "produto")
            {
               sqlItens = "SELECT * FROM `itens_orcamento` WHERE id_orcamento =" + id + " AND id_produto != 0";

            }
            else if(tipoConsulta == "servico")
            {
                sqlItens = "SELECT * FROM `itens_orcamento` WHERE id_orcamento =" + id + " AND id_servico != 0";
            }
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

        public DataTable consultaTodosItens(int id)
        {

            sqlItens = "SELECT * FROM `itens_orcamento_com_localizacao` WHERE id_orcamento =" + id;
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

        public void deleteTodos(int num)
        {
            DataTable itens = new DataTable();
            itens = consultaTodosItens(num);

            for (int i = 0; i < itens.Rows.Count; i++)
            {
                int qtde = Convert.ToInt32(itens.Rows[i][6]);
                int id_produto = Convert.ToInt32(itens.Rows[i][2]);
             
                //essa condição impede que estorne para o estoque itens de orçamento que sao "serviços"
                if(id_produto > 0)
                {
                    estoqueDb.debita_credita_Qtde(id_produto, qtde);
                }
            }

            string sqlDeleta = "DELETE FROM `itens_orcamento` WHERE id_orcamento =" + num;
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

        private void atualiza_estoque(int id_estoque, int qtde)
        {
        }

        public void delete(Itens_Orcamento itens)
        {
            string sqlDeleta = "DELETE FROM `itens_orcamento` WHERE id =" + itens.Id;
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

        public void atualiza(Itens_Orcamento itens)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string updateItens = "UPDATE `itens_orcamento` SET valor_uni=@valor_uni, qtde=@qtde, desconto=@desconto, sub_total = @sub_total WHERE id =" + itens.Id;

                //string sqlitens = "UPDATE `itens_orcamento` SET valor_uni=@valor_uni, qtde=@qtde, desconto=@desconto, sub_total=@sub_total WHERE id = " + itens.Id;
                MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
             
                objcmd.Parameters.Add("@valor_uni", MySqlDbType.Decimal, 8).Value = itens.Valor_uni;
                objcmd.Parameters.Add("@qtde", MySqlDbType.Int32, 11).Value = itens.Qtde;
                objcmd.Parameters.Add("@desconto", MySqlDbType.Decimal, 8).Value = itens.Desconto;
                objcmd.Parameters.Add("@sub_total", MySqlDbType.Decimal, 8).Value = itens.Sub_total;


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

        public decimal totalPecas(int id)
        {
            decimal total_pecas;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT SUM(`sub_total`) FROM `itens_orcamento` WHERE `id_orcamento` ='" + id + "' AND `id_produto` != '0'";

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

        public decimal totalServicos(int id)
        {
            decimal total_servicos;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT SUM(`sub_total`) FROM `itens_orcamento` WHERE `id_orcamento` ='" + id + "' AND `id_servico` != '0'";

                MySqlCommand obj = new MySqlCommand(sql, conn);
                if (obj.ExecuteScalar() != DBNull.Value)
                {
                    total_servicos = Convert.ToDecimal(obj.ExecuteScalar());
                    return total_servicos;
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

        public DataTable consultaServicosOrcamento(int id)
        {
            sqlItens = "SELECT * FROM `itens_orcamento` WHERE id_orcamento ='" + id + "' AND id_produto = '0'";
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
    }
}
