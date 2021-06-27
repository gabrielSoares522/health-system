using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace health_system.Models
{
    public class Doenca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }
    }
}
