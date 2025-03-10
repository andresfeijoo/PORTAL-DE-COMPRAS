using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using PortalCompras.Models;

namespace PortalCompras.Controllers
{
    //[Authorize(Roles = "Prov")]
    public class LicitacionCotizacionProvController : Controller
    {
        // Obtiene el email del usuario logueado, que es el mismo que el username.
        
        public ActionResult Index()
        {
            // Obtiene el email del usuario logueado, que es el mismo que el username.
            string emailUsuario = User.Identity.GetUserName();

            // Filtra las cotizaciones en las que el correo del proveedor coincide con el email del usuario logueado.
            var licitacionCotizacionProvs = db.LicitacionCotizacionProvs
                .Include(l => l.Licitacione)
                .Include(l => l.Producto)
                .Include(l => l.Proveedor)
                .Where(l => l.Proveedor.CorreoProveedor == emailUsuario);

            return View(licitacionCotizacionProvs.ToList());
        }
        



        private PortalComprasEntities db = new PortalComprasEntities();
        
       
        public ActionResult Indexadm()
        {
            var licitacionCotizacionProvs = db.LicitacionCotizacionProvs.Include(l => l.Licitacione).Include(l => l.Producto).Include(l => l.Proveedor);
            return View(licitacionCotizacionProvs.ToList());
        }
        
        // GET: LicitacionCotizacionProv/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionCotizacionProv licitacionCotizacionProv = db.LicitacionCotizacionProvs.Find(id);
            if (licitacionCotizacionProv == null)
            {
                return HttpNotFound();
            }
            return View(licitacionCotizacionProv);
        }

        // GET: LicitacionCotizacionProv/Create
        public ActionResult Create()
        {
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion");
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto");


            string emailUsuario = User.Identity.GetUserName();

            // Busca el proveedor que tenga ese correo.
            var proveedor = db.Proveedors.FirstOrDefault(p => p.CorreoProveedor == emailUsuario);
            ViewBag.IdProveedor = new SelectList(new List<Proveedor> { proveedor }, "IdProveedor", "NombreProveedor");




           // ViewBag.IdProveedor = new SelectList(db.Proveedors, "CorreoProveedor", "NombreProveedor");
            return View();
        }

        // POST: LicitacionCotizacionProv/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCotizacion,IdLicitacion,IdProducto,IdProveedor,FechaCotizacionProveedor,PrecioUnitario")] LicitacionCotizacionProv licitacionCotizacionProv)
        {
            if (ModelState.IsValid)
            {
                db.LicitacionCotizacionProvs.Add(licitacionCotizacionProv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", licitacionCotizacionProv.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacionCotizacionProv.IdProducto);



            string emailUsuario = User.Identity.GetUserName();

            // Busca el proveedor que tenga ese correo.
            var proveedor = db.Proveedors.FirstOrDefault(p => p.CorreoProveedor == emailUsuario);
            ViewBag.IdProveedor = new SelectList(new List<Proveedor> { proveedor }, "IdProveedor", "NombreProveedor");








           // ViewBag.IdProveedor = new SelectList(db.Proveedors, "CorreoProveedor", "NombreProveedor", licitacionCotizacionProv.Proveedor);
            return View(licitacionCotizacionProv);
        }

        // GET: LicitacionCotizacionProv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionCotizacionProv licitacionCotizacionProv = db.LicitacionCotizacionProvs.Find(id);
            if (licitacionCotizacionProv == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", licitacionCotizacionProv.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacionCotizacionProv.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedors, "IdProveedor", "NombreProveedor", licitacionCotizacionProv.IdProveedor);
            return View(licitacionCotizacionProv);
        }

        // POST: LicitacionCotizacionProv/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCotizacion,IdLicitacion,IdProducto,IdProveedor,FechaCotizacionProveedor,PrecioUnitario")] LicitacionCotizacionProv licitacionCotizacionProv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licitacionCotizacionProv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", licitacionCotizacionProv.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", licitacionCotizacionProv.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedors, "IdProveedor", "NombreProveedor", licitacionCotizacionProv.IdProveedor);
            return View(licitacionCotizacionProv);
        }

        // GET: LicitacionCotizacionProv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicitacionCotizacionProv licitacionCotizacionProv = db.LicitacionCotizacionProvs.Find(id);
            if (licitacionCotizacionProv == null)
            {
                return HttpNotFound();
            }
            return View(licitacionCotizacionProv);
        }

        // POST: LicitacionCotizacionProv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicitacionCotizacionProv licitacionCotizacionProv = db.LicitacionCotizacionProvs.Find(id);
            db.LicitacionCotizacionProvs.Remove(licitacionCotizacionProv);
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
