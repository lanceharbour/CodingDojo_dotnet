using System;

namespace WizardNinjaSamurai
{
    public class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int Health;

        public int HealthProp
        {
            get { return Health; }
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        public Human(string name, int str, int intel, int dex, int hlth)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Health = hlth;
        }
        public virtual int Attack(Human target)
        {
            int damage = 3*Strength;
            target.Health = target.Health - damage;
            Console.WriteLine($"{this.Name} attacked {target.Name} for {damage}");
            return target.Health;
        }
    }

    class Wizard : Human
    {
        public Wizard(string name) :base(name)
        {
            Health =50;
            Intelligence = 25;
        }

        public override int Attack(Human target)
        {
            int damage = 5*Intelligence;
            target.Health = target.Health - damage;
            Console.WriteLine($"{this.Name} attacked {target.Name} for {damage}");
            this.Health = this.Health + damage;
            return target.Health;
        }

        public int Heal(Human target)
        {
            int heal = 10*Intelligence;
            target.Health = target.Health + heal;
            return target.Health;
        }
    }

    class Ninja : Human
    {
        public Ninja(string name) :base(name)
        {
            Dexterity = 175;
        }

        public override int Attack(Human target)
        {
            Random randomDmg = new Random();
            int damage = 5*Dexterity;
            int moreDmg = (randomDmg.Next(10));
            target.Health = target.Health - (damage + moreDmg);
            Console.WriteLine($"{this.Name} attacked {target.Name} for {damage} plus an additional {moreDmg}");
            return target.Health;
        }

        public int Steal(Human target)
        {
            target.Health = target.Health - 5;
            this.Health = this.Health + 5;
            return target.Health;
        }
    }

    class Samurai : Human
    {
        public Samurai(string name) :base(name)
        {
            Health =200;
        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            if (target.Health < 50)
            {
                target.Health = 0;
            }
            return target.Health;
        }

        public void Meditate()
        {
            this.Health = 200;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Samurai P1 = new Samurai("Lance");
            Samurai P2 = new Samurai("Erik");
            Console.WriteLine(P1.Name);
            Console.WriteLine(P2.Name);
            P1.Attack(P2);
            P2.Attack(P1);
            P1.Meditate();
            Console.WriteLine($"{P1.Name}'s health is now {P1.HealthProp}");
            Console.WriteLine($"{P2.Name}'s health is now {P2.HealthProp}");
        }
    }
}
