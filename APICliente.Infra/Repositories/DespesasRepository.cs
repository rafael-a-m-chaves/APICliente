using APICliente.Domain.Entities;
using APICliente.Infra.Contexts;
using APICliente.Infra.IRepositories;

namespace APICliente.Infra.Repositories
{
    public class DespesasRepository : BaseRepository<Despesas>, IDespesasRepository
    {
        Context context;
        public DespesasRepository(Context ctx) : base (ctx)
        {
            context = ctx;
        }
    }
}
