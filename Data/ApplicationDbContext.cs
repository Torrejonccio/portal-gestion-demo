// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using PortalGestionInterna.Models; // Asegúrate que el namespace de tus modelos sea correcto

namespace PortalGestionInterna.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para cada uno de tus modelos. Estos representarán las tablas en la base de datos.
        public DbSet<Project> Projects { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aquí puedes añadir configuraciones adicionales para tus modelos usando Fluent API si es necesario.
            // Por ejemplo, para configurar índices, relaciones complejas, etc.

            // Ejemplo de configuración para la entidad Project (si fuera necesario):
            // modelBuilder.Entity<Project>()
            //     .HasIndex(p => p.Name) // Crear un índice en la columna Name
            //     .IsUnique(); // Si el nombre del proyecto debe ser único

            // Ejemplo para asegurar que las fechas en VacationRequest son solo Date (sin time component) si tu BD lo requiere.
            // modelBuilder.Entity<VacationRequest>()
            //     .Property(vr => vr.StartDate)
            //     .HasColumnType("date");
            // modelBuilder.Entity<VacationRequest>()
            //     .Property(vr => vr.EndDate)
            //     .HasColumnType("date");

            // Si tuvieras usuarios (por ejemplo, usando ASP.NET Core Identity),
            // el DbContext podría heredar de IdentityDbContext<ApplicationUser>
            // y no necesitarías declarar DbSets para las tablas de Identity (Users, Roles, etc.)
            // ya que IdentityDbContext los incluye.
        }
    }
}
