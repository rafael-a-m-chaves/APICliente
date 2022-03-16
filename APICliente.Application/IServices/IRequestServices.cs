using APICliente.Domain.DTOs.Request;
using APICliente.Domain.DTOs.Response;
using System.Collections.Generic;

namespace APICliente.Application.IServices
{
    public interface IRequestServices
    {
        public List<Clientes> ListaClientesAPICurso(string tipo);
        public void AlterarStatusApiCurso(string tipoEUsuario, int codigo);
        public ObterLimite ObterLimiteClienteApiCurso(int codigo);
        public void AlterarLimiteClienteApiCurso(AlteraValorResponse alteraValor);
    }
}
