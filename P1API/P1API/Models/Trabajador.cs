using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class Trabajador
    {
        public Trabajador()
        {
            Cita = new HashSet<Citum>();
            Sucursals = new HashSet<Sucursal>();
        }

        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? TPassword { get; set; }
        public string? TPago { get; set; }
        public string? Rol { get; set; }
        public DateTime? Nacimiento { get; set; }
        public int? Edad { get; set; }
        public DateTime? Ingreso { get; set; }

        public virtual ICollection<Citum> Cita { get; set; }
        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
