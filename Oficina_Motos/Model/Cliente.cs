using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina_Motos.Model
{
    public class Cliente
    {
        private int Id { get; set; }

        private string Nome { get; set; }

        private string sexo { get; set; }

        private string rg { get; set; }

        private string cpf { get; set; }

        private DateTime data_nasc { get; set; }

        private string status { get; set; }

        private Contato contato { get; set; }

        private Endereco endereco { get; set; }
    }
}
