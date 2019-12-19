using System;

namespace Human
{
    class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int HealthProp
        {
            get { return health; }
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        public Human(string name, int str, int intel, int dex, int hlth)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hlth;
        }
        public int Attack(Human target)
        {
            int damage = 5*Strength;
            target.health = target.health - damage;
            Console.WriteLine($"{this.Name} attacked {target.Name} for {damage}");
            return target.health;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Human P1 = new Human("Lance", 5,1,1,150);
            Human P2 = new Human("Erik",6,0,4,200);
            Console.WriteLine(P1.Name);
            Console.WriteLine(P2.Name);
            P1.Attack(P2);
            P2.Attack(P1);
            Console.WriteLine(P1.HealthProp);
            Console.WriteLine(P2.HealthProp);
        }
    }
}
