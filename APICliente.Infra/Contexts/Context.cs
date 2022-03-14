using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using APICliente.Domain.Entities;
using APICliente.Infra.Mapping;

namespace APICliente.Infra.Contexts
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public Context()
        {
        }

        //Seta as Classes que devem estar no banco de dados e atribui o Get e Set

        public DbSet<VendasCliente> VendasCliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Informa ao Context as classes maps 

            modelBuilder.Entity<VendasCliente>(new VendasClienteMap().Configure);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);

            base.OnModelCreating(modelBuilder);
        }
    }
}
