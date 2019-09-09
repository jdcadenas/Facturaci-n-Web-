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
    public class tipodocumentoesController : Controller
    {
        private facturacionEntities db = new facturacionEntities();

        // GET: tipodocumentoes
        public ActionResult Index()
        {
            var tipodocumento = db.tipodocumento.Include(t => t.sucursal);
            return View(tipodocumento.ToList());
        }

        // GET: tipodocumentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            tipodocumento tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return RedirectToAction("Error");
            }
            return View(tipodocumento);
        }

        // GET: tipodocumentoes/Create
        public ActionResult Create()
        {
            ViewBag.IdSucursalEncabezado = new SelectList(db.sucursal, "IdSucursal", "NombreSucursal");
            return View();
        }

        // POST: tipodocumentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEncabezado,TipoEncabezado,TituloEncabezado,LogoEncabezado,IdSucursalEncabezado")] tipodocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                db.tipodocumento.Add(tipodocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSucursalEncabezado = new SelectList(db.sucursal, "IdSucursal", "NombreSucursal", tipodocumento.IdSucursalEncabezado);
            return View(tipodocumento);
        }

        // GET: tipodocumentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            tipodocumento tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return RedirectToAction("Error");
            }
            ViewBag.IdSucursalEncabezado = new SelectList(db.sucursal, "IdSucursal", "NombreSucursal", tipodocumento.IdSucursalEncabezado);
            return View(tipodocumento);
        }

        // POST: tipodocumentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEncabezado,TipoEncabezado,TituloEncabezado,LogoEncabezado,IdSucursalEncabezado")] tipodocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSucursalEncabezado = new SelectList(db.sucursal, "IdSucursal", "NombreSucursal", tipodocumento.IdSucursalEncabezado);
            return View(tipodocumento);
        }

        // GET: tipodocumentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            tipodocumento tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return RedirectToAction("Error");
            }
            return View(tipodocumento);
        }

        // POST: tipodocumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipodocumento tipodocumento = db.tipodocumento.Find(id);
            db.tipodocumento.Remove(tipodocumento);
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
