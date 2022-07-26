using Sponte.Sdn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.App.Dtos
{
    public class InscricaoDto
    {
        public int Id { get; set; }
        public decimal ValorInscricao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public Boolean StatusPagamento { get; set; }
        public int LiveId { get; set; }
        public Live Live { get; set; }
        public int InscritoId { get; set; }
        public Inscrito Inscrito { get; set; }
    }
}
