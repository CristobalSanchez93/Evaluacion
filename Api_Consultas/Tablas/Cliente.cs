using System.ComponentModel.DataAnnotations;

namespace Api_Consultas.Tablas
{
    public class Cliente
    {
        [Key]
        public int Cli_ID { get; set; }
        [StringLength(255)]
        public string Razon_Social { get; set; } = string.Empty;
        [StringLength(50)]
        public string CUIT { get; set; } = string.Empty;
        [StringLength(255)]
        public string Direccion { get; set; } = string.Empty;
        public bool Deshabilitado { get; set; }
    }
}
