using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practica20240214.Models
{
    public partial class Ropa
    {
        public int IdRopa { get; set; }
        public string NombreRopa { get; set; } = null!;
        public string? TipoRopa { get; set; }
        [Display(Name ="Talla")]
        public int? IdTalla { get; set; }

        public virtual Talla? IdTallaNavigation { get; set; }
    }
}
