using HotDrinksMachine.Server.Controllers;
using HotDrinksMachine.Server.Data.Repositories;
using HotDrinksMachine.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HotDrinksMachine.Test.Controllers
{
    public class DrinksControllerTest
    {

        [Fact]
        public void Get_ReturnsOkObjectResult_WithAListOfDrinks()
        {
            var drinks = new List<Drink>()
            {
                new Drink()
                {
                    Id = 1,
                    Name = "Lemon Tea",
                    DrinkPreparationActions = new List<DrinkPreparationAction>()
                    {
                        new DrinkPreparationAction()
                        {
                            Id = 1,
                            DrinkId = 1,
                            ActionOrder = 1,
                            PreparationActionId = 1,
                            PreparationAction = new PreparationAction()
                            {
                                Id = 1,
                                Description = "Boil some water"
                            }
                        },
                        new DrinkPreparationAction()
                        {
                            Id = 2,
                            DrinkId = 1,
                            ActionOrder = 2,
                            PreparationActionId = 2,
                            PreparationAction = new PreparationAction()
                            {
                                Id = 2,
                                Description = "Add tea to water"
                            }
                        }
                    }
                },
                                new Drink()
                {
                    Id = 2,
                    Name = "Coffee",
                    DrinkPreparationActions = new List<DrinkPreparationAction>()
                    {
                        new DrinkPreparationAction()
                        {
                            Id = 3,
                            DrinkId = 2,
                            ActionOrder = 1,
                            PreparationActionId = 1,
                            PreparationAction = new PreparationAction()
                            {
                                Id = 1,
                                Description = "Boil some water"
                            }
                        },
                        new DrinkPreparationAction()
                        {
                            Id = 4,
                            DrinkId = 2,
                            ActionOrder = 2,
                            PreparationActionId = 3,
                            PreparationAction = new PreparationAction()
                            {
                                Id = 3,
                                Description = "Add coffee to water"
                            }
                        }
                    }
                }
            };
            var mockRepository = new Mock<IDrinkRepository>();
            mockRepository.Setup(r => r.GetDrinks())
                .Returns(drinks);
            var controller = new DrinksController(mockRepository.Object);

            var result = controller.Get();

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(typeof(OkObjectResult), okObjectResult.GetType());
            Assert.Equal(drinks, okObjectResult.Value);
        }
    }
}
