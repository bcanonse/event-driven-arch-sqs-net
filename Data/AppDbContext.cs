using EventOne.Models;
using Microsoft.EntityFrameworkCore;

namespace EventOne.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Drivers> Drivers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<Drivers> drivers =
        [
            new Drivers { Id = Guid.NewGuid(), FirstName = "Bryan", LastName= "Canon", LicenseNumber="KS0-34KSDFGSD"},
        ];

        modelBuilder.Entity<Drivers>(driver =>
        {
            driver.ToTable("drivers");

            driver.HasKey(field => field.Id).HasName("drivers_pk_id");

            driver.HasData(drivers);
        });
    }
}