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
            // Fallback to a sensible local SQLite connection
            connectionString = "Data Source=smartspace.db";
        }

        var optionsBuilder = new DbContextOptionsBuilder<SmartSpaceDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new SmartSpaceDbContext(optionsBuilder.Options);
    }
}

