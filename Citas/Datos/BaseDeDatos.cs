using Citas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Datos
{
    public class BaseDeDatos : DbContext
    {
        //public static List<Usuario> Usuarios { get; set; } = new List<Usuario>(); 
        public BaseDeDatos(DbContextOptions opciones) : base(opciones)
        {

        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Citas.Models.Categoria> Categorias { get; set; }
        
        public DbSet<Citas.Models.Cita> Citas { get; set; }
    }
}
