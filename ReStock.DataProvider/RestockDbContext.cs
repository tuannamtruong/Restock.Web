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

            SeedStockItemData(modelBuilder);
            SeedShoppingItemData(modelBuilder);
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
                        new ShoppingItem { Id = 1, ItemName = "Beans", Amount = "200g"},
                        new ShoppingItem { Id = 2, ItemName = "Butter", Amount = "300g"},
                        new ShoppingItem { Id = 3, ItemName = "Grapes", Amount = "1 box"}
                        );
        }
    }
}
