using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class Citum
    {
        public string PlacaVehiculo { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string? TipoLavado { get; set; }
        public string? Sucursal { get; set; }
        public int? CedEmpleado { get; set; }
        public int? CedCliente { get; set; }

        public virtual Cliente? CedClienteNavigation { get; set; }
        public virtual Trabajador? CedEmpleadoNavigation { get; set; }
        public virtual Sucursal? SucursalNavigation { get; set; }
        public virtual Lavado? TipoLavadoNavigation { get; set; }
    }
}
