using System;

namespace fundamentals_i
{
    class Program
    {
        static void Main(string[] args)
        {
             for(int i = 1; i <= 255; i++)
             {
                 Console.Write(i + " ");
             }
            System.Console.WriteLine("\n\n#################WHILE 1-255#################\n\n");
            int counter = 1;
            while(counter <= 255)
            {
                Console.Write(counter + " ");
                counter++;
            }
            Console.WriteLine("\n\n" + counter);
            //#####################################################
            Console.WriteLine("\n################FOR LOOP 1 - 100#################\n");
            for(int i = 1; i <= 100; i++)
             {
                 if(i%3 == 0 || i%5 == 0)
                 {
                     if(i%3==0 && i%5==0)
                     {
                         Console.WriteLine();
                     }
                     else
                     {
                         Console.WriteLine(i);
                     }
                     
                 }
             }
             System.Console.WriteLine("\n\n#################WHILE 1-100#################\n\n");
             int counter2 = 1;
             while(counter2 <= 100)
             {
                 if(counter2%3 == 0 || counter2%5 == 0)
                 {
                     if(counter2%3==0 && counter2%5==0)
                     {
                         Console.WriteLine();
                     }
                     else
                     {
                         Console.WriteLine(counter2);
                     }
                 }
                 counter2++;
             }
            


             Console.WriteLine("\n#################FOR LOOP FIZZBUZZ################\n");
            for(int i = 1; i <= 100; i++)
             {
                 if(i%3==0)
                 {
                     if(i%5==0)
                     {
                         System.Console.WriteLine(i + " FizzBuzz");
                     }
                     else
                     {
                         System.Console.WriteLine(i + " Fizz");
                     }
                 }
                 else if(i%5==0)
                 {
                     System.Console.WriteLine(i + " Buzz");
                 }

             }



        }
    }
}
