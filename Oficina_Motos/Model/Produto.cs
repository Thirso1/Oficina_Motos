using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Produto
    {
        private int id;

        private string cod_barras;

        private string descricao;

        private string marca;

        private string cod_marca;

        private decimal preco_custo;

        private decimal preco_venda;

        private decimal desconto;

        private string imagem;

        private int id_categoria;

        private string status;

        private decimal margem_lucro;


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

        public string Cod_barras
        {
            get
            {
                return cod_barras;
            }

            set
            {
                cod_barras = value;
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

        public string Marca
        {
            get
            {
                return marca;
            }

            set
            {
                marca = value;
            }
        }

        public string Cod_marca
        {
            get
            {
                return cod_marca;
            }

            set
            {
                cod_marca = value;
            }
        }

        public decimal Preco_custo
        {
            get
            {
                return preco_custo;
            }

            set
            {
                preco_custo = value;
            }
        }

        public decimal Preco_venda
        {
            get
            {
                return preco_venda;
            }

            set
            {
                preco_venda = value;
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

        public string Imagem
        {
            get
            {
                return imagem;
            }

            set
            {
                imagem = value;
            }
        }

        public int Id_categoria
        {
            get
            {
                return id_categoria;
            }

            set
            {
                id_categoria = value;
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

        public decimal Margem_lucro
        {
            get
            {
                return margem_lucro;
            }

            set
            {
                margem_lucro = value;
            }
        }
    }
}
