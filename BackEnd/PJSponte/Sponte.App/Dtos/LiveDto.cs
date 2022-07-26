using Sponte.Sdn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.App.Dtos
{
    public class LiveDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public int DuracaoMinutos { get; set; }
        public decimal ValorInscricao { get; set; }
        public int? InstrutorId { get; set; }
        public Instrutor Instrutor { get; set; }
    }
}
