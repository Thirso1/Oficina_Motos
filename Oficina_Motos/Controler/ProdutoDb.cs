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
    class ProdutoDb
    {
        public int geraCodProduto()
        {
            string sqlCod = "SELECT * FROM produto ORDER BY id DESC LIMIT 1";
            int numProduto = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcodClie = new MySqlCommand(sqlCod, conn);
                numProduto = Convert.ToInt32(objcodClie.ExecuteScalar());
                numProduto += 1;
                return numProduto;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return numProduto;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaNome(string nome)
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM `produto` WHERE descricao LIKE '" + nome + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);
                return returProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable produtoGrid(string descricao)
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM `produtoparagrid` WHERE descricao LIKE '" + descricao + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);
                return returProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public Produto consultaPorId(int id)
        {
            //MessageBox.Show("produtoDb linha 91      ====      " + id.ToString());

            Produto produto = new Produto();
            DataTable dtProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM `produto` WHERE id = '"+id+"'";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtProdutos);

                if (dtProdutos.Rows.Count > 0)
                {
                    produto.Id = Convert.ToInt32(dtProdutos.Rows[0][0]);
                    produto.Cod_barras = dtProdutos.Rows[0][1].ToString();
                    produto.Descricao = dtProdutos.Rows[0][2].ToString();
                    produto.Marca = dtProdutos.Rows[0][3].ToString();
                    produto.Cod_marca = dtProdutos.Rows[0][4].ToString();
                    produto.Preco_custo = Convert.ToDecimal(dtProdutos.Rows[0][5]);
                    produto.Margem_lucro = Convert.ToDecimal(dtProdutos.Rows[0][6]);
                    produto.Preco_venda = Convert.ToDecimal(dtProdutos.Rows[0][7]);
                    produto.Desconto = Convert.ToDecimal(dtProdutos.Rows[0][8]);
                    produto.Imagem = dtProdutos.Rows[0][9].ToString();
                    produto.Id_categoria = Convert.ToInt32(dtProdutos.Rows[0][10]);
                    produto.Status = dtProdutos.Rows[0][11].ToString();

                    return produto;
                }
                else
                {
                    produto.Id = 0;
                    return produto;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return produto;
            }
            finally
            {
                Conect.fecharConexao();
            }           
        }

        public Produto consultaPorCodBarras(string cod_barras)
        {
            Produto produto = new Produto();
            DataTable dtProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM `produto` WHERE cod_barras = '" + cod_barras + "'";

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtProdutos);

                if(dtProdutos.Rows.Count > 0)
                {
                    produto.Id = Convert.ToInt32(dtProdutos.Rows[0][0]);
                    produto.Cod_barras = dtProdutos.Rows[0][1].ToString();
                    produto.Descricao = dtProdutos.Rows[0][2].ToString();
                    produto.Marca = dtProdutos.Rows[0][3].ToString();
                    produto.Cod_marca = dtProdutos.Rows[0][4].ToString();
                    produto.Preco_custo = Convert.ToDecimal(dtProdutos.Rows[0][5]);
                    produto.Margem_lucro = Convert.ToDecimal(dtProdutos.Rows[0][6]);
                    produto.Preco_venda = Convert.ToDecimal(dtProdutos.Rows[0][7]);
                    produto.Desconto = Convert.ToDecimal(dtProdutos.Rows[0][8]);
                    produto.Imagem = dtProdutos.Rows[0][9].ToString();
                    produto.Id_categoria = Convert.ToInt32(dtProdutos.Rows[0][10]);
                    produto.Status = dtProdutos.Rows[0][11].ToString();

                    return produto;
                }
                else
                {
                    produto.Id = 0;
                    return produto;
                }
               
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return produto;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Produto produto)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `produto`(`id`, `cod_barras`, `descricao`, `marca`, `cod_marca`, `preco_custo`,`margem_lucro`, `preco_venda`, `desconto`, `imagem`, `id_categoria`, `status`) values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = produto.Id;
                objcmd.Parameters.Add("@cod_barras", MySqlDbType.VarChar, 13).Value = produto.Cod_barras;
                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = produto.Descricao;
                objcmd.Parameters.Add("@marca", MySqlDbType.VarChar, 50).Value = produto.Marca;
                objcmd.Parameters.Add("@modelo", MySqlDbType.VarChar, 50).Value = produto.Cod_marca;
                objcmd.Parameters.Add("@preco_custo", MySqlDbType.Decimal,8).Value = produto.Preco_custo;
                objcmd.Parameters.Add("@margem_lucro", MySqlDbType.Decimal, 8).Value = produto.Margem_lucro;
                objcmd.Parameters.Add("@preco_venda", MySqlDbType.Decimal, 8).Value = produto.Preco_venda;
                objcmd.Parameters.Add("@desconto", MySqlDbType.Decimal, 8).Value = produto.Desconto;
                objcmd.Parameters.Add("@imagem", MySqlDbType.VarChar, 100).Value = produto.Imagem;
                objcmd.Parameters.Add("@id_categoria", MySqlDbType.VarChar, 50).Value = produto.Id_categoria;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = produto.Status;

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

        public void atualiza(Produto produto)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela       
                string sql = "UPDATE `produto` SET `cod_barras`= @cod_barras,`descricao`= @descricao,`marca`= @marca,`cod_marca`= @cod_marca,`preco_custo`= @preco_custo,`margem_lucro`= @margem_lucro,`preco_venda`=@preco_venda,`desconto`=@desconto,`imagem`=@imagem,`id_categoria`=@id_categoria,`status`=@status WHERE id = " + produto.Id;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@cod_barras", MySqlDbType.VarChar, 20).Value = produto.Cod_barras;
                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = produto.Descricao;
                objcmd.Parameters.Add("@marca", MySqlDbType.VarChar, 50).Value = produto.Marca;
                objcmd.Parameters.Add("@cod_marca", MySqlDbType.VarChar, 50).Value = produto.Cod_marca;
                objcmd.Parameters.Add("@preco_custo", MySqlDbType.Decimal, 8).Value = produto.Preco_custo;
                objcmd.Parameters.Add("@margem_lucro", MySqlDbType.Decimal, 8).Value = produto.Margem_lucro;
                objcmd.Parameters.Add("@preco_venda", MySqlDbType.Decimal, 8).Value = produto.Preco_venda;
                objcmd.Parameters.Add("@desconto", MySqlDbType.Decimal, 8).Value = produto.Desconto;
                objcmd.Parameters.Add("@imagem", MySqlDbType.VarChar, 100).Value = produto.Imagem;
                objcmd.Parameters.Add("@id_categoria", MySqlDbType.Int32, 11).Value = produto.Id_categoria;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = produto.Status;

                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Produto atualizado com sucesso.");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao atualizar Produto");
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void atualizaPreço(int id, decimal custo, decimal venda)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela       
                string sql = "UPDATE `produto` SET `preco_custo`= @preco_custo,`preco_venda`=@preco_venda WHERE id = " + id;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
               
                objcmd.Parameters.Add("@preco_custo", MySqlDbType.Decimal, 8).Value = custo;
                objcmd.Parameters.Add("@preco_venda", MySqlDbType.Decimal, 8).Value = venda;

                //executa a inserção
                objcmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao atualizar Produto");
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void delete(Produto produto)
        {
            string sqlDeleta = "DELETE FROM `produto` WHERE id = "+ produto.Id;
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

        public DataTable consultaRapidaDescricao(string descricao)
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM consultarapidaproduto WHERE `descricao` LIKE '" + descricao + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);
                return returProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaRapidaDescricaoMarca(string descricao, string marca)
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM consultarapidaproduto WHERE `descricao` LIKE '" + descricao + "%' AND `marca` LIKE '%" + marca + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);
                return returProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaRapidaPorId(string id)
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM consultarapidaproduto WHERE `id` = '" + id + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);
                return returProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaPdv(int id)
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM consultapdv WHERE `id` = '" + id + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);
                return returProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaParaPedido(string id)
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM produtoparapedido WHERE `id` = '" + id + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);
                return returProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public bool produto_em_Pedido(string id)
        {
            bool em_pedido;
            string sqlProduto = "SELECT `pedido_em_andamento` FROM produtoparapedido WHERE `id` = '" + id + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                em_pedido = Convert.ToBoolean( objcomand.ExecuteScalar());
   
                return em_pedido;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return false;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public DataTable consultaTodos()
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM consultapdv ORDER BY `consultapdv`.`id` ASC";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlProduto, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returProdutos);
                return returProdutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returProdutos;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }
    }
}
