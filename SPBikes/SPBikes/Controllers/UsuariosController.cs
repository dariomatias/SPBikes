using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPBikes.Data;
using SPBikes.Models;

namespace SPBikes.Controllers
{
    public class UsuariosController : Controller
    {
        private SPBikesContext db = new SPBikesContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            List<Usuario> lista = new List<Usuario>();

            Usuario U1 = new Usuario();
            U1.Id = 1;
            U1.Email = "esba@esba.com.ar";
            U1.Nombre = "Instituto";
            U1.Apellido = "ESBA";
            U1.Direccion = "Monroe 4171";
            U1.Telefono = "011-4311-1232";
            lista.Add(U1);

            return View(lista);
           // return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Usuario usuario = db.Usuarios.Find(id);
            //if (usuario == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(usuario);
            Usuario U1 = new Usuario();

            U1.Id = 1;
            U1.Email = "esba@esba.com.ar";
            U1.Nombre = "Instituto";
            U1.Apellido = "ESBA";
            U1.Direccion = "Monroe 4171";
            U1.Telefono = "011-4311-1232";
            return View(U1);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Nombre,Apellido,Direccion,Telefono,FechaAlta,FechaBaja,Activo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            //  if (id == null)
            //  {
            //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //  }
            //  Usuario usuario = db.Usuarios.Find(id);
            //  if (usuario == null)
            //  {
            //      return HttpNotFound();
            //  }
            //  return View(usuario);
            //  Usuario U1 = new Usuario();


            Usuario U1 = new Usuario();
            U1.Id = 1;
            U1.Email = "esba@esba.com.ar";
            U1.Nombre = "Instituto";
            U1.Apellido = "ESBA";
            U1.Direccion = "Monroe 4171";
            U1.Telefono = "011-4311-1232";


            return View(U1);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Nombre,Apellido,Direccion,Telefono,FechaAlta,FechaBaja,Activo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
          //  if (id == null)
          //  {
          //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          //  }
          //  Usuario usuario = db.Usuarios.Find(id);
          //  if (usuario == null)
          //  {
          //      return HttpNotFound();
          //  }
          //  return View(usuario);

            Usuario U1 = new Usuario();
            U1.Id = 1;
            U1.Email = "esba@esba.com.ar";
            U1.Nombre = "Instituto";
            U1.Apellido = "ESBA";
            U1.Direccion = "Monroe 4171";
            U1.Telefono = "011-4311-1232";


            return View(U1);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
