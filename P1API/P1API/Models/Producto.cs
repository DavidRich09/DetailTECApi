using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class Producto
    {
        public Producto()
        {
            LavadoProductos = new HashSet<LavadoProducto>();
        }

        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public int? Costo { get; set; }
        public string TipoLavado { get; set; } = null!;

        public virtual ICollection<LavadoProducto> LavadoProductos { get; set; }
    }
}
