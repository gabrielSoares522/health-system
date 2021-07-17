﻿using System.Collections.Generic;

namespace health_system_api.Models
{
    public class Doenca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }
    }
}
