using MySql.Data.MySqlClient;
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
using Oficina_Motos.View;
using Oficina_Motos.View.Consulta;

namespace Oficina_Motos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Usuario usuario = new Usuario();
        UsuarioDb usuarioDb = new UsuarioDb();
        Login login = new Login();
        Fluxo_caixa fluxo = new Fluxo_caixa();
        OrcamentoDb orcamentoDb = new OrcamentoDb();
        DataTable dtOrcamento = new DataTable();
        Ordem_ServicoDb ordem_ServicoDb = new Ordem_ServicoDb();
        VendaDb vendaDb = new VendaDb();

        private bool logado = false;
        public bool Logado
        {
            get
            {
                return logado;
            }

            set
            {
                logado = value;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            login = LoginDb.caixa_login();
            FrmLogin frmLogin = new FrmLogin(login);
            frmLogin.form1 = this;
            frmLogin.ShowDialog();
            if (Logado == false)
            {
                this.Close();
            }

                else if (Logado == true)
            {

                login = LoginDb.caixa_login();

                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
                //
                usuario = usuarioDb.consultaPorID(login.Id_usuario);
                //passa o codigo do perfil do usuario para o metodo
                string perfil = usuario.Perfil;
                controleUsuario(perfil);
                //

                textUsuario.Text = usuario.Login;
            }

            botoesOrcamento();
            botoesOrdemServico();
            botoesVendas();
            panelOrcamento.Select();
            qtdeEstoque();
        }

        void qtdeEstoque()
        {
            EstoqueDb estoqueDb = new EstoqueDb();
            int qtdeZerado = estoqueDb.contaItensZeradoBaixo("estoquezerado");
            int qtdeBaixo = estoqueDb.contaItensZeradoBaixo("estoquebaixo");
            textEstoqueZerado.Text = qtdeZerado.ToString();
            textEstoqueBaixo.Text = qtdeBaixo.ToString();
        }

        void controleUsuario(string perfil)
        {
            switch (perfil)
            {
                case "Operador":
                    menuStrip1.Items[1].Enabled = false;
                    menuStrip1.Items[2].Enabled = false;
                    menuStrip1.Items[9].Enabled = false;
                    iconPictureBox12.ForeColor = Color.Gray;
                    iconPictureBox5.ForeColor = Color.Gray;
                    iconPictureBox4.ForeColor = Color.Gray;

                    break;
                case "Operador/Caixa":
                    menuStrip1.Items[1].Enabled = false;
                    menuStrip1.Items[2].Enabled = false;
                    //menuStrip1.Items[9].Enabled = false;
                    //caixaToolStripMenuItem.Enabled = false;
                    //statusToolStripMenuItem.Enabled = false;
                    abrirToolStripMenuItem.Enabled = false;
                    fecharToolStripMenuItem.Enabled = false;
                    break;
                case "Gerente":
                    
                    break;
                case "root":
                   
                    break;
            }
        }
           
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAgendaOrcamento_Click(object sender, EventArgs e)
        {
            //FrmConferenciaPedido a = new FrmConferenciaPedido();
            //a.ShowDialog();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void retiradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRetirada ret = new FrmRetirada();
            ret.ShowDialog();
        }

        private void sairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            login = LoginDb.caixa_login();
            LoginDb.atualiza(login.Id, login.Caixa_aberto, "nenhum", 0);
            Application.Exit();
        }

        private void cadastrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmCadastroCliente c = new FrmCadastroCliente(0);
            //c.MdiParent = this;
            c.ShowDialog();

        }

        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmConsultaCliente c = new FrmConsultaCliente();
            c.ShowDialog();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           //consulta usuario --- esta desabilitado
        }

        private void cadastrarToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            FrmCadastroFuncionarios c = new FrmCadastroFuncionarios(0);//parametro '0' significa que é novo cadastro e nao atualização
            c.ShowDialog();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaFuncionario c = new FrmConsultaFuncionario();
            c.ShowDialog();
        }

        private void cadastrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos c = new FrmCadastroProdutos(0);
            c.ShowDialog();
        }

        //consulta produtos
        private void consultarToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            FrmConsultaProduto C = new FrmConsultaProduto();
            C.ShowDialog();
        }

        //cadastro de serviço
        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroServico s = new FrmCadastroServico(0);
            s.ShowDialog();
        }

        //nova venda
        private void novaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            novaVenda();
        }
        private void novaVenda()
        {
            //MessageBox.Show(LoginDb.caixaAberto().ToString());
            if (LoginDb.caixaAberto() == true)
            {
                FrmPdv pdv = new FrmPdv(0);//o parametro indica que é uma nova venda
                pdv.ShowDialog();
                botoesVendas();
            }
            else
            {
                if (usuario.Perfil != "Gerente")
                {
                    MessageBox.Show("Usuário " + usuario.Login + " não tem permissão para abrir o caixa.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Caixa fechado! Deseja abrir?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        FrmAberturaCaixa1 ab = new FrmAberturaCaixa1();
                        ab.ShowDialog();
                        if (LoginDb.caixaAberto() == true)
                        {
                            FrmPdv pdv = new FrmPdv(0);
                            pdv.ShowDialog();
                            botoesVendas();
                        }
                    }
                }              
            }
        }
        
        //vendas suspensas
        private void suspensasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
                FrmVendasSuspensas v = new FrmVendasSuspensas("Suspensa");
                v.ShowDialog();
                botoesVendas();
           
        }

        //consulta vendas
        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmConsultaVendas v = new FrmConsultaVendas();
            v.ShowDialog();
            botoesVendas();
        }

        //novo orçamento
        private void novoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmOrcamento f = new FrmOrcamento(usuario, 0);
            f.ShowDialog();
            botoesOrcamento();
        }

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmConsultaOrcamento fco = new FrmConsultaOrcamento(usuario);
            fco.ShowDialog();
            botoesOrcamento();
        }

        private void consultarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FrmConsultaOrdemServico os = new FrmConsultaOrdemServico();
            os.ShowDialog();
            botoesOrdemServico();
        }

        private void suspensosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrcamentosSuspensos suspensos = new FrmOrcamentosSuspensos("Suspenso");
            suspensos.ShowDialog();
        }

        private void btnOrcamentosSuspensos_Click(object sender, EventArgs e)
        {
            
        }
        string Valor(decimal valor)
        {
            string strValor = "0,00";
            if(valor == 0)
            {
                strValor = "0,00";
            }
            else
            {
                strValor = valor.ToString();
            }
            return strValor;
        }
        //carrega botoes orcamento
        private void botoesOrcamento()
        {
            lblOrcamentosSuspensos.Text = "Suspensos         ["+ orcamentoDb.contaRegistros("Suspenso").ToString()+"]";
            decimal suspenso = orcamentoDb.valorPorStatus("suspenso");
            textSuspensos.Text = suspenso.ToString();//orcamentoDb.contaRegistros("Suspenso").ToString();

            //textSuspensos.Text = "R$"+ Valor(suspenso);

            lblOrcamentosAnalise.Text = "Em Análise        [" + orcamentoDb.contaRegistros("Em análise").ToString() + "]";
            decimal analise = orcamentoDb.valorPorStatus("Em análise");
            //textAnalise.Text = orcamentoDb.contaRegistros("Em análise").ToString();
            textAnalise.Text = Valor(analise);

            lblOrcamentosConcluidos.Text = "Aguard. Aprovação [" + orcamentoDb.contaRegistros("Concluído").ToString() + "]";
            decimal aguardando = orcamentoDb.valorPorStatus("Concluído");
            //textConcluido.Text = orcamentoDb.contaRegistros("Concluído").ToString();
            textConcluido.Text = Valor(aguardando);

            lblOrcamentosAprovados.Text = "Aprovados         [" + orcamentoDb.contaRegistrosHoje("Aprovado").ToString() + "]";
            decimal aprovado = orcamentoDb.valorPorStatusData("Aprovado");
            //textAprovados.Text = orcamentoDb.contaRegistrosHoje("Aprovado").ToString();
            textAprovados.Text = Valor(aprovado);

            lblOrcamentosCancelados.Text = "Cancelados        [" + orcamentoDb.contaRegistrosHoje("Cancelado").ToString() + "]";
            decimal cancelado = orcamentoDb.valorPorStatus("Cancelado");
            //textCancelados.Text = orcamentoDb.contaRegistros("Cancelado").ToString();
            textCancelados.Text = Valor(cancelado);

        }

        //carrega botoes os
        private void botoesOrdemServico()
        {
            lblOsIniciadas.Text = "Em Andamento   [" + ordem_ServicoDb.contaRegistros("Em Andamento").ToString() + "]";
            decimal iniciadas = ordem_ServicoDb.valorPorStatus("Em Andamento");
            //textOsIniciadas.Text = ordem_ServicoDb.contaRegistros("Em Andamento").ToString();
            textOsIniciadas.Text = Valor(iniciadas);

            lblOsPecas.Text = "Suspensas    [" + ordem_ServicoDb.contaRegistros("Aguardando Peças").ToString() + "]";
            decimal pecas = ordem_ServicoDb.valorPorStatus("Suspensa");
            //textOsAguarPecas.Text = ordem_ServicoDb.contaRegistros("Suspensa").ToString();
            textOsAguarPecas.Text = Valor(pecas);

            label8.Text = "Aguard. Pagamento   [" + ordem_ServicoDb.contaRegistros("Concluída - Não Pago").ToString() + "]";
            decimal concluidas = ordem_ServicoDb.valorPorStatus("Concluída - Não Pago");
            //textOsPagPendente.Text = ordem_ServicoDb.contaRegistros("Concluída - Não Pago").ToString();
            textOsPagPendente.Text = Valor(concluidas);

            lblOsFinalizadas.Text = "Finalizadas  [" + ordem_ServicoDb.contaRegistrosHoje("Finalizada").ToString() + "]";
            decimal finalizadas = ordem_ServicoDb.valorPorStatusData("Finalizada");
            //textOsEntregues.Text = ordem_ServicoDb.contaRegistrosHoje("Finalizada").ToString();
            textOsEntregues.Text = Valor(finalizadas);

            lblOsCanceladas.Text = "Canceladas  [" + ordem_ServicoDb.contaRegistrosHoje("Cancelada").ToString() + "]";
            decimal canceladas = ordem_ServicoDb.valorPorStatusData("Cancelada");
            //textOsCanceladas.Text = ordem_ServicoDb.contaRegistrosHoje("Cancelada").ToString();
            textOsCanceladas.Text = Valor(canceladas);
        }

        //carrega botoes vendas
        private void botoesVendas()
        {
            lblVendasSuspensas.Text = "Suspensas  ["+vendaDb.contaRegistros("Suspensa").ToString()+"]";
            decimal suspensas = vendaDb.valorPorStatus("Suspensa");
            //textVendasSuspensas.Text = vendaDb.contaRegistros("Suspensa").ToString();
            textVendasSuspensas.Text = Valor(suspensas);

            lblVendasFinalizadas.Text = "Finalizadas  [" + vendaDb.contaRegistrosHoje("Finalizada").ToString() + "]";
            decimal finalizadas = vendaDb.valorPorStatusData("Finalizada");
            //textVendasFinalizadas.Text = vendaDb.contaRegistrosHoje("Finalizada").ToString();
            textVendasFinalizadas.Text = Valor(finalizadas);

            lblVendasCanceladas.Text = "Canceladas  [" + vendaDb.contaRegistrosHoje("Cancelada").ToString() + "]";
            decimal canceladas = vendaDb.valorPorStatusData("Cancelada");
            //textVendasCanceladas.Text = vendaDb.contaRegistrosHoje("Cancelada").ToString();
            textVendasCanceladas.Text =  Valor(canceladas);


        }

        private void btnVendasSuspensas_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoginDb.caixaAberto() == true)
            {
                MessageBox.Show("O Caixa já esta aberto!");
            }
            else
            {
                FrmAberturaCaixa1 abertura = new FrmAberturaCaixa1();
                abertura.ShowDialog();
            }                
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCaixa caixa = new FrmCaixa();
            caixa.ShowDialog();
        }

        private void cadastrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmCadastroFornecedor cf = new FrmCadastroFornecedor(0);
            cf.ShowDialog();
        }

        private void atualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaFornecedor cf = new FrmConsultaFornecedor();
            cf.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        //clic no painel orcamentos suspensos
        private void lblOrcamentosSuspensos_Click(object sender, EventArgs e)
        {
            if (textSuspensos.Text != "0,00")
            {
                FrmOrcamentosSuspensos suspensos = new FrmOrcamentosSuspensos("Suspenso");
                suspensos.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }
        //clic no painel orcamentos em analise
        private void panelOrcamentoAnnalise_Click(object sender, EventArgs e)
        {
            if (textAnalise.Text != "0,00")
            {
                FrmOrcamentosSuspensos suspensos = new FrmOrcamentosSuspensos("Em Análise");
                suspensos.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }
        //clic no painel orcamentos aguardando aprovação    
        private void panelOrcamentoAguardando_Click(object sender, EventArgs e)
        {
            if (textConcluido.Text != "0,00")
            {
                FrmOrcamentosSuspensos suspensos = new FrmOrcamentosSuspensos("Concluído");
                suspensos.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }

        private void panelOrcamentoAprovados_Click(object sender, EventArgs e)
        {
            if (textAprovados.Text != "0,00")
            {
                FrmOrcamentosSuspensos suspensos = new FrmOrcamentosSuspensos("Aprovado");
                suspensos.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }

        private void panelOrcamentoCancelados_Click(object sender, EventArgs e)
        {
            if (textCancelados.Text != "0,00")
            {
                FrmOrcamentosSuspensos suspensos = new FrmOrcamentosSuspensos("Cancelado");
                suspensos.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }

        private void panellOsAguardandoPecas_Click(object sender, EventArgs e)
        {
            if (textOsAguarPecas.Text != "0,00")
            {
                FrmOsSuspensas suspensas = new FrmOsSuspensas("Suspensa");
                suspensas.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }

        private void panelOsEmAndamento_Click(object sender, EventArgs e)
        {
            if (textOsIniciadas.Text != "0,00")
            {
                FrmOsSuspensas suspensas = new FrmOsSuspensas("Em Andamento");
                suspensas.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            if (textOsPagPendente.Text != "0,00")
            {
                FrmOsSuspensas suspensas = new FrmOsSuspensas("Concluída - Não Pago");
                suspensas.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }

        private void panelOsFinalizadas_Click(object sender, EventArgs e)
        {
            if(textOsEntregues.Text != "0,00")
            {
                FrmOsSuspensas suspensas = new FrmOsSuspensas("Finalizada");
                suspensas.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }            
        }

        private void panelOsCanceladas_Click(object sender, EventArgs e)
        {
            if (textOsCanceladas.Text != "0,00")
            {
                FrmOsSuspensas suspensas = new FrmOsSuspensas("Cancelada");
                suspensas.ShowDialog();
                botoesOrcamento();
                botoesOrdemServico();
            }
        }

        private void panelVendasSuspensas_Click(object sender, EventArgs e)
        {
            if (textVendasSuspensas.Text != "0,00")
            {
                FrmVendasSuspensas vendas = new FrmVendasSuspensas("Suspensa");
                vendas.ShowDialog();
                botoesVendas();
            }
        }

        private void panelVendasFinalizadas_Click(object sender, EventArgs e)
        {
            if (textVendasFinalizadas.Text != "0,00")
            {
                FrmVendasSuspensas vendas = new FrmVendasSuspensas("Finalizada");
                vendas.ShowDialog();
                botoesVendas();
            }
        }

        private void panelVendasCanceladas_Click(object sender, EventArgs e)
        {
            if (textVendasCanceladas.Text != "0,00")
            {
                FrmVendasSuspensas vendas = new FrmVendasSuspensas("Cancelada");
                vendas.ShowDialog();
                botoesVendas();
            }
        }

        private void estoquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entradaProdutos en = new entradaProdutos();
            en.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaServico s = new FrmConsultaServico();
            s.ShowDialog();
        }

        private void aVencerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaCrediarios atrasados = new FrmConsultaCrediarios(1);
            atrasados.ShowDialog();
        }

        private void vencidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaCrediarios atrasados = new FrmConsultaCrediarios(3);
            atrasados.ShowDialog();
        }

        private void crediarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrediarioPorCliente credCliente = new FrmCrediarioPorCliente();
            credCliente.ShowDialog();

        }

        private void panelOrcamento_Click(object sender, EventArgs e)
        {
            FrmOrcamento f = new FrmOrcamento(usuario, 0);
            f.ShowDialog();
            botoesOrcamento();
        }

        private void panelVendas_Click(object sender, EventArgs e)
        {
            novaVenda();
        }

        private void panelOS_Click(object sender, EventArgs e)
        {
            FrmOrcamento f = new FrmOrcamento(usuario, 0);
            f.ShowDialog();
            botoesOrcamento();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFechamento f = new FrmFechamento();
            f.ShowDialog();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuarios c = new FrmCadastroUsuarios();
            c.ShowDialog();
        }

        private void novoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPedido pedido = new FrmPedido(0);
            pedido.ShowDialog();
        }

        private void consultarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmConsultaPedido conPedido = new FrmConsultaPedido();
            conPedido.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ImpressaoEtiquetas i = new ImpressaoEtiquetas();

            i.imprimeEtiquetas();
        }

        private void etiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEtiquetas etiquetas = new FrmEtiquetas();
            etiquetas.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable produtos = new DataTable();
            produtos = todos_produtos();
            EstoqueDb estoqueDb = new EstoqueDb();

            foreach (DataRow linha in produtos.Rows)
            {
                Estoque estoque = new Estoque();
                estoque.Estoque_atual = 5;
                estoque.Estoque_max = 10;
                estoque.Estoque_min = 2;
                estoque.Localizacao = "1A1";
                estoque.Unid_venda = "Unid";
                estoque.Pedido_em_endamento = false;
                estoque.Id_produto = Convert.ToInt32(linha[0]);

                estoqueDb.insere(estoque);
                
            }

        }


        public DataTable todos_produtos()
        {
            DataTable returProdutos = new DataTable();
            string sqlProduto = "SELECT * FROM `produto` ORDER BY `produto`.`id` ASC";
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

        private void iconPictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pnEstoqurZerado_Click(object sender, EventArgs e)
        {
            FrmRelatorioEstoqueZerado zerado = new FrmRelatorioEstoqueZerado(0);
            zerado.ShowDialog();
        }

        private void pnEstoqueBaixo_Click(object sender, EventArgs e)
        {
            FrmRelatorioEstoqueBaixo baixo = new FrmRelatorioEstoqueBaixo();
            baixo.ShowDialog();
        }
    }
}