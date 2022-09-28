using System.ComponentModel.DataAnnotations;

namespace Api_Consultas.Tablas
{
    public class Articulos
    {
        [Key]
        public int Art_ID { get; set; }
        [StringLength(50)]
        public string Codigo { get; set; } = string.Empty;
        [StringLength(255)]
        public string Descripcion { get; set; } = string.Empty;
    }
}
