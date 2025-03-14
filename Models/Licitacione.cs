//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortalCompras.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Licitacione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Licitacione()
        {
            this.AdjudicacionLicitacionProveedors = new HashSet<AdjudicacionLicitacionProveedor>();
            this.LicitacionCotizacionProvs = new HashSet<LicitacionCotizacionProv>();
        }
    
        public int IdLicitacion { get; set; }
        public string NombreLicitacion { get; set; }
        public int IdLicitador { get; set; }
        public System.DateTime FechaCreacionLicitacion { get; set; }
        public System.DateTime FechaCierreLicitacion { get; set; }
        public System.DateTime FechaAdjudicacionLicitacion { get; set; }
        public string ObservacionesLicitacion { get; set; }
        public int IdProducto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjudicacionLicitacionProveedor> AdjudicacionLicitacionProveedors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LicitacionCotizacionProv> LicitacionCotizacionProvs { get; set; }
        public virtual Licitador Licitador { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
