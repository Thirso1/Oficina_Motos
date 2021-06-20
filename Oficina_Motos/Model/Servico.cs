using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Servico
    {
        private int id;

        private string descricao;

        private int tempo_minutos;

        private decimal preco;

        private decimal desconto;

        private string imagem;

        private int id_categoria;

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

        public int Tempo_minutos
        {
            get
            {
                return tempo_minutos;
            }

            set
            {
                tempo_minutos = value;
            }
        }

        public decimal Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
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
    }
}
