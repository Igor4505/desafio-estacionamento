using System.Collections.Generic;
using Vsoft.Estacionamento.Core.Models.Base;

namespace Vsoft.Estacionamento.Core.Models
{
	public class VagaModel : BaseModel
	{
		public bool Ocupada { get; set; }

		public bool? Ativa { get; set; }



		public int IdIlha { get; set; }

		// Relationship
		public IlhaModel Ilha { get; set; }
		public List<MovimentacaoModel> Movimentacoes { get; set; }
	}
}
