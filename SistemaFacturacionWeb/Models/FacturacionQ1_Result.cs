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
    
    public partial class FacturacionQ1_Result
    {
        public System.Guid OrderId { get; set; }
        public string Articulo { get; set; }
        public string ArticuloCodigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Nullable<decimal> Total { get; set; }
        public System.Guid CustomerId { get; set; }
    }
}
