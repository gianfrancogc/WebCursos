using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo;

namespace Persistence.Config
{
    public class CursoConfig
    {
        public CursoConfig(EntityTypeBuilder<Curso> entityType)
        {
            entityType.Property(x => x.Nombre).HasColumnType("varchar(100)").IsRequired();
            entityType.Property(x => x.Descripcion).HasColumnType("varchar(200)").IsRequired();
            entityType.Property(x => x.Picture).HasColumnType("varchar(200)");

        }
    }
}
