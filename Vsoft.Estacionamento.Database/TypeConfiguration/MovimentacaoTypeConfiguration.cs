using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vsoft.Estacionamento.Core.Models;

namespace Vsoft.Estacionamento.Database.TypeConfiguration
{
	public class MovimentacaoTypeConfiguration : IEntityTypeConfiguration<MovimentacaoModel>
	{
		public void Configure(EntityTypeBuilder<MovimentacaoModel> builder)
		{
			// Chave primária
			builder.HasKey(m => m.Id);

			// Vaga 1 - n Movimentacao
			builder
				.HasOne(m => m.Vaga)
				.WithMany(v => v.Movimentacoes)
				.HasForeignKey(m => m.IdVaga);
		}
	}
}
