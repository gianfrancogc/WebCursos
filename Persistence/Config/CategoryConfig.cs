using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Config
{
    public class CategoryConfig
    {
        public CategoryConfig(EntityTypeBuilder<Categoria> entityType)
        {
            entityType.Property(x => x.Nombre).HasColumnType("varchar(100)").IsRequired();

            entityType.HasMany(x => x.Cursos)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.IdCategoria)
                .IsRequired();

        }
    }
}
