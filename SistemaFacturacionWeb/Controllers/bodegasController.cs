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
    public class bodegasController : Controller
    {
        private facturacionEntities db = new facturacionEntities();

        // GET: bodegas
        public ActionResult Index()
        {
            var bodega = db.bodega.Include(b => b.sucursal);
            return View(bodega.ToList());
        }

        // GET: bodegas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            bodega bodega = db.bodega.Find(id);
            if (bodega == null)
            {
                return RedirectToAction("Error");
            }
            return View(bodega);
        }

        // GET: bodegas/Create
        public ActionResult Create()
        {
            ViewBag.IdSucursalBodega = new SelectList(db.sucursal, "IdSucursal", "NombreSucursal");
            return View();
        }

        // POST: bodegas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBodega,NombreBodega,IdSucursalBodega")] bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.bodega.Add(bodega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSucursalBodega = new SelectList(db.sucursal, "IdSucursal", "NombreSucursal", bodega.IdSucursalBodega);
            return View(bodega);
        }

        // GET: bodegas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            bodega bodega = db.bodega.Find(id);
            if (bodega == null)
            {
                return RedirectToAction("Error");
            }
            ViewBag.IdSucursalBodega = new SelectList(db.sucursal, "IdSucursal", "NombreSucursal", bodega.IdSucursalBodega);
            return View(bodega);
        }

        // POST: bodegas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBodega,NombreBodega,IdSucursalBodega")] bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSucursalBodega = new SelectList(db.sucursal, "IdSucursal", "NombreSucursal", bodega.IdSucursalBodega);
            return View(bodega);
        }

        // GET: bodegas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            bodega bodega = db.bodega.Find(id);
            if (bodega == null)
            {
                return RedirectToAction("Error");
            }
            return View(bodega);
        }

        // POST: bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bodega bodega = db.bodega.Find(id);
            db.bodega.Remove(bodega);
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
