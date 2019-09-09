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
    public class modopagoController : Controller
    {
        private facturacionEntities db = new facturacionEntities();

        // GET: modopago
        public ActionResult Index()
        {
            return View(db.modopago.ToList());
        }

        // GET: modopago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            modopago modopago = db.modopago.Find(id);
            if (modopago == null)
            {
                return RedirectToAction("Error");
            }
            return View(modopago);
        }

        // GET: modopago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: modopago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdModoPago,NombreModoPago,DetalleModoPago")] modopago modopago)
        {
            if (ModelState.IsValid)
            {
                db.modopago.Add(modopago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modopago);
        }

        // GET: modopago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            modopago modopago = db.modopago.Find(id);
            if (modopago == null)
            {
                return RedirectToAction("Error");
            }
            return View(modopago);
        }

        // POST: modopago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdModoPago,NombreModoPago,DetalleModoPago")] modopago modopago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modopago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modopago);
        }

        // GET: modopago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            modopago modopago = db.modopago.Find(id);
            if (modopago == null)
            {
                return RedirectToAction("Error");
            }
            return View(modopago);
        }

        // POST: modopago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modopago modopago = db.modopago.Find(id);
            db.modopago.Remove(modopago);
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
