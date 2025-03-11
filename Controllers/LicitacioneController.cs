using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalCompras.Models;

namespace PortalCompras.Controllers
{
    public class LicitacioneController : Controller
    {
        private PortalComprasEntities db = new PortalComprasEntities();

        // GET: Licitacione
        public ActionResult Index()
        {
            var licitaciones = db.Licitaciones.Include(l => l.Licitador).Include(l => l.Producto);
            return View(licitaciones.ToList());
        }
        public ActionResult Indexprov()
        {
            var licitaciones = db.Licitaciones.Include(l => l.Licitador).Include(l => l.Producto);
            return View(licitaciones.ToList());
        }
        // GET: Licitacione/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitacione licitacione = db.Licitaciones.Find(id);
            if (licitacione == null)
            {
                return HttpNotFound();
            }
            return View(licitacione);
        }
        public ActionResult Detailspro(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitacione licitacione = db.Licitaciones.Find(id);
            if (licitacione == null)
            {
                return HttpNotFound();
            }
            return View(licitacione);
        }
        // GET: Licitacione/Create
        public ActionResult Create()
        {
            ViewBag.IdLicitador = new SelectList(db.Licitadors, "IdLicitador", "NombreLicitador");
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto");
            return View();
        }

        // POST: Licitacione/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLicitacion,NombreLicitacion,IdLicitador,FechaCreacionLicitacion,FechaCierreLicitacion,FechaAdjudicacionLicitacion,ObservacionesLicitacion,IdProducto")] Licitacione licitacione)
        {
            if (ModelState.IsValid)
            {
                db.Licitaciones.Add(licitacione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLicitador = new SelectList(db.Licitadors, "IdLicitador", "NombreLicitador", licitacione.IdLicitador);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacione.IdProducto);
            return View(licitacione);
        }

        // GET: Licitacione/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitacione licitacione = db.Licitaciones.Find(id);
            if (licitacione == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLicitador = new SelectList(db.Licitadors, "IdLicitador", "NombreLicitador", licitacione.IdLicitador);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacione.IdProducto);
            return View(licitacione);
        }

        // POST: Licitacione/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLicitacion,NombreLicitacion,IdLicitador,FechaCreacionLicitacion,FechaCierreLicitacion,FechaAdjudicacionLicitacion,ObservacionesLicitacion,IdProducto")] Licitacione licitacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLicitador = new SelectList(db.Licitadors, "IdLicitador", "NombreLicitador", licitacione.IdLicitador);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacione.IdProducto);
            return View(licitacione);
        }

        // GET: Licitacione/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licitacione licitacione = db.Licitaciones.Find(id);
            if (licitacione == null)
            {
                return HttpNotFound();
            }
            return View(licitacione);
        }

        // POST: Licitacione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Licitacione licitacione = db.Licitaciones.Find(id);
            db.Licitaciones.Remove(licitacione);
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
