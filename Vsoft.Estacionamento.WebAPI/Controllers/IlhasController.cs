using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.DTOs;
using Vsoft.Estacionamento.Core.Models;
using Vsoft.Estacionamento.Database.Repository.Interfaces;

namespace Vsoft.Estacionamento.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IlhasController : ControllerBase
	{
		private readonly IIlhasRepository _repository;

		public IlhasController(IIlhasRepository repository)
		{
			_repository = repository;
		}

		// GET: api/Vagas
		[HttpGet]
		public async Task<List<IlhaDTO>> CarregarVaga()
		{
			// Carregar Ilhas
			var ilhas = await _repository.CarregarIlhas();

			// Instanciar Lista de Ilhas DTO
			List<IlhaDTO> Ilhas = new List<IlhaDTO>();

			// Mapear Ilhas
			foreach (var ilha in ilhas)
			{
				IlhaDTO Ilha = new IlhaDTO()
				{
					Id = ilha.Id,
					Localizacao = ilha.Localizacao,
					Vagas = new List<VagaDTO>()
				};
				// Mapear Vagas
				foreach (var vaga in ilha.Vagas)
				{
					VagaDTO vagaDto = new VagaDTO()
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
					if (vaga.Ocupada)
					{
						var movimentacao = await _repository.CarregarMovimentacao(vaga.Id);
						vagaDto.DataEntrada = movimentacao.DataEntrada;
						vagaDto.CorVeiculo = movimentacao.CorVeiculo;
						vagaDto.NomeVeiculo = movimentacao.NomeVeiculo;
						vagaDto.PlacaVeiculo = movimentacao.PlacaVeiculo;
						vagaDto.NomeCliente = movimentacao.NomeCliente;
						vagaDto.CpfCliente = movimentacao.CpfCliente;
					}
					Ilha.Vagas.Add(vagaDto);
				}
				// Inserir na lista de Ilhas
				Ilhas.Add(Ilha);
			}

			return Ilhas;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public async Task<ActionResult<IlhaModel>> CarregarIlha(int id)
		{
			var ilha = await _repository.CarregarIlha(id);
			if (ilha == null)
			{
				return NotFound();
			}
			else
			{
				return ilha;
			}
		}

		// POST - INSERIR ILHAS
		[HttpPost]
		public async Task<ActionResult<IlhaModel>> Post([FromBody] IlhaDTO Ilha)
		{
			if (String.IsNullOrEmpty(Ilha.Localizacao))
			{
				return BadRequest("O campo localização é obrigatório");
			}
			else
			{
				try
				{
					IlhaModel ilhaModel = new IlhaModel()
					{
						Localizacao = Ilha.Localizacao
					};
					await _repository.InserirIlha(ilhaModel);
					return CreatedAtAction(nameof(CarregarIlha), new { Id = ilhaModel.Id }, ilhaModel);
				}
				catch (Exception e)
				{
					return BadRequest(e.Message);
				}
			}
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
