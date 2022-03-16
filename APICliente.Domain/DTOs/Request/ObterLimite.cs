using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICliente.Domain.DTOs.Request
{
    public class ObterLimite
    {
        public int Codigo { get;  set; }
        public decimal LimiteCredito { get;  set; }
        public string Nome { get;  set; }
        public bool IsActive { get;  set; }
        public string ErrorMensagem { get; set; }
        public bool Subtrair { get; set; }
        public decimal Valor { get; set; }
    }
}
