using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SmartSpaceDbContext>
{
    public SmartSpaceDbContext CreateDbContext(string[] args)
    {
        // Prefer connection string from environment variable so secrets aren't checked in
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
        {
            // Fallback to a sensible local SQL Server connection
            connectionString = "Server=localhost\\SQLEXPRESS;Database=SmartSpace;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        var optionsBuilder = new DbContextOptionsBuilder<SmartSpaceDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new SmartSpaceDbContext(optionsBuilder.Options);
    }
}

