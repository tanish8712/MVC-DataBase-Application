using Microsoft.EntityFrameworkCore;
using MVC_Application.Models;

namespace MVC_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Category> categories {get; set;}
    }
}
