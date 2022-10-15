using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Cita = new HashSet<Citum>();
        }

        public string Nombre { get; set; } = null!;
        public string? Provincia { get; set; }
        public string? Canton { get; set; }
        public string? Distrito { get; set; }
        public int Telefono { get; set; }
        public DateTime? InicioGerente { get; set; }
        public DateTime? Apertura { get; set; }
        public int? CedGerente { get; set; }

        public virtual Trabajador? CedGerenteNavigation { get; set; }
        public virtual ICollection<Citum> Cita { get; set; }
    }
}
