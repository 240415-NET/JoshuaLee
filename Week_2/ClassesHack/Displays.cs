using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListPro
{
    public class Displays
    {
        public static void DisplayList(List<ShoppingItem> list)
        {
            Console.WriteLine($"Shopping List:\n");
            foreach (var item in list)
            {
                Console.WriteLine(item);

            }   
        }
    }
}