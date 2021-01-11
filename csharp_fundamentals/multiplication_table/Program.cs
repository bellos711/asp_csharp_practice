using System;

namespace multiplication_table
{
    class Program
    {
        static void Main(string[] args)
        {
            int multiplicator = 2;
            int upto = 1;
            for(int i = 1; i <= 10; i++)
            {
                System.Console.Write($"[{i}, ");
                upto = i*10;
                // System.Console.WriteLine($"upto is {upto}\n");
                for(int j = i; j < upto; j++)
                {
                    int temp = i * multiplicator;
                    if(temp >= upto+1)
                    {
                        continue;
                    }
                    System.Console.Write($"{temp},");
                    multiplicator++;
                }//end innerfor
                multiplicator = 2;
                upto = i;
                System.Console.WriteLine("]");
                // System.Console.WriteLine($"upto is {upto}\n");

            }//endfor
        }
    }
}
