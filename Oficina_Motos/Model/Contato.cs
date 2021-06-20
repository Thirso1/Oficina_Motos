using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Contato
    {
        private int id;

        private string telefone_1;

        private string telefone_2;

        private string email;



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

        public string Telefone_1
        {
            get
            {
                return telefone_1;
            }

            set
            {
                telefone_1 = value;
            }
        }

        public string Telefone_2
        {
            get
            {
                return telefone_2;
            }

            set
            {
                telefone_2 = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
    }
}
