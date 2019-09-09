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
    [Authorize(Roles = "Administrador")]
    public class impuestosController : Controller
    {
        private facturacionEntities db = new facturacionEntities();

        // GET: impuestos
        public ActionResult Index()
        {
            return View(db.impuesto.ToList());
        }

        // GET: impuestos/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            impuesto impuesto = db.impuesto.Find(id);
            if (impuesto == null)
            {
                return RedirectToAction("Error");
            }
            return View(impuesto);
        }

        // GET: impuestos/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: impuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "IdImpuesto,NombreImpuesto,ValorAgregadoImpuesto")] impuesto impuesto)
        {
            if (ModelState.IsValid)
            {
                db.impuesto.Add(impuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(impuesto);
        }

        // GET: impuestos/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            impuesto impuesto = db.impuesto.Find(id);
            if (impuesto == null)
            {
                return RedirectToAction("Error");
            }
            return View(impuesto);
        }

        // POST: impuestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "IdImpuesto,NombreImpuesto,ValorAgregadoImpuesto")] impuesto impuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(impuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(impuesto);
        }

        // GET: impuestos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            impuesto impuesto = db.impuesto.Find(id);
            if (impuesto == null)
            {
                return RedirectToAction("Error");
            }
            return View(impuesto);
        }

        // POST: impuestos/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            impuesto impuesto = db.impuesto.Find(id);
            db.impuesto.Remove(impuesto);
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
