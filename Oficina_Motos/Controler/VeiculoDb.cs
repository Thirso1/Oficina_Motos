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
    class VeiculoDb
    {
        DataTable dtVeiculo = new DataTable();
        Veiculo veiculo = new Veiculo();
        public int geraNumVeiculo()
        {
            int id_veiculo = 0;
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM veiculo ORDER BY id DESC LIMIT 1";
                MySqlCommand objMeio = new MySqlCommand(sql_num, conn);
                id_veiculo = Convert.ToInt32(objMeio.ExecuteScalar());
                id_veiculo += 1;
                return id_veiculo;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return id_veiculo;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void insere(Veiculo veiculo)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                string sqlVeiculo = "INSERT INTO veiculo (`id`, `descricao`, `marca`, `modelo`, `ano`, `cor`, `placa`, `problema_informado`, `problema_verificado`,`observacao`,`km`) values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                MySqlCommand objcmd = new MySqlCommand(sqlVeiculo, conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = veiculo.Id;
                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 50).Value = veiculo.Descricao;
                objcmd.Parameters.Add("@marca", MySqlDbType.VarChar, 50).Value = veiculo.Marca;
                objcmd.Parameters.Add("@modelo", MySqlDbType.VarChar, 20).Value = veiculo.Modelo;
                objcmd.Parameters.Add("@ano", MySqlDbType.VarChar, 4).Value = veiculo.Ano;
                objcmd.Parameters.Add("@cor", MySqlDbType.VarChar, 20).Value = veiculo.Cor;
                objcmd.Parameters.Add("@placa", MySqlDbType.VarChar, 8).Value = veiculo.Placa;
                objcmd.Parameters.Add("@problema_informado", MySqlDbType.VarChar, 120).Value = veiculo.Defeito;
                objcmd.Parameters.Add("@problema_verificado", MySqlDbType.Text, 120).Value = veiculo.Problema_verificado;
                objcmd.Parameters.Add("@observacao", MySqlDbType.VarChar, 120).Value = veiculo.Observacao;
                objcmd.Parameters.Add("@km", MySqlDbType.VarChar, 8).Value = veiculo.Km;


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

        public void atualiza(Veiculo veiculo)
        {

            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `veiculo` SET descricao=@descricao, marca=@marca, modelo=@modelo, ano = @ano, cor=@cor, placa = @placa, problema_informado = @problema_informado, problema_verificado = @problema_verificado, observacao = @observacao, km = @km  WHERE id =" + veiculo.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 50).Value = veiculo.Descricao;
            objcmd.Parameters.Add("@marca", MySqlDbType.VarChar, 50).Value = veiculo.Marca;
            objcmd.Parameters.Add("@modelo", MySqlDbType.VarChar, 20).Value = veiculo.Modelo;
            objcmd.Parameters.Add("@ano", MySqlDbType.VarChar, 4).Value = veiculo.Ano;
            objcmd.Parameters.Add("@cor", MySqlDbType.VarChar, 20).Value = veiculo.Cor;
            objcmd.Parameters.Add("@placa", MySqlDbType.VarChar, 8).Value = veiculo.Placa;
            objcmd.Parameters.Add("@problema_informado", MySqlDbType.VarChar, 120).Value = veiculo.Defeito;
            objcmd.Parameters.Add("@problema_verificado", MySqlDbType.Text, 120).Value = veiculo.Problema_verificado;
            objcmd.Parameters.Add("@observacao", MySqlDbType.VarChar, 120).Value = veiculo.Observacao;
            objcmd.Parameters.Add("@km", MySqlDbType.VarChar, 8).Value = veiculo.Km;

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

        public void delete(string num)
        {
            string sqlDeleta = "DELETE FROM `veiculo` WHERE id =" + num;
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

        public DataTable consultaPorId(string id)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_num = "SELECT * FROM veiculo WHERE id = " + id;
                MySqlCommand objVeiculo = new MySqlCommand(sql_num, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objVeiculo);
                objadp.Fill(dtVeiculo);
                return dtVeiculo;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtVeiculo;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public Veiculo constroiVeiculo(string id)
        {
            dtVeiculo = consultaPorId(id);

            veiculo.Id = Convert.ToInt32(dtVeiculo.Rows[0]["id"]);
            veiculo.Descricao = dtVeiculo.Rows[0]["descricao"].ToString();
            veiculo.Marca = dtVeiculo.Rows[0]["marca"].ToString();
            veiculo.Modelo = dtVeiculo.Rows[0]["modelo"].ToString();
            veiculo.Ano = dtVeiculo.Rows[0]["ano"].ToString();
            veiculo.Cor = dtVeiculo.Rows[0]["cor"].ToString();
            veiculo.Placa = dtVeiculo.Rows[0]["placa"].ToString();
            veiculo.Km = dtVeiculo.Rows[0]["km"].ToString();
            veiculo.Defeito = dtVeiculo.Rows[0]["problema_informado"].ToString();
            veiculo.Problema_verificado = dtVeiculo.Rows[0]["problema_verificado"].ToString();
            veiculo.Observacao = dtVeiculo.Rows[0]["observacao"].ToString();

            return veiculo;

        }
    }
}