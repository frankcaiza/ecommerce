//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce.WebASP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_FORMA_PAGO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_FORMA_PAGO()
        {
            this.TBL_PAGOS = new HashSet<TBL_PAGOS>();
        }
    
        public int FPA_ID { get; set; }
        public string FPA_DESCRIPCION { get; set; }
        public string FPA_CODIGOSRI { get; set; }
        public string FPA_ESTADO { get; set; }
        public Nullable<System.DateTime> FPA_FECHA_CREACION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PAGOS> TBL_PAGOS { get; set; }
    }
}
