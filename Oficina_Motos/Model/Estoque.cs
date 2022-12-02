using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Estoque
    {
        private int id { get; set; }
        private string unid_venda { get; set; }
        private int estoque_min { get; set; }
        private int estoque_max { get; set; }
        private int estoque_atual { get; set; }
        private string localizacao { get; set; }
        private bool pedido_em_endamento { get; set; }
        private int id_produto { get; set; }

    }
}
