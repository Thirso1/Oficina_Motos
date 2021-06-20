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
    public partial class FrmCadastroFuncionarios : Form
    {
        public FrmCadastroFuncionarios(int id_funcionario)
        {
            InitializeComponent();
            this.funcionario.Id = id_funcionario;
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        Funcionario funcionario = new Funcionario();
        FuncionarioDb funcionarioDb = new FuncionarioDb();
        DataTable dtFuncionario = new DataTable();

        Contato contato = new Contato();
        ContatoDb contatoDb = new ContatoDb();

        Endereco endereco = new Endereco();
        EnderecoDb enderecoDb = new EnderecoDb();

        ClienteDb clienteDb = new ClienteDb();

        bool cpf;

        private void FrmCadastroFuncionarios_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
            cbTipoPessoa.SelectedIndex = 0;

            if (funcionario.Id == 0)
            {
                cadastrar();
            }
            else if(funcionario.Id > 0)
            {
                aditar();
            }
            txtnome.Select();
        }

        private void cadastrar()
        {
            funcionario.Id = funcionarioDb.geraCodFuncionario();
            txtCod.Text = funcionario.Id.ToString();
            lblCadFuncionario.Visible = true;
            btnSalvar.Visible = true;
            btnAtualizar.Visible = false;
        }

        private void aditar()
        {
            txtCod.Text = funcionario.Id.ToString();
            lblCadFuncionario.Visible = false;
            btnSalvar.Visible = false;
            btnAtualizar.Visible = true;



            dtFuncionario = funcionarioDb.consultaPorId(funcionario.Id.ToString());
            txtCod.Text = funcionario.Id.ToString();
            cbStatus.Text = dtFuncionario.Rows[0][8].ToString();
            txtnome.Text = dtFuncionario.Rows[0][1].ToString();
            txtcpf.Text = dtFuncionario.Rows[0][4].ToString();
          
            cbSexo.Text = dtFuncionario.Rows[0][2].ToString();
            txtRg.Text = dtFuncionario.Rows[0][3].ToString();
            txtNascimento.Text = dtFuncionario.Rows[0][5].ToString();


            contato = contatoDb.consultaPorId(dtFuncionario.Rows[0][6].ToString());
            txttelefone.Text = contato.Telefone_1;
            txttelefone_2.Text = contato.Telefone_2;
            txtEmail.Text = contato.Email;

            endereco = enderecoDb.consultaPorId(dtFuncionario.Rows[0][7].ToString());
            cbLogradouro.Text = endereco.Logradouro;
            txtrua.Text = endereco.Nome;
            txtnumero.Text = endereco.Numero;
            txtComplemento.Text = endereco.Complemento;
            txtReferencia.Text = endereco.Referencia;
            txtbairro.Text = endereco.Bairro;
            txtcidade.Text = endereco.Cidade;
            cbUf.Text = endereco.Uf;
            txtcep.Text = endereco.Cep;
        }

        private bool validaCampos()
        {
            if (txtcpf.Text == "   .   .   -")
            {
                return false;
                cbTipoPessoa.Select();
            }
            else if (txtnome.Text == "")
            {
                return false;
                txtnome.Select();
            }
            else if (txtrua.Text == "")
            {
                return false;
                txtrua.Select();
            }
            else if (txttelefone.Text == "" || txttelefone_2.Text == "")
            {
                return false;
                MessageBox.Show("Informe um telefone.");
                txttelefone.Select();
            }
            else if (cbLogradouro.Text == "")
            {
                return false;
                MessageBox.Show("Informe o logradouro");
                cbLogradouro.Select();
            }
            else if (txtrua.Text == "")
            {
                return false;
                txtrua.Select();
            }
            else if (txtnumero.Text == "")
            {
                return false;
                txtnumero.Select();
            }
            else if (txtbairro.Text == "")
            {
                return false;
                txtbairro.Select();
            }
            else
            {
                return true; ;
            }
        }

        private void salvar()
        {

            //gera novo id de contato
            contato.Id = contatoDb.geraCodContato();
            //gera novo id de endereço
            endereco.Id = enderecoDb.geraCodEndereco();

            contato.Telefone_1 = txttelefone.Text;
            contato.Telefone_2 = txttelefone_2.Text;
            contato.Email = txtEmail.Text;

            endereco.Logradouro = cbLogradouro.Text;
            endereco.Nome = txtrua.Text;
            endereco.Numero = txtnumero.Text;
            endereco.Complemento = txtReferencia.Text;
            endereco.Referencia = txtReferencia.Text;
            endereco.Bairro = txtbairro.Text;
            endereco.Cidade = txtcidade.Text;
            endereco.Uf = cbUf.Text;
            endereco.Cep = txtcep.Text;

            funcionario.Id = Convert.ToInt32(txtCod.Text);
            funcionario.Nome = txtnome.Text;
            funcionario.Sexo = cbSexo.Text;
            funcionario.Rg = txtRg.Text;
            funcionario.Cpf = txtcpf.Text;
            funcionario.Data_nasc = txtNascimento.Text;
            funcionario.Status = cbStatus.Text;
            funcionario.Id_contato = contato.Id;
            funcionario.Id_endereco = endereco.Id;

            contatoDb.insere(contato);
            enderecoDb.insere(endereco);
            funcionarioDb.insere(funcionario);

            MessageBox.Show("Cadastro realizado com sucesso.");
            DialogResult result = MessageBox.Show("Cadastrar novo Funcionário?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                limpaCamposCad();
                funcionario.Id = funcionarioDb.geraCodFuncionario();
                txtCod.Text = funcionario.Id.ToString();
                cbStatus.SelectedValue = "Ativo";
                txtnome.Select();
            }
            else
            {
                this.Close();
            }
        }

        private void atualizar()
        {
            contato.Telefone_1 = txttelefone.Text;
            contato.Telefone_2 = txttelefone_2.Text;
            contato.Email = txtEmail.Text;

            endereco.Logradouro = cbLogradouro.Text;
            endereco.Nome = txtrua.Text;
            endereco.Numero = txtnumero.Text;
            endereco.Complemento = txtReferencia.Text;
            endereco.Referencia = txtReferencia.Text;
            endereco.Bairro = txtbairro.Text;
            endereco.Cidade = txtcidade.Text;
            endereco.Uf = cbUf.Text;
            endereco.Cep = txtcep.Text;

            funcionario.Nome = txtnome.Text;
            funcionario.Sexo = cbSexo.Text;
            funcionario.Rg = txtRg.Text;
            funcionario.Cpf = txtcpf.Text;
            funcionario.Data_nasc = txtNascimento.Text;
            funcionario.Status = cbStatus.Text;
            funcionario.Id_contato = contato.Id;
            funcionario.Id_endereco = endereco.Id;

            contatoDb.atualiza(contato);
            enderecoDb.atualiza(endereco);
            funcionarioDb.atualiza(funcionario);

        }

        private void limpaCamposCad()
        {
            txtnome.Text = string.Empty;
            txtcpf.Text = string.Empty;
            txtrua.Text = string.Empty;
            txttelefone.Text = string.Empty;
            txttelefone_2.Text = string.Empty;
            cbLogradouro.Text = string.Empty;
            txtnumero.Text = string.Empty;
            txtbairro.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            txtcidade.Text = string.Empty;
            cbUf.Text = string.Empty;
            txtcep.Text = string.Empty;
            cbSexo.Text = string.Empty;
            txtRg.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNascimento.Text = string.Empty;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                salvar();
            }
        }

        private void txtcpf_Leave(object sender, EventArgs e)
        {
            if (txtcpf.Text == "   .   .   -")
            {
                txtcpf.BackColor = Color.White;
            }
            else
            {
                cpf = ValidaCpfCnpj.IsCpf(txtcpf.Text);
                bool existeCpf = funcionarioDb.cpfJaCadastrado(txtcpf.Text);
                if (!cpf)
                {
                    MessageBox.Show("CPF inválido!");
                    txtcpf.Text = "";
                    txtcpf.Select();
                }
                else if (existeCpf)
                {
                    MessageBox.Show("CPF já cadastrado!");
                    txtcpf.Text = "";
                    txtcpf.Select();
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                atualizar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaCamposCad();
        }

        private void FrmCadastroFuncionarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
