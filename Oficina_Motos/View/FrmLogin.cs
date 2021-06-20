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
    public partial class FrmLogin : Form
    {
        Usuario usuario = new Usuario();
        UsuarioDb usuarioDb = new UsuarioDb();
        Login caixa_login = new Login();

       public Form1 form1 = new Form1();

        public FrmLogin(Login caixa_login)
        {
            InitializeComponent();
            this.caixa_login = caixa_login;
        }
        

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            textUsuario.Select();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            validacao();
        }

        private void textUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                textSenha.Select();
            }
        }

        private void textSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dispara evento na tecla enter
            if (e.KeyChar == 13)
            {
                validacao();
            }
        }

        private void validacao()
        {
            string login = textUsuario.Text;
            string senha = textSenha.Text;
            usuario = usuarioDb.consultaPorNome(login);
            if (usuario.Login == login && usuario.Senha == senha)
            {
                LoginDb.atualiza(1, caixa_login.Caixa_aberto, usuario.Login, usuario.Id);
                form1.Logado = true;
                this.Close();
            }
            else
            {
                form1.Logado = false;
                MessageBox.Show("Usuário não encontrado.");
                textSenha.Text = "";
                textUsuario.Text = "";
                textUsuario.Select();
            }
        }

        private void textUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            string nome = textUsuario.Text;
            //dgResultCliente.Columns[1].Width = 300;
            //dgResultCliente.Columns[2].Width = 100;
            //consultaPorNome(string nome)
        }
    }
}
               
