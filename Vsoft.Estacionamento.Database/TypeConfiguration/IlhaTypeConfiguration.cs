using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vsoft.Estacionamento.Core.Models;

namespace Vsoft.Estacionamento.Database.TypeConfiguration
{
    class IlhaTypeConfiguration : IEntityTypeConfiguration<IlhaModel>
    {
        public void Configure(EntityTypeBuilder<IlhaModel> builder)
        {
            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.Localizacao)
                .IsRequired();
        }
    }
}
