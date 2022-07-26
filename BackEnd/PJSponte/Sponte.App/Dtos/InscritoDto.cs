using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.App.Dtos
{
    public class InscritoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string EndInstagram { get; set; }
    }
}
