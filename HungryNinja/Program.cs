using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;

        public Food(string name, int calories, bool isspicy, bool issweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = isspicy;
            IsSweet = issweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;

        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Noodles", 1000, true, false),
                new Food("Cheese Burger", 1200, false, false),
                new Food("Fried Rice", 800, false, false),
                new Food("Beijing Beef", 750, true, true),
                new Food("Spaghetti", 900, false, false),
                new Food("Sandwich", 800, false, false),
                new Food("Salad", 400, false, false)
            };
        }

        public Food Serve()
        {
            Random randFood = new Random();
            return Menu[randFood.Next(0, Menu.Count)];
        }
    }

    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        public bool IsFull
        {
            get
            {
                return calorieIntake >= 1200;
            }
        }

        public void Eat(Buffet item)
        {
            while (IsFull != true)
            {
                Food food = item.Serve();
                FoodHistory.Add(food);
                calorieIntake = calorieIntake + food.Calories;
                if (food.IsSpicy == true && food.IsSweet == true)
                {
                    System.Console.WriteLine($"Ninja's eating {food.Name} with {food.Calories} calories and it's spicy and sweet.");
                }
                if (food.IsSpicy == true && food.IsSweet != true)
                {
                    System.Console.WriteLine($"Ninja's eating {food.Name} with {food.Calories} calories and it's spicy.");
                }
                if (food.IsSpicy != true && food.IsSweet == true)
                {
                    System.Console.WriteLine($"Ninja's eating {food.Name} with {food.Calories} calories and sweet.");
                }
                if (food.IsSpicy != true && food.IsSweet != true)
                {
                    System.Console.WriteLine($"Ninja's eating {food.Name} with {food.Calories} calories.");
                }
            }
            System.Console.WriteLine($"Ninja is full, total calories: {this.calorieIntake}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Buffet mybuffet = new Buffet();
            Ninja N1 = new Ninja();
            N1.Eat(mybuffet);
            // Food food = mybuffet.Serve(); 
            // System.Console.WriteLine($"{food.Name}");
        }
    }
}