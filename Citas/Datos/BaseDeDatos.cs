using Citas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Datos
{
    public class BaseDeDatos
    {
        public static List<Usuario> Usuarios { get; set; } = new List<Usuario>(); 
    }
}
