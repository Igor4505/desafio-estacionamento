using System;

namespace Vsoft.Estacionamento.Core.DTOs
{
	public class VagaDTO : BaseDTO
	{
		public bool Ocupada { get; set; }

		public int IdIlha { get; set; }

		public string NomeVeiculo { get; set; }

		public string PlacaVeiculo { get; set; }

		public string CorVeiculo { get; set; }

		public string NomeCliente { get; set; }

		public string CpfCliente { get; set; }

		public DateTime DataEntrada { get; set; }

		public DateTime DataSaida { get; set; }

		public int ValorTotal { get; set; }
	}
}
