using health_system_api.Enum;
using System;
using System.Collections.Generic;

namespace health_system_api.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Genero { get; set; }
        public DateTime Nascimento { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
