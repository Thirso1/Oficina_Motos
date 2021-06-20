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
    class FechamentoDb
    {

        public void insere(Fechamento fechamento)
        {
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                //string de inserção na tabela 
                MySqlCommand objcmd = new MySqlCommand("INSERT INTO `fechamento_caixa`(`entradasDinheiro`, `entradasCartao`, `entradasCheque`, `saidaDinheiro`, `saldoCheque`, `saldoDinheiro`, `recolhimentoCheque`, `recolhimentoDinheiro`, `fundoCaixa`, `id_usuario`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);
               
                //objcmd.Parameters.Add("@data_hora", MySqlDbType.DateTime, 11).Value = fechamento.Data_hora;
                objcmd.Parameters.Add("@entradasDinheiro", MySqlDbType.Decimal, 8).Value = fechamento.EntradaDinheiro;
                objcmd.Parameters.Add("@entradasCartao", MySqlDbType.Decimal, 8).Value = fechamento.EntradaCartao;
                objcmd.Parameters.Add("@entradasCheque", MySqlDbType.Decimal, 8).Value = fechamento.EntradaCheque;
                objcmd.Parameters.Add("@saidaDinheiro", MySqlDbType.Decimal, 8).Value = fechamento.SaidaDinheiro;
                objcmd.Parameters.Add("@saldoCheque", MySqlDbType.Decimal, 8).Value = fechamento.SaldoCheque;
                objcmd.Parameters.Add("@saldoDinheiro", MySqlDbType.Decimal, 8).Value = fechamento.SaldoDinheiro;
                objcmd.Parameters.Add("@recolhimentoCheque", MySqlDbType.Decimal, 8).Value = fechamento.RecolhimentoCheque;
                objcmd.Parameters.Add("@recolhimentoDinheiro", MySqlDbType.Decimal, 8).Value = fechamento.RecolhimentoDinheiro;
                objcmd.Parameters.Add("@fundoCaixa", MySqlDbType.Decimal, 8).Value = fechamento.FundoCaixa;
                objcmd.Parameters.Add("@id_usuario", MySqlDbType.Int32, 11).Value = fechamento.Id_usuario;
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

        public Fechamento ultimoFechamento()
        {
            string sql = "SELECT * FROM `fechamento_caixa` ORDER BY id DESC LIMIT 1";
            DataTable dtFechameto = new DataTable();
            Fechamento fechamento = new Fechamento();
            try
            {
                MySqlConnection conn = Conect.obterConexao();
                MySqlCommand objcomand = new MySqlCommand(sql, conn);
                MySqlDataAdapter objadp = new MySqlDataAdapter(objcomand);
                objadp.Fill(dtFechameto);
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
            if (dtFechameto.Rows.Count > 0)
            {
                fechamento.Id = Convert.ToInt32(dtFechameto.Rows[0][0]);
                fechamento.Data_hora = dtFechameto.Rows[0][1].ToString();
                fechamento.EntradaDinheiro = Convert.ToDecimal(dtFechameto.Rows[0][2]);
                fechamento.EntradaCartao = Convert.ToDecimal(dtFechameto.Rows[0][3]);
                fechamento.EntradaCheque = Convert.ToDecimal(dtFechameto.Rows[0][4]);
                fechamento.SaidaDinheiro = Convert.ToDecimal(dtFechameto.Rows[0][5]);
                fechamento.SaldoCheque = Convert.ToDecimal(dtFechameto.Rows[0][6]);
                fechamento.SaldoDinheiro = Convert.ToDecimal(dtFechameto.Rows[0][7]);
                fechamento.RecolhimentoCheque = Convert.ToDecimal(dtFechameto.Rows[0][8]);
                fechamento.RecolhimentoDinheiro = Convert.ToDecimal(dtFechameto.Rows[0][9]);
                fechamento.FundoCaixa = Convert.ToDecimal(dtFechameto.Rows[0][10]);
                fechamento.Id_usuario = Convert.ToInt32(dtFechameto.Rows[0][11]);
               return fechamento;
            }
            else
            {
                return fechamento;
            }
        }
    }
}
