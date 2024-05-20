using FitnessApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Identity tables to use custom table names
        modelBuilder.Entity<IdentityUser>(b =>
        {
            b.ToTable("Users"); // This maps the IdentityUser entity to the 'Users' table
        });

        modelBuilder.Entity<IdentityRole>(b =>
        {
            b.ToTable("Roles"); // Custom table name for roles
        });

        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            b.ToTable("UserRoles"); // Custom table name for user roles
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.ToTable("UserClaims"); // Custom table name for user claims
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.ToTable("UserLogins"); // Custom table name for user logins
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
        {
            b.ToTable("RoleClaims"); // Custom table name for role claims
        });

        modelBuilder.Entity<IdentityUserToken<string>>(b =>
        {
            b.ToTable("UserTokens"); // Custom table name for user tokens
        });

        // Configure relationships for your custom entities
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




/*
using FitnessApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships for your custom entities
        modelBuilder.Entity<Utilizator>()
            .HasOne(u => u.Masuratori)
            .WithOne(m => m.Utilizator)
            .HasForeignKey<Masuratori>(m => m.ID_Utilizator);

        modelBuilder.Entity<Antrenament>()
            .HasOne(a => a.Istoric)
            .WithOne(i => i.Antrenament)
            .HasForeignKey<Istoric>(i => i.ID_Antrenament);

        // Ensure Identity entities have keys defined
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });

        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(r => new { r.UserId, r.RoleId });
        });

        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        });
    }
}
*/