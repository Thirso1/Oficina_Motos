using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Fluxo_caixa
    {
        private int id;

        private string grupo;

        private string descricao;

        private int id_forma_pag;

        private decimal entrada;

        private decimal saida;

        private string usuario;


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

        public int Id_forma_pag
        {
            get
            {
                return id_forma_pag;
            }

            set
            {
                id_forma_pag = value;
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

        public decimal Saida
        {
            get
            {
                return saida;
            }

            set
            {
                saida = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Grupo
        {
            get
            {
                return grupo;
            }

            set
            {
                grupo = value;
            }
        }
    }
}
