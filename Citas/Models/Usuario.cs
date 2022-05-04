using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Models
{
    public class Usuario
    {
        [Display(Name = "Clave")]
        [Key]
        public int Id { get; set; }
        
        
        [Display(Name = "Name")]
        public string Nombre { get; set; }
        
        public string Apellido { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Cita> Citas { get; set; }
    }
}
