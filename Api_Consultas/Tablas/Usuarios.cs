using System.ComponentModel.DataAnnotations;

namespace Api_Consultas.Tablas
{
    public class Usuarios
    {
        [Key]
        public int Usua_ID { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string contra { get; set; } = string.Empty;
    }
}
