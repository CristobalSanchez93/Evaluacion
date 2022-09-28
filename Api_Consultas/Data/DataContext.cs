using Api_Consultas.Tablas;
using Microsoft.EntityFrameworkCore;

namespace Api_Consultas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Compra_Cab> Factura_Cabecera { get; set; }

        public DbSet<Compra_Det> Factura_Detalle { get; set; }

        public DbSet<Articulos> Articulo { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
    }
}
