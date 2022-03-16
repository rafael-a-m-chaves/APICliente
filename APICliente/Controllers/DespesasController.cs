using APICliente.Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Controllers
{
    public class DespesasController : Controller
    {
        private readonly IDespesasSevice service;
        public DespesasController(IDespesasSevice _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            var despesas = service.Get();

            return View(despesas);
        }
    }
}
