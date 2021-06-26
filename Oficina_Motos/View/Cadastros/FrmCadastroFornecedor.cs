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
    public partial class FrmCadastroFornecedor : Form
    {
        Fornecedor fornecedor = new Fornecedor();
        FornecedorDb fornecedorDb = new FornecedorDb();
        DataTable dtFornecedor = new DataTable();

        Contato contato = new Contato();
        ContatoDb contatoDb = new ContatoDb();
        DataTable dtContato = new DataTable();

        Endereco endereco = new Endereco();
        EnderecoDb enderecoDb = new EnderecoDb();
        DataTable dtEndereco = new DataTable();

        int id_fornecedor;
        int id_contato;
        int id_endereco;


        public FrmCadastroFornecedor(int id_fornecedor)
        {
            InitializeComponent();
            this.id_fornecedor = id_fornecedor;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        private void FrmCadastroFornecedor_Load(object sender, EventArgs e)
        {
            if (id_fornecedor == 0)
            {
                novo();
            }
            else
            {
                editar();
            }
            cbStatus.Text = "Ativo";
        }

        private void novo()
        {
            id_fornecedor = fornecedorDb.geraCodFornecedor();
            id_contato = contatoDb.geraCodContato();
            id_endereco = enderecoDb.geraCodEndereco();

            txtCod.Text = id_fornecedor.ToString();
            btnAtualizar.Visible = false;
            btnSalvar.Visible = true;
        }

        private void editar()
        {
            //objeto fornecedor
            fornecedor = fornecedorDb.consultaPorId(id_fornecedor);

            txtCod.Text = fornecedor.Id.ToString();
            cbStatus.Text = "Ativo";
            txtNome.Text = fornecedor.Nome;
            txtCnpj.Text = fornecedor.Cnpj;
            txtSite.Text = fornecedor.Site;

            //objeto contado
            contato = contatoDb.consultaPorId(fornecedor.Id_contato);
            txtTelefone1.Text = contato.Telefone_1;
            txtTelefone2.Text = contato.Telefone_2;
            txtEmail.Text = contato.Email;

            //objeto endereco
            endereco = enderecoDb.consultaPorId(fornecedor.Id_endereco);
            cbLogradouro.Text = endereco.Logradouro;
            txtRua.Text = endereco.Nome;
            txtNumero.Text = endereco.Numero;
            txtComplemento.Text = endereco.Complemento;
            txtReferencia.Text = endereco.Referencia;
            txtBairro.Text = endereco.Bairro;
            txtCidade.Text = endereco.Cidade;
            cbUf.Text = endereco.Uf;
            txtCep.Text = endereco.Cep;

            txtVendedor.Text = fornecedor.Vendedor;
            txtCelVendedor.Text = fornecedor.Cel_vendedor;

            btnAtualizar.Visible = true;
            btnLimparAtu.Enabled = false;
            btnSalvar.Visible = false;
        }

        private bool validaCampos()
        {
            if (txtCnpj.Text == "   .   .   /    -")
            {
                MessageBox.Show("Informe o CNPJ");
                txtCnpj.BackColor = Color.Tomato;
                txtCnpj.Select();
                return false;
            }
            else if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o nome.");
                txtNome.BackColor = Color.Tomato;
                txtNome.Select();
                return false;
            }
            else if (txtTelefone1.Text == "" || txtTelefone2.Text == "")
            {
                MessageBox.Show("Informe um telefone.");
                txtTelefone1.BackColor = Color.Tomato;
                txtTelefone2.BackColor = Color.Tomato;
                txtTelefone1.Select();
                return false;
            }
            else if (txtVendedor.Text == "")
            {
                MessageBox.Show("Informe o vendedor.");
                txtVendedor.BackColor = Color.Tomato;
                txtVendedor.Select();
                return false;
            }
            else if (txtCelVendedor.Text == "")
            {
                MessageBox.Show("Informe o Celular do vendedor.");
                txtCelVendedor.BackColor = Color.Tomato;
                txtCelVendedor.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void salvar()
        {
            contato.Id = id_contato;
            contato.Telefone_1 = txtTelefone1.Text;
            contato.Telefone_2 = txtTelefone2.Text;
            contato.Email = txtEmail.Text;

            endereco.Id = id_endereco;
            endereco.Logradouro = cbLogradouro.Text;
            endereco.Nome = txtRua.Text;
            endereco.Numero = txtNumero.Text;
            endereco.Complemento = txtComplemento.Text;
            endereco.Referencia = txtReferencia.Text;
            endereco.Bairro = txtBairro.Text;
            endereco.Cidade = txtCidade.Text;
            endereco.Uf = cbUf.Text;

            endereco.Cep = txtCep.Text;

            fornecedor.Id = id_fornecedor;
            fornecedor.Nome = txtNome.Text;
            fornecedor.Cnpj = txtCnpj.Text;
            fornecedor.Id_contato = contato.Id;
            fornecedor.Id_endereco = endereco.Id;
            fornecedor.Status = cbStatus.Text;
            fornecedor.Site = txtSite.Text;

            fornecedor.Vendedor = txtVendedor.Text;
            fornecedor.Cel_vendedor = txtCelVendedor.Text;

            try
            {
                //chama o metodo que grava
                contatoDb.insere(contato);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            try
            {
                //chama o metodo que grava
                enderecoDb.insere(endereco);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            try
            {
                //chama o metodo que grava
                fornecedorDb.insere(fornecedor);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
        }

        private void atualizar()
        {
            contato.Id = fornecedor.Id_contato;
            contato.Telefone_1 = txtTelefone1.Text;
            contato.Telefone_2 = txtTelefone2.Text;
            contato.Email = txtEmail.Text;
            MessageBox.Show(contato.Id.ToString());

            endereco.Id = fornecedor.Id_endereco;
            endereco.Logradouro = cbLogradouro.Text;
            endereco.Nome = txtRua.Text;
            endereco.Numero = txtNumero.Text;
            endereco.Complemento = txtComplemento.Text;
            endereco.Referencia = txtReferencia.Text;
            endereco.Bairro = txtBairro.Text;
            endereco.Cidade = txtCidade.Text;
            endereco.Uf = cbUf.Text;
            endereco.Cep = txtCep.Text;

            fornecedor.Id = Convert.ToInt32(txtCod.Text);
            fornecedor.Nome = txtNome.Text;
            fornecedor.Cnpj = txtCnpj.Text;
            fornecedor.Id_contato = contato.Id;
            fornecedor.Id_endereco = endereco.Id;
            fornecedor.Status = cbStatus.Text;
            fornecedor.Site = txtSite.Text;

            fornecedor.Vendedor = txtVendedor.Text;
            fornecedor.Cel_vendedor = txtCelVendedor.Text;

            try
            {
                //chama o metodo que grava
                contatoDb.atualiza(contato);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            try
            {
                //chama o metodo que grava
                enderecoDb.atualiza(endereco);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
            try
            {
                //chama o metodo que grava
                fornecedorDb.atualiza(fornecedor);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaCampos() == true)
            {
                salvar();
                DialogResult result = MessageBox.Show("Cadastrar novo Fornecedor?", "Cancela", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    limpar();
                    novo();
                    txtNome.Select();
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (validaCampos() == true)
            {
                atualizar();
                MessageBox.Show("Fornecedor atualizado");
                this.Close();
            }
        }

        private void limpar()
        {

            txtCod.Text = string.Empty;
            cbStatus.Text = "Ativo";
            txtNome.Text = string.Empty;
            txtCnpj.Text = string.Empty;
            //objeto contado
            txtTelefone1.Text = string.Empty;
            txtTelefone2.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSite.Text = string.Empty;

            //objeto endereco
            cbLogradouro.SelectedIndex = 0;
            txtRua.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            cbUf.Text = string.Empty;
            txtCep.Text = string.Empty;
        }

        private void panelAtualizar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimparAtu_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void FrmCadastroFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
