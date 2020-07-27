using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.Models;
using Vsoft.Estacionamento.Database.Repository.Interfaces;

namespace Vsoft.Estacionamento.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovimentacoesController : ControllerBase
	{
		private readonly IMovimentacaoRepository _repository;

		public MovimentacoesController(IMovimentacaoRepository repository)
		{
			_repository = repository;
		}
		// GET: api/Movimentacoes
		[HttpGet]
		public async Task<IEnumerable<MovimentacaoModel>> Get()
		{
			return await _repository.CarregarMovimentacoes();
		}

	}
}
