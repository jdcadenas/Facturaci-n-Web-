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
    
    public partial class tipodocumento
    {
        public int IdEncabezado { get; set; }
        public string TipoEncabezado { get; set; }
        public string TituloEncabezado { get; set; }
        public int IdSucursalEncabezado { get; set; }
    
        public virtual sucursal sucursal { get; set; }
    }
}
