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

       
        modelBuilder.Entity<Workspace>().HasKey(e => e.Id);
        modelBuilder.Entity<Facility>().HasKey(e => e.Id);
        modelBuilder.Entity<Reservation>().HasKey(e => e.Id);
        modelBuilder.Entity<Customer>().HasKey(e => e.Id);
        modelBuilder.Entity<Admin>().HasKey(e => e.Id);
        modelBuilder.Entity<Location>().HasKey(e => e.Id);
        modelBuilder.Entity<Person>().HasKey(e => e.Id);
        modelBuilder.Entity<Payment>().HasKey(e => e.Id);
        modelBuilder.Entity<Review>().HasKey(e => e.Id);
        modelBuilder.Entity<WorkspaceType>().HasKey(e => e.Id);

        // Configure relationships
        modelBuilder.Entity<Workspace>()
            .HasOne(w => w.Location)
            .WithMany(l => l.Workspaces)
            .HasForeignKey(w => w.LocationId);

        modelBuilder.Entity<Workspace>()
            .HasOne(w => w.WorkspaceType)
            .WithMany(wt => wt.Workspaces)
            .HasForeignKey(w => w.WorkspaceTypeId);

        modelBuilder.Entity<Facility>()
            .HasOne(f => f.Workspace)
            .WithMany(w => w.Facilities)
            .HasForeignKey(f => f.WorkspaceId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Workspace)
            .WithMany(w => w.Reservations)
            .HasForeignKey(r => r.WorkspaceId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerId);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Reservation)
            .WithOne(r => r.Payment)
            .HasForeignKey<Payment>(p => p.ReservationId);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerId);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Workspace)
            .WithMany(w => w.Reviews)
            .HasForeignKey(r => r.WorkspaceId);
    }
}
