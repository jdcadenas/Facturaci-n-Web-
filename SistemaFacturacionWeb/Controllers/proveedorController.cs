using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaFacturacionWeb.Models;

namespace SistemaFacturacionWeb.Controllers
{
    [Authorize(Roles = "Facturador,Administrador")]
    public class proveedorController : Controller
    {
        
        private facturacionEntities db = new facturacionEntities();

        // GET: proveedor
        public ActionResult Index()
        {
            return View(db.proveedor.ToList());
        }

        // GET: proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return RedirectToAction("Error");
            }
            return View(proveedor);
        }

        // GET: proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProveedor,RazonSocialProveedor,RifProveedor,TelefonoProveedor,DireccionProveedor,DetallesProveedor,NombreContactoProveedor,SitioWebProveedor")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedor);
        }

        // GET: proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return RedirectToAction("Error");
            }
            return View(proveedor);
        }

        // POST: proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProveedor,RazonSocialProveedor,RifProveedor,TelefonoProveedor,DireccionProveedor,DetallesProveedor,NombreContactoProveedor,SitioWebProveedor")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        // GET: proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return RedirectToAction("Error");
            }
            return View(proveedor);
        }

        // POST: proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            db.proveedor.Remove(proveedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
