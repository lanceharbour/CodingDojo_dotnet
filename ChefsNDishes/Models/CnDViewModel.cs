using System.Collections.Generic;
namespace ChefsNDishes
{
    public class CnDViewModel
    {
        public Chef VMChef { get; set; }
        public Dish VMDish { get; set; }

        public List<Chef> ChefList { get; set; }
    }
}