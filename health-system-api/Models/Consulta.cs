using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace health_system.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime diaConsulta { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        public List<Tratamento> Tratamentos { get; set; }

        public List<Diagnostico> Diagnosticos { get; set; }

    }
}
