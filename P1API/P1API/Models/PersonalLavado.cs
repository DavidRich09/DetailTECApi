using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class PersonalLavado
    {
        public string? TipoLavado { get; set; }
        public string? Rol { get; set; }

        public virtual Lavado? TipoLavadoNavigation { get; set; }
    }
}
