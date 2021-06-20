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
    public static class Fluxo_caixaDb
    {
        public static string data_hora = DateTime.Today.ToString("yyyy-MM-dd 00:00:00");
        public static DataTable dtFornecedor = new DataTable();
        public static DataTable dtEntradas = new DataTable();
        public static DataTable dtFluxo = new DataTable();


        public static void insere(Fluxo_caixa fluxo)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `fluxo_caixa` ( `grupo`,`descricao`,`id_forma_pag`,`entrada`,`saida`,`usuario`) values(?,?,?,?,?,?)", conn);
                objcmd.Parameters.Add("@grupo", MySqlDbType.VarChar, 30).Value = fluxo.Grupo;
                objcmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 50).Value = fluxo.Descricao;
                objcmd.Parameters.Add("@id_forma_pag", MySqlDbType.Int32, 11).Value = fluxo.Id_forma_pag;
                objcmd.Parameters.Add("@entrada", MySqlDbType.Decimal, 8).Value = fluxo.Entrada;
                objcmd.Parameters.Add("@saida", MySqlDbType.Decimal, 8).Value = fluxo.Saida;
                objcmd.Parameters.Add("@usuario", MySqlDbType.VarChar, 20).Value = fluxo.Usuario;


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

        public static bool verifica()
        {
            bool aberto;
            string sql_verif_abertura = "SELECT * FROM `login` WHERE `caixa_aberto` = 'aberto'";

            try
            {
                MySqlConnection conn = new MySqlConnection();
                MySqlCommand objVerifica = new MySqlCommand(sql_verif_abertura, conn);
                string resulVerifica = objVerifica.ExecuteScalar().ToString();
                if (resulVerifica == "")
                {
                    aberto = false;
                }
                else
                {
                    aberto = true;
                }
                return aberto;
            }
            catch
            {
                return true;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public static decimal valorAtual()
        {
            decimal entradas;
            decimal saidas;
            decimal valor;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //SELECT COUNT(id) FROM `venda` WHERE `status` = 'Suspensa'
                string sql_entrada = "SELECT SUM(entrada) FROM fluxo_caixa";
                MySqlCommand objEntrada = new MySqlCommand(sql_entrada, conn);
                entradas= Convert.ToDecimal(objEntrada.ExecuteScalar());

                string sql_saida = "SELECT SUM(saida) FROM fluxo_caixa";
                MySqlCommand objSaida = new MySqlCommand(sql_saida, conn);
                saidas = Convert.ToDecimal(objSaida.ExecuteScalar());

                valor = entradas - saidas;
                return valor;
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

        public static DataTable ultimoFechamento()
        {
            DataTable fechamento = new DataTable();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT * FROM `fechamento_caixa` ORDER BY `fechamento_caixa`.`id` DESC LIMIT 1";

                MySqlCommand obj = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(obj);
                objadp.Fill(fechamento);             
                return fechamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return fechamento;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public static decimal entradas(string grupo, string descricao, int forma)
        {
            decimal entradas;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_entrada = "SELECT SUM(`entrada`) FROM `fluxo_caixa` WHERE `descricao` ='"+ descricao + "' AND `id_forma_pag` = '"+forma+"' AND `data_hora` > '"+data_hora+"'";

                MySqlCommand objEntrada = new MySqlCommand(sql_entrada, conn);
                if (objEntrada.ExecuteScalar() != DBNull.Value)
                {
                    entradas = Convert.ToDecimal(objEntrada.ExecuteScalar());
                    return entradas;
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

        public static decimal entradasPorForma(int forma)
        {
            decimal entradas;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_entrada = "SELECT SUM(`entrada`) FROM `fluxo_caixa` WHERE `id_forma_pag` = '" + forma + "' AND `data_hora` > '" + data_hora + "'";

                MySqlCommand objEntrada = new MySqlCommand(sql_entrada, conn);
                if (objEntrada.ExecuteScalar() != DBNull.Value)
                {
                    entradas = Convert.ToDecimal(objEntrada.ExecuteScalar());
                    return entradas;
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

        public static decimal saldoPorForma(int forma)
        {
            decimal entradas = 0;
            decimal saidas = 0;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_entrada = "SELECT SUM(`entrada`) FROM `fluxo_caixa` WHERE `id_forma_pag` = '" + forma + "' AND `data_hora` > '" + data_hora + "'";
                string sql_saida = "SELECT SUM(`saida`) FROM `fluxo_caixa` WHERE `id_forma_pag` = '" + forma + "' AND `data_hora` > '" + data_hora + "'";

                MySqlCommand objEntrada = new MySqlCommand(sql_entrada, conn);
                if (objEntrada.ExecuteScalar() != DBNull.Value)
                {
                    entradas = Convert.ToDecimal(objEntrada.ExecuteScalar());
                }
                MySqlCommand objSaida = new MySqlCommand(sql_saida, conn);
                if (objSaida.ExecuteScalar() != DBNull.Value)
                {
                    saidas = Convert.ToDecimal(objSaida.ExecuteScalar());
                }
                decimal saldo = entradas - saidas;
                return saldo ;
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

        public static decimal saidas(string grupo, string descricao, int forma)
        {
            decimal saidas;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_saida = "SELECT SUM(`saida`) FROM `saidas` WHERE `grupo` = '"+grupo+"' AND `data_hora` > '" + data_hora + "'";
                MySqlCommand objsaida = new MySqlCommand(sql_saida, conn);
                if (objsaida.ExecuteScalar() != DBNull.Value)
                {
                    saidas = Convert.ToDecimal(objsaida.ExecuteScalar());
                    return saidas;
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

        public static decimal saidasPorForma(int forma)// inteiro indica a forma de pagamento
        {
            decimal saidas;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_saida = "SELECT SUM(`saida`) FROM `saidas` WHERE `id_forma_pag` = '" + forma + "' AND `data_hora` > '" + data_hora + "'";
                MySqlCommand objsaida = new MySqlCommand(sql_saida, conn);
                if (objsaida.ExecuteScalar() != DBNull.Value)
                {
                    saidas = Convert.ToDecimal(objsaida.ExecuteScalar());
                    return saidas;
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

        public static DataTable saidaDetalhes(string grupo)
        {
            string sql = "SELECT * FROM `saidas` WHERE `grupo` = '"+grupo+"' AND `data_hora` > '" + data_hora + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFornecedor);
                return dtFornecedor;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtFornecedor;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public static DataTable entradaDetalhes(int meio_pag)
        {
            string sql = "SELECT * FROM `entradas` WHERE `forma_pag` = '"+meio_pag+"' AND `data_hora` > '" + data_hora + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtEntradas);
                return dtEntradas;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtEntradas;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public static DataTable abertura()
        {
            DataTable abertura = new DataTable();
            string sql = "SELECT * FROM `fluxo_caixa` WHERE `descricao` = 'abertura' AND `data_hora` > '" + data_hora + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(abertura);
                return abertura;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return abertura;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }

        public static decimal totalDinheiro()
        {
            decimal entrada;
            decimal saida;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_saida = "SELECT SUM(`saida`) FROM `fluxo_caixa` WHERE `id_forma_pag` = '"+1+"'";
                string sql_entrada = "SELECT SUM(`entrada`) FROM `fluxo_caixa` WHERE `id_forma_pag` = '" + 1 + "'";

                MySqlCommand objsaida = new MySqlCommand(sql_saida, conn);
                MySqlCommand objentrada = new MySqlCommand(sql_entrada, conn);

                saida = Convert.ToDecimal(objsaida.ExecuteScalar());
                entrada = Convert.ToDecimal(objentrada.ExecuteScalar());

                return entrada - saida;
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

        public static decimal ultimoLancamento()
        {
            decimal ultimoLancamento;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql = "SELECT `entrada` FROM `fluxo_caixa` ORDER BY id DESC LIMIT 1";
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

        public static decimal entradasPorDescricao(string descricao)
        {
            decimal entradas;

            try
            {
                MySqlConnection conn = Conect.obterConexao();
                string sql_entrada = "SELECT SUM(`entrada`) FROM `fluxo_caixa` WHERE `descricao` ='" + descricao + "' AND `data_hora` > '" + data_hora + "'";

                MySqlCommand objEntrada = new MySqlCommand(sql_entrada, conn);
                if (objEntrada.ExecuteScalar() != DBNull.Value)
                {
                    entradas = Convert.ToDecimal(objEntrada.ExecuteScalar());
                    return entradas;
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

        public static DataTable fluxoCaixa()
        {
            string sql = "SELECT * FROM `fluxocaixa` WHERE `Hora` > '" + data_hora + "'";
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFluxo);
                return dtFluxo;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
                return dtFluxo;
            }
            finally
            {
                Conect.fecharConexao();
            }
        }
    }
}