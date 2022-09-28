using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Consultas.Tablas
{
    public class Compra_Det
    {
        [Key]
        public int DT_ID { get; set; }
        public int Compra_ID { get; set; }
        [ForeignKey("Compra_ID")]
        public Compra_Cab? Compra_Cabecera { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public int ART_ID { get; set; }
        [ForeignKey("ART_ID")]
        public Articulos? articulo { get; set; }
        public decimal Cant { get; set; }
        public decimal Precio { get; set; }
        public decimal Monto { get; set; }
    }
}
