using APICliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICliente.Domain.DTOs.Request
{
    public class FinanceiroDashboardRequest
    {
        public List<Clientes> Clientes { get; set; }
        public decimal Receita { get; set; }
        public decimal Despesa { get; set; }
        public int ClientesJaCompraram { get; set; }
    }
}
