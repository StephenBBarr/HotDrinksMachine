using HotDrinksMachine.Server.Data.Repositories;
using HotDrinksMachine.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDrinksMachine.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private IDrinkRepository drinkRepository;

        public DrinksController(IDrinkRepository drinkRepository)
        {
            this.drinkRepository = drinkRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(drinkRepository.GetDrinks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var drink = drinkRepository.GetDrink(id);
            return Ok(drinkRepository.GetDrink(id));
        }

        [HttpPost]
        public IActionResult Post(Drink drink)
        {
            drinkRepository.InsertDrink(drink);
            drinkRepository.Save();
            return Ok(drinkRepository.GetDrink(drink.Id));
        }
    }
}
