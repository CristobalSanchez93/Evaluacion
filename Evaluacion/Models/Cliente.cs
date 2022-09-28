using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion.Models
{
    public class Cliente
    {
        public int Cli_ID { get; set; }
        public string Razon_Social { get; set; } 
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public bool Deshabilitado { get; set; }
    }
}