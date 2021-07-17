using System;
using System.Collections.Generic;

namespace health_system_api.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime diaConsulta { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario{ get; set; }

        public List<Tratamento> Tratamentos { get; set; }

        public List<Diagnostico> Diagnosticos { get; set; }

    }
}
