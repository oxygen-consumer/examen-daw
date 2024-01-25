using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ShopContext(DbContextOptions<ShopContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });
            modelBuilder.Entity<UserOrder>().HasKey(uo => new { uo.UserId, uo.OrderId });
        }

        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<OrderProduct> OrderProduct { get; set; } = null!;
        public DbSet<UserOrder> UserOrder { get; set; } = null!;
    }
}
