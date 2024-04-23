namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false; 
        Console.WriteLine("Hello, Shopper! We're ready to begin your shopping list.");
        

        do 
        {
        string[] menuOptions = ["1. View grocery list", "2. Add to grocery list", "3. Exit"];
        
        
        Console.WriteLine("Please select a menu number");
        foreach(string options in menuOptions)
            {
                Console.WriteLine(options);
            }
        int userInput = Convert.ToInt32(Console.ReadLine().Trim());
        string[] groceryList = new string[10];
            if(userInput == 3)
            {
                quit = true;
            }
            else if(userInput == 2)
            {
                
            }
            else foreach(string groceries in groceryList)
            {
                Console.WriteLine(groceries);
            }
        
        }  
        while (quit == false); 
    }
}