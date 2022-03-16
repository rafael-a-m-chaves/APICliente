using APICliente.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICliente.Infra.Mapping
{
    public class DespesasMap
    {
        public void Configure(EntityTypeBuilder<Despesas> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Valor);
            builder.Property(r => r.Motivo);
            builder.Property(r => r.DataDespesa);
        }
    }
}
