using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Models
{
    public class Cita
    {
        [Display(Name = "Id")]
        [Key]
        public int Id { get; set; }

        [Display(Name ="Fecha de Creacion de la Cita")]
        public DateTime Fechacreacion { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        //public int Usuario2Id { get; set; }
        //[ForeignKey("Usuario2Id")]
        //public Usuario UsuarioSuplente { get; set; }
    }
}
