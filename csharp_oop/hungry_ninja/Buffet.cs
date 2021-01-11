using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    class Buffet
    {
        public List<Food> Menu;
    
    //constructor
        public Buffet()
        {
            System.Console.WriteLine("Buffet Constructor");
            Menu = new List<Food>()
            {
                new Food("Example1", 1000, false, false),
                new Food("Example2", 1200, true, true),
                new Food("Example3", 700, true, false),
                new Food("Example4", 500, false, true),
                new Food("Example5", 420, false, false),
                new Food("Example6", 360, true, true),
                new Food("Example7", 1500, true, false) 
            };
        }
    
        public Food Serve()
        {
            System.Random random = new System.Random();

            return Menu[(random.Next(Menu.Count))];

        }
    }
}
