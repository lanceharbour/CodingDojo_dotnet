using System;
using System.Collections.Generic;
namespace basic_13
{
    class Program
    {
        //Print 1-255
        public static void PrintNumbers()
        {
            for (int i=0; i<=255; i++)
            {
                Console.WriteLine(i);
            }
        }

        // Print odd numbers between 1-255
        public static void PrintOdds()
        {
            for (int i=0; i<=255;i++)
            {
                if (i%2 == 1)
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Print Sum
        public static void PrintSum()
        {
            int sum = 0;
            for (int i=0; i<=255; i++)
            {
                sum = sum + i;
                Console.WriteLine($"New number: {i} Sum: {sum}");
            }
        }

        // Iterating through an Array
        public static void LoopArray(int[] numbers)
        {
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }

        // Find Max
        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            foreach (var num in numbers)
            {
                if (max < num)
                {
                    max = num;
                }
            }
            return max;
        }

        // Get Average
        public static void GetAverage(int[] numbers)
        {
            int avg = 0;
            int sum = 0;
            foreach (var num in numbers)
            {
                sum = sum + num;
            }
            avg = sum/numbers.Length;
            System.Console.WriteLine(avg);
        }

        // Array with Odd Numbers
        public static int[] OddArray()
        {
            List<int> oddList = new List<int>();
            for (int i=0; i<=255; i++)
            {
                if (i%2 == 1)
                {
                    oddList.Add(i);
                }
            }
        int[] odd = oddList.ToArray();
        return odd;
        }

        // Greater than Y
        public static int GreaterThanY(int[] numbers, int y)
        {
            int gtY = 0;
            foreach (var num in numbers)
            {
                if (num > y)
                {
                    gtY = gtY +1;
                }
            }
            System.Console.WriteLine(gtY);
            return gtY;
        }

        // Square the Values
        public static void SquareArrayValues(int[] numbers)
        {
            for (int i=0; i<numbers.Length; i++)
            {
                numbers[i] = numbers[i]*numbers[i];
                System.Console.WriteLine(numbers[i]);
            }
        }

        // Eliminate Negative Numbers
        public static void EliminateNegatives(int[] numbers)
        {
            for (int i=0; i<numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        // Min, Max, and Average
        public static void MinMaxAverage(int[] numbers)
        {
            int max = numbers[0];
            int min = numbers[0];
            int avg = numbers[0];
            int sum = numbers[0];
            for (int i=0; i<numbers.Length; i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
                if (min > numbers[i])
                {
                    min = numbers[i];
                }
                sum = sum + numbers[i];
            }
            avg = sum/numbers.Length;
            Console.WriteLine($"Min: {min}, Max: {max}, Avg: {avg}");
        }

        // Shifting the values in an array
        public static void ShiftValues(int[] numbers)
        {
            for (int i=0; i<numbers.Length-1; i++)
            {
                numbers[i] = numbers[i+1];
            }
            numbers[numbers.Length-1] = 0;
        }

        // Number to String
        public static object[] NumToString(int[] numbers)
        {
            List<object> stringList = new List<object>();
            foreach (var num in numbers)
            {
                if (num < 0)
                {
                    stringList.Add("Dojo");
                }
                else
                {
                    stringList.Add(num);
                }
            }
            return stringList.ToArray();
        }
        static void Main(string[] args)
        {
            int[] output = {-1,-3,2};
            NumToString(output);
        }
    }
}
