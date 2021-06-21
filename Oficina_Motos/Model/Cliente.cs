using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Cliente
    {
        private int id;

        private string nome;

        private string sexo;

        private string rg;

        private string cpf;

        private string data_nasc;

        private string status;

        private int id_contato;

        private int id_endereco;



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

        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public string Rg
        {
            get
            {
                return rg;
            }

            set
            {
                rg = value;
            }
        }

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public string Data_nasc
        {
            get
            {
                return data_nasc;
            }

            set
            {
                data_nasc = value;
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
    }
}
