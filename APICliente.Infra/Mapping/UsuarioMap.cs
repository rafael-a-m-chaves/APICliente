using APICliente.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICliente.Infra.Mapping
{
    public class UsuarioMap
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Tipo);
            builder.Property(r => r.Nome);
            builder.Property(r => r.IsActive);
        }
    }
}
