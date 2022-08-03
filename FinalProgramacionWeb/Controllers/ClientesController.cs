using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace FinalProgramacionWeb.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CUIT,Id,RazonSocial,Nombre,Apellido,Direccion,Telefono")] Cliente cliente)
        {
            cliente.Activo = true;
            cliente.FechaAlta = DateTime.Now;

            ValidarCliente(cliente, true);

            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        private void ValidarCliente(Cliente cliente, bool creacion)
        {
            if (creacion)
            {
                //Validaciones CUIT
                if (db.Clientes.Any(c => c.CUIT == cliente.CUIT && c.Activo == true))
                    ModelState["CUIT"].Errors.Add("El CUIT ya existe.");
                if (!Regex.IsMatch(cliente.CUIT, "[0-9]{2}-[0-9]{6,8}-[0-9]{1}"))
                    ModelState["CUIT"].Errors.Add("El formato del CUIT Ingresado es inválido.");

                //Validaciones Razon Social
                if (db.Clientes.Any(c => c.Activo && c.RazonSocial == cliente.RazonSocial))
                    ModelState["RazonSocial"].Errors.Add("La Razón Social ingresada ya existe.");

            }

            //Validaciones Direccion
            if (!Regex.IsMatch(cliente.Direccion, "[A-Z,a-z, ,']{0,50} [0-9]{1,8}"))
                ModelState["Direccion"].Errors.Add("El formato de la Dirección es inválido.");

            //Validaciones telefono
            if (!Regex.IsMatch(cliente.Telefono, "[0-9]{0,5}[-, ]{1}[0-9]{0,4}[-, ]{1}[0-9]{4}"))
                ModelState["Telefono"].Errors.Add("El formato del Telefono es inválido.");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null) return HttpNotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazonSocial,CUIT,Nombre,Apellido,Direccion,Telefono,Activo")] Cliente cliente)
        {
            ValidarCliente(cliente, false);
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Activate(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateConfirmed(int? id)
        {
            Cliente cliente = db.Clientes.Find(id);
            cliente.Activo = true;
            cliente.FechaBaja = SqlDateTime.Null;

            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Cliente cliente = db.Clientes.Find(id);
            cliente.Activo = false;
            cliente.FechaBaja = DateTime.Now;

            db.Entry(cliente).State = EntityState.Modified;
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
