using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Model;

namespace Oficina_Motos.Controler
{
    class CrediarioDb
    {
        Crediario crediario = new Crediario();

        public int geraCodCrediario()
        {
            string sqlCod = "SELECT * FROM crediario ORDER BY id DESC LIMIT 1";
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

        public void insere(Crediario crediario)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `crediario`(`id`, `id_cliente`, `referencia`, `num_referencia`, `entrada`, `valor_parcelado`, `num_parcelas`, `data`, `status`) values(?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);
                objcmd.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = crediario.Id;
                objcmd.Parameters.Add("@id_cliente", MySqlDbType.Int32, 20).Value = crediario.Id_cliente;
                objcmd.Parameters.Add("@referencia", MySqlDbType.VarChar, 50).Value = crediario.Referencia;
                objcmd.Parameters.Add("@num_referencia", MySqlDbType.Int32, 11).Value = crediario.Num_referencia;
                objcmd.Parameters.Add("@entrada", MySqlDbType.Decimal, 8).Value = crediario.Entrada;
                objcmd.Parameters.Add("@valor_parcelado", MySqlDbType.Decimal, 8).Value = crediario.Valor_parcelado;
                objcmd.Parameters.Add("@num_parcelas", MySqlDbType.Int32, 11).Value = crediario.Num_parcelas;
                objcmd.Parameters.Add("@data", MySqlDbType.Date, 8).Value = crediario.Data;
                objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = crediario.Status;

                //executa a inserção
                objcmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar Parcelamento");
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public void atualizaStatus(Crediario crediario)
        {
            MySqlConnection conn = Conect.obterConexao();
            string updateItens = "UPDATE `crediario` SET status=@status WHERE id =" + crediario.Id;
            MySqlCommand objcmd = new MySqlCommand(updateItens, conn);
            objcmd.Parameters.Add("@status", MySqlDbType.VarChar, 20).Value = crediario.Status;

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

        public DataTable consultaPorStatus(int status)
        {
            string sql = "SELECT * FROM `crediarios` WHERE `status` = '"+status+"'";
            DataTable crediarios = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(crediarios);
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
            if (crediarios.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Registro!");
                return null;
            }
            else
            {
                return crediarios;
            }
        }

        public DataTable consultaPorCpf(string cpf)
        {
            string sql = "SELECT * FROM `crediarios` WHERE `cpf` = '" + cpf + "'";
            DataTable crediarios = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(crediarios);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            finally
            {
                Conect.fecharConexao();
            }            
            return crediarios;
        }

        public DataTable consultaPorId(int id)
        {
            string sql = "SELECT * FROM `crediarios` WHERE `num_crediario` = '" + id + "'";
            DataTable crediarios = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(crediarios);
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
            if (crediarios.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Registro!");
                return null;
            }
            else
            {
                return crediarios;
            }
        }

        public DataTable consultaNome(string nome)
        {
            DataTable returCrediarios = new DataTable();
            string sqlCliente = "SELECT * FROM `crediarios` WHERE `Cliente` = '" + nome + "' AND `Status` != 1";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sqlCliente, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(returCrediarios);
                return returCrediarios;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return returCrediarios;
            }
            finally
            {
                Conect.fecharConexao();
            }

        }

        public Crediario retornaPorId(int id)
        {
            string sql = "SELECT * FROM `crediario` WHERE `id` = '" + id + "'";
            DataTable crediarios = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(crediarios);

                crediario.Id = Convert.ToInt32(crediarios.Rows[0][0]);
                crediario.Id_cliente = Convert.ToInt32(crediarios.Rows[0][1]);
                crediario.Referencia = crediarios.Rows[0][2].ToString();
                crediario.Num_referencia = Convert.ToInt32(crediarios.Rows[0][3]);
                crediario.Entrada = Convert.ToDecimal(crediarios.Rows[0][4]);
                crediario.Valor_parcelado = Convert.ToDecimal(crediarios.Rows[0][5]);
                crediario.Num_parcelas = Convert.ToInt32(crediarios.Rows[0][6]);
                crediario.Data = crediarios.Rows[0][7].ToString();
                crediario.Status = crediarios.Rows[0][8].ToString();
                return crediario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return crediario;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public DataTable consultaAtrasados(int[] atrasados)
        {
            string sql = "";
            for (int i = 0; i < atrasados.Length; i++)
            {
                 sql = "select `zoinho_motos`.`crediario`.`id` AS `Num_crediario`,`zoinho_motos`.`crediario`.`data` AS `Data`,`zoinho_motos`.`crediario`.`num_referencia` AS `Número`,`zoinho_motos`.`crediario`.`referencia` AS `Referência`,`zoinho_motos`.`crediario`.`entrada` AS `Entrada`,`zoinho_motos`.`crediario`.`valor_parcelado` AS `Valor Parcelado`,`zoinho_motos`.`cliente`.`nome` AS `Cliente`,`zoinho_motos`.`cliente`.`cpf` AS `CPF` from(`zoinho_motos`.`crediario` join `zoinho_motos`.`cliente` on((`zoinho_motos`.`cliente`.`id` = `zoinho_motos`.`crediario`.`id_cliente`))) where(`zoinho_motos`.`crediario`.`id` = "+ atrasados[i]+")";

            }
            DataTable crediarios = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(crediarios);
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
            if (crediarios.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Registro!");
                return null;
            }
            else
            {
                return crediarios;
            }
        }

        public decimal entrada(int id)
        {
            decimal entrada;

            try
            {
                MySqlConnection conn = Conect.obterConexao();

                //pegar o valor da entrada
                string sqlentrada = "SELECT `entrada` FROM `crediario` WHERE `id` ='" + id + "'";
                MySqlCommand objentrada = new MySqlCommand(sqlentrada, conn);
                if (objentrada.ExecuteScalar() != DBNull.Value)
                {
                    entrada = Convert.ToDecimal(objentrada.ExecuteScalar());
                    return entrada;
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

        public decimal valor_parcelado(int id)
        {
            decimal valor_parcelado;

            try
            {
                MySqlConnection conn = Conect.obterConexao();

                //pegar o valor parcelado
                string sqlParcelado = "SELECT `valor_parcelado` FROM `crediario` WHERE `id` ='" + id + "'";
                MySqlCommand objParcelado = new MySqlCommand(sqlParcelado, conn);
                if (objParcelado.ExecuteScalar() != DBNull.Value)
                {
                    valor_parcelado = Convert.ToDecimal(objParcelado.ExecuteScalar());
                    return valor_parcelado;
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

        public decimal parcelas_recebidas(int id)
        {
            decimal parcelas_recebidas;

            try
            {
                MySqlConnection conn = Conect.obterConexao();

                string sqlRecebido = "SELECT SUM(`valor_recebido`) FROM `parcela` WHERE `id_crediario` ='" + id + "'";
                MySqlCommand objParcela = new MySqlCommand(sqlRecebido, conn);
                if (objParcela.ExecuteScalar() != DBNull.Value)
                {
                    parcelas_recebidas = Convert.ToDecimal(objParcela.ExecuteScalar());
                    return parcelas_recebidas;
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

        //verifica se todas estao pagas
        public bool verifica_pagamento(int id)
        {
            string sql = "SELECT * FROM `parcela` WHERE `id_crediario` = '" + id + "' AND `status` = 0";
            DataTable parcelas = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(parcelas);
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
            if (parcelas.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //verifica se existe pagamento de alguma parcela, se todas estao pagas, ou nenhuma
        public int status_crediario(int id)
        {
            int status = 0;
            string sql = "SELECT * FROM `parcela` WHERE `id_crediario` = '" + id + "' AND `status` = 0";
            DataTable parcelas = new DataTable();
                try
                {
                    MySqlConnection conn = Conect.obterConexao();
                    MySqlCommand objcomand = new MySqlCommand(sql, conn);
                    MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                    objadp.Fill(parcelas);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.ToString());
                }
                finally
                {
                    Conect.fecharConexao();
                }
            
            decimal valorEntrada = entrada(id);
            decimal valorRecebido = parcelas_recebidas(id);
            decimal valorParcelado = valor_parcelado(id);

            MessageBox.Show("entrada " + valorEntrada.ToString());
            MessageBox.Show("parcelado " + valorParcelado.ToString());
            MessageBox.Show("recebido " + valorRecebido.ToString());


            if (valorRecebido == 0)
                {
                    status = 1;//nada pago
                }
            else if (valorRecebido > 0 && valorRecebido < valorParcelado)
                {
                    status = 2;//parcialmente pago  
                }
            else if (valorRecebido == valorParcelado)
                {
                    status = 0;//totalmente pago
                }

            return status;
        }

        //armazena o id dos crediarios que estao com parcelas em atraso 
        public List<int> crediarios_atrasados()
        {
            List<int> cred = new List<int>();

            string sql = "SELECT DISTINCT(`id_crediario`) FROM `parcela` WHERE `vencimento` < CURRENT_DATE AND `status` = 0";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand comandos = new MySqlCommand(sql, conn);
                MySqlDataReader dr = comandos.ExecuteReader();

                int index = 0;

                while (dr.Read())
                {
                    cred.Add(dr.GetInt32(0));

                    //cred[index] = Convert.ToInt32(dr["id_crediario"]);

                    index++;

                }
                return cred;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return cred;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public List<int> crediarios_a_vencer()
        {
            List<int> cred = new List<int>();

            string sql = "SELECT DISTINCT(`id_crediario`) FROM `parcela` WHERE `vencimento` >= CURRENT_DATE AND `status` = 0";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand comandos = new MySqlCommand(sql, conn);
                MySqlDataReader dr = comandos.ExecuteReader();

                int index = 0;

                while (dr.Read())
                {
                    cred.Add(dr.GetInt32(0));

                    //cred[index] = Convert.ToInt32(dr["id_crediario"]);

                    index++;

                }
                return cred;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return cred;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public decimal ultimoLancamento()
        {
            decimal ultimoLancamento;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT `valor_parcelado` FROM `crediario` ORDER BY id DESC LIMIT 1";
                MySqlCommand objsaida = new MySqlCommand(sql, conn);
                if (objsaida.ExecuteScalar() != DBNull.Value)
                {
                    ultimoLancamento = Convert.ToDecimal(objsaida.ExecuteScalar());
                    return ultimoLancamento;
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
