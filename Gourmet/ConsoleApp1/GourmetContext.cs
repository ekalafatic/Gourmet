using Microsoft.EntityFrameworkCore;

namespace GourmetSp
{
    public class GourmetContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeBook> RecipeBooks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }


        public GourmetContext() { }


        public GourmetContext(DbContextOptions<GourmetContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RecipeBook>()
            .HasMany(r => r.Recipes)
            .WithMany(r => r.RecipeBooks)
            .UsingEntity(t => t.ToTable("RecipeBookRecipe"));

            modelBuilder.Entity<Recipe>()
              .HasMany(r => r.Ingredients)
              .WithMany(i => i.Recipes)
              .UsingEntity(t => t.ToTable("RecipeIngredient"));

            modelBuilder.Entity<Ingredient>()
              .HasOne(i => i.Food)
              .WithMany(f => f.Ingredients);
        }
    }
}
