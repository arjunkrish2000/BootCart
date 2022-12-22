using BootCart.Model;

namespace BootCart.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
               
            builder.Entity<Cart>()
               .HasOne(m => m.Product)
               .WithMany(m => m.Addtocart)
               .OnDelete(DeleteBehavior.NoAction);
           
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ProductMaster> ProductMasters { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
