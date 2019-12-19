using System;

namespace IronNinja
{
    class SweetTooth : Ninja
    {
        public override bool IsFull
        {
            get
            {
                if (calorieIntake >= 1500)
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
                if (item.IsSweet)
                {
                    calorieIntake = calorieIntake + 10;
                }
                calorieIntake = calorieIntake + item.Calories;
                ConsumptionHistory.Add(item);
                item.GetInfo();
            }
            else
            {
                System.Console.WriteLine("The SweetTooth is full and can't eat any more.");
            }
        }
    }
}