﻿internal class Program
{
    private static void Main(string[] args)
    {
        for (int x = 1; x <= 100;)
        {
            if (x % 3 == 0 && x % 5 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            if (x % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else if (x % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine(x);
            }
            x++;
        }
    }
}