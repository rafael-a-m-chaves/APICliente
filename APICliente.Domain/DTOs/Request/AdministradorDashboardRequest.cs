using APICliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICliente.Domain.DTOs.Request
{
    public class AdministradorDashboardRequest
    {
        public List<VendasCliente> VendasClientes { get; set; }
        public List<Clientes> Clientes { get; set; }
        public List<Despesas> Despesas { get; set; }
    }
}
