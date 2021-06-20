using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Fornecedor
    {
        private int id;

        private string nome;

        private string cnpj;

        private string vendedor;

        private string cel_vendedor;

        private int id_contato;

        private int id_endereco;

        private string status;

        private string site;

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

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Cnpj
        {
            get
            {
                return cnpj;
            }

            set
            {
                cnpj = value;
            }
        }

        public int Id_contato
        {
            get
            {
                return id_contato;
            }

            set
            {
                id_contato = value;
            }
        }

        public int Id_endereco
        {
            get
            {
                return id_endereco;
            }

            set
            {
                id_endereco = value;
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

        public string Vendedor
        {
            get
            {
                return vendedor;
            }

            set
            {
                vendedor = value;
            }
        }

        public string Cel_vendedor
        {
            get
            {
                return cel_vendedor;
            }

            set
            {
                cel_vendedor = value;
            }
        }

        public string Site
        {
            get
            {
                return site;
            }

            set
            {
                site = value;
            }
        }
    }
}
