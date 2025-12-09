using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SmartSpaceDbContext : DbContext
{
    public SmartSpaceDbContext(DbContextOptions<SmartSpaceDbContext> options) : base(options)
    {
    }

    public DbSet<Admin> Admins { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Facility> Facilities { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<Workspace> Workspaces { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<WorkspaceType> WorkspaceTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ensure entity keys if missing; many Domain entities have int Id properties.
        modelBuilder.Entity<Workspace>().HasKey(e => e.Id);
        modelBuilder.Entity<Facility>().HasKey(e => e.Id);
        modelBuilder.Entity<Reservation>().HasKey(e => e.Id);
        modelBuilder.Entity<Customer>().HasKey(e => e.Id);
        modelBuilder.Entity<Admin>().HasKey(e => e.Id);
    }
}
