using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluacion.Models
{
    public class Compra_Det
    {
        public int DT_ID { get; set; }
        public int Compra_ID { get; set; }
        public Compra_Cab Compra_Cabecera { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public int ART_ID { get; set; }
        public Articulo articulo { get; set; }
        public decimal Cant { get; set; }
        public decimal Precio { get; set; }
        public decimal Monto { get; set; }
    }
}