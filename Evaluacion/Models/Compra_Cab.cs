using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion.Models
{
    public class Compra_Cab
    {
        public int Compra_ID { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public int Cli_ID { get; set; }
        public Cliente Cliente_Info { get; set; }
        public string Estado { get; set; }
    }
}