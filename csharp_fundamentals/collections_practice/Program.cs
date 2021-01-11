using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] intArray = new int[10];
            int count = 0;
            while(count < intArray.Length)
            {
                intArray[count] = count;
                Console.WriteLine($"index {count} = {intArray[count]}");
                count++;
            }//endwhile
            count = 0;
            System.Console.WriteLine("############################################");

            string[] nameAray = new string[]{"Tim","Martin","Nikki","Sara"};
            while(count < nameAray.Length)
            {
                System.Console.WriteLine(nameAray[count]);
                count++;
            }
            count = 0;
            System.Console.WriteLine("############################################");

            bool[] boolArray = new bool[10];
            while(count < boolArray.Length)
            {
                if(count==0)
                {
                    boolArray[count] = true;
                    System.Console.WriteLine(boolArray[count]);
                }
                else if(count%2==0)
                {
                    boolArray[count] = true;
                    System.Console.WriteLine(boolArray[count]);
                }
                else
                {
                    boolArray[count] = false;
                    System.Console.WriteLine(boolArray[count]);
                }
                count++;
            }//endwhile
            count = 0;
            System.Console.WriteLine("############################################");

            List<string> iceCreamList = new List<string>()
            {
                "Mint",
                "Bubblegum",
                "Vanilla",
                "Pumpkin",
                "Pecan"
            };
            iceCreamList.Add("Cake");
            int iceCreamLength = iceCreamList.Count;
            System.Console.WriteLine($"The length of the list is {iceCreamLength}");
            while(count < iceCreamLength)
            {
                System.Console.WriteLine(iceCreamList[count]);
                count++;
            }
            
            System.Console.WriteLine($"Third flavor is {iceCreamList[2]}");
            count = 0;
            System.Console.WriteLine("############################################");


            Dictionary<string,string> myDictionary = new Dictionary<string,string>();
            Random randomNum = new Random();//EDIT THIS
            for(int i = 0; i < nameAray.Length; i++)
            {
                myDictionary.Add(nameAray[i], iceCreamList[randNum]);
            }//endfor
            
            foreach(KeyValuePair<string, string> entry in myDictionary)
            {
                System.Console.WriteLine($"{entry.Key} = {entry.Value}");
            }
            System.Console.WriteLine("############################################");
{
    // do something with entry.Value or entry.Key
}
        }
    }
}
