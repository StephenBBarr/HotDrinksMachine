using System.ComponentModel.DataAnnotations.Schema;

namespace HotDrinksMachine.Shared.Entities
{
    public class DrinkPreparationAction
    {
        public int Id { get; set; }

        public int ActionOrder { get; set; }

        public int DrinkId { get; set; }
        public int PreparationActionId { get; set; }
        [ForeignKey("PreparationActionId")]
        public PreparationAction PreparationAction { get; set; }
    }
}
