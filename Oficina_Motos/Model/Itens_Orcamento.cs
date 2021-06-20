using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Itens_Orcamento
    {
        private int id;

        private int id_orcamento;

        private int id_produto;

        private int id_servico;

        private string descricao;

        private decimal valor_uni;

        private int qtde;

        private decimal desconto;

        private decimal sub_total;



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

        public int Id_servico
        {
            get
            {
                return id_servico;
            }

            set
            {
                id_servico = value;
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

        public decimal Sub_total
        {
            get
            {
                return sub_total;
            }

            set
            {
                sub_total = value;
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

        public int Id_orcamento
        {
            get
            {
                return id_orcamento;
            }

            set
            {
                id_orcamento = value;
            }
        }
    }
}
