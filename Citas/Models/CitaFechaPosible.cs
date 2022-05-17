using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Models
{
    public class CitaFechaPosible
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int CitaId { get; set; }
        public Cita Cita { get; set; }
    }
}
