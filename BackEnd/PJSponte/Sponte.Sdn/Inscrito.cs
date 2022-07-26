using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.Sdn
{
    public class Inscrito
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string EndInstagram { get; set; }
        public IEnumerable<Inscricao> Inscricao { get; set; }

    }
}
