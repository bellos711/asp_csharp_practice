using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dojidachi.Models
{
    public class Dojidachi
    {
        public int Fullness {get;set;}
        public int Happiness {get;set;}
        public int Meals {get;set;}
        public int Energy {get;set;}

        public string MyMsg {get;set;}

        private Random rand = new Random();

        public Dojidachi()
        {
            this.Fullness = 20;
            this.Happiness = 20;
            this.Meals = 3;
            this.Energy = 50;
        }

        private int Chancec()
        {
            int chance = rand.Next(1, 101);
            return chance;
        }

        public void Feedc()
        {
            
            if(Chancec() <= 25)
            {
                System.Console.WriteLine($"Dochidachi doesn't want to eat 25%. lost some meals and is now at {this.Meals}");
            }
            else
            {
                if(this.Meals <= 0)
                {
                    System.Console.WriteLine("OUT OF MEALS");
                }
                else
                {
                    this.Meals -= 1;
                    // System.Random rand = new Random();
                    this.Fullness = this.Fullness + rand.Next(5, 11);
                    System.Console.WriteLine($"Dojidachi ate, fullness is now {this.Fullness}");
                }
            }
        }//end feed

        public void Playc()
        {
            if(Chancec() <= 25)
            {
                this.Energy -= 5;
                System.Console.WriteLine($"Dojidachi doesn't want to play with you, lol. 25%. lost some energy and is now at {this.Energy}");
            }
            else
            {
                if(this.Energy <= 0)
                {
                    System.Console.WriteLine($"Dojidachi not enough energy to play. Energy is {this.Energy}");
                }
                else
                {
                    this.Energy -= 5;
                    this.Happiness = this.Happiness + rand.Next(5, 11);
                    System.Console.WriteLine($"Dojidachi playedl, happiness is now {this.Happiness}");
                }
            }

        }//end play

        public void Workc()
        {
            if(this.Energy <= 0)
            {
                System.Console.WriteLine($"Dojidachi not enough energy to work. Energy is {this.Energy}");
            }
            else
            {
                this.Energy -= 5;
                this.Meals = this.Meals + rand.Next(1, 4);
                System.Console.WriteLine($"Dojidachi worked, meals is now {this.Meals}");
            }
        }//end Work

        public void Sleepc()
        {
            this.Fullness -= 5;
            this.Happiness -= 5;
            this.Energy += 15;
        }//end sleep

    }//end dojidachi class
}//end namespace