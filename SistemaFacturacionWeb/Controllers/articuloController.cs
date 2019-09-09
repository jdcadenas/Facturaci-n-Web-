using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaFacturacionWeb.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;


namespace SistemaFacturacionWeb.Controllers
{

    [Authorize(Roles = "Facturador,Administrador")]
    public class articuloController : Controller
    {
        private facturacionEntities db = new facturacionEntities();


        
        // GET: articulo
        public ActionResult Index()
        {
            return View(db.articulo.ToList());
        }

        public ActionResult Imprimir()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes"), "ListaProductos.rpt"));
            rd.SetDataSource(db.articulo.Select(p => new
            {
                Codigo = p.Codigo,
                DescripcionArticulo = p.DescripcionArticulo,
                PrecioPromedioArticulo = p.PrecioPromedioArticulo,
                CantidadArticulo = p.CantidadArticulo,
                FechaVencimiento = p.FechaVencimiento
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Lista.pdf");


        }

        public ActionResult ImprimirstockMin()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes"), "StockMinQ.rpt"));
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "StockMinQ.pdf");


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


        // GET: articulo/Details/5
        public ActionResult Details(int id=0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: articulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockMinArticulo,StockMaxArticulo,Codigo,PrecioPromedioArticulo,CantidadArticulo,FechaVencimiento,DescripcionArticulo,UnidadMedidaArticulo,NombreArticulo")] articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.articulo.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articulo);
        }

        // GET: articulo/Edit/5
        public ActionResult Edit(int id=0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: articulo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArticulo,NombreArticulo,StockMinArticulo,StockMaxArticulo,Codigo,PrecioPromedioArticulo,CantidadArticulo,FechaVencimiento,DescripcionArticulo,UnidadMedidaArticulo")] articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articulo);
        }

        // GET: articulo/Delete/5
        public ActionResult Delete(int id=0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            articulo articulo = db.articulo.Find(id);
            db.articulo.Remove(articulo);
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
