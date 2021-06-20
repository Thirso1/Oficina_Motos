using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Controler;
using Oficina_Motos.Model;

namespace Oficina_Motos.View
{
    public partial class FrmCaixa : Form
    {
        public FrmCaixa()
        {
            InitializeComponent();
        }

        FornecedorDb fornecedorDb = new FornecedorDb();
        DataTable dtFornecedor = new DataTable();
        DataTable dtEntradas = new DataTable();

        //essas instancias do form1 para manipular o 'visible' dos paineis
        private Form1 form_1;
        public Form1 Form_1
        {
            get
            {
                return form_1;
            }

            set
            {
                form_1 = value;
            }
        }

        decimal saidaFornecedor;
        decimal saidaFuncionario;
        decimal saidaContasConsumo;
        decimal saidaRecolhimento;
        decimal saidaOutros;

        decimal totalCartao;
        decimal totalCheque;
        decimal totalDinheiro;
        decimal totalEntradas;
        decimal totalSaidas;


        decimal anterior;
        decimal saldoAbertura;
        decimal totalVendas;
        decimal totalOs;
        decimal totalSuprimentos;
        decimal totalCrediario;
        decimal totalAbertura;
        decimal saldoGaveta;
        string usuarioAtual;
        string horaAbertura;
        string usuarioAbertura;


        private void FrmCaixa_Load(object sender, EventArgs e)
        {
            entradasDinheiro();
            entradasCartao();
            entradasCheque();
            saidas();
            status();
            povoaGridFluxoCaixa();

            totalEntradas = totalCartao + totalCheque + totalDinheiro;
            txtTotalEntradas.Text = totalEntradas.ToString("N2");

            totalSaidas = totalCartao + totalCheque + totalDinheiro;
            txtTotalEntradas.Text = totalEntradas.ToString("N2");

        }

        private void entradasDinheiro()
        {
            decimal abertura = Fluxo_caixaDb.entradas("", "abertura", 1);
            txtDinheiroInicial.Text = abertura.ToString("N2");

            decimal vendasDinheiro = Fluxo_caixaDb.entradas("", "venda", 1);
            txtDinheiroVendas.Text = vendasDinheiro.ToString("N2"); 

            decimal osDinheiro = Fluxo_caixaDb.entradas("", "ordem serviço", 1);
            txtDinheiroOS.Text = osDinheiro.ToString("N2");

            decimal crediarioDinheiro = Fluxo_caixaDb.entradas("", "crediario", 1);
            txtDinheiroCrediario.Text = crediarioDinheiro.ToString("N2");

            totalDinheiro = abertura + vendasDinheiro + osDinheiro + crediarioDinheiro;
            txtDinheiroTotal.Text = totalDinheiro.ToString("N2");
        }

        private void entradasCartao()
        {
            decimal vendasCartao = Fluxo_caixaDb.entradas("", "venda", 2);
            txtCartaoVendas.Text = vendasCartao.ToString("N2"); 

            decimal osCartao = Fluxo_caixaDb.entradas("", "ordem servico", 2);
            txtCartaoOS.Text = osCartao.ToString("N2");

            decimal crediarioCartao = Fluxo_caixaDb.entradas("", "crediario", 2);
            txtCartaoCrediario.Text = crediarioCartao.ToString("N2");

            totalCartao = vendasCartao + osCartao + crediarioCartao;
            txtCartaoTotal.Text = totalCartao.ToString("N2");

        }

        private void entradasCheque()
        {
            decimal vendasCheque = Fluxo_caixaDb.entradas("", "venda", 3);
            txtChequeVendas.Text = vendasCheque.ToString("N2");

            decimal osCheque = Fluxo_caixaDb.entradas("", "ordem servico", 3);
            txtChequeOS.Text = osCheque.ToString("N2");

            decimal crediarioCheque = Fluxo_caixaDb.entradas("", "crediario", 3);
            txtChequeCrediario.Text = crediarioCheque.ToString("N2");

            totalCheque = vendasCheque + osCheque + crediarioCheque;
            txtChequeTotal.Text = totalCheque.ToString("N2");

        }


        private void saidas()
        {
            saidaFornecedor = Fluxo_caixaDb.saidas("fornecedor", "", 1);
            txtFornecedores.Text = saidaFornecedor.ToString("N2");

            saidaFuncionario = Fluxo_caixaDb.saidas("funcionários", "", 1);
            textFuncionarios.Text = saidaFuncionario.ToString("N2");

            saidaContasConsumo = Fluxo_caixaDb.saidas("contas de consumo", "", 1);
            txtContasConsumo.Text = saidaContasConsumo.ToString("N2");

            saidaRecolhimento = Fluxo_caixaDb.saidas("recolhimento", "", 1);
            textRecolhimento.Text = saidaRecolhimento.ToString("N2");

            saidaOutros = Fluxo_caixaDb.saidas("outros", "", 1);
            txtOutros.Text = saidaOutros.ToString("N2");
        }

        private void status()
        {
            FechamentoDb fechamentoDb = new FechamentoDb();
            Fechamento fechamento = new Fechamento();
            fechamento = fechamentoDb.ultimoFechamento();
            DataTable abertura = new DataTable();
            abertura = Fluxo_caixaDb.abertura();


            anterior = fechamento.FundoCaixa;
            textSaldoAnterior.Text = anterior.ToString();

            saldoAbertura = Fluxo_caixaDb.entradasPorDescricao("abertura");
            textAbertura.Text = saldoAbertura.ToString("N2");

            totalVendas = Fluxo_caixaDb.entradasPorDescricao("venda");
            textTotalVendas.Text = totalVendas.ToString("N2");

            totalOs = Fluxo_caixaDb.entradasPorDescricao("ordem serviço");
            textTotalOs.Text = totalOs.ToString("N2");

            totalSuprimentos = Fluxo_caixaDb.entradasPorDescricao("suprimento");
            textTotalSuprimentos.Text = totalSuprimentos.ToString("N2");

            totalCrediario = Fluxo_caixaDb.entradasPorDescricao("crediario");
            totalAbertura = Fluxo_caixaDb.entradasPorDescricao("abertura");


            saldoGaveta = Fluxo_caixaDb.saldoPorForma(1);
            if (abertura.Rows.Count > 0)
            {
                horaAbertura = abertura.Rows[0][1].ToString();
                usuarioAbertura = abertura.Rows[0][7].ToString();
                textHorarioAbertura.Text = horaAbertura.Substring(11, 8);
                textUsuarioAbertura.Text = usuarioAbertura;
            }

            Login login  = LoginDb.caixa_login();
            lblTitulo.Text += ": "+ login.Caixa_aberto;
            textUsuarioAtual.Text = login.Usuario;
            textSaldoGaveta.Text = saldoGaveta.ToString("N2");
        }

        //carrega a grid com detalhes das saidas fornecedor
        private void loadDgDetalhes(string grupo)
        {
            dtFornecedor.Rows.Clear();
            dtFornecedor = Fluxo_caixaDb.saidaDetalhes(grupo);
            //for (int i = 0; i <= dtFornecedor.Rows.Count-1; i++)
            //{
            //    DateTime data_hora = Convert.ToDateTime(dtFornecedor.Rows[i][0]);
            //    //string hora = data_hora.Substring(11, 8);
            //    dtFornecedor.Rows[i][0] = data_hora.ToString("hh:mm");
            //}
            dgSaidaFornecedor.DataSource = dtFornecedor;
        }

        private void loadDgDetalhesEntrada(string grupo)
        {
            //for (int i = 0; i <= dtFornecedor.Rows.Count-1; i++)
            //{
            //    DateTime data_hora = Convert.ToDateTime(dtFornecedor.Rows[i][0]);
            //    //string hora = data_hora.Substring(11, 8);
            //    dtFornecedor.Rows[i][0] = data_hora.ToString("hh:mm");
            //}
        }

        private void povoaGrid(int formaPag)
        {
            dtEntradas.Rows.Clear();
            dgEntradas.Columns.Clear();
            dgEntradas.Columns.Add("hora", "Hora");
            dgEntradas.Columns.Add("descricao", "Descrição");
            dgEntradas.Columns.Add("valor", "Valor");
            dgEntradas.Columns.Add("usuario", "Usuário");
            string hora = "";
            dtEntradas = Fluxo_caixaDb.entradaDetalhes(formaPag);

            for (int i = 0; i < dtEntradas.Rows.Count; i++)
            {
                // cria uma linha

                DataGridViewRow item = new DataGridViewRow();

                item.CreateCells(dgEntradas);
                // seta os valores
                hora = dtEntradas.Rows[i][0].ToString();
                hora = hora.Substring(11, 8);
                //MessageBox.Show(hora);

                item.Cells[0].Value = hora;
                item.Cells[1].Value = dtEntradas.Rows[i][2].ToString();
                item.Cells[2].Value = dtEntradas.Rows[i][3].ToString();
                item.Cells[3].Value = dtEntradas.Rows[i][5].ToString();

                // adiciona na gid
                dgEntradas.Rows.Add(item);
            }
            //dgEntradas.DataSource = dtEntradas;
            dgEntradas.Columns[0].Width = 100;
            dgEntradas.Columns[1].Width = 140;
            dgEntradas.Columns[2].Width = 100;
            dgEntradas.Columns[3].Width = 100;
            dgEntradas.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dgEntradas.ClearSelection();
            dgEntradas.Columns["usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEntradas.ClearSelection();
        }

        private void povoaGridFluxoCaixa()
        {
            DataTable dtFluxo = new DataTable();
            dtFluxo = Fluxo_caixaDb.fluxoCaixa();
            dgFluxoCaixa.DataSource = dtFluxo;
        }
        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            dtFornecedor.Rows.Clear();
            loadDgDetalhes("fornecedor");
            dgSaidaFornecedor.ClearSelection();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            dtFornecedor.Rows.Clear();
            loadDgDetalhes("funcionários");
            dgSaidaFornecedor.ClearSelection();
        }

        private void btnContasConsumo_Click(object sender, EventArgs e)
        {
            dtFornecedor.Rows.Clear();
            loadDgDetalhes("contas de consumo");
            dgSaidaFornecedor.ClearSelection();
        }

        private void btnOutros_Click(object sender, EventArgs e)
        {
            dtFornecedor.Rows.Clear();
            loadDgDetalhes("outros");
            dgSaidaFornecedor.ClearSelection();
        }

        private void btnRecolhimento_Click(object sender, EventArgs e)
        {
            dtFornecedor.Rows.Clear();
            loadDgDetalhes("recolhimento");
            dgSaidaFornecedor.ClearSelection();
        }

        private void btnDetanhesDinheiro_Click(object sender, EventArgs e)
        {
            povoaGrid(1);//um para dinheiro 
        }

        private void btnDetalhesCartao_Click(object sender, EventArgs e)
        {
            povoaGrid(2);//dois para cartao
        }

        private void btnDetalhesCheque_Click(object sender, EventArgs e)
        {
            povoaGrid(3);//tres para cheque
        }

        private void FrmCaixa_FormClosed(object sender, FormClosedEventArgs e)
        {
            //chama a instancia do form1 que esta aberta e chama o metodo que verifica se todas as janelas fecharam
            //permitindo os paineis de orcamento, Os, vendas ficarem visiveis
            //Form_1.form_unico = true;
            //Form_1.escondePainel();
        }
    }
}
