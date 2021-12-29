using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RestApp.Data.Database
{
    /// <summary>
    /// It is a generic way to set connection string in separated project database
    /// Source: https://www.benday.com/2017/12/19/ef-core-2-0-migrations-without-hard-coded-connection-strings/
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        public TContext CreateDbContext(string[] args)
        {
            return Create(
                Directory.GetCurrentDirectory(),
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }

        public TContext Create()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var basePath = AppContext.BaseDirectory;
            return Create(basePath, environmentName);
        }

        private TContext Create(string basePath, string environmentName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString("default");

            if (String.IsNullOrWhiteSpace(connectionString) == true)
            {
                throw new InvalidOperationException("Could not find a connection string named 'default'.");
            }
            else
            {
                return Create(connectionString);
            }
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"{nameof(connectionString)} is null or empty.", nameof(connectionString));
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            Console.WriteLine("MyDesignTimeDbContextFactory.Create(string): Connection string: {0}",connectionString);
            optionsBuilder.UseSqlite(connectionString);
            DbContextOptions<TContext> options = optionsBuilder.Options;
            return CreateNewInstance(options);
        }

    }
}
