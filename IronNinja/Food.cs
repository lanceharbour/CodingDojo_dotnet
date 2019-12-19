using System;
using System.Collections.Generic;

namespace IronNinja
{
    class Food : IConsumable
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSweet { get; set; }
        
        public string GetInfo()
        {
            return $"{ Name } has { Calories } calories. Spicy?: { IsSpicy }, Sweet?: { IsSweet }";
        }

        public Food(string name, int calories, bool isSpicy, bool isSweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
    }

    class Buffet
    {
        public List<IConsumable> Menu;
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Noodles", 1000, true, false),
                new Food("Cheese Burger", 1200, false, false),
                new Food("Fried Rice", 800, false, false),
                new Food("Beijing Beef", 750, true, true),
                new Food("Spaghetti", 900, false, false),
                new Food("Sandwich", 800, false, false),
                new Food("Salad", 400, false, false),
                new Drink("Coke", 150, false, true),
                new Drink("Root Beer", 170, false, false),
                new Drink("Rum and Coke", 300, false, true)
            };
        }

        public IConsumable Serve()
        {
            Random randFood = new Random();
            int randInt = randFood.Next(Menu.Count);
            return Menu[randInt];
        }
    }
}