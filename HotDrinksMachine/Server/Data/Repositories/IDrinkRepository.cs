using HotDrinksMachine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDrinksMachine.Server.Data.Repositories
{
    public interface IDrinkRepository : IDisposable
    {
        public IEnumerable<Drink> GetDrinks();
        public Drink GetDrink(int drinkId);
        void InsertDrink(Drink drink);
        void Save();
    }
}
