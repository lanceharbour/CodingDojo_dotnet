using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Dish name needs to be more then 2 characters.")]
        public string DishName { get; set; }

        [Required]
        [Range(1,5)]
        public int Tastiness { get; set; }

        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Calories need to be more then 0.")]
        public int Calories { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Description needs to be more then 20 characters.")]
        public string Description { get; set; }

        public int ChefId { get; set; }

        public Chef Creator { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}