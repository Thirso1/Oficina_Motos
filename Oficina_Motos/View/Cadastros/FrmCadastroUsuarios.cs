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
    public partial class FrmCadastroUsuarios : Form
    {
        public FrmCadastroUsuarios()
        {
            InitializeComponent();
            MudaCorTextBox.RegisterFocusEvents(this.Controls);
        }

        Usuario usuarioLogado = new Usuario();
        Usuario usuario = new Usuario();
        UsuarioDb usuarioDb = new UsuarioDb();
        DataTable existeUsuario = new DataTable();
        int id_funcionario;

        private void FrmCadastroUsuarios_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login = LoginDb.caixa_login();
            povoaGrid();
            panelAtualiza.Visible = false;
            usuarioLogado = usuarioDb.consultaPorID(login.Id_usuario);
        }

        private void povoaGrid()
        {
            FuncionarioDb funcionarioDb = new FuncionarioDb();
            dgUsuarios.DataSource = funcionarioDb.funcionariosAtivos();
            dgUsuarios.ClearSelection();
        }

        private void dgUsuarios_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            existeUsuario.Rows.Clear();
            limpaCampos();
            // vamos obter a linha da célula selecionada
            DataGridViewRow linhaAtual = dgUsuarios.CurrentRow;
            // vamos exibir o índice da linha atual
            int indice = linhaAtual.Index;
            id_funcionario = Convert.ToInt32(dgUsuarios.Rows[indice].Cells[0].Value);
            string funcionario = dgUsuarios.Rows[indice].Cells[1].Value.ToString();
            //MessageBox.Show(id_item);
            existeUsuario = usuarioDb.consultaIdFuncionario(id_funcionario);

            if (existeUsuario.Rows.Count > 0)
            {
                panelNovo.Visible = false;
                panelAtualiza.Visible = true;


                usuario.Id = Convert.ToInt32(existeUsuario.Rows[0][0]);
                usuario.Login = existeUsuario.Rows[0][1].ToString();
                usuario.Senha = existeUsuario.Rows[0][2].ToString();
                usuario.Status = existeUsuario.Rows[0][5].ToString();
                usuario.Perfil = existeUsuario.Rows[0][4].ToString();
                usuario.Id_funcionario = Convert.ToInt32(existeUsuario.Rows[0][3]);

                textFuncionarioAtu.Text = funcionario;
                textLoginAtu.Text = usuario.Login;
                cbPerfilAtu.Text = usuario.Perfil;
                cbStatusAtu.Text = usuario.Status;


                btnExcluir.Enabled = true;
                textFuncionarioAtu.Enabled = false;
                textLoginAtu.Enabled = false;

            }
            else
            {
                limpaCampos();
                txtFuncionario.Text = funcionario;
                panelAtualiza.Visible = false;
                panelNovo.Visible = true;
                panelNovo.BringToFront();
                btnExcluir.Enabled = false;
                txtFuncionario.Enabled = false;
            }
        }

        private bool valicaCamposNovo()
        {
            if (txtFuncionario.Text == "")
            {
                MessageBox.Show("Selecione um Funcionário");
                txtFuncionario.Select();
                return false;
            }
            else if (txtLogin.Text == "")
            {
                MessageBox.Show("Preencha o campo Login");
                txtLogin.Select();
                return false;
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Preencha o campo Senha");
                txtSenha.Select();
                return false;
            }
            else if (txtSenha.Text != txtConfirmaSenha.Text)
            {
                MessageBox.Show("Senhas diferentes");
                txtSenha.Text = string.Empty;
                txtConfirmaSenha.Text = string.Empty;
                txtSenha.Select();
                return false;
            }
            else if (cbPerfil.Text == "")
            {
                MessageBox.Show("Selecione o Perfil");
                return false;
            }
            else
            {
                if (cbStatus.Text == "")
                {
                    cbStatus.Text = "Ativo";
                }
                return true;
            }
        }

        private bool senhasAtualizacaoVazias()
        {
            if (txtNovaSenha.Text == "" && TextConfirmaSenhaAtu.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool confirmaSenhaAntiga()
        {
            string login = textLoginAtu.Text;
            string senha = txtSenhaAntiga.Text;
            Usuario usuario = new Usuario();
            usuario = usuarioDb.consultaPorNome(login);
            if (usuario.Login == login && usuario.Senha == senha)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        private bool valicaCamposAtualizar()
        {
            if (textFuncionarioAtu.Text == "")
            {
                MessageBox.Show("Selecione um Funcionário");
                txtFuncionario.Select();
                return false;
            }
            else if (textLoginAtu.Text == "")
            {
                MessageBox.Show("Preencha o campo Login");
                txtLogin.Select();
                return false;
            }
            else if (!senhasAtualizacaoVazias())
            {
                txtNovaSenha.Select();
                return false;
            }
            else if (!confirmaSenhaAntiga())
            {
                MessageBox.Show("Senha antiga não confere.");
                txtSenhaAntiga.Text = string.Empty;
                txtSenhaAntiga.Select();
                return false;
            }
            else if (txtNovaSenha.Text != TextConfirmaSenhaAtu.Text)
            {
                MessageBox.Show("Senhas diferentes");
                txtSenha.Text = string.Empty;
                txtConfirmaSenha.Text = string.Empty;
                txtSenha.Select();
                return false;
            }
            else if (cbPerfilAtu.Text == "")
            {
                MessageBox.Show("Selecione o Perfil");
                return false;
            }
            else
            {
                if (cbStatus.Text == "")
                {
                    cbStatus.Text = "Ativo";
                }
                return true;
            }
        }

        private void limpaCampos()
        {
            //txtCod.Text = "";
            //txtConfirmaFuncionario.Text = "";
            txtFuncionario.Text = "";
            textFuncionarioAtu.Text = "";

            txtLogin.Text = "";
            textLoginAtu.Text = "";

            txtSenha.Text = "";
            txtConfirmaSenha.Text = "";

            txtSenhaAntiga.Text = "";
            txtNovaSenha.Text = "";
            TextConfirmaSenhaAtu.Text = "";

            cbPerfil.Text = "";
            cbPerfilAtu.Text = "";

            cbStatus.Text = "";
            cbStatusAtu.Text = "";


        }

        private bool verificaNomeLogin(string login)
        {
            bool existeNome;

            DataTable _existeNome = usuarioDb.consultaNomeUsuario(login);
            if (_existeNome.Rows.Count > 0)
            {
                existeNome = true;
            }
            else
            {
                existeNome = false;
            }
            return existeNome;
        }

        private void cadastrarOutro()
        {
            DialogResult result = MessageBox.Show("Deseja realizar outro cadastro?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                limpaCampos();
                usuario.Login = "";
                usuario.Senha = "";
                usuario.Perfil = "";
                usuario.Status = "";
            }
            else
            {
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (valicaCamposNovo())
            {
                usuario.Login = txtLogin.Text;
                usuario.Senha = txtSenha.Text;
                usuario.Status = cbStatus.Text;
                usuario.Perfil = cbPerfil.Text;
                usuario.Id_funcionario = id_funcionario;

                usuarioDb.insere(usuario);
                cadastrarOutro();
            }
        }
 
        private void txtLogin_Leave(object sender, EventArgs e)
        {
            if (verificaNomeLogin(txtLogin.Text))
            {
                MessageBox.Show("Login já utilizado.");
                txtLogin.Text = "";
                txtLogin.Select();
            }
        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            if (txtSenhaAntiga.Text == "" & txtNovaSenha.Text == "" & TextConfirmaSenhaAtu.Text == "")
            {
                DialogResult result = MessageBox.Show("Deseja atualizar apenas o \"Perfil\"?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    usuario.Perfil = cbPerfilAtu.Text;
                    usuarioDb.atualiza(usuario);
                    cadastrarOutro();
                }

            }
            else
            {

                if (valicaCamposAtualizar())
                {
                    //usuario.Id = Convert.ToInt32(txtCod.Text);
                    usuario.Login = textLoginAtu.Text;
                    usuario.Senha = txtNovaSenha.Text;
                    usuario.Status = cbStatusAtu.Text;
                    usuario.Perfil = cbPerfilAtu.Text;
                    usuario.Id_funcionario = id_funcionario;

                    usuarioDb.atualiza(usuario);
                    cadastrarOutro();
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            usuario.Id = usuarioDb.geraCodUsuario();
            usuario.Login = "";
            usuario.Senha = "";
            usuario.Perfil = "";
            usuario.Status = "";

            //txtCod.Text = usuario.Id.ToString();
            btnAtualizar.Visible = false;
            btnSalvar.Visible = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
         
        }

        private void textLoginAtu_Leave(object sender, EventArgs e)
        {
            if (verificaNomeLogin(textLoginAtu.Text))
            {
                MessageBox.Show("Login já utilizado.");
                textLoginAtu.Text = "";
                textLoginAtu.Select();
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (id_funcionario == 0)
            {
                MessageBox.Show("Esse Usuário não pode ser excluído");
            }
            else
            {
                DialogResult result = MessageBox.Show("Deseja excluir o usuário?", "Cancela", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    usuarioDb.delete(id_funcionario);
                    limpaCampos();
                }
            }
        }
    }
}
