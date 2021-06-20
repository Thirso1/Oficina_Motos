using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Venda
    {
        private int id;

        private string data_hora;

        private decimal valor_total;

        private decimal desconto;

        private string status;

        private int id_usuario;

        private int id_cliente;



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

        public decimal Valor_total
        {
            get
            {
                return valor_total;
            }

            set
            {
                valor_total = value;
            }
        }

        public decimal Desconto
        {
            get
            {
                return desconto;
            }

            set
            {
                desconto = value;
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
