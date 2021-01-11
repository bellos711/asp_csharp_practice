using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy; 
        public bool IsSweet; 
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet

        //CONSTRUCTORS START
        public Food(string name, int calories, bool isSpicy, bool isSweet)
        {
            this.Name = name;
            this.Calories = calories;
            this.IsSpicy = isSpicy;
            this.IsSweet = isSweet;
        }

        public Food()
        {
            this.Name = "Default Food";
            this.Calories = 600;
            this.IsSpicy = false;
            this.IsSweet = false;
        }
        //END CONSTRUCTORS
    }
}
