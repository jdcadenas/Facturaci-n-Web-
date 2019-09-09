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
    public class sucursalesController : Controller
    {
        private facturacionEntities db = new facturacionEntities();

        // GET: sucursales
        public ActionResult Index()
        {
            var sucursal = db.sucursal.Include(s => s.AspNetUsers);
            return View(sucursal.ToList());
        }

        // GET: sucursales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return RedirectToAction("Error");
            }
            return View(sucursal);
        }

        // GET: sucursales/Create
        public ActionResult Create()
        {
            ViewBag.IdResponsableSucursal = new SelectList(db.AspNetUsers, "Id", "NombreUser");
            return View();
        }

        // POST: sucursales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSucursal,NombreSucursal,DetallesSucursal,DireccionSucursal,IdResponsableSucursal,TelefonoSucursal")] sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.sucursal.Add(sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdResponsableSucursal = new SelectList(db.AspNetUsers, "Id", "Email", sucursal.IdResponsableSucursal);
            return View(sucursal);
        }

        // GET: sucursales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return RedirectToAction("Error");
            }
            ViewBag.IdResponsableSucursal = new SelectList(db.AspNetUsers, "Id", "Email", sucursal.IdResponsableSucursal);
            return View(sucursal);
        }

        // POST: sucursales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSucursal,NombreSucursal,DetallesSucursal,DireccionSucursal,IdResponsableSucursal,TelefonoSucursal")] sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdResponsableSucursal = new SelectList(db.AspNetUsers, "Id", "Email", sucursal.IdResponsableSucursal);
            return View(sucursal);
        }

        // GET: sucursales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            sucursal sucursal = db.sucursal.Find(id);
            if (sucursal == null)
            {
                return RedirectToAction("Error");
            }
            return View(sucursal);
        }

        // POST: sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sucursal sucursal = db.sucursal.Find(id);
            db.sucursal.Remove(sucursal);
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
