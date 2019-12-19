using System;

namespace Fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print 1-255
            // for (int i = 1; i <= 255; i++)
            // {
            //     Console.WriteLine(i);
            // }

            // Print 1-100 all values from 1-100 that are divisible by 3 or 5, but not both
            for (int i = 1; i <= 100; i++)
            {
                if (i%3 == 0 && i%5 != 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i%5 == 0 && i%3 !=0)
                {
                    Console.WriteLine("Buzz");
                }
                else if(i%5 == 0 && i%3 ==0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
        }
    }
}
