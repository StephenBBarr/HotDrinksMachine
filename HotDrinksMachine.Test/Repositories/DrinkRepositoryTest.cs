using HotDrinksMachine.Server.Data;
using HotDrinksMachine.Server.Data.Repositories;
using HotDrinksMachine.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HotDrinksMachine.Test.Repositories
{
    public class DrinkRepositoryTest
    {
        [Fact]
        public void GetDrinks_ShouldReturnAListOfDrinks()
        {
            var options = new DbContextOptionsBuilder<HotDrinksMachineDbContext>()
                .UseInMemoryDatabase(databaseName: "GetDrinks_ShouldReturnAListOfDrinks")
                .Options;

            // Creating an in memory database
            using (var dbContext = new HotDrinksMachineDbContext(options))
            {
                dbContext.Drinks.AddRange(
                    new Drink { Id = 1, Name = "Lemon Tea" },
                    new Drink { Id = 2, Name = "Coffee" },
                    new Drink { Id = 3, Name = "Chocolate" });

                dbContext.PreparationActions.AddRange(
                    new PreparationAction() { Id = 1, Description = "Boil some water" },
                    new PreparationAction() { Id = 2, Description = "Steep the water in the tea" },
                    new PreparationAction() { Id = 3, Description = "Pour tea in the cup" },
                    new PreparationAction() { Id = 4, Description = "Add lemon" },
                    new PreparationAction() { Id = 5, Description = "Brew the coffee grounds" },
                    new PreparationAction() { Id = 6, Description = "Pour coffee in the cup" },
                    new PreparationAction() { Id = 7, Description = "Add sugar and milk" },
                    new PreparationAction() { Id = 8, Description = "Add drinking chocolate powder to the water" },
                    new PreparationAction() { Id = 9, Description = "Pour chocolate in the cup" });

                dbContext.DrinkPreparationActions.AddRange(
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

                dbContext.SaveChanges();
            }

            using (var dbContext = new HotDrinksMachineDbContext(options))
            {
                IDrinkRepository drinkRepository = new DrinkRepository(dbContext);
                var drinks = drinkRepository.GetDrinks();

                Assert.IsAssignableFrom<IEnumerable<Drink>>(drinks);
                Assert.Equal(3, drinkRepository.GetDrinks().Count());
                Assert.Contains("Lemon Tea", drinks.FirstOrDefault().Name);
                Assert.Contains("Chocolate", drinks.LastOrDefault().Name);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetDrink_ShouldReturnDrink_WhereIdBetween1And3(int id)
        {
            // Creating an in memory database
            var options = new DbContextOptionsBuilder<HotDrinksMachineDbContext>()
                .UseInMemoryDatabase(databaseName: "GetDrink_ShouldReturnDrink_WhereIdBetween1And3" + id)
                .Options;

            using (var dbContext = new HotDrinksMachineDbContext(options))
            {
                dbContext.Drinks.AddRange(
                    new Drink { Id = 1, Name = "Lemon Tea" },
                    new Drink { Id = 2, Name = "Coffee" },
                    new Drink { Id = 3, Name = "Chocolate" });

                dbContext.PreparationActions.AddRange(
                    new PreparationAction() { Id = 1, Description = "Boil some water" },
                    new PreparationAction() { Id = 2, Description = "Steep the water in the tea" },
                    new PreparationAction() { Id = 3, Description = "Pour tea in the cup" },
                    new PreparationAction() { Id = 4, Description = "Add lemon" },
                    new PreparationAction() { Id = 5, Description = "Brew the coffee grounds" },
                    new PreparationAction() { Id = 6, Description = "Pour coffee in the cup" },
                    new PreparationAction() { Id = 7, Description = "Add sugar and milk" },
                    new PreparationAction() { Id = 8, Description = "Add drinking chocolate powder to the water" },
                    new PreparationAction() { Id = 9, Description = "Pour chocolate in the cup" });

                dbContext.DrinkPreparationActions.AddRange(
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

                dbContext.SaveChanges();
            }

            using (var dbContext = new HotDrinksMachineDbContext(options))
            {
                IDrinkRepository drinkRepository = new DrinkRepository(dbContext);
                var drink = drinkRepository.GetDrink(id);

                Assert.NotNull(drink);
            }
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void GetDrink_ShouldReturnNull_WhereIdNotInDb(int id)
        {
            // Creating an in memory database
            var options = new DbContextOptionsBuilder<HotDrinksMachineDbContext>()
                .UseInMemoryDatabase(databaseName: "GetDrink_ShouldReturnDrink_WhereIdBetween1And3" + id)
                .Options;

            using (var dbContext = new HotDrinksMachineDbContext(options))
            {
                dbContext.Drinks.AddRange(
                    new Drink { Id = 1, Name = "Lemon Tea" },
                    new Drink { Id = 2, Name = "Coffee" },
                    new Drink { Id = 3, Name = "Chocolate" });

                dbContext.PreparationActions.AddRange(
                    new PreparationAction() { Id = 1, Description = "Boil some water" },
                    new PreparationAction() { Id = 2, Description = "Steep the water in the tea" },
                    new PreparationAction() { Id = 3, Description = "Pour tea in the cup" },
                    new PreparationAction() { Id = 4, Description = "Add lemon" },
                    new PreparationAction() { Id = 5, Description = "Brew the coffee grounds" },
                    new PreparationAction() { Id = 6, Description = "Pour coffee in the cup" },
                    new PreparationAction() { Id = 7, Description = "Add sugar and milk" },
                    new PreparationAction() { Id = 8, Description = "Add drinking chocolate powder to the water" },
                    new PreparationAction() { Id = 9, Description = "Pour chocolate in the cup" });

                dbContext.DrinkPreparationActions.AddRange(
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

                dbContext.SaveChanges();
            }

            using (var dbContext = new HotDrinksMachineDbContext(options))
            {
                IDrinkRepository drinkRepository = new DrinkRepository(dbContext);
                var drink = drinkRepository.GetDrink(id);

                Assert.Null(drink);
            }
        }
    }
}
