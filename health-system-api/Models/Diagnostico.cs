namespace health_system_api.Models
{
    public class Diagnostico
    {
        public int DoencaId { get; set; }
        public Doenca Doenca { get; set; }

        public int ConsultaId { get; set; }
        public Consulta Consulta { get; set; }
    }
}
