using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Parcela
    {
        private int id;

        private int id_crediario;

        private int num_parcela;

        private decimal valor;

        private string vencimento;

        private decimal valor_recebido;

        private int status;



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

        public int Id_crediario
        {
            get
            {
                return id_crediario;
            }

            set
            {
                id_crediario = value;
            }
        }

        public int Num_parcela
        {
            get
            {
                return num_parcela;
            }

            set
            {
                num_parcela = value;
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

        public string Vencimento
        {
            get
            {
                return vencimento;
            }

            set
            {
                vencimento = value;
            }
        }

        public int Status
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

        public decimal Valor_recebido
        {
            get
            {
                return valor_recebido;
            }

            set
            {
                valor_recebido = value;
            }
        }
    }
}
