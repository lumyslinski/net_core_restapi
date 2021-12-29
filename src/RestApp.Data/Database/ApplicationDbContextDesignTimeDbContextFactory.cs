using System;
using Microsoft.EntityFrameworkCore;

namespace RestApp.Data.Database
{
    public class ApplicationDbContextDesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }

    public static class ApplicationDbContextContainer
    {
        public static ApplicationDbContext GetInstance()
        {
            try
            {
                var applicationDbContextDesignTimeDbContextFactory = new ApplicationDbContextDesignTimeDbContextFactory();
                var dbContext = applicationDbContextDesignTimeDbContextFactory.Create();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                return dbContext;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
