using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Login
    {
        private int id;

        private bool caixa_aberto;

        private string usuario;

        private int id_usuario;

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

        public bool Caixa_aberto
        {
            get
            {
                return caixa_aberto;
            }

            set
            {
                caixa_aberto = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public int Id_usuario
        {
            get
            {
                return id_usuario;
            }

            set
            {
                id_usuario = value;
            }
        }
    }
}
