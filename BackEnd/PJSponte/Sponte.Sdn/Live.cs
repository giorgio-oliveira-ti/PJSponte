using System;
using System.Collections.Generic;

namespace Sponte.Sdn
{
    public class Live
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public int DuracaoMinutos { get; set; }
        public decimal ValorInscricao { get; set; }
        public int InstrutorId { get; set; }
        public Instrutor Instrutor { get; set; }
        public IEnumerable<Inscricao> Inscricao { get; set; }

    }
}
