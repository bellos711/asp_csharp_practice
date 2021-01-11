using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzles
{
    class Program
    {
        public static int[] RandomArray()
        {
            System.Console.WriteLine("You are in RandomArray");
            System.Console.WriteLine("Generating 10 random ints from 5-25");
            System.Random random = new System.Random(); 
            int[] randomIntegers = new int[10];
            for(int i = 0; i < randomIntegers.Length; i++)
            {
                randomIntegers[i] = random.Next(5,26);
            }//endfor
            return randomIntegers;
        }//end RandomArray

        public static string TossCoin()
        {
            System.Random random = new System.Random();
            int headsOrTails = random.Next(2);
            string headsOrTailsStr = "";
            if(headsOrTails == 0)
            {
                // System.Console.WriteLine(headsOrTails);
                // System.Console.WriteLine("Heads");
                headsOrTailsStr += "Heads";
            }
            else
            {
                // System.Console.WriteLine(headsOrTails);
                // System.Console.WriteLine("Tails");
                headsOrTailsStr += "Tails";
            }
            return headsOrTailsStr;
        }//end TossCoin

        public static double TossMultipleCoins(int tossTimes)
        {
            int counter = 0;
            int headsCount = 0;
            while(counter < tossTimes)
            {
                TossCoin();
                if(TossCoin()=="Heads")
                {
                    // System.Console.WriteLine("You are getting heads");
                    headsCount++;
                }
                // else
                // {
                //     System.Console.WriteLine("You are getting tails");
                // }
                counter++;
            }//endwhile
            // System.Console.WriteLine(headsCount);
            double headsRatio = ((double)headsCount)/((double)tossTimes)*100;
            return Math.Round(headsRatio, 2);
        }//end TossMultipleCoins

        public static List<string> Names() //List<string>
        {
            System.Console.WriteLine("you are in Names()");
            System.Random random = new System.Random();
            List<string> names = new List<string>
            {
                "Todd",
                "Tiffany",
                "Charlie",
                "Geneva",
                "Sydney"
            };
            

            for(int i = 0; i <names.Count; i++)
            {
                System.Console.WriteLine(names[i]);
                if(names[i].Length < 5)
                {
                    System.Console.WriteLine($"Removing name: {names[i]}");
                    names.Remove(names[i]);
                    
                }
                
            }
            List<string> shuffledList = names.OrderBy( i => random.Next() ).ToList();
            System.Console.WriteLine("#########SHUFFLED LIST###########");
            for(int i = 0; i <shuffledList.Count; i++)
            {
                System.Console.WriteLine(shuffledList[i]);
            }

            return shuffledList;
        }//end names

        static void Main(string[] args)
        {
            foreach(int value in RandomArray())
            {
                System.Console.Write($"{value},");
            }//end foreach
            System.Console.WriteLine("\n#######################################\n");
            System.Console.WriteLine($"Coin toss:\n{TossCoin()}");

            System.Console.WriteLine("\n#######################################\n");
            System.Console.WriteLine($"Tossing {37} times, heads ratio is {TossMultipleCoins(37)}%");

            System.Console.WriteLine("\n#######################################\n");
            System.Console.WriteLine($"This is actually returning a list but i did a lot of console outputs in the actual method {Names()}, i could loop the data here");
        }
    }
}
