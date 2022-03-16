using APICliente.Domain.DTOs.Response;
using APICliente.Domain.Entities;

namespace APICliente.Application.IServices
{
    public interface IVendasClienteService : IBaseService<VendasCliente>
    {
        public void SalvaNovaVenda(AlteraValorResponse alteraValor, int IdUsuario);
    }
}
