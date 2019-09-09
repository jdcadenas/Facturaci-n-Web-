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


namespace SistemaFacturacionWeb.Controllers
{

    [Authorize(Roles = "Facturador,Administrador")]
    public class ComprasController : Controller
    {
        private SqlConnection con;
        facturacionEntities db = new facturacionEntities();




        private void Conectar()
        {


            string constr = ConfigurationManager.ConnectionStrings["facturacionConnectionString"].ToString();
            con = new SqlConnection(constr);
        }


        public ActionResult Imprimir(string cod)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes"), "Compras.rpt"));
            rd.SetParameterValue("@Param", cod);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Compras.pdf");

        }

        // GET: Compras
        public ActionResult Index()
        {
            return View(db.Compras.ToList());
        }


        public ActionResult SaveOrder(string Cliente, String Factura, ComprasDetalles[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (Cliente != null && Factura != null && order != null)
            {
                var CustomerId = Guid.NewGuid();
                Compras model = new Compras();
                model.CustomerId = CustomerId;
                model.Proveedor = Cliente;
                model.Factura = Factura;
                model.OrderDate = DateTime.Now;
                db.Compras.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    ComprasDetalles O = new ComprasDetalles();
                    O.OrderId = orderId;
                    O.Articulo = item.Articulo;
                    O.Cantidad = item.Cantidad;
                    O.Precio = item.Precio;
                    O.ArticuloCodigo = item.Articulo;
                    O.Total = item.Cantidad+ item.Precio;
                    O.CustomerId = CustomerId;
                    //

                    Conectar();
                    SqlCommand comando = new SqlCommand("update articulo set CantidadArticulo = ((CantidadArticulo)+('" + item.Cantidad + "')) where codigo='" + item.Articulo + "'", con);
                    con.Open();
                    int i = comando.ExecuteNonQuery();
                    con.Close();
                    db.ComprasDetalles.Add(O);

                    string Pid = Convert.ToString(CustomerId);

                    result = Pid;

                }
                db.SaveChanges();
                //result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Compras/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras Compras = db.Compras.Find(id);
            if (Compras == null)
            {
                return HttpNotFound();
            }
            return View(Compras);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Cliente,Factura,OrderDate")] Compras Compras)
        {
            if (ModelState.IsValid)
            {
                Compras.CustomerId = Guid.NewGuid();
                db.Compras.Add(Compras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Compras);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras Compras = db.Compras.Find(id);
            if (Compras == null)
            {
                return HttpNotFound();
            }
            return View(Compras);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Cliente,Factura,OrderDate")] Compras Compras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Compras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Compras);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras Compras = db.Compras.Find(id);
            if (Compras == null)
            {
                return HttpNotFound();
            }
            return View(Compras);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Compras Compras = db.Compras.Find(id);
            db.Compras.Remove(Compras);
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
