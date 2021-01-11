using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Human humanJoe = new Human("Joe");
            System.Console.WriteLine($"Human name {humanJoe.Name} with str {humanJoe.Strength}");

            Human humanBob = new Human("Bob", 5, 1, 2, 150);
            System.Console.WriteLine($"Human name {humanBob.Name} with str {humanBob.Strength} with health {humanBob.getHealth()}");

            
            System.Console.WriteLine($"{humanJoe.Name} Just attacked {humanBob.Name} for {humanJoe.Attack(humanBob)} damage!");
            System.Console.WriteLine($"{humanBob.Name}'s health is now {humanBob.getHealth()}");
        }
    }
}
