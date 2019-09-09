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
    public class VentasDetallesController : Controller
    {
        private facturacionEntities db = new facturacionEntities();

        // GET: VentasDetalles
        public ActionResult Index()
        {
            var ventasDetalles = db.VentasDetalles.Include(v => v.Ventas);
            return View(ventasDetalles.ToList());
        }

       


        public ActionResult Buscar(String NombreArticulo)
        {
            var narticulo = from s in db.articulo select s;
            var articuloSl = narticulo.Where(j => j.NombreArticulo.Contains(NombreArticulo));
            //articulox articulos = db.articulo.Find(NombreArticulo);
            if (NombreArticulo == null)
            {
                return View(narticulo);
            }
            else
            {
                return View(articuloSl);
            }

        }

        // GET: VentasDetalles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasDetalles ventasDetalles = db.VentasDetalles.Find(id);
            if (ventasDetalles == null)
            {
                return HttpNotFound();
            }
            return View(ventasDetalles);
        }

        // GET: VentasDetalles/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Ventas, "CustomerId", "Cliente");
            return View();
        }

        // POST: VentasDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,Articulo,ArticuloCodigo,Cantidad,Precio,Total,CustomerId")] VentasDetalles ventasDetalles)
        {
            if (ModelState.IsValid)
            {
                ventasDetalles.OrderId = Guid.NewGuid();
                db.VentasDetalles.Add(ventasDetalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Ventas, "CustomerId", "Cliente", ventasDetalles.CustomerId);
            return View(ventasDetalles);
        }

        // GET: VentasDetalles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasDetalles ventasDetalles = db.VentasDetalles.Find(id);
            if (ventasDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Ventas, "CustomerId", "Cliente", ventasDetalles.CustomerId);
            return View(ventasDetalles);
        }

        // POST: VentasDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,Articulo,ArticuloCodigo,Cantidad,Precio,Total,CustomerId")] VentasDetalles ventasDetalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventasDetalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Ventas, "CustomerId", "Cliente", ventasDetalles.CustomerId);
            return View(ventasDetalles);
        }

        // GET: VentasDetalles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasDetalles ventasDetalles = db.VentasDetalles.Find(id);
            if (ventasDetalles == null)
            {
                return HttpNotFound();
            }
            return View(ventasDetalles);
        }

        // POST: VentasDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VentasDetalles ventasDetalles = db.VentasDetalles.Find(id);
            db.VentasDetalles.Remove(ventasDetalles);
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
