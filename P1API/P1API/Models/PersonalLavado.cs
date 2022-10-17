using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class PersonalLavado
    {
        public string TipoLavado { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public int Cantidad { get; set; }

        public virtual Lavado TipoLavadoNavigation { get; set; } = null!;
    }
}
