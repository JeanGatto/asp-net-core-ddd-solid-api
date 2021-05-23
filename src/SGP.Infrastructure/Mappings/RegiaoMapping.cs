using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.Domain.Entities;
using SGP.Infrastructure.Extensions;

namespace SGP.Infrastructure.Mappings
{
    public class RegiaoMapping : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(regiao => regiao.Nome)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.HasIndex(regiao => regiao.Nome)
                .IsUnique();
        }
    }
}