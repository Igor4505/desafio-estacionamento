using System.Collections.Generic;

namespace Vsoft.Estacionamento.Core.DTOs
{
	public class IlhaDTO : BaseDTO
	{
		public string Localizacao { get; set; }
		public List<VagaDTO> Vagas { get; set; }
	}
}
