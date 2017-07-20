using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class MiTablasController : Controller
    {
        private CargaDatosEntities db = new CargaDatosEntities();

        // GET: MiTablas
        public ActionResult Index()
        {
            return View(db.MiTabla.ToList());
        }
        public ActionResult Buscar()
        {
            return View(db.MiTabla.ToList());
        }

        // GET: MiTablas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiTabla miTabla = db.MiTabla.Find(id);
            if (miTabla == null)
            {
                return HttpNotFound();
            }
            return View(miTabla);
        }

        // GET: MiTablas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiTablas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Detalle,Fecha,Precio,Cantidad")] MiTabla miTabla)
        {
            if (ModelState.IsValid)
            {
                db.MiTabla.Add(miTabla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miTabla);
        }

        // GET: MiTablas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiTabla miTabla = db.MiTabla.Find(id);
            if (miTabla == null)
            {
                return HttpNotFound();
            }
            return View(miTabla);
        }

        // POST: MiTablas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Detalle,Fecha,Precio,Cantidad")] MiTabla miTabla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miTabla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miTabla);
        }

        // GET: MiTablas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiTabla miTabla = db.MiTabla.Find(id);
            if (miTabla == null)
            {
                return HttpNotFound();
            }
            return View(miTabla);
        }

        // POST: MiTablas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MiTabla miTabla = db.MiTabla.Find(id);
            db.MiTabla.Remove(miTabla);
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
        public JsonResult BuscarDatosAutocomplete(string term)
        {
            var resultado = db.MiTabla.Where(x => x.Nombre.Contains(term)).Select(x => x.Nombre).ToList();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}
