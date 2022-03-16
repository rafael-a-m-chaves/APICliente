using APICliente.Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Controllers
{
    public class VendasController : Controller
    {
        private readonly IVendasClienteService service;
        public VendasController(IVendasClienteService vendasCliente)
        {
            service = vendasCliente;
        }
        public IActionResult Index()
        {
            var vendas = service.Get();
            return View(vendas);
        }
    }
}
