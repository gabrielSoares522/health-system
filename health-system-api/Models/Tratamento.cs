using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace health_system.Models
{
    public class Tratamento
    {
        public int Id { get; set; }
        public int qtDiasDuracao { get; set; }
        public string Observacao { get; set; }
        public int qtHorasIntervalo { get; set; }
        public int qtDose { get; set; }

        public int ConsultaId { get; set; }
        public Consulta Consulta { get; set; }

        public int RemedioId { get; set; }
        public Remedio Remedio { get; set; }


    }
}
