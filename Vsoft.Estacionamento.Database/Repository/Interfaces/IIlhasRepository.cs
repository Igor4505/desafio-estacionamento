using System.Collections.Generic;
using System.Threading.Tasks;
using Vsoft.Estacionamento.Core.Models;

namespace Vsoft.Estacionamento.Database.Repository.Interfaces
{
	public interface IIlhasRepository
	{
		Task<MovimentacaoModel> CarregarMovimentacao(int idVaga);

		Task<IEnumerable<IlhaModel>> CarregarIlhas();

		Task<IlhaModel> CarregarIlha(int idIlha);

		Task InserirIlha(IlhaModel ilha);
	}
}
