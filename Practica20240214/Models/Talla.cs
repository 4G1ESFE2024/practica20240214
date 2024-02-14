using System;
using System.Collections.Generic;

namespace Practica20240214.Models
{
    public partial class Talla
    {
        public Talla()
        {
            Ropas = new HashSet<Ropa>();
        }

        public int IdTalla { get; set; }
        public string NombreTalla { get; set; } = null!;

        public virtual ICollection<Ropa> Ropas { get; set; }
    }
}
