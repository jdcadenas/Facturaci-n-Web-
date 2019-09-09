using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFacturacionWeb.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Facturador,Administrador")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection coleccion)
        {
            MantenimientoPersona m = new MantenimientoPersona();
            Persona per = m.Retornar(int.Parse(coleccion["Codigo"].ToString()));
            if (per != null)
                return View("EditarPersona", per);
            else
                return RedirectToAction("Index");
        }

    }
}