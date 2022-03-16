using APICliente.Application.IServices;
using APICliente.Domain.DTOs.Response;
using APICliente.Domain.Entities;
using APICliente.Infra.IRepositories;

namespace APICliente.Application.Services
{
    public class VendasClienteService : BaseService<VendasCliente>, IVendasClienteService
    {
        private readonly IVendasClienteRepository vendasClienteRepository;
        public VendasClienteService(IVendasClienteRepository _repository) : base(_repository)
        {
            vendasClienteRepository = _repository;
        }

        public void SalvaNovaVenda(AlteraValorResponse alteraValor, int IdUsuario)
        {
            VendasCliente vendasCliente = new VendasCliente();
            vendasCliente.NovaVenda(alteraValor.Codigo, System.DateTime.Now, alteraValor.Valor, IdUsuario);
            vendasClienteRepository.Save(vendasCliente);
        }
    }
}
