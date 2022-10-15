using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class TelCliente
    {
        public int? Telefono { get; set; }
        public int CedCliente { get; set; }

        public virtual Cliente CedClienteNavigation { get; set; } = null!;
    }
}
