using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.DTOs;
using Vsoft.Estacionamento.Core.Models;
using Vsoft.Estacionamento.Database.Repository.Interfaces;

namespace Vsoft.Estacionamento.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VagasController : ControllerBase
	{
		private readonly IVagasRepository _repository;

		public VagasController(IVagasRepository repository)
		{
			_repository = repository;
		}


		// GET CARREGAR UNICA VAGA api/vagas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<VagaDTO>> CarregarVaga(int id)
		{
			var vaga = await _repository.CarregarVaga(id);
			if (vaga == null)
			{
				return NotFound();
			}
			else
			{
				return new VagaDTO()
				{
					Id = vaga.Id,
					IdIlha = vaga.IdIlha,
					CorVeiculo = "",
					NomeVeiculo = "",
					PlacaVeiculo = "",
					Ocupada = vaga.Ocupada,
					NomeCliente = "",
					CpfCliente = ""
				};
			}
		}

		// POST: INSERIR VAGA api/Vagas
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] VagaDTO vaga)
		{
			try
			{
				var vagaModel = new VagaModel()
				{
					IdIlha = vaga.IdIlha
				};

				await _repository.InserirVaga(vagaModel);
				return CreatedAtAction(nameof(CarregarVaga), new { Id = vagaModel.Id },
					new VagaDTO()
					{
						Id = vagaModel.Id,
						IdIlha = vagaModel.IdIlha,
						CorVeiculo = "",
						NomeVeiculo = "",
						PlacaVeiculo = "",
						Ocupada = false,
						NomeCliente = "",
						CpfCliente = ""
					}
					);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		//PUT: OCUPAR VAGA
		[HttpPut("ocupar")]
		public async Task<ActionResult> OcuparVaga([FromBody] VagaDTO vaga)
		{
			try
			{
				var horaEntrada = await _repository.OcuparVaga(vaga);
				return Ok(horaEntrada);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPut("receber")]
		public async Task<ActionResult> ReceberValor([FromBody] VagaDTO vaga)
		{
			try
			{
				await _repository.ReceberValor(vaga);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
