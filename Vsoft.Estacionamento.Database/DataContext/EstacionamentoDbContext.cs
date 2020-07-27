using Microsoft.EntityFrameworkCore;
using Vsoft.Estacionamento.Core.Models;
using Vsoft.Estacionamento.Database.TypeConfiguration;

namespace Vsoft.Estacionamento.Database.DataContext
{
	public class EstacionamentoDbContext : DbContext
	{
		public EstacionamentoDbContext(DbContextOptions<EstacionamentoDbContext> options) : base(options)
		{
			Database.Migrate();
		}

		public DbSet<IlhaModel> Ilhas { get; set; }
		public DbSet<MovimentacaoModel> Movimentacoes { get; set; }
		public DbSet<VagaModel> Vagas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new IlhaTypeConfiguration());
			modelBuilder.ApplyConfiguration(new MovimentacaoTypeConfiguration());
			modelBuilder.ApplyConfiguration(new VagaTypeConfiguration());
		}
	}
}
