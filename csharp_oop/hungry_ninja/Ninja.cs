using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;
    
    // add a constructor
    public Ninja()
    {
        this.calorieIntake = 0;
        FoodHistory = new List<Food>();
    }
    
    // add a public "getter" property called "IsFull"
    public bool isFull()
    {
        if(this.calorieIntake>=1200)
        {
            System.Console.WriteLine("Ninja is full and cannot eat anymore.");
            return true;
        }
        else
        {
            return false;
        }
    }//end isfull
    
    // build out the Eat method
        public void Eat(Food item)
        {
            System.Console.WriteLine("In Eat method..");
            if(!isFull())
            {
                this.calorieIntake += item.Calories;
                FoodHistory.Add(item);
                System.Console.WriteLine($"Food item {item.Name} eaten it had {item.Calories} calories");
                if(item.IsSpicy || item.IsSweet)
                {
                    System.Console.WriteLine("This food item is sweet/spicy.");
                }//endif
            }//endif
            else
            {
                System.Console.WriteLine("This ninja is FULL!");
            }
        }
    }
}
