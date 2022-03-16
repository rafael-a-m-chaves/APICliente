using APICliente.Application.IServices;
using APICliente.Domain.DTOs.Request;
using APICliente.Domain.DTOs.Response;
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

            if (usuario != null)
            {
                if (usuario.Tipo == "Vendedor")
                {
                    var clientes = services.ListaClientesAPICurso(usuario.Tipo);
                    return View("ListarCliente", clientes);
                }
                else
                {
                    var clientes = services.ListaClientesAPICurso(usuario.Tipo);
                    return View("ListarClienteAdministradorEFinanceiro", clientes);
                }
            }
            else
            {
                return Redirect("Home");
            }
        }

        public IActionResult AlterarStatus(int codigo)
        {
            Usuario usuario = new Usuario();

            using (var storage = new LocalStorage())
            {
                usuario = storage.Get<Usuario>("usuario");
                storage.Persist();
            }
            if (usuario == null) return Redirect("Home");

            services.AlterarStatusApiCurso(usuario.Tipo+" "+usuario.Nome, codigo);

            return Index();
        }

        public IActionResult RealizarVenda(int codigo)
        {
            ObterLimite obterLimite = services.ObterLimiteClienteApiCurso(codigo);
            return View("RealizarVenda", obterLimite);
        }

        public IActionResult AjustarLimite(int codigo)
        {
            ObterLimite obterLimite = services.ObterLimiteClienteApiCurso(codigo);
            return View("AjustarLimite", obterLimite);
        }

        public IActionResult AlterarLimite(IFormCollection collection)
        {
            Usuario usuario = new Usuario();

            using (var storage = new LocalStorage())
            {
                usuario = storage.Get<Usuario>("usuario");
                storage.Persist();
            }
            if (usuario == null) return Redirect("Home");

            AlteraValorResponse alteraValor = new AlteraValorResponse();

            if ()
            {

            }
            else
            {
               
            }
        }
    }
}
