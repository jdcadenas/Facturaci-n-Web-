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
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
//using SistemaFacturacionWeb.Reportes;

namespace SistemaFacturacionWeb.Controllers
{
    [Authorize(Roles = "Facturador,Administrador")]
    public class PresupuestoController : Controller
    {
        private SqlConnection con;
        facturacionEntities db = new facturacionEntities();


        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["facturacionConnectionString"].ToString();
            con = new SqlConnection(constr);
        }

        // GET: Presupuesto
        public ActionResult Index()
        {
            return View(db.Presupuesto.ToList());
        }

        public ActionResult Imprimir(string cod)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes"), "Presupuesto.rpt"));
            rd.SetParameterValue("@Param", cod);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Presupuesto.pdf");

        }

        public ActionResult SaveOrder(string Cliente, String Factura, PresupuestoDetalles[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (Cliente != null && Factura != null && order != null)
            {
                var CustomerId = Guid.NewGuid();
                Presupuesto model = new Presupuesto();
                model.CustomerId = CustomerId;
                model.Cliente = Cliente;
                model.Factura = Factura;
                model.OrderDate = DateTime.Now;
                db.Presupuesto.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    PresupuestoDetalles O = new PresupuestoDetalles();
                    O.OrderId = orderId;
                    O.Articulo = item.Articulo;
                    O.Cantidad = item.Cantidad;
                    O.Precio = item.Precio;
                    O.ArticuloCodigo = item.Articulo;
                    O.Total = item.Total;
                    O.CustomerId = CustomerId;
                    //

                   // Conectar();
                    //SqlCommand comando = new SqlCommand("update articulo set CantidadArticulo = ('" + item.Cantidad + "' + CantidadArticulo) where codigo='" + item.Articulo + "'", con);
                    //con.Open();
                    //int i = comando.ExecuteNonQuery();
                    //con.Close();
                    db.PresupuestoDetalles.Add(O);


                    string Pid = Convert.ToString(CustomerId);

                    result = Pid;

                    //

                   
                }
                db.SaveChanges();
                //result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Presupuesto/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // GET: Presupuesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Presupuesto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Cliente,Factura,OrderDate")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                presupuesto.CustomerId = Guid.NewGuid();
                db.Presupuesto.Add(presupuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(presupuesto);
        }

        // GET: Presupuesto/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // POST: Presupuesto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Cliente,Factura,OrderDate")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presupuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presupuesto);
        }

        // GET: Presupuesto/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // POST: Presupuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Presupuesto presupuesto = db.Presupuesto.Find(id);
            db.Presupuesto.Remove(presupuesto);
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
