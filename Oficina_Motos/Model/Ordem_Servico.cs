using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina_Motos.Controler;

namespace Oficina_Motos.Model
{
    class Ordem_Servico
    {
        private int id;

        private string data_hora_inicio;

        private string data_hora_fim;

        private decimal valor;

        private string status;

        private int id_cliente;

        private int id_veiculo;

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

        public string Data_hora_inicio
        {
            get
            {
                return data_hora_inicio;
            }

            set
            {
                data_hora_inicio = value;
            }
        }

        public string Data_hora_fim
        {
            get
            {
                return data_hora_fim;
            }

            set
            {
                data_hora_fim = value;
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

        public int Right { get; private set; }

        
    }
}