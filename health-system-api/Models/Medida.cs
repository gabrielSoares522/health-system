using System.Collections.Generic;

namespace health_system_api.Models
{
    public class Medida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Remedio> Remedios { get; set; }
    }
}
