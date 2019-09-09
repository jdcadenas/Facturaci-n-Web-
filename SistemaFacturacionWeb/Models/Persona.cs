using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFacturacionWeb.Models
{
    public class Persona
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public float Peso { get; set; }
        public bool Trabaja { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}