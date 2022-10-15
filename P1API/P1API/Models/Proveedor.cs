using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int CedJuridica { get; set; }
        public string? Nombre { get; set; }
        public int? Contacto { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
