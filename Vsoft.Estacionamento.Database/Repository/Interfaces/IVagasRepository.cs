using System;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.DTOs;
using Vsoft.Estacionamento.Core.Models;

namespace Vsoft.Estacionamento.Database.Repository.Interfaces
{
	public interface IVagasRepository
	{
		Task InserirVaga(VagaModel vaga);

		Task<VagaModel> CarregarVaga(int idVaga);

		Task<DateTime> OcuparVaga(VagaDTO data);

		Task ReceberValor(VagaDTO vaga);
	}
}
