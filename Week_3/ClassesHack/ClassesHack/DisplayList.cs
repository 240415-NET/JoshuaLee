using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListPro
{
    public class DisplayList
    {
        public DisplayList()
        {
        }

        public void  DisplayListFunc(List<ShoppingItem> list)
        {
            var mf = new MenuFunc();
            //List<ShoppingItem> list
            Console.WriteLine($"Shopping List:\n");
            foreach (var item in list)
            {
                Console.WriteLine(item);

            }   
            mf.Menu();
        }

     
    }
}