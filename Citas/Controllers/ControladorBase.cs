using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Citas.Controllers
{
    public class ControladorBase : Controller
    {
        public bool EsAdmin
        {
            get
            {
                string rol = User.FindFirstValue(ClaimTypes.Role);
                return rol.Equals("ADMIN");
            }
        }
        public int IdUsuario
        {
            get
            {
                string idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return int.Parse(idUsuario);
            }
        }
    }
}
