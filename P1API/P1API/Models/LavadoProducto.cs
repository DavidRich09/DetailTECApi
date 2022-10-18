using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class LavadoProducto
    {
        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string TipoLavado { get; set; } = null!;
        public int? Cantidad { get; set; }

        public virtual Producto Producto { get; set; } = null!;
        public virtual Lavado TipoLavadoNavigation { get; set; } = null!;
    }
}
