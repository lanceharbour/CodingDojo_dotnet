using System;
using System.Collections.Generic;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array to hold integer values 0 through 9
            int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string [] nameArray = new string[] {"Tim","Martin","Mikki","Sara"};
            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] boolArry = new bool[10];
            boolArry[0] = true;
            boolArry[2] = true;
            boolArry[4] = true;
            boolArry[6] = true;
            boolArry[8] = true;

            // Create a list of ice cream flavors that holds at least 5 different flavors
            List<string> flavors = new List<string>();
            flavors.Add("Mint Chip");
            flavors.Add("Neapolitan");
            flavors.Add("Rocky Road");
            flavors.Add("Pistachio");
            flavors.Add("Vanilla");
            // Output the length of this list after building it
            Console.WriteLine(flavors.Count);
            // Output the third flavor in the list, then remove this value
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            // Output the new length of the list
            Console.WriteLine(flavors.Count);
            // Create a dictionary that will store both string keys as well as string values
            Dictionary<string,string> nameflavor = new Dictionary<string, string>();
            for (int i = 0; i < nameArray.Length; i++)
            {
                Random rand = new Random();
                nameflavor.Add(nameArray[i],flavors[rand.Next(0,3)]);
            }
            //////////
            foreach (var entry in nameflavor)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
