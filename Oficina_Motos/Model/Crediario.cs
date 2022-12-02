using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Crediario
    {
        private int id { get; set; }

        private int id_cliente { get; set; }

        private string referencia { get; set; }

        private int num_referencia { get; set; }

        private decimal entrada { get; set; }

        private decimal valor_parcelado { get; set; }

        private int num_parcelas { get; set; }

        private string data { get; set; }

        string status { get; set; }

    }
}
