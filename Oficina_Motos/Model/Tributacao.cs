using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Tributacao
    {
        private int id;

        private string origem;

        private string tipo_Item;

        private int ncm;

        private int cest;

        private decimal ipi;

        private decimal icms;

        private decimal pis;

        private decimal confins;

        private string inf_ad_prod;

        private int id_produto;

        private int id_categoria;



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

        public string Origem
        {
            get
            {
                return origem;
            }

            set
            {
                origem = value;
            }
        }

        public string Tipo_Item
        {
            get
            {
                return tipo_Item;
            }

            set
            {
                tipo_Item = value;
            }
        }

        public int Ncm
        {
            get
            {
                return ncm;
            }

            set
            {
                ncm = value;
            }
        }

        public int Cest
        {
            get
            {
                return cest;
            }

            set
            {
                cest = value;
            }
        }

        public decimal Ipi
        {
            get
            {
                return ipi;
            }

            set
            {
                ipi = value;
            }
        }

        public decimal Icms
        {
            get
            {
                return icms;
            }

            set
            {
                icms = value;
            }
        }

        public decimal Pis
        {
            get
            {
                return pis;
            }

            set
            {
                pis = value;
            }
        }

        public decimal Confins
        {
            get
            {
                return confins;
            }

            set
            {
                confins = value;
            }
        }

        public string Inf_ad_prod
        {
            get
            {
                return inf_ad_prod;
            }

            set
            {
                inf_ad_prod = value;
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
    }
}
