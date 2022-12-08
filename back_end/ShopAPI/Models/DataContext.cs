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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
            modelBuilder.Entity<Collection>().HasKey(x => x.CollectionId);
            modelBuilder.Entity<Coupon>().HasKey(x => x.CouponId);
            modelBuilder.Entity<Color>().HasKey(x => x.ColorId);
            modelBuilder.Entity<Size>().HasKey(x => x.SizeId);
            modelBuilder.Entity<Address>().HasKey(x => x.AddressId);
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<Recipe>().HasKey(x => x.RecipeId);
            modelBuilder.Entity<RecipeItem>().HasKey(x => x.RecipeItemId);
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryId);

            modelBuilder.Entity<Address>(e =>
            {
                e.Property(en => en.UserName).IsRequired(false);
                e.Property(en => en.Pin).IsRequired(false);
                e.Property(en => en.District).IsRequired(false);
                e.Property(en => en.City).IsRequired(false);

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

            modelBuilder.Entity<Color>()
                .HasMany(color => color.Products)
                .WithMany(product => product.Colors)
                .UsingEntity(j => j.ToTable("ColorProducts"));

            modelBuilder.Entity<Size>()
                .HasMany(size => size.Products)
                .WithMany(product => product.Sizes)
                .UsingEntity(j => j.ToTable("SizeProducts"));

            modelBuilder.Entity<Address>()
                .HasOne(address => address.User)
                .WithMany(user => user.Addresses)
                .HasForeignKey(address => address.UserId);

            modelBuilder.Entity<Recipe>()
                .HasOne(recipe => recipe.User)
                .WithMany(user => user.Recipes)
                .HasForeignKey(recipe => recipe.UserId);

            modelBuilder.Entity<Recipe>()
                .HasOne(recipe => recipe.Coupon)
                .WithMany(coupon => coupon.Recipes)
                .HasForeignKey(recipe => recipe.UserId);

            modelBuilder.Entity<RecipeItem>()
                .HasOne(recipeItem => recipeItem.Product)
                .WithMany(product => product.RecipeItems)
                .HasForeignKey(recipe => recipe.ProductId)
                .IsRequired();

            modelBuilder.Entity<RecipeItem>()
               .HasOne(recipeItem => recipeItem.Recipe)
               .WithMany(recipe => recipe.RecipeItems)
               .HasForeignKey(recipeItem => recipeItem.RecipeId)
               .IsRequired();


        }
    }
}
