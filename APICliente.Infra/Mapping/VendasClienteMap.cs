using APICliente.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICliente.Infra.Mapping
{
    public class VendasClienteMap
    {
        public void Configure(EntityTypeBuilder<VendasCliente> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.CodigoCliente);
            builder.Property(r => r.DataVenda);
            builder.Property(r => r.ValorDaVenda);
            builder.HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(m => m.IdUsuario);

        }
    }
}
