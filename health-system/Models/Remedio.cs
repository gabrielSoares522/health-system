using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace health_system.Models
{
    public class Remedio
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public bool Liquida { get; set; }
        public int IngestaoId { get; set; }
        public Ingestao Ingestao { get; set; }
    }
}
