using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDrinksMachine.Shared.Entities
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("DrinkId")]
        public List<DrinkPreparationAction> DrinkPreparationActions { get; set; }
    }
}
