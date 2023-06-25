using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Context
{
    public class ECommerceEfDbContext : DbContext
    {
        public ECommerceEfDbContext(DbContextOptions options) : base(options)
        {
        }

        //Dbset
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<ProductCategoryMap> ProductCategoryMaps { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CouponConfiguration());
            modelBuilder.ApplyConfiguration(new CouponConfiguration());


            base.OnModelCreating(modelBuilder);
        }

    }
}
