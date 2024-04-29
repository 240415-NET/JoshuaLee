using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListPro
{
    public class MenuFunc
    {
        
        public static void Menu()
        {
            int Selection = 0;

            do
            {
                Console.WriteLine("\n\nShopping List Menu");
                Console.WriteLine("Please Select a Number from the Options Below:\n");
                Console.WriteLine("1.  Add Items to Your List");
                Console.WriteLine("2.  View Your Current List");
                // Console.WriteLine("3.  Edit Your List");
                // Console.WriteLine("4.  Save Your List");
                Console.WriteLine("3.  Exit\n\n");
                
                if(!int.TryParse(Console.ReadLine().Trim(), out Selection))
                {
                    Console.WriteLine($"Invalid selection of {Selection}");
                    Console.WriteLine("Please enter a Number.");
                    continue;
                }

                switch (Selection)
                {
                    case 1:
                        Console.Clear();
                        AddItems.AddItemFunc();
                        break;
                    case 2:
                        Console.Clear();
                        Displays.DisplayList();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Exiting the application.\nHave a great day!");
                        Console.WriteLine((char)0x263A);
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
            while(Selection != 3);
        }
    }
}