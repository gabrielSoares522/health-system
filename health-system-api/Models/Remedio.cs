using System.Collections.Generic;

namespace health_system_api.Models
{
    public class Remedio
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public int MedidaId { get; set; }

        public List<Tratamento> Tratamentos { get; set; }
        public Medida Medida { get; set; }
    }
}
