using Demo.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }
        public DbSet<Product> Products { get; set; }


    }
}
