using APICliente.Domain.DTOs.Request;
using System.Collections.Generic;

namespace APICliente.Application.IServices
{
    public interface IRequestServices
    {
        public List<Clientes> ListaClientesAPICurso(string tipo);
    }
}
