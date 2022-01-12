using HotDrinksMachine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDrinksMachine.Server.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository, IDisposable
    {
        private HotDrinksMachineDbContext dbContext;

        public DrinkRepository(HotDrinksMachineDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Drink> GetDrinks()
        {
            return dbContext.Drinks.ToList();
        }

        public Drink GetDrink(int id)
        {
            return dbContext.Drinks.Find(id);
        }

        public void InsertDrink(Drink drink)
        {
            dbContext.Drinks.Add(drink);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
