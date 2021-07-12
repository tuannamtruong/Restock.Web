using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReStock.Models;
using System;

namespace ReStock.DataProvider
{
    public class RestockDbContext : DbContext
    {
        public DbSet<StockItem> Books { get; set; }
        //public RestockDbContext(DbContextOptions<RestockDbContext> options) : base(options)
        //{
        //}

        public RestockDbContext() : base()
        {
        }

        /// <summary>
        /// DBContext configuration
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB; Database=ReStockDb; Trusted_Connection=True;MultipleActiveResultSets=true");
        //=> options.UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB; Database=ReStockDb; Trusted_Connection=True; Integrated Security = True");

        /// <summary>
        /// Seeding data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockItem>().ToTable(nameof(StockItem));
            modelBuilder
             .Entity<StockItem>()
             .Property(e => e.StockType)
             .HasConversion(
                v => v.ToString(),
                v => (StockType)Enum.Parse(typeof(StockType), v));

            SeedStockItemData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static DataBuilder<StockItem> SeedStockItemData(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<StockItem>().HasData(
                        new StockItem { Id = 1, Name = "Thing", Amount = "2", StockType = StockType.FruitsAndVeggies },
                        new StockItem { Id = 2, Name = "Thing 2", Amount = "1", StockType = StockType.Proteins },
                        new StockItem { Id = 3, Name = "Thing 3", Amount = "4", StockType = StockType.Spices }
                        );
        }
    }
}
