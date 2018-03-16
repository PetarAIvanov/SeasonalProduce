using Microsoft.EntityFrameworkCore;
using System;

namespace SP.DataModel
{
    public class SeasonalProduceContext : DbContext
    {
        public SeasonalProduceContext(DbContextOptions<SeasonalProduceContext> options)
            : base(options)
        {

        }

        public DbSet<FoodData> FoodDataItems { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
    }
}
