﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Funcionario
    {
        private int id;

        private string nome;

        private string sexo;

        private string rg;

        private string cpf;

        private string data_nasc;

        private Contato contato;

        private Endereco endereco;

        private string status;
        

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

        public Contato Contato { get => contato; set => contato = value; }
        public Endereco Endereco { get => endereco; set => endereco = value; }
    }
}
