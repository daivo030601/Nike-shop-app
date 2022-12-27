using Microsoft.EntityFrameworkCore;

namespace ShopAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> products { get; set;}
        public DbSet<Collection> collections { get; set;}
        public DbSet<Coupon> coupons { get; set;}
        public DbSet<Color> colors { get; set;}
        public DbSet<Size> sizes { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Recipe> recipes { get; set; }
        public DbSet<RecipeItem> recipeItems { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<ColorProduct> colorProducts { get; set; }
        public DbSet<SizeProduct> sizeProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
            modelBuilder.Entity<Collection>().HasKey(x => x.CollectionId);
            modelBuilder.Entity<Coupon>().HasKey(x => x.CouponId);
            modelBuilder.Entity<Color>().HasKey(x => x.ColorId);
            modelBuilder.Entity<Size>().HasKey(x => x.SizeId);
            modelBuilder.Entity<Address>().HasKey(x => x.id);
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<Recipe>().HasKey(x => x.RecipeId);
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryId);
            modelBuilder.Entity<ColorProduct>().HasKey(sc => new { sc.ColorId, sc.ProductId });
            modelBuilder.Entity<SizeProduct>().HasKey(sc => new { sc.SizeId, sc.ProductId });

            modelBuilder.Entity<Address>(e =>
            {
                e.Property(en => en.name).IsRequired(false);
                e.Property(en => en.pin).IsRequired(false);
                e.Property(en => en.district).IsRequired(false);
                e.Property(en => en.city).IsRequired(false);

            });

            modelBuilder.Entity<Product>(e =>
            {
                e.Property(en => en.Name).IsRequired(false);
                e.Property(en => en.Variety).IsRequired(false);
                e.Property(en => en.Picture).IsRequired(false);
                e.Property(en => en.Description).IsRequired(false);
            });

            modelBuilder.Entity<Collection>(e =>
            {
                e.Property(en => en.Name).IsRequired(false);
                e.Property(en => en.Picture).IsRequired(false);
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.Property(en => en.Picture).IsRequired(false);
                e.Property(en => en.Description).IsRequired(false);
                e.Property(en => en.Name).IsRequired(false);
            });

            modelBuilder.Entity<Color>(e =>
            {
                e.Property(en => en.ColorName).IsRequired();
            });

            modelBuilder.Entity<Size>(e =>
            {
                e.Property(en => en.SizeName).IsRequired();
            });

            modelBuilder.Entity<Recipe>(e =>
            {
                e.Property(en => en.RecipeDate).IsRequired();
            });

            modelBuilder.Entity<Coupon>(e =>
            {
                e.Property(en => en.Name).IsRequired(false);
            });

            modelBuilder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(product => product.Collection)
                .WithMany(collection => collection.Products)
                .HasForeignKey(product => product.CollectionId)
                .IsRequired();

            modelBuilder.Entity<ColorProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.ColorProducts)
                .HasForeignKey(cp => cp.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ColorProduct>()
               .HasOne(cp => cp.Color)
               .WithMany(p => p.ColorProducts)
               .HasForeignKey(cp => cp.ColorId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SizeProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.SizeProducts)
                .HasForeignKey(sp => sp.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SizeProduct>()
               .HasOne(sp => sp.Size)
               .WithMany(p => p.SizeProducts)
               .HasForeignKey(sp => sp.SizeId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);


            

            modelBuilder.Entity<Recipe>()
                .HasOne(recipe => recipe.User)
                .WithMany(user => user.Recipes)
                .HasForeignKey(recipe => recipe.UserId);

            modelBuilder.Entity<Recipe>()
                .HasOne(recipe => recipe.Coupon)
                .WithMany(coupon => coupon.Recipes)
                .HasForeignKey(recipe => recipe.UserId);


            modelBuilder.Entity<RecipeItem>().HasKey(ri => new { ri.RecipeId, ri.ProductId });
        }
    }
}
