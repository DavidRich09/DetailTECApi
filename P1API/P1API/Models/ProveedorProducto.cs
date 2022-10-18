using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class ProveedorProducto
    {
        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public int CedProveedor { get; set; }

        public virtual Proveedor CedProveedorNavigation { get; set; } = null!;
    }
}
