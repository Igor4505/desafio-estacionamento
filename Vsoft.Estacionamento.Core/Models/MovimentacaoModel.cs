using System;
using Vsoft.Estacionamento.Core.Models.Base;

namespace Vsoft.Estacionamento.Core.Models
{
	public class MovimentacaoModel : BaseModel
	{
		public DateTime DataEntrada { get; set; }

		public DateTime? DataSaida { get; set; }

		public double Valor { get; set; }

		public int IdVaga { get; set; }

		public string NomeVeiculo { get; set; }

		public string PlacaVeiculo { get; set; }

		public string CorVeiculo { get; set; }

		public string NomeCliente { get; set; }

		public string CpfCliente { get; set; }

		public VagaModel Vaga { get; set; }
	}
}
