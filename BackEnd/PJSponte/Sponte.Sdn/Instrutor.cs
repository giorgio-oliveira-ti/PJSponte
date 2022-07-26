using System;
using System.Collections.Generic;

namespace Sponte.Sdn
{
    public class Instrutor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string AndInstagram { get; set; }
        public IEnumerable<Live> Live { get; set; }
    }
}