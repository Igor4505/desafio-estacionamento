using System.Collections.Generic;
using Vsoft.Estacionamento.Core.Models.Base;

namespace Vsoft.Estacionamento.Core.Models
{
    public class IlhaModel : BaseModel
    {
        public string Localizacao { get; set; }

        // Relationship
        public List<VagaModel> Vagas { get; set; }
    }
}
