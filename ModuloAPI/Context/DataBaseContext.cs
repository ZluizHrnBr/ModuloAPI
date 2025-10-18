using Microsoft.EntityFrameworkCore;
using ModuloAPI.Entidades;

namespace ModuloAPI.Context
{
    public class DataBaseContext : DbContext
    {


        public DbSet<Usuario> Usuarios { get; set; }    
        public DbSet<Veiculo> Veiculos { get; set; }


        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id_Usuario)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Id_Veiculo)
                .HasDefaultValueSql("gen_random_uuid()");           
        }
    }
}
