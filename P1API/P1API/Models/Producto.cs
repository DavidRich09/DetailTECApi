using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class Producto
    {
        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public int? Costo { get; set; }
        public int CedProveedor { get; set; }
        public string? TipoLavado { get; set; }

        public virtual Proveedor CedProveedorNavigation { get; set; } = null!;
        public virtual Lavado? TipoLavadoNavigation { get; set; }
    }
}
