using APICliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICliente.Domain.DTOs.Request
{
    public class VendedorDashboardRequest
    {
        public int TotalDeClientes  { get; set; }
        public int TotalDeVendas { get; set; }
        public decimal ValorVendido { get; set; }
        public decimal ComissaoGerada { get; set; }
    }
}
