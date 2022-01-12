using HotDrinksMachine.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotDrinksMachine.Server.Data
{
    public class HotDrinksMachineDbContext : DbContext
    {
        public HotDrinksMachineDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureModelRelationNavigation(modelBuilder);
            SeedDatbaseData(modelBuilder);
        }

        public void ConfigureModelRelationNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().Navigation(e => e.DrinkPreparationActions).AutoInclude();
            modelBuilder.Entity<DrinkPreparationAction>().Navigation(e => e.PreparationAction).AutoInclude();
        }

        public void SeedDatbaseData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().HasData(
                new Drink { Id = 1, Name = "Lemon Tea" },
                new Drink { Id = 2, Name = "Coffee" },
                new Drink { Id = 3, Name = "Chocolate" });

            modelBuilder.Entity<PreparationAction>().HasData(
                new PreparationAction() { Id = 1, Description = "Boil some water" },
                new PreparationAction() { Id = 2, Description = "Steep the water in the tea" },
                new PreparationAction() { Id = 3, Description = "Pour tea in the cup" },
                new PreparationAction() { Id = 4, Description = "Add lemon" },
                new PreparationAction() { Id = 5, Description = "Brew the coffee grounds" },
                new PreparationAction() { Id = 6, Description = "Pour coffee in the cup" },
                new PreparationAction() { Id = 7, Description = "Add sugar and milk" },
                new PreparationAction() { Id = 8, Description = "Add drinking chocolate powder to the water" },
                new PreparationAction() { Id = 9, Description = "Pour chocolate in the cup" });

            modelBuilder.Entity<DrinkPreparationAction>().HasData(
                new DrinkPreparationAction() { Id = 1, DrinkId = 1, PreparationActionId = 1, ActionOrder = 1 },
                new DrinkPreparationAction() { Id = 2, DrinkId = 1, PreparationActionId = 2, ActionOrder = 2 },
                new DrinkPreparationAction() { Id = 3, DrinkId = 1, PreparationActionId = 3, ActionOrder = 3 },
                new DrinkPreparationAction() { Id = 4, DrinkId = 1, PreparationActionId = 4, ActionOrder = 4 },
                new DrinkPreparationAction() { Id = 5, DrinkId = 2, PreparationActionId = 1, ActionOrder = 1 },
                new DrinkPreparationAction() { Id = 6, DrinkId = 2, PreparationActionId = 5, ActionOrder = 2 },
                new DrinkPreparationAction() { Id = 7, DrinkId = 2, PreparationActionId = 6, ActionOrder = 3 },
                new DrinkPreparationAction() { Id = 8, DrinkId = 2, PreparationActionId = 7, ActionOrder = 4 },
                new DrinkPreparationAction() { Id = 9, DrinkId = 3, PreparationActionId = 1, ActionOrder = 1 },
                new DrinkPreparationAction() { Id = 10, DrinkId = 3, PreparationActionId = 8, ActionOrder = 2 },
                new DrinkPreparationAction() { Id = 11, DrinkId = 3, PreparationActionId = 9, ActionOrder = 3 });
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkPreparationAction> DrinkPreparationActions { get; set; }
        public DbSet<PreparationAction> PreparationActions { get; set; }
    }
}
