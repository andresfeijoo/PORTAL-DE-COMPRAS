using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PortalCompras.Models;

namespace PortalCompras.Controllers
{
    public class AdjudicacionLicitacionProveedorController : Controller
    {
        private PortalComprasEntities db = new PortalComprasEntities();

        // GET: AdjudicacionLicitacionProveedor
        public ActionResult Indexprov()
        {
            var adjudicaciones = db.AdjudicacionLicitacionProveedors
                .Include(a => a.LicitacionCotizacionProv)
                .Include(a => a.Licitacione)
                .Include(a => a.Producto);

            if (User.IsInRole("Prov"))
            {
                string correoProv = User.Identity.Name;
                var proveedor = db.Proveedors
                    .FirstOrDefault(p => p.CorreoProveedor.Equals(correoProv, StringComparison.OrdinalIgnoreCase));
                if (proveedor != null)
                {
                    adjudicaciones = adjudicaciones.Where(a => a.LicitacionCotizacionProv.IdProveedor == proveedor.IdProveedor);
                }
                else
                {
                    return Index();
                }
            }
            return View(adjudicaciones.ToList());
        }

        public ActionResult Index()
        {
            var adjudicaciones = db.AdjudicacionLicitacionProveedors
                .Include(a => a.LicitacionCotizacionProv)
                .Include(a => a.Licitacione)
                .Include(a => a.Producto);

            if (User.IsInRole("Prov"))
            {
                string correoProv = User.Identity.Name;
                var proveedor = db.Proveedors
                    .FirstOrDefault(p => p.CorreoProveedor.Equals(correoProv, StringComparison.OrdinalIgnoreCase));
                if (proveedor != null)
                {
                    adjudicaciones = adjudicaciones.Where(a => a.LicitacionCotizacionProv.IdProveedor == proveedor.IdProveedor);
                }
                else
                {
                    return new HttpNotFoundResult("Proveedor no encontrado.");
                }
            }
            return View(adjudicaciones.ToList());
        }

        // GET: AdjudicacionLicitacionProveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor = db.AdjudicacionLicitacionProveedors.Find(id);
            if (adjudicacionLicitacionProveedor == null)
                return HttpNotFound();
            return View(adjudicacionLicitacionProveedor);
        }

        public ActionResult Detailspro(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var cotizacion = db.AdjudicacionLicitacionProveedors
                        .Include(a => a.LicitacionCotizacionProv)
                        .FirstOrDefault(a => a.IdAdjudicacion == id);
            if (cotizacion == null)
                return HttpNotFound();
            ViewBag.PrecioUnitario = cotizacion.LicitacionCotizacionProv.PrecioUnitario;
            return View(cotizacion);
        }

        // GET: AdjudicacionLicitacionProveedor/Create
        public ActionResult Create()
        {
            // Cargamos las licitaciones para el dropdown
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion");
            // Los dropdowns de cotización se llenarán vía AJAX.
            return View();
        }

        // POST: AdjudicacionLicitacionProveedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdjudicacion,IdLicitacion,IdCotizacion,IdProducto,FormaPagoAdj")] AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor)
        {
            if (ModelState.IsValid)
            {
                // Es posible que IdAdjudicacion sea autogenerado; de ser así, no se debe enviarlo desde la vista.
                db.AdjudicacionLicitacionProveedors.Add(adjudicacionLicitacionProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", adjudicacionLicitacionProveedor.IdLicitacion);
            return View(adjudicacionLicitacionProveedor);
        }

        // GET: AdjudicacionLicitacionProveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor = db.AdjudicacionLicitacionProveedors.Find(id);
            if (adjudicacionLicitacionProveedor == null)
                return HttpNotFound();
            ViewBag.IdCotizacion = new SelectList(db.LicitacionCotizacionProvs, "IdCotizacion", "IdCotizacion", adjudicacionLicitacionProveedor.IdCotizacion);
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", adjudicacionLicitacionProveedor.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", adjudicacionLicitacionProveedor.IdProducto);
            return View(adjudicacionLicitacionProveedor);
        }

        // POST: AdjudicacionLicitacionProveedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdjudicacion,IdLicitacion,IdCotizacion,IdProducto,FormaPagoAdj")] AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adjudicacionLicitacionProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCotizacion = new SelectList(db.LicitacionCotizacionProvs, "IdCotizacion", "IdCotizacion", adjudicacionLicitacionProveedor.IdCotizacion);
            ViewBag.IdLicitacion = new SelectList(db.Licitaciones, "IdLicitacion", "NombreLicitacion", adjudicacionLicitacionProveedor.IdLicitacion);
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "NombreProducto", adjudicacionLicitacionProveedor.IdProducto);
            return View(adjudicacionLicitacionProveedor);
        }

        // GET: AdjudicacionLicitacionProveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor = db.AdjudicacionLicitacionProveedors.Find(id);
            if (adjudicacionLicitacionProveedor == null)
                return HttpNotFound();
            return View(adjudicacionLicitacionProveedor);
        }

        // POST: AdjudicacionLicitacionProveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdjudicacionLicitacionProveedor adjudicacionLicitacionProveedor = db.AdjudicacionLicitacionProveedors.Find(id);
            db.AdjudicacionLicitacionProveedors.Remove(adjudicacionLicitacionProveedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Acción AJAX para filtrar las cotizaciones según la licitación seleccionada
        public ActionResult GetCotizacionesByLicitacion(int idLicitacion)
        {
            var cotizaciones = db.LicitacionCotizacionProvs
                .Where(c => c.IdLicitacion == idLicitacion)
                .Select(c => new
                {
                    Id = c.IdCotizacion,
                    Nombre = "Cotización " + c.IdCotizacion, // O la descripción que prefieras
                    Producto = c.Producto.NombreProducto,    // Se asume que la relación existe
                    IdProducto = c.IdProducto,                 // Se envía el identificador del producto
                    PrecioUnitario = c.PrecioUnitario
                })
                .ToList();

            return Json(cotizaciones, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
