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
    public class RolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Activate(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Rol rol = db.Rols.Find(id);
            if (rol == null) return HttpNotFound();
            return View(rol);
        }

        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateConfirmed(int id)
        {
            Rol rol = db.Rols.Find(id);
            rol.Activo = true;
            rol.FechaBaja = SqlDateTime.Null;
            db.Entry(rol).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion")] Rol rol)
        {
            rol.Activo = true;
            rol.FechaAlta = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Rols.Add(rol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rol);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Rol rol = db.Rols.Find(id);
            if (rol == null) return HttpNotFound();
            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Rol rol = db.Rols.Find(id);
            if (rol == null) return HttpNotFound();
            return View(rol);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol rol = db.Rols.Find(id);
            rol.Activo = false;
            rol.FechaBaja = DateTime.Now;
            db.Entry(rol).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View(db.Rols.ToList());
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
