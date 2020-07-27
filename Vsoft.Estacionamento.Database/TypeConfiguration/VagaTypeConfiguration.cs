using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vsoft.Estacionamento.Core.Models;

namespace Vsoft.Estacionamento.Database.TypeConfiguration
{
	public class VagaTypeConfiguration : IEntityTypeConfiguration<VagaModel>
	{
		public void Configure(EntityTypeBuilder<VagaModel> builder)
		{
			builder.HasKey(v => v.Id);

			builder.Property(v => v.Ativa).HasDefaultValue(true);

			builder
				.HasOne(v => v.Ilha)
				.WithMany(i => i.Vagas)
				.HasForeignKey(v => v.IdIlha);
		}
	}
}
