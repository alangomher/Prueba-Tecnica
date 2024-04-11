using Microsoft.EntityFrameworkCore;

namespace Prueba_Tecnica.Models
{
    public class EmpleadoDBContext : DbContext
    {   
        public EmpleadoDBContext(DbContextOptions<EmpleadoDBContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>()
                .HasIndex(x => x.Usuario)
                .IsUnique();
        }
    }
}
