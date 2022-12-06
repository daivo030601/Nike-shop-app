using Microsoft.EntityFrameworkCore;

namespace ShopAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set;}
        public DbSet<Collection> collections { get; set;}
        public DbSet<Coupon> coupons { get; set;}
        public DbSet<Color> colors { get; set;}
        public DbSet<Size> sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Collection>().HasKey(x => x.Id);
            modelBuilder.Entity<Coupon>().HasKey(x => x.Id);
            modelBuilder.Entity<Color>().HasKey(x => x.ColorId);
            modelBuilder.Entity<Size>().HasKey(x => x.SizeId);

            modelBuilder.Entity<Product>(e =>
            {
                e.Property(en => en.Name).IsRequired();
                e.Property(en => en.Price).IsRequired();
                e.Property(en => en.Picture).IsRequired();
                e.Property(en => en.variety).IsRequired();
                e.Property(en => en.Sizes).IsRequired();
                e.Property(en => en.Category).IsRequired();
                e.Property(en => en.Colors).IsRequired();
            });

            modelBuilder.Entity<Collection>(e =>
            {
                e.Property(en => en.Picture).IsRequired();
                e.Property(en => en.Name).IsRequired();
            });

            modelBuilder.Entity<Coupon>(e =>
            {
                e.Property(en => en.Cost).IsRequired();
                e.Property(en => en.Name).IsRequired();
                e.Property(en => en.Cost).IsRequired();
                e.Property(en => en.Exp).IsRequired();
            });

            

            modelBuilder.Entity<Product>()
                .HasOne(q => q.Collection)
                .WithMany(f => f.Products)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasMany(q => q.Sizes)
                .WithOne(f => f.Product)
                .IsRequired();


        }
    }
}
