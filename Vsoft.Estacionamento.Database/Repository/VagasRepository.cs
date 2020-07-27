using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.DTOs;
using Vsoft.Estacionamento.Core.Models;
using Vsoft.Estacionamento.Database.DataContext;
using Vsoft.Estacionamento.Database.Repository.Interfaces;

namespace Vsoft.Estacionamento.Database.Repository
{
	public class VagasRepository : IVagasRepository
	{
		private readonly EstacionamentoDbContext _context;

		public VagasRepository(EstacionamentoDbContext context)
		{
			_context = context;
		}

		// POST - Inserir uma nova vaga
		public async Task InserirVaga(VagaModel vaga)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					_context.Vagas.Add(vaga);
					await _context.SaveChangesAsync();



					transaction.Commit();
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}
		}

		public async Task<VagaModel> CarregarVaga(int idVaga)
		{
			return await _context.Vagas.FindAsync(idVaga);
		}

		public async Task<DateTime> OcuparVaga(VagaDTO data)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					var vagaModel = _context.Vagas.Find(data.Id);

					vagaModel.Ocupada = true;


					_context.Update(vagaModel);
					await _context.SaveChangesAsync();

					MovimentacaoModel movimentacao = new MovimentacaoModel()
					{
						DataEntrada = DateTime.Now,
						IdVaga = data.Id,
						CpfCliente = data.CpfCliente,
						CorVeiculo = data.CorVeiculo,
						NomeCliente = data.NomeCliente,
						NomeVeiculo = data.NomeVeiculo,
						PlacaVeiculo = data.PlacaVeiculo
					};
					_context.Movimentacoes.Add(movimentacao);
					await _context.SaveChangesAsync();

					transaction.Commit();
					return movimentacao.DataEntrada;
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}

		}

		public async Task ReceberValor(VagaDTO vaga)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					var vagaModel = _context.Vagas.Find(vaga.Id);

					vagaModel.Ocupada = false;


					_context.Update(vagaModel);
					await _context.SaveChangesAsync();

					var movimentacao = await _context.Movimentacoes.Where(m => m.IdVaga == vaga.Id && m.DataSaida == null).SingleOrDefaultAsync();

					movimentacao.Valor = vaga.ValorTotal;
					movimentacao.DataSaida = vaga.DataSaida;

					_context.Update(movimentacao);
					await _context.SaveChangesAsync();
					transaction.Commit();
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}
		}
	}
}
