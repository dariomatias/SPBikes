using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace FinalProgramacionWeb.Controllers
{
    public class FacturasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Facturas.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Factura factura = db.Facturas.Find(id);
            if (factura == null) 
                return HttpNotFound();
            
            return View(factura);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Activo,NumeroDeFactura,Importe,IdCliente")] Factura factura)
        {
            var idClienteFromForm = Request.Form["idCliente"];
            Cliente cliente = db.Clientes.Find(Convert.ToInt16(idClienteFromForm));
            if (cliente == null) return HttpNotFound();

            factura.Cliente = cliente;
            factura.FechaAlta = DateTime.Now;
            factura.Activo = true;

            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factura);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
                return HttpNotFound();

            return View(factura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            factura.Activo = false;
            factura.FechaBaja = DateTime.Now;

            db.Entry(factura).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Activate(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
                return HttpNotFound();

            return View(factura);
        }

        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            factura.Activo = true;
            factura.FechaBaja = SqlDateTime.Null;

            db.Entry(factura).State = EntityState.Modified;
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
