using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Utilizator> Utilizatori { get; set; }
    public DbSet<Masuratori> Masuratori { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utilizator>()
            .HasOne(u => u.Masuratori)
            .WithOne(m => m.Utilizator)
            .HasForeignKey<Masuratori>(m => m.ID_Utilizator);
        modelBuilder.Entity<Antrenament>()
            .HasOne(a => a.Istoric)
            .WithOne(i => i.Antrenament)
            .HasForeignKey<Istoric>(i => i.ID_Antrenament);
    }

public DbSet<FitnessApp.Models.Antrenament> Antrenament { get; set; } = default!;
}
