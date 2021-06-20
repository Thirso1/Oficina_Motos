using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Veiculo
    {
        private int id;
        private string descricao;
        private string marca;
        private string modelo;
        private string ano;
        private string cor;
        private string placa;
        private string defeito;
        private string problema_verificado;
        private string observacao;
        private string km;

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

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        public string Marca
        {
            get
            {
                return marca;
            }

            set
            {
                marca = value;
            }
        }

        public string Modelo
        {
            get
            {
                return modelo;
            }

            set
            {
                modelo = value;
            }
        }

        public string Ano
        {
            get
            {
                return ano;
            }

            set
            {
                ano = value;
            }
        }

        public string Cor
        {
            get
            {
                return cor;
            }

            set
            {
                cor = value;
            }
        }

        public string Placa
        {
            get
            {
                return placa;
            }

            set
            {
                placa = value;
            }
        }

        public string Defeito
        {
            get
            {
                return defeito;
            }

            set
            {
                defeito = value;
            }
        }

        public string Observacao
        {
            get
            {
                return observacao;
            }

            set
            {
                observacao = value;
            }
        }

        public string Km
        {
            get
            {
                return km;
            }

            set
            {
                km = value;
            }
        }

        public string Problema_verificado
        {
            get
            {
                return problema_verificado;
            }

            set
            {
                problema_verificado = value;
            }
        }
    }
}
