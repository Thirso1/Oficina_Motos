using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Orcamento
    {
        private int id;

        private decimal valor;

        private string data;

        private TimeSpan hora;

        private string status;

        private int id_usuario;

        private int id_cliente;

        private int id_veiculo;



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

        public TimeSpan Hora
        {
            get
            {
                return hora;
            }

            set
            {
                hora = value;
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

        public int Id_veiculo
        {
            get
            {
                return id_veiculo;
            }

            set
            {
                id_veiculo = value;
            }
        }
    }
}
