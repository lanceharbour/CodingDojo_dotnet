using System;
using System.Collections.Generic;

namespace box_unbox
{
    class Program
    {
        static void Main()
        {
            int total = 0;

            List<object> mixedList = new List<object>();
            mixedList.Add(7);
            mixedList.Add(28);
            mixedList.Add(-1);
            mixedList.Add(true);
            mixedList.Add("chair");

            foreach (var value in mixedList)
            {
                if (value is int)
                    {
                        total = total + (int)value;
                    }
            }
            Console.WriteLine(total);
        }
    }
}
