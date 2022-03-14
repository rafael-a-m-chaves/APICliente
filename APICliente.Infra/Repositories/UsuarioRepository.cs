using APICliente.Domain.Entities;
using APICliente.Infra.Contexts;
using APICliente.Infra.IRepositories;

namespace APICliente.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        Context context;
        public UsuarioRepository(Context _context) : base(_context)
        {
            context = _context;
        }
    }
}
