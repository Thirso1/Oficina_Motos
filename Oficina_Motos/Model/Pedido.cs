using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Pedido
    {
        private int id;
        private string data;
        private decimal valor;
        private string status;
        private int id_usuario;
        private int id_fornecedor;



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

        public int Id_fornecedor
        {
            get
            {
                return id_fornecedor;
            }

            set
            {
                id_fornecedor = value;
            }
        }

    }
}
