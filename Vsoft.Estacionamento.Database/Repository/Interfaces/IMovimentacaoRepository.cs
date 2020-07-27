using System.Collections.Generic;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.Models;

namespace Vsoft.Estacionamento.Database.Repository.Interfaces
{
	public interface IMovimentacaoRepository
	{
		Task<MovimentacaoModel> CarregarMovimentacao(int idVaga);

		Task<IEnumerable<MovimentacaoModel>> CarregarMovimentacoes();
	}
}
