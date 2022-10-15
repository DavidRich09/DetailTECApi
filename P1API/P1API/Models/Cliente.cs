using System;
using System.Collections.Generic;

namespace P1API.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cita = new HashSet<Citum>();
        }

        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Usuario { get; set; }
        public string? CPassword { get; set; }
        public string? Correo { get; set; }

        public virtual ICollection<Citum> Cita { get; set; }
    }
}
