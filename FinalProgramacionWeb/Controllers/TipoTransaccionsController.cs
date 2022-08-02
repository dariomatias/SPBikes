using System;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Datos.Models;

namespace FinalProgramacionWeb.Controllers
{
    public class TipoTransaccionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Activate(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TipoTransaccion tipoTransaccion = db.TiposTransacciones.Find(id);
            if (tipoTransaccion == null || tipoTransaccion.Activo) return HttpNotFound();

            return View(tipoTransaccion);
        }

        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateConfirmed(int id)
        {
            TipoTransaccion tipoTransaccion = db.TiposTransacciones.Find(id);
            Desactivar(tipoTransaccion, true);
            return RedirectToAction("Index");
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion")] TipoTransaccion tipoTransaccion)
        {
            tipoTransaccion.Activo = true;
            tipoTransaccion.FechaAlta = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                db.TiposTransacciones.Add(tipoTransaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTransaccion);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TipoTransaccion tipoTransaccion = db.TiposTransacciones.Find(id);
            if (tipoTransaccion == null || !tipoTransaccion.Activo) return HttpNotFound();

            return View(tipoTransaccion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTransaccion tipoTransaccion = db.TiposTransacciones.Find(id);
            Desactivar(tipoTransaccion);
            return RedirectToAction("Index");
        }

        public void Desactivar(TipoTransaccion item, bool reverse = false)
        {
            item.Activo = reverse;
            item.FechaBaja = reverse ? SqlDateTime.Null : DateTime.Now;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TipoTransaccion tipoTransaccion = db.TiposTransacciones.Find(id);
            if (tipoTransaccion == null || !tipoTransaccion.Activo) return HttpNotFound();

            return View(tipoTransaccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] TipoTransaccion tipoTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTransaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTransaccion);
        }

        public ActionResult Index()
        {
            var tiposDeTransaccion =
                db.TiposTransacciones.ToList();

            return View(tiposDeTransaccion);
        }
    }
}
