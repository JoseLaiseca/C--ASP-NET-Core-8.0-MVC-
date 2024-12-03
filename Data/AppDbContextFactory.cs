using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using EjemploReporte.Data;

namespace EjemploReporte.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=José\\SQLEXPRESS;Database=Stock;Trusted_Connection=True;TrustServerCertificate=True;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
