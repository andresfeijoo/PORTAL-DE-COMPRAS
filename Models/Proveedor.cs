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
    
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            this.LicitacionCotizacionProvs = new HashSet<LicitacionCotizacionProv>();
        }
    
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public int CUITProveedor { get; set; }
        public int TelProveedor { get; set; }
        public string CorreoProveedor { get; set; }
        public string DomicilioProveedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LicitacionCotizacionProv> LicitacionCotizacionProvs { get; set; }
    }
}
