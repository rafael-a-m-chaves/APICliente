using APICliente.Application.IServices;
using APICliente.Domain.DTOs.Request;
using APICliente.Domain.Entities;
using APICliente.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioServices usuarioServices;
        public HomeController(ILogger<HomeController> logger, IUsuarioServices _usuarioServices)
        {
            _logger = logger;
            usuarioServices = _usuarioServices;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = usuarioServices.Get(r => r.IsActive != false).ToList();
            UsuarioRequest usuarioRequest = new UsuarioRequest();
            usuarioRequest.Usuarios = usuarios;
            return View(usuarioRequest);
        }

        [HttpPost]
        [Route("AcessarSistema")]
        public IActionResult AcessarSistema(IFormCollection collection)
        {
            try
            {
                Usuario usuario = usuarioServices.FindById(Convert.ToInt32(collection["IdUsuario"]));
                return View(usuario);
            }
            catch
            {
                List<Usuario> usuarios = usuarioServices.Get(r => r.IsActive != false).ToList();
                UsuarioRequest usuarioRequest = new UsuarioRequest();
                usuarioRequest.Usuarios = usuarios;
                return View(usuarioRequest);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
