using APICliente.Application.IServices;
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
    }
}
