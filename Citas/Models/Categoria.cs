using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Models
{
    public class Categoria
    {
        [Display(Name = "Id")]
        [Key]
        public int Id { get; set; }


        [Display(Name = "Nombre de Categoria")]
        public string Descripcion { get; set; }

        public ICollection<Cita> Citas { get; set; }
    }
}
