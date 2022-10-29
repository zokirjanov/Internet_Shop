using InternetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
       public DbSet<Category> Category { get; set; }
       public DbSet<HomeWork> homeWorks { get; set; }

     
    }
}
