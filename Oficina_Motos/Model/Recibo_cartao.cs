using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Recibo_cartao
    {
        private int id;

        private string cartao;

        private decimal valor;

        private string aut;

        string data_hora;

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

        public string Cartao
        {
            get
            {
                return cartao;
            }

            set
            {
                cartao = value;
            }
        }

        public decimal Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        public string Aut
        {
            get
            {
                return aut;
            }

            set
            {
                aut = value;
            }
        }

        public string Data_hora
        {
            get
            {
                return data_hora;
            }

            set
            {
                data_hora = value;
            }
        }
    }
}
