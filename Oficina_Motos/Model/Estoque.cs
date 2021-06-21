using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Estoque
    {
        private int id;
        private string unid_venda;
        private int estoque_min;
        private int estoque_max;
        private int estoque_atual;
        private string localizacao;
        private bool pedido_em_endamento;
        private int id_produto;

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

        public int Estoque_min
        {
            get
            {
                return estoque_min;
            }

            set
            {
                estoque_min = value;
            }
        }

        public int Estoque_max
        {
            get
            {
                return estoque_max;
            }

            set
            {
                estoque_max = value;
            }
        }

        public int Estoque_atual
        {
            get
            {
                return estoque_atual;
            }

            set
            {
                estoque_atual = value;
            }
        }

        public string Localizacao
        {
            get
            {
                return localizacao;
            }

            set
            {
                localizacao = value;
            }
        }

        public string Unid_venda
        {
            get
            {
                return unid_venda;
            }

            set
            {
                unid_venda = value;
            }
        }

        public bool Pedido_em_endamento
        {
            get
            {
                return pedido_em_endamento;
            }

            set
            {
                pedido_em_endamento = value;
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
    }
}
