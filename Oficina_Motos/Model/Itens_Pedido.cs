using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Itens_Pedido
    {
        private int id;

        private int id_pedido;

        private int id_produto;

        private string descricao;

        private string aplicacao;

        private decimal valor_uni;

        private int qtde;

        private decimal total_item;

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

        public int Id_produto
        {
            get
            {
                return id_produto;
            }

            set
            {
                id_produto = value;
            }
        }

        public decimal Valor_uni
        {
            get
            {
                return valor_uni;
            }

            set
            {
                valor_uni = value;
            }
        }

        public int Qtde
        {
            get
            {
                return qtde;
            }

            set
            {
                qtde = value;
            }
        }

        public decimal Total_item
        {
            get
            {
                return total_item;
            }

            set
            {
                total_item = value;
            }
        }

        public int Id_pedido
        {
            get
            {
                return id_pedido;
            }

            set
            {
                id_pedido = value;
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

        public string Aplicacao
        {
            get
            {
                return aplicacao;
            }

            set
            {
                aplicacao = value;
            }
        }
    }
}
