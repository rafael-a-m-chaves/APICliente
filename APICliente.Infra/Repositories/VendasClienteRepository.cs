using APICliente.Domain.Entities;
using APICliente.Infra.Contexts;
using APICliente.Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APICliente.Infra.Repositories
{
    public class VendasClienteRepository : BaseRepository<VendasCliente>, IVendasClienteRepository
    {
        Context context;
        public VendasClienteRepository(Context _context) : base(_context)
        {
            context = _context;
        }

        public override ICollection<VendasCliente> Get()
        {
            return context.VendasCliente
                .Include(r => r.Usuario)
                .ToList();
        }

        public override ICollection<VendasCliente> Get(Expression<Func<VendasCliente, bool>> predicate)
        {
            return context.VendasCliente
                .Include(r => r.Usuario)
                .Where(predicate)
                .ToList();
        }
    }
}
