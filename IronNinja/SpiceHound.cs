using System;

namespace IronNinja
{
    class SpiceHound : Ninja
    {
        public override bool IsFull
        {
            get
            {
                if (calorieIntake >= 1200)
                {
                    return true;
                }
                return false;
            }
        }

        public override void Consume(IConsumable item)
        {
            if (IsFull == false)
            {
                if (item.IsSpicy)
                {
                    calorieIntake = calorieIntake - 5;
                }
                calorieIntake = calorieIntake + item.Calories;
                ConsumptionHistory.Add(item);
                item.GetInfo();
            }
            else
            {
                System.Console.WriteLine("The SpiceHound is full and can't eat any more.");
            }
        }
    }
}