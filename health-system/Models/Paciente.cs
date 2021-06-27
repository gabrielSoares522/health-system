using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace health_system.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Genero { get; set; }
        public int Idade { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
