using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICliente.Domain.DTOs.Response
{
    public class AlteraValorResponse
    {
        public string Usuario { get; set; }
        public int Codigo { get; set; }
        public decimal Valor { get; set; }
        public bool Subtrair { get; set; }
    }
}
