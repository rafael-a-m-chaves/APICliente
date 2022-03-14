using APICliente.Application.IServices;
using APICliente.Domain.Entities;
using APICliente.Infra.IRepositories;

namespace APICliente.Application.Services
{
    public class UsuarioService : BaseService<Usuario> , IUsuarioServices
    {
        private readonly IUsuarioRepository repository;
        public UsuarioService(IUsuarioRepository _repository) : base(_repository)
        {
            repository = _repository;
        }
    }
}
