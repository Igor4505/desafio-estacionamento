using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.Models;
using Vsoft.Estacionamento.Database.DataContext;
using Vsoft.Estacionamento.Database.Repository.Interfaces;

namespace Vsoft.Estacionamento.Database.Repository
{
	public class IlhasRepository : IIlhasRepository
	{
		private readonly EstacionamentoDbContext _context;

		public IlhasRepository(EstacionamentoDbContext context)
		{
			_context = context;
		}

		// GET - Carregar todas as vagas
		public async Task<IEnumerable<IlhaModel>> CarregarIlhas()
		{
			return await _context.Ilhas.Include(i => i.Vagas).ToListAsync();
		}

		// GET - Uma unica ilha
		public async Task<IlhaModel> CarregarIlha(int idIlha)
		{
			return await _context.Ilhas.FindAsync(idIlha);
		}

		// POST - Inserir uma nova ilha
		public async Task InserirIlha(IlhaModel ilha)
		{
			try
			{
				_context.Ilhas.Add(ilha);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<MovimentacaoModel> CarregarMovimentacao(int idVaga)
		{
			return await _context.Movimentacoes.Where(m => m.IdVaga == idVaga && m.DataSaida == null).SingleOrDefaultAsync();
		}
	}
}
