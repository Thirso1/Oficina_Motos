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
    class ServicoDb
    {
        Servico servico = new Servico();
        public int geraCodProduto()
        {
            string sqlCod = "SELECT * FROM servico ORDER BY id DESC LIMIT 1";
            int num = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcodClie = new MySqlCommand(sqlCod, conn);
                num = Convert.ToInt32(objcodClie.ExecuteScalar());
                num += 1;
                return num;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return num;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Servico servico)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `servico`(`id`, `descricao`, `tempo_minutos`, `preco`, `desconto`, `imagem`, `id_categoria`, `id_fornecedor`) values(?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = servico.Id;
                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = servico.Descricao;
                objcmd.Parameters.Add("@tempo_minutos", MySqlDbType.Int32, 11).Value = servico.Tempo_minutos;
                objcmd.Parameters.Add("@preco", MySqlDbType.Decimal, 8).Value = servico.Preco;
                objcmd.Parameters.Add("@desconto", MySqlDbType.Decimal, 8).Value = servico.Desconto;
                objcmd.Parameters.Add("@imagem", MySqlDbType.VarChar, 100).Value = servico.Imagem;
                objcmd.Parameters.Add("@id_categoria", MySqlDbType.VarChar, 50).Value = servico.Id_categoria;
                objcmd.Parameters.Add("@id_fornecedor", MySqlDbType.VarChar, 20).Value = servico.Id_fornecedor;

                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Serviço cadastrado com sucesso.");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());// "Erro ao cadastrar Serviço");
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void atualiza(Servico servico)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela       
                string sql = "UPDATE `servico` SET `descricao`= @descricao, `tempo_minutos` = @tempo_minutos,`preco`= @preco,`desconto`=@desconto,`imagem`=@imagem,`id_categoria`=@id_categoria,`id_fornecedor`=@id_fornecedor WHERE id = " + servico.Id;
                MySqlCommand objcmd = new MySqlCommand(sql, conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = servico.Id;
                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = servico.Descricao;
                objcmd.Parameters.Add("@tempo_minutos", MySqlDbType.Int32, 11).Value = servico.Tempo_minutos;
                objcmd.Parameters.Add("@preco", MySqlDbType.Decimal, 8).Value = servico.Preco;
                objcmd.Parameters.Add("@desconto", MySqlDbType.Decimal, 8).Value = servico.Desconto;
                objcmd.Parameters.Add("@imagem", MySqlDbType.VarChar, 100).Value = servico.Imagem;
                objcmd.Parameters.Add("@id_categoria", MySqlDbType.VarChar, 50).Value = servico.Id_categoria;
                objcmd.Parameters.Add("@id_fornecedor", MySqlDbType.VarChar, 20).Value = servico.Id_fornecedor;

                //executa a inserção
                objcmd.ExecuteNonQuery();
                MessageBox.Show("Serviço atualizado com sucesso.");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());// "Erro ao atualizar Produto");
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaNome(string nome)
        {
            DataTable returServicos = new DataTable();
            string sqlServico = "SELECT * FROM `servico` WHERE descricao LIKE '%" + nome + "%'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlServico, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returServicos);
                return returServicos;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returServicos;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public Servico consultaPorId(int id)
        {
            DataTable returServicos = new DataTable();
            string sqlServico = "SELECT * FROM `servico` WHERE id = " + id;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlServico, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returServicos);
                servico.Id = id;
                servico.Descricao = returServicos.Rows[0][1].ToString();
                servico.Tempo_minutos = Convert.ToInt32(returServicos.Rows[0][2]);
                servico.Preco = Convert.ToDecimal(returServicos.Rows[0][3]);
                servico.Desconto = Convert.ToInt32(returServicos.Rows[0][4]);
                servico.Imagem = returServicos.Rows[0][5].ToString();
                servico.Id_categoria = Convert.ToInt32(returServicos.Rows[0][6]);
                servico.Id_fornecedor = Convert.ToInt32(returServicos.Rows[0][7]);

                return servico;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return servico;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

    }
}
