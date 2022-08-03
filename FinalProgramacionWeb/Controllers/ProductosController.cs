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
    public class ProductosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SKU,Nombre,Descripcion")] Producto producto)
        {
            producto.Activo = true;
            producto.FechaAlta = DateTime.Now;

            ValidarProducto(producto, true);

            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Producto producto = db.Productos.Find(id);
            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SKU,Nombre,Descripcion,Activo")] Producto producto)
        {
            ValidarProducto(producto, false);

            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        private void ValidarProducto(Producto producto, bool creacion)
        {
            if (creacion)
                if (db.Productos.Any(p => p.SKU == producto.SKU && p.Activo))
                    ModelState["SKU"].Errors.Add("El SKU ingresado ya existe.");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Producto producto = db.Productos.Find(id);
            if (producto == null)
                return HttpNotFound();

            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            producto.Activo = false;
            producto.FechaBaja = DateTime.Now;

            db.Entry(producto).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Activate(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Producto producto = db.Productos.Find(id);
            if (producto == null)
                return HttpNotFound();

            bool puedeActivarse = !db.Productos.Any(p => p.SKU == producto.SKU);

            return View((producto, puedeActivarse));
        }

        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            producto.Activo = true;
            producto.FechaBaja = SqlDateTime.Null;

            db.Entry(producto).State = EntityState.Modified;
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
