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


        [HttpPost]
        [ValidateAntiForgeryToken]
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

            alteraValor.Usuario = usuario.Tipo + " " + usuario.Nome;
            alteraValor.Codigo = Convert.ToInt32(collection["Codigo"]);
            var subtrair = collection["Subtrair"];

            //Foi implementado dessa maneira pois estava dando erro de vim dois bits de uma vez
            if (subtrair.Count == 2)
            {
                alteraValor.Subtrair = true;
            }
            else
            {
                alteraValor.Subtrair = false;
            }

            //Transforma decimal pt-br em decimal em en
            string valor = collection["Valor"];
            valor = valor.Replace(".", ",").Replace(",", ",");
            alteraValor.Valor = Convert.ToDecimal(valor);

            var valorAtual = services.ObterLimiteClienteApiCurso(alteraValor.Codigo);
            
            
            if (valorAtual.LimiteCredito < alteraValor.Valor && alteraValor.Subtrair)
            {
                valorAtual.ErrorMensagem = "O Valor informado ultrapassa o limite do Cliente";
                return View("RealizarVenda", valorAtual);
            }
            else
            {
                services.AlterarLimiteClienteApiCurso(alteraValor);
                return Index();
            }
        }
    }
}
