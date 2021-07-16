using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace health_system.Models
{
    public class Diagnostico
    {
        public int DoencaId { get; set; }
        public Doenca Doenca { get; set; }

        public int ConsultaId { get; set; }
        public Consulta Consulta { get; set; }
    }
}
