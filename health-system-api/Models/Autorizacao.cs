using System.Collections.Generic;

namespace health_system_api.Models
{
    public class Autorizacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
