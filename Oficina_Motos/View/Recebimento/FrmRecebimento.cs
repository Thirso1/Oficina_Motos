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
    public partial class FrmRecebimento : Form
    {
        public FrmRecebimento(int numero, int tipo, decimal valor, string id_cliente)//primeiro parametro = numero da venda ou Os, segundo parametro = 1 para venda, 2 para OS, 3 para parcelas
        {
            InitializeComponent();
            this.tipo = tipo;
            this.valor = valor;
            this.numero = numero;
            this.id_cliente = id_cliente;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        string id_cliente;
        int tipo;
        int numero;
        decimal valor;
        decimal desconto = 0;
        decimal valorPago = 0;
        decimal receber = 0;
        decimal restante = 0;
        decimal descontoPorcent = 0;
        decimal descontoReais = 0;
        decimal valorComDesconto = 0;

        private FrmOsSuspensas osSuspensas;
        public FrmOsSuspensas OsSuspensas
        {
            get
            {
                return osSuspensas;
            }

            set
            {
                osSuspensas = value;
            }
        }

        private FrmConsultaOrdemServico consultaOs;
        public FrmConsultaOrdemServico ConsultaOs
        {
            get { return consultaOs; }
            set { consultaOs = value; }
        }

        private FrmPdv pdv;
        public FrmPdv Pdv
        {
            get { return pdv; }
            set { pdv = value; }
        }

        private FrmOrdemServico os;
        public FrmOrdemServico Os
        {
            get { return os; }
            set { os = value; }
        }

        private FrmExibeCrediario crediario;
        public FrmExibeCrediario Crediario
        {
            get { return crediario; }
            set { crediario = value; }
        }

        private bool recebido = false;
        public bool Recebido
        {
            get
            {
                return recebido;
            }

            set
            {
                recebido = value;
            }
        }

        private void confirmaRecebimento()
        {
            //listar aqui os forms que chamaram essa tela
            switch (tipo)
            {
                case 1:
                    Pdv.Confirma_pagamento = true;
                    break;
                case 2:
                    Os.Confirma_pagamento = true;
                    break;
                case 22:
                    OsSuspensas.Confirma_pagamento = true;
                    break;
                case 222:
                    ConsultaOs.Confirma_pagamento = true;
                    break;
                case 3:
                    Crediario.Confirma_pagamento = true;
                    break;
            }

        }
        Login login = new Login();

        private void FrmRecebimento_Load(object sender, EventArgs e)
        {
            login = LoginDb.caixa_login();
            textTotal.Text = valor.ToString();
            textValorPago.Text = "0,00";
            textDescontoPorcet.Text = "0,00";
            textRestante.Text = calculaRestante(desconto).ToString();
            if (tipo == 3)
            {
                btnCrediario.Enabled = false;
            }
            textValorDigitado.Text = valor.ToString();
            textDescontoReais.Text = "0,00";

            textDescontoPorcet.Select();
            textDescontoPorcet.Visible = true;
            }

   

        private void gridPagamentos(int formaPag)
        {
            switch (formaPag)
            {
                case 1:
                    dataGridView1.Rows.Add("Dinheiro", Fluxo_caixaDb.ultimoLancamento());
                    dataGridView1.ClearSelection();
                    break;
                case 2:
                    dataGridView1.Rows.Add("Cartão", Fluxo_caixaDb.ultimoLancamento());
                    dataGridView1.ClearSelection();
                    break;
                case 3:
                    dataGridView1.Rows.Add("Cheque", Fluxo_caixaDb.ultimoLancamento());
                    dataGridView1.ClearSelection();
                    break;
                case 4:
                    CrediarioDb crediarioDb = new CrediarioDb();
                    dataGridView1.Rows.Add("Crediário", crediarioDb.ultimoLancamento());
                    dataGridView1.ClearSelection();
                    break;
            }
        }

        private void resultado(int formaPag)
        {
            if (Recebido == true)
            {
                gridPagamentos(formaPag);
                //valorPago é o valor digitado
                valorPago += receber;
                textValorPago.Text = valorPago.ToString();

                if (calculaRestante(desconto) == 0)
                {
                    confirmaRecebimento();
                    MessageBox.Show("Pagamento concluído.");
                    this.Close();
                }
                else if (calculaRestante(desconto) > 0)
                {
                    textRestante.Text = calculaRestante(desconto).ToString();
                    textValorDigitado.Text = "";
                    textValorDigitado.Select();
                    textRestante.Text = calculaRestante(desconto).ToString();
                    Recebido = false;
                }
            }
        }

        private void textValorDigitado_KeyUp(object sender, KeyEventArgs e)
        {
            textValorDigitado.Text = MascaraDecimal.mascara(textValorDigitado.Text);
            textValorDigitado.SelectionStart = textValorDigitado.TextLength + 1;
        }

        public void conta_ocorrencias(char caracter, string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == caracter)
                {
                    count++;
                }
            }
            if (count > 1)
            {
                textValorDigitado.Text = "";
            }
        }

        private void FrmRecebimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ////MessageBox.Show(calculaRestante().ToString());

            //if (calculaRestante() == valor)
            //{
            //    e.Cancel = false;
            //}
            if (calculaRestante(desconto) == 0 || calculaRestante(desconto) == valor)
            {
                e.Cancel = false;
            }
            else if (calculaRestante(desconto) > 0 || calculaRestante(desconto) < valor)
            {
                e.Cancel = true;
                MessageBox.Show("Ainda existe saldo a receber!");
            }
        }

        private void textValorDigitado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == 8))
            {
                textValorDigitado.Text = "";
                textValorDigitado.Select();
            }
            if ((e.KeyChar == 13))
            {
                btnDinheiro.Select();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void textDescontoReais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                textDescontoReais.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                textDescontoReais.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                descontoEmReais();
            }
        }

        private void textDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //deleta tudo pelo backspace
            if (e.KeyChar == 8)
            {
                textDescontoPorcet.Text = "";
            }
            //evita duas virgulas no campo
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                textDescontoPorcet.Text = "";
            }
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                descontoPorcentagem();
            }
        }

        private decimal descontoPorcentagem()
        {
            if (textDescontoPorcet.Text == "")
            {
                textDescontoPorcet.Text = "0";
            }
            else
            {
                descontoPorcent = Convert.ToDecimal(textDescontoPorcet.Text);
            }
            if (descontoPorcent > 30)
            {
                MessageBox.Show("Desconto não permitido!");
                textDescontoPorcet.Text = "";
                textDescontoPorcet.Select();
                return 0;
            }
            else
            {
                desconto = (valor / 100) * descontoPorcent;
                desconto = Math.Round(desconto, 2);
                textDescontoReais.Text = desconto.ToString();
                btnDinheiro.Select();
                calculaRestante(desconto);
                receber = calculaRestante(desconto);

                textValorDigitado.Text = receber.ToString();
                return desconto;
            }
        }

        private decimal descontoEmReais()
        {
            if (textDescontoReais.Text == "")
            {
                textDescontoReais.Text = "0";
            }
            desconto = Convert.ToDecimal(textDescontoReais.Text);
            descontoPorcent = (desconto * 100) / valor;
            descontoPorcent = Math.Round(descontoPorcent, 2);

            if (descontoPorcent > 30)
            {
                MessageBox.Show("Desconto não permitido!");
                textDescontoReais.Text = "";
                textDescontoReais.Select();
                return 0;
            }
            else
            {
                textDescontoPorcet.Text = descontoPorcent.ToString();
                btnDinheiro.Select();
                calculaRestante(desconto);
                receber = calculaRestante(desconto);
                textValorDigitado.Text = receber.ToString();
                return descontoReais;
            }            
        }

        decimal calculaRestante(decimal desconto)
        {
         
            valorComDesconto = valor - desconto;
            //MessageBox.Show("valor com desconto  " + valorComDesconto.ToString());
            //MessageBox.Show("valor pago    " + valorPago.ToString());

            restante = valorComDesconto - valorPago;
            textRestante.Text = restante.ToString();
            return restante;
        }

        private void textDescontoPorcet_KeyUp(object sender, KeyEventArgs e)
        {
            textDescontoPorcet.Text = MascaraDecimal.mascara(textDescontoPorcet.Text);
            textDescontoPorcet.SelectionStart = textDescontoPorcet.TextLength + 1;
        }

        private void textDescontoReais_KeyUp(object sender, KeyEventArgs e)
        {
            textDescontoReais.Text = MascaraDecimal.mascara(textDescontoReais.Text);
            textDescontoReais.SelectionStart = textDescontoReais.TextLength + 1;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (textValorDigitado.Text == "")
            {

            }
            else
            {
                receber = Convert.ToDecimal(textValorDigitado.Text);
                if (receber > calculaRestante(desconto))
                {
                    MessageBox.Show("Valor acima...");
                }
                else if (receber <= calculaRestante(desconto))
                {
                    FrmTroco troco = new FrmTroco(tipo, receber);//1 para venda, receber para o valor a receber
                    troco.Recebimento = this;
                    troco.ShowDialog();
                    resultado(1);
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (textValorDigitado.Text == "")
            {

            }
            else
            {
                receber = Convert.ToDecimal(textValorDigitado.Text);
                if (receber > calculaRestante(desconto))
                {
                    MessageBox.Show("Valor acima...");
                }
                else if (receber <= calculaRestante(desconto))
                {
                    FrmCartao cartao = new FrmCartao(tipo, receber);//1 para venda, receber para o valor a receber
                    cartao.Recebimento = this;
                    cartao.ShowDialog();

                    resultado(2);
                }
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (textValorDigitado.Text == "")
            {

            }
            else
            {
                receber = Convert.ToDecimal(textValorDigitado.Text);
                if (receber > calculaRestante(desconto))
                {
                    MessageBox.Show("Valor acima...");
                }
                else if (receber <= calculaRestante(desconto))
                {
                    FrmCheque cheque = new FrmCheque(tipo, receber);//1 para venda, receber para o valor a receber
                    cheque.Recebimento = this;
                    cheque.ShowDialog();

                    resultado(3);
                }
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            
            receber = calculaRestante(desconto);
            textValorDigitado.Text = receber.ToString();
            //id, oque esta sendo parcelado, total, valor a parcelar, entrada
            FrmCrediario crediario = new FrmCrediario(numero, tipo, valor, receber, valorPago, id_cliente);
            crediario.Recebimento = this;
            crediario.ShowDialog();

            resultado(4);
        }
    }
}