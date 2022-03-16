using APICliente.Application.IServices;
using APICliente.Domain.Entities;
using Hanssens.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Controllers
{
    public class ClienteController : Controller
    {
        IRequestServices services;
        public ClienteController(IRequestServices _services)
        {
            services = _services;
        }
        public IActionResult Index()
        {
            Usuario usuario = new Usuario();

            using (var storage = new LocalStorage())
            {
                usuario = storage.Get<Usuario>("usuario");
                storage.Persist();
            }
            var clientes = services.ListaClientesAPICurso(usuario.Tipo);
            return View("ListarCliente", clientes);
        }

        public IActionResult AlterarStatus(int codigo)
        {
            return View();
        }

        public IActionResult RealizarVenda (int codigo)
        {
            return View();
        }
    }
}
