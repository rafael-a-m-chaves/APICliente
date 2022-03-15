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
        public IActionResult Index()
        {
            Usuario usuario = new Usuario();
            
            using (var storage = new LocalStorage())
            {
                usuario = storage.Get<Usuario>("usuario");
                storage.Persist();
            }
            //Este Bloco
            if(usuario != null)
            {
                if(usuario.Tipo == "Administrador")
                {
                    return View("AdministradorDashboard");
                }
                else if (usuario.Tipo == "Financeiro")
                {
                    return View("FinanceiroDashboard");
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
