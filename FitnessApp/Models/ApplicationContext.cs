using FitnessApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : IdentityDbContext<IdentityUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Utilizator> Utilizatori { get; set; }
    public DbSet<Masuratori> Masuratori { get; set; }
    public DbSet<Antrenament> Antrenament { get; set; } = default!;
    public DbSet<FitnessApp.Models.Timer> Timers { get; set; }  // Adăugat aici

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUser>(b =>
        {
            b.ToTable("Users");
        });

        modelBuilder.Entity<IdentityRole>(b =>
        {
            b.ToTable("Roles");
        });

        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            b.ToTable("UserRoles");
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.ToTable("UserClaims");
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.ToTable("UserLogins");
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
        {
            b.ToTable("RoleClaims");
        });

        modelBuilder.Entity<IdentityUserToken<string>>(b =>
        {
            b.ToTable("UserTokens");
        });

        modelBuilder.Entity<Utilizator>()
            .HasOne(u => u.Masuratori)
            .WithOne(m => m.Utilizator)
            .HasForeignKey<Masuratori>(m => m.ID_Utilizator);

        modelBuilder.Entity<Antrenament>()
            .HasOne(a => a.Istoric)
            .WithOne(i => i.Antrenament)
            .HasForeignKey<Istoric>(i => i.ID_Antrenament);
    }
}
