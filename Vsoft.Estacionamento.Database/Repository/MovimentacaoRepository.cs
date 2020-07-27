using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.Models;
using Vsoft.Estacionamento.Database.DataContext;
using Vsoft.Estacionamento.Database.Repository.Interfaces;

namespace Vsoft.Estacionamento.Database.Repository
{
	public class MovimentacaoRepository : IMovimentacaoRepository
	{
		private readonly EstacionamentoDbContext _context;

		public MovimentacaoRepository(EstacionamentoDbContext context)
		{
			_context = context;
		}

		public async Task<MovimentacaoModel> CarregarMovimentacao(int idVaga)
		{
			return await _context.Movimentacoes.Where(m => m.IdVaga == idVaga).SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<MovimentacaoModel>> CarregarMovimentacoes()
		{
			return await _context.Movimentacoes.ToListAsync();
		}
	}
}
