using System;

namespace hungry_ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Buffet firstCourse = new Buffet();
            Ninja supraNinja = new Ninja();

            while(!supraNinja.isFull())
            {
                supraNinja.Eat(firstCourse.Serve());
                System.Console.WriteLine("##################################");
            }
        }
    }
}
