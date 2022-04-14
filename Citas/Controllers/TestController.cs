using Citas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Hola()
        {
            return View("Chau");
        }

        //public IActionResult Saludar(string Mensaje, string Nombre)
        public IActionResult Saludar(Saludo saludo)
        {
            //ViewBag.Mensaje = Saludo;
            //Saludo saludo = new Saludo();
            //saludo.Mensaje = Mensaje;
            //saludo.Nombre = Nombre;
            return View(saludo);
        }
    }
}
