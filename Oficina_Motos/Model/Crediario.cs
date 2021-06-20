using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Crediario
    {
        private int id;

        private int id_cliente;

        private string referencia;

        private int num_referencia;

        private decimal entrada;

        private decimal valor_parcelado;

        private int num_parcelas;

        private string data;

        string status;



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

        public string Referencia
        {
            get
            {
                return referencia;
            }

            set
            {
                referencia = value;
            }
        }

        public int Num_referencia
        {
            get
            {
                return num_referencia;
            }

            set
            {
                num_referencia = value;
            }
        }

        public decimal Entrada
        {
            get
            {
                return entrada;
            }

            set
            {
                entrada = value;
            }
        }

        public decimal Valor_parcelado
        {
            get
            {
                return valor_parcelado;
            }

            set
            {
                valor_parcelado = value;
            }
        }

        public int Num_parcelas
        {
            get
            {
                return num_parcelas;
            }

            set
            {
                num_parcelas = value;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
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

        public int Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
            }
        }
    }
}
