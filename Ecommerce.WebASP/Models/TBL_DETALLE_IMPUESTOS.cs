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
    
    public partial class TBL_DETALLE_IMPUESTOS
    {
        public int DIM_ID { get; set; }
        public Nullable<int> IMP_ID { get; set; }
        public Nullable<int> PRO_ID { get; set; }
        public string DIM_ESTADO { get; set; }
    
        public virtual TBL_IMPUESTOS TBL_IMPUESTOS { get; set; }
        public virtual TBL_PRODUCTO TBL_PRODUCTO { get; set; }
    }
}
