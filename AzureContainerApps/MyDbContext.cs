using AzureContainerApps.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureContainerApps
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SalesLT");
        }
        public DbSet<Customer> Customer { get; set; }

    }
}
