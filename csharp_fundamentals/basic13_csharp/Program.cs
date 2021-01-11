using System;
using System.Collections.Generic;

namespace basic13_csharp
{
    class Program
    {
        public static void PrintNumbers()
        {
            // Print all of the integers from 1 to 255.
            int counter = 1;
            while(counter <= 255)
            {
                System.Console.Write($"{counter}, ");
                counter++;
            }
            System.Console.WriteLine();
        }

        public static void PrintOdds()
        {
            // Print all of the odd integers from 1 to 255.
            int counter = 1;
            while(counter <= 255)
            {
                if(counter%2!=0)
                {
                    System.Console.Write($"{counter}, ");
                }
                counter++;
            }
            System.Console.WriteLine();
        }

        public static void PrintSum()
        {
            // Print all of the numbers from 0 to 255, 
            // but this time, also print the sum as you go. 
            // For example, your output should be something like this:
            
            // New number: 0 Sum: 0
            // New number: 1 Sum: 1
            // New Number: 2 Sum: 3
            int counter = 1;
            int sum = 0;
            while(counter <= 255)
            {
                System.Console.Write($"{counter}, ");
                sum+=counter;
                System.Console.Write($"Sum so far is {sum}\n");
                counter++;

            }
        }

        public static void LoopArray(int[] numbers)
        {
            System.Console.WriteLine("You are in LoopArray");
            // Write a function that would iterate through each item of the given integer array and 
            // print each value to the console. 
            for(int i = 0; i < numbers.Length; i++)
            {
                System.Console.Write($"{numbers[i]}, ");
            }//endfor
            System.Console.WriteLine();
        }

        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            // Write a function that takes an integer array and prints and returns the maximum value in the array. 
            // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
            // or even a mix of positive numbers, negative numbers and zero.
            for (int i = 0; i < numbers.Length; i++)
            {
                if(max < numbers[i])
                {
                    max = numbers[i];
                }//endif
            }
            return max;
        }

        public static void GetAverage(int[] numbers)
        {
            System.Console.WriteLine("You are in GetAverage");
            // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
            // For example, with an array [2, 10, 3], your program should write 5 to the console.
            int average = 0;
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            System.Console.WriteLine($"The sum is: {sum}");
            average = (sum/numbers.Length);
            System.Console.WriteLine($"The average is {average}");
        }

        public static int[] OddArray()
        {
            System.Console.WriteLine("You are in OddArray");
            // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
            // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].
            int[] myArr = new int[255];
            int[] myArrOdd = new int[255];
            for(int i = 0; i < myArr.Length; i++)
            {
                myArr[i] = i;
                if(myArr[i]%2 != 0)
                {
                    myArrOdd[i] = myArr[i];
                    // System.Console.WriteLine($"in function {myArrOdd[i]}");
                }
            }//endfor
            
            return myArrOdd;
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            System.Console.WriteLine("You are in GreaterThanY");
            // Write a function that takes an integer array, and a integer "y" and returns the number of array values 
            // That are greater than the "y" value. 
            // For example, if array = [1, 3, 5, 7] and y = 3. Your function should return 2 
            // (since there are two values in the array that are greater than 3).
            
            int greaterThanYCount = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                System.Console.WriteLine($"inside loop {numbers[i]}");
                if(numbers[i] >= y)
                {
                    System.Console.WriteLine($"this is greater than y {numbers[i]}");
                    greaterThanYCount++;
                }//endif
            }//endfor
            return greaterThanYCount;
        }

        public static void SquareArrayValues(int[] numbers)
        {
            System.Console.WriteLine("You are in SquareArrayValues");
            // Write a function that takes an integer array "numbers", and then multiplies each value by itself.
            // For example, [1,5,10,-10] should become [1,25,100,100]
            for (int i = 0; i < numbers.Length; i++)
            {
                System.Console.Write($"{Math.Pow(numbers[i], 2)},");
            }
            System.Console.WriteLine();
        }

        public static void EliminateNegatives(int[] numbers)
        {
            System.Console.WriteLine("You are in EliminateNegatives");
            // Given an integer array "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
            // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] >= 0)
                {
                    System.Console.Write($"{numbers[i]},");
                }
            }
            System.Console.WriteLine();
        }

        public static void MinMaxAverage(int[] numbers)
        {
            
            System.Console.WriteLine("You are in MinMaxAverage");
            // Given an integer array, say [1, 5, 10, -2], create a function that prints the maximum number in the array, 
            // the minimum value in the array, and the average of the values in the array.
            int min = numbers[0];
            int max = numbers[0];
            // int average = 0;
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] > max)
                {
                    max = numbers[i];
                }

                if(numbers[i] < min)
                {
                    min = numbers[i];
                }

                sum+=numbers[i];
            }

            System.Console.WriteLine($"The max is {max}");
            System.Console.WriteLine($"The min is {min}");
            System.Console.WriteLine($"The average is {sum/numbers.Length}");
        }


        public static void ShiftValues(int[] numbers)
        {
            System.Console.WriteLine("You are in ShiftValues");
            // Given an integer array, say [1, 5, 10, 7, -2], 
            // Write a function that shifts each number by one to the front and adds '0' to the end. 
            // For example, when the program is done, if the array [1, 5, 10, 7, -2] is passed to the function, 
            // it should become [5, 10, 7, -2, 0].
            int lastIndex = numbers.Length-1;
            for (int i = 0; i < numbers.Length; i++)
            {

                if(i==lastIndex)
                {
                    numbers[i] = 0;
                    System.Console.Write($"{numbers[i]}, ");
                }
                else
                {
                    numbers[i] = numbers[i+1];
                    System.Console.Write($"{numbers[i]}, ");
                }
                
            }
            System.Console.WriteLine();
        }

        public static object[] NumToString(int[] numbers)
        {
            System.Console.WriteLine("You are in NumToString");
            // Write a function that takes an integer array and returns an object array 
            // that replaces any negative number with the string 'Dojo'.
            // For example, if array "numbers" is initially [-1, -3, 2] 
            // your function should return an array with values ['Dojo', 'Dojo', 2].
            // List<object> newObject = new List<object>();
            object[] newObject = new object[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                
                if(numbers[i] < 0)
                {
                    // System.Console.Write($"negative: {numbers[i]},");
                    // newObject.Add("Dojo");
                    newObject[i] = "Dojo";
                }
                else
                {
                    // System.Console.Write($"positive {numbers[i]},");
                    // newObject.Add(numbers[i]);
                    newObject[i] = numbers[i];
                }
            }
            System.Console.WriteLine();
            return newObject;

        }

 
        //########################START OF MAIN####################################
        static void Main(string[] args)
        {
            PrintNumbers();
            System.Console.WriteLine("\n#################################################\n");
            PrintOdds();
            System.Console.WriteLine("\n#################################################\n");
            PrintSum();
            System.Console.WriteLine("\n#################################################\n");

            int[] myArr = new int[9]
            {
                7,11,-2,77,51,82,-19,49,69
            };
            LoopArray(myArr);
            System.Console.WriteLine("\n#################################################\n");
            System.Console.WriteLine("The max value in this array is " + FindMax(myArr));

            System.Console.WriteLine("\n#################################################\n");
            GetAverage(myArr);
            
            System.Console.WriteLine("\n#################################################\n");
            foreach(int value in OddArray())
            {
                if(value!=0)
                {
                    System.Console.Write($"{value},");
                }
            }//end foreach
            System.Console.WriteLine();
            System.Console.WriteLine("\n#################################################\n");
            int y = 60;
            System.Console.WriteLine($"There are {GreaterThanY(myArr, y)} values greater than {y} in this array.");

            System.Console.WriteLine("\n#################################################\n");
            SquareArrayValues(myArr);

            System.Console.WriteLine("\n#################################################\n");
            EliminateNegatives(myArr);

            System.Console.WriteLine("\n#################################################\n");
            MinMaxAverage(myArr);

            System.Console.WriteLine("\n#################################################\n");
            ShiftValues(myArr);

            System.Console.WriteLine("\n#################################################\n");
            foreach(var value in NumToString(myArr))
            {
                System.Console.Write($"{value},");
            }//end foreach
        }
    }
}
