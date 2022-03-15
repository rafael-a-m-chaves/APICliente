using APICliente.Application.IServices;
using APICliente.Domain.DTOs.Request;
using APICliente.Domain.Entities;
using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IRequestServices requestServices;
        private readonly IVendasClienteService vendasClienteService;
        private readonly IDespesasSevice despesasService;
        public DashBoardController(IRequestServices _requestServices, IVendasClienteService _vendasClienteService, IDespesasSevice _despesasService)
        {
            requestServices = _requestServices;
            vendasClienteService = _vendasClienteService;
            despesasService = _despesasService;
        }

        public IActionResult Index()
        {
            Usuario usuario = new Usuario();
            
            using (var storage = new LocalStorage())
            {
                usuario = storage.Get<Usuario>("usuario");
                storage.Persist();
            }
            //Este Bloco de condiçoes checa com qual usuario esta sendo feita a requisição
            if(usuario != null)
            {
                if(usuario.Tipo == "Administrador")
                {
                    //busca todas as informações nescessarias para compor a view

                    AdministradorDashboardRequest administrador = new AdministradorDashboardRequest();
                    administrador.VendasClientes = vendasClienteService.Get().ToList();
                    administrador.Despesas = despesasService.Get().ToList();
                    administrador.Clientes = requestServices.ListaClientesAPICurso("Administrador");

                    foreach(var item in administrador.VendasClientes)
                    {
                        administrador.Saldo += item.ValorDaVenda;
                    }

                    foreach (var item in administrador.Despesas)
                    {
                        administrador.Saldo -= item.Valor;
                    }

                    foreach (var item in administrador.Clientes)
                    {
                        if(administrador.VendasClientes.Exists(r => r.CodigoCliente == item.Codigo))
                        {
                            administrador.ClientesJaCompraram++;
                        }
                    }

                    return View("AdministradorDashboard", administrador);
                }
                else if (usuario.Tipo == "Financeiro")
                {

                    //busca todas as informações nescessarias para compor a view

                    FinanceiroDashboardRequest financeiro = new FinanceiroDashboardRequest();
                    var vendasClientes = vendasClienteService.Get().ToList();
                    var despesas = despesasService.Get().ToList();
                    financeiro.Clientes = requestServices.ListaClientesAPICurso("Financeiro");

                    foreach (var item in vendasClientes)
                    {
                        financeiro.Receita += item.ValorDaVenda;
                    }

                    foreach (var item in despesas)
                    {
                        financeiro.Despesa += item.Valor;
                    }

                    foreach (var item in financeiro.Clientes)
                    {
                        if (vendasClientes.Exists(r => r.CodigoCliente == item.Codigo))
                        {
                            financeiro.ClientesJaCompraram++;
                        }
                    }

                    return View("FinanceiroDashboard", financeiro);
                }
                else if (usuario.Tipo == "Vendedor")
                {
                    return View("VendedorDashboard");
                }
                else
                {
                    return Redirect("Home");
                }
            }
            else
            {
                return Redirect("Home");
            }

        }
    }
}
