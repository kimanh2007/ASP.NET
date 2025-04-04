using DangNuKimAnh_2122110482_b2.Model;
using Microsoft.EntityFrameworkCore;

namespace DangNuKimAnh_2122110482_b2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
