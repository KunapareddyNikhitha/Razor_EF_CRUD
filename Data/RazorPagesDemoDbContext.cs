using Microsoft.EntityFrameworkCore;
using Razor_EF_CRUD.Models.Domain;

namespace Razor_EF_CRUD.Data
{
    public class RazorPagesDemoDbContext : DbContext
    {
        public RazorPagesDemoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
