using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class Lavado
    {
        public Lavado()
        {
            Cita = new HashSet<Citum>();
            LavadoProductos = new HashSet<LavadoProducto>();
            PersonalLavados = new HashSet<PersonalLavado>();
        }

        public string TipoLavado { get; set; } = null!;
        public string? Duracion { get; set; }
        public int? Costo { get; set; }
        public int? Precio { get; set; }
        public int? PuntosOtorga { get; set; }
        public int? PuntosRedimir { get; set; }

        public virtual ICollection<Citum> Cita { get; set; }
        public virtual ICollection<LavadoProducto> LavadoProductos { get; set; }
        public virtual ICollection<PersonalLavado> PersonalLavados { get; set; }
    }
}
