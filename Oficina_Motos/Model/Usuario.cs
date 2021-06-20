using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Usuario
    {
        private int id;

        private string login;

        private string senha;

        private string status;

        private int id_funcionario;

        private string perfil;


        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Perfil
        {
            get
            {
                return perfil;
            }

            set
            {
                perfil = value;
            }
        }

        public int Id_funcionario
        {
            get
            {
                return id_funcionario;
            }

            set
            {
                id_funcionario = value;
            }
        }
    }
}
