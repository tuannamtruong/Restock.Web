using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReStock.Models;
using System;

namespace ReStock.DataProvider
{
    public class RestockDbContext : DbContext
    {
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public RestockDbContext() : base()
        {
        }

        /// <summary>
        /// DBContext configuration
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB; Database=ReStockDb; Trusted_Connection=True;MultipleActiveResultSets=true");

        /// <summary>
        /// Seeding data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupStockItem(modelBuilder);
            SetupShoppingItem(modelBuilder);
            SetupRecipe(modelBuilder);

            SeedStockItemData(modelBuilder);
            SeedShoppingItemData(modelBuilder);
            SeedRecipe(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SetupStockItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockItem>().ToTable(nameof(StockItem));
            modelBuilder
             .Entity<StockItem>()
             .Property(e => e.StockType)
             .HasConversion(
                v => v.ToString(),
                v => (StockType)Enum.Parse(typeof(StockType), v));
        }
        private void SetupShoppingItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingItem>().ToTable(nameof(ShoppingItem));
        }
        private void SetupRecipe(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().ToTable(nameof(Recipe));
        }

        private static DataBuilder<StockItem> SeedStockItemData(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<StockItem>().HasData(
                        new StockItem { Id = 1, Name = "Bell pepper", Amount = "2", StockType = StockType.FruitsAndVeggies },
                        new StockItem { Id = 2, Name = "Fish", Amount = "1", StockType = StockType.Proteins },
                        new StockItem { Id = 3, Name = "Salt", Amount = "4", StockType = StockType.Spices }
                        );
        }
        private static DataBuilder<ShoppingItem> SeedShoppingItemData(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<ShoppingItem>().HasData(
                        new ShoppingItem { Id = 1, ItemName = "Beans", Amount = "200g" },
                        new ShoppingItem { Id = 2, ItemName = "Butter", Amount = "300g" },
                        new ShoppingItem { Id = 3, ItemName = "Grapes", Amount = "1 box" }
                        );
        }
        private static DataBuilder<Recipe> SeedRecipe(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Recipe>().HasData(
                       new Recipe { Id = 1, Name = "Pork ribs", CookTime = 180, Instruction = "Do this then that then boom" },
                       new Recipe { Id = 2, Name = "Salat", CookTime = 20 },
                       new Recipe { Id = 3, Name = "Meatballs", Instruction = "Just this. Then .... Finally" },
                       new Recipe { Id = 4, Name = "Boiling Eggs" }
                       );
        }
    }
}
