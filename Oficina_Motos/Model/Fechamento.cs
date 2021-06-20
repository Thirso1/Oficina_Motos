using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Fechamento
    {
        private int id;

        private string data_hora;

        private decimal entradaDinheiro;

        private decimal entradaCartao;

        private decimal entradaCheque;

        private decimal saidaDinheiro;

        private decimal saidaCheque;

        private decimal saldoDinheiro;

        private decimal saldoCheque;

        private decimal recolhimentoCheque;

        private decimal recolhimentoDinheiro;

        private decimal fundoCaixa;

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

        public decimal EntradaDinheiro
        {
            get
            {
                return entradaDinheiro;
            }

            set
            {
                entradaDinheiro = value;
            }
        }

        public decimal EntradaCartao
        {
            get
            {
                return entradaCartao;
            }

            set
            {
                entradaCartao = value;
            }
        }

        public decimal EntradaCheque
        {
            get
            {
                return entradaCheque;
            }
            
            set
            {
                entradaCheque = value;
            }
        }

        public decimal SaidaDinheiro
        {
            get
            {
                return saidaDinheiro;
            }

            set
            {
                saidaDinheiro = value;
            }
        }

        public decimal SaidaCheque
        {
            get
            {
                return saidaCheque;
            }

            set
            {
                saidaCheque = value;
            }
        }   

        public decimal SaldoDinheiro
        {
            get
            {
                return saldoDinheiro;
            }

            set
            {
                saldoDinheiro = value;
            }
        }

        public decimal SaldoCheque
        {
            get
            {
                return saldoCheque;
            }

            set
            {
                saldoCheque = value;
            }
        }

        public decimal RecolhimentoCheque
        {
            get
            {
                return recolhimentoCheque;
            }

            set
            {
                recolhimentoCheque = value;
            }
        }

        public decimal RecolhimentoDinheiro
        {
            get
            {
                return recolhimentoDinheiro;
            }

            set
            {
                recolhimentoDinheiro = value;
            }
        }

        public decimal FundoCaixa
        {
            get
            {
                return fundoCaixa;
            }

            set
            {
                fundoCaixa = value;
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
