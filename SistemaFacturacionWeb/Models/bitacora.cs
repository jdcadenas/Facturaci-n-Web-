//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaFacturacionWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bitacora
    {
        public int IdBitacora { get; set; }
        public string IdUsuario { get; set; }
        public string ModuloBitacora { get; set; }
        public System.DateTime FechaBitacora { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
