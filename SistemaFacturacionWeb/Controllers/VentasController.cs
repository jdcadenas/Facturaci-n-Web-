using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaFacturacionWeb.Models;
using System.Configuration;
using System.Data.SqlClient;
//using SistemaFacturacionWeb.Reportes;
using CrystalDecisions.CrystalReports.Engine;

using System.IO;

namespace SistemaFacturacionWeb.Controllers
{
    [Authorize(Roles = "Facturador,Administrador")]
    public class VentasController : Controller
    {
        private SqlConnection con;
        facturacionEntities db = new facturacionEntities();


        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["facturacionConnectionString"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: Ventas
        public ActionResult Index()
        {
            return View(db.Ventas.ToList());
        }

        public ActionResult Imprimir(string cod)
        {
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reportes"), "Factura.rpt"));
                rd.SetParameterValue("@Param", cod);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Factura.pdf");
            
        }

        public ActionResult ImprimirVentasLista()
        {
            DateTime fecha = DateTime.Today;
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes"), "VentasLista.rpt"));
            rd.SetParameterValue("@Param", fecha);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "VentasLista.pdf");


        }



        public ActionResult SaveOrder(string Cliente, String Factura, VentasDetalles[] order)
        {
            string result = "Orden no Completada";
            if (Cliente != null && Factura != null && order != null)
            {
                    
                var CustomerId = Guid.NewGuid();
                Ventas model = new Ventas();
                model.CustomerId = CustomerId;
                model.Cliente = Cliente;
                model.Factura = Factura;
                model.OrderDate = DateTime.Now;
                db.Ventas.Add(model);

                foreach (var item in order)
                {

                    
                    var orderId = Guid.NewGuid();
                    VentasDetalles O = new VentasDetalles();
                    O.OrderId = orderId;
                    O.Articulo = item.Articulo;
                    O.Cantidad = item.Cantidad;
                    O.Precio = item.Precio;
                    O.ArticuloCodigo = item.Articulo;
                    O.Total = item.Cantidad* item.Precio;
                    O.CustomerId = CustomerId;

                    //

                   Conectar();
                   SqlCommand comando = new SqlCommand("update articulo set CantidadArticulo = ((CantidadArticulo)-('" + item.Cantidad + "')) where codigo='" + item.Articulo + "'", con);
                   con.Open();
                   int i = comando.ExecuteNonQuery();
                   con.Close();
                    db.VentasDetalles.Add(O);
                    //


                    string Pid = Convert.ToString(CustomerId);

                    result = Pid;
                }
                db.SaveChanges();
                

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Ventas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas Ventas = db.Ventas.Find(id);
            if (Ventas == null)
            {
                return HttpNotFound();
            }
            return View(Ventas);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Cliente,Factura,OrderDate")] Ventas Ventas)
        {
            if (ModelState.IsValid)
            {
                Ventas.CustomerId = Guid.NewGuid();
                db.Ventas.Add(Ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Ventas);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas Ventas = db.Ventas.Find(id);
            if (Ventas == null)
            {
                return HttpNotFound();
            }
            return View(Ventas);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Cliente,Factura,OrderDate")] Ventas Ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Ventas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Ventas);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas Ventas = db.Ventas.Find(id);
            if (Ventas == null)
            {
                return HttpNotFound();
            }
            return View(Ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Ventas Ventas = db.Ventas.Find(id);
            db.Ventas.Remove(Ventas);
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
