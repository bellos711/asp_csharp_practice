using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<object> MyObjects = new List<object>();
            MyObjects.Add(7);
            MyObjects.Add(28);
            MyObjects.Add(-1);
            MyObjects.Add(true);
            MyObjects.Add("chair");
            int sum = 0;
            foreach(var theObject in MyObjects)
            {
                System.Console.WriteLine(theObject);
                if (theObject is int)
                {   
                    sum+=(int)theObject;
                    System.Console.WriteLine("Adding...");
                }
            }//end foreach
            System.Console.WriteLine($"The sum of integer types is {sum}");
        }
    }
}
