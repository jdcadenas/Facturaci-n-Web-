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
    [Authorize(Roles = "Facturador,Administrador")]
    public class clientesController : Controller
    {
        private facturacionEntities db = new facturacionEntities();

        // GET: clientes
        public ActionResult Index()
        {
            return View(db.cliente.ToList());
            // forma de consulta
            //var cliente = (from p in db.cliente
            //               where p.NombreCliente == "Jorge "
            //              select p).ToList();
            //return View(cliente);
        }

        // GET: clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return RedirectToAction("Error");
            }
            return View(cliente);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,NombreCliente,CedulaCliente,DireccionCliente,FechaNacimientoCliente,TelefonoCliente,EmailCliente")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return RedirectToAction("Error");
            }
            return View(cliente);
        }

        // POST: clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,NombreCliente,CedulaCliente,DireccionCliente,FechaNacimientoCliente,TelefonoCliente,EmailCliente")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return RedirectToAction("Error");
            }
            return View(cliente);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente cliente = db.cliente.Find(id);
            db.cliente.Remove(cliente);
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
