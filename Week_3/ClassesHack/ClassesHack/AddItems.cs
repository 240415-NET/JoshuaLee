using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ShoppingListPro
{
    public class AddItems
    {
        class CallList
        {
            // public List<ShoppingItem> ListOfItems = [];
            public List<ShoppingItem> ListOfItems
            {
                get { return ListOfItems; }
            }
        }
        public void AddItemstolist()
        {
            bool DoneAdding = false;

            do
            {
                try
                {
                    //int ItemNum = 0;
                    {
                        var mf = new MenuFunc();
                        var cl = new CallList();

                        Console.WriteLine("What is the name of the item you are adding?");
                        string itemname = Console.ReadLine().Trim();

                        Console.WriteLine($"How many {itemname}'s do you want?");
                        int itemcount = int.Parse(Console.ReadLine().Trim());

                        Console.WriteLine("What is the estimated price of the item?");

                        decimal itemprice = decimal.Parse(Console.ReadLine().Trim());


                        var NewItem = new ShoppingItem { ItemName = itemname, ItemCount = itemcount, ItemPrice = itemprice };
                        cl.ListOfItems.Add(NewItem);
                        Console.Clear();
                        Console.WriteLine($"Item added to the list.\n");

                        AddAnother();
                    }
                }
                catch (Exception f)
                {
                    Console.WriteLine($"{f.Message} Please enter a valid selection.");
                }
            }
            while (DoneAdding != true);

            static void AddAnother()
            {
                var ai = new AddItems();
                var mf = new MenuFunc();

                Console.WriteLine("Do you want to add another item to your list? (Y or N)");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                string continueResponse = Console.ReadLine().Trim().ToLower();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                if (continueResponse == "y" || continueResponse == "yes")
                {
                    ai.AddItemstolist();
                }
                else if (continueResponse == "n" || continueResponse == "no")
                {
                    Console.Clear();
                    mf.Menu();
                }
                else Console.WriteLine($"Invalid Entry! Please try again.\n");
            }
        }

        public void DisplayList()
        {
            var cl = new CallList();
            foreach (ShoppingItem item in cl.ListOfItems) ;
            {
                Console.WriteLine(cl.ListOfItems);
            }
        }
    }
}
