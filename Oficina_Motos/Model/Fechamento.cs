using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    class Fechamento
    {
        private int id {get; set;}

        private string data_hora {get; set;}

        private decimal entradaDinheiro {get; set;}

        private decimal entradaCartao {get; set;}

        private decimal entradaCheque {get; set;}

        private decimal saidaDinheiro {get; set;}

        private decimal saidaCheque {get; set;}

        private decimal saldoDinheiro {get; set;}

        private decimal saldoCheque {get; set;}

        private decimal recolhimentoCheque {get; set;}

        private decimal recolhimentoDinheiro {get; set;}

        private decimal fundoCaixa {get; set;}

        private int id_usuario {get; set;}

    }
}
