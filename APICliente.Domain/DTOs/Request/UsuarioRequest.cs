using APICliente.Domain.Entities;
using System.Collections.Generic;

namespace APICliente.Domain.DTOs.Request
{
    public class UsuarioRequest
    {
        public int IdUsuario { get; set; }
        public List<Usuario> Usuarios {get; set;}
    }
}
