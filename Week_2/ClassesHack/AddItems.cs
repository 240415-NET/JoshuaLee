using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListPro
{
    public class AddItems
    {
        public void AddItemFunc()
        {
            int ItemNum = 0;
            bool DoneAdding = false;
            List<ShoppingItem> ListOfItems = new List<ShoppingItem>();

            do
            {
                try
                {
                    static void AddItem(ListOfItems list)
                    {
                        Console.WriteLine("What is the name of the item you are adding?");
                        string itemname = Console.ReadLine().Trim();

                        Console.WriteLine($"How many {itemname}'s do you want?");
                        int itemcount = int.Parse(Console.ReadLine().Trim());

                        Console.WriteLine("What is the estimated price of the item?");
                        decimal itemprice = decimal.Parse(Console.ReadLine().Trim());

                        var NewItem = new ShoppingItem {ItemName = itemname, ItemCount = itemcount, ItemPrice = itemprice};
                        list.Add(NewItem);
                        Console.WriteLine($"Item added to the list.\n");
                    }

                }

                catch(Exception f)
                {
                    Console.WriteLine($"{f.Message} Please enter a valid selection.");
                }
            }
            while(DoneAdding != true);

        
        }


    }    
}
