using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Consultas.Tablas
{
    public class Compra_Cab
    {
        [Key]
        public int Compra_ID { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public int Cli_ID { get; set; }
        [ForeignKey("Cli_ID")]
        public Cliente? Cliente_Info { get; set; }
        [StringLength(50)]
        public string Estado { get; set; } = string.Empty;
    }
}
