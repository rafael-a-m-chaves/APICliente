using APICliente.Application.IServices;
using APICliente.Domain.Entities;
using APICliente.Infra.IRepositories;

namespace APICliente.Application.Services
{
    public class DespesasService : BaseService<Despesas>, IDespesasSevice
    {
        private readonly IDespesasRepository repository;
        public DespesasService(IDespesasRepository _repository) : base(_repository)
        {
            repository = _repository;
        }
    }
}
