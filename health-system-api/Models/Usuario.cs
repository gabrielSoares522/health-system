using System.Collections.Generic;

namespace health_system_api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        public int AutorizacaoId { get; set; }
        public Autorizacao Autorizacao { get; set; }

        public List<Consulta> Consultas { get; set; }

        public string CRM { get; set; }
    }
}
