using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICliente.Domain.Entities
{
    public class Despesas
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Motivo { get; set; }
    }
}
