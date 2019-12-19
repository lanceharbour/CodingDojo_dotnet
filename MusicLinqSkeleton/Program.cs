using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist mtVernon = Artists.FirstOrDefault(artage => artage.Hometown == "Mount Vernon");
            System.Console.WriteLine($"Name: {mtVernon.RealName}, Age: {mtVernon.Age}");
            //Who is the youngest artist in our collection of artists?
            Artist youngone = Artists.OrderBy(a => a.Age).First();
            System.Console.WriteLine($"Name: {youngone.RealName}, Age: {youngone.Age} ");

            //Display all artists with 'William' somewhere in their real name
            List<Artist> realWilliam = Artists.Where(a => a.RealName.Contains("Wil")).ToList();
            foreach (Artist wil in realWilliam)
            {
                System.Console.WriteLine($"{wil.RealName}");
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> oldestAtlanta = Artists.Where(h => h.Hometown == "Atlanta").OrderByDescending(a => a.Age).Take(3).ToList();
            foreach (Artist age in oldestAtlanta)
            {
                System.Console.WriteLine($"Name: {age.ArtistName}, Age: {age.Age}");
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	        Console.WriteLine(Groups.Count);

        }
    }
}
