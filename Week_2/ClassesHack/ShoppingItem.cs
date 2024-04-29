using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListPro
{
    public class ShoppingItem
    {
        public string ItemName {get;set;}
        public int ItemCount {get;set;}
        public decimal ItemPrice {get;set;}
        // public decimal TotalItemCost;
    
    public override string ToString()
    {
        return $"{ItemName} ({ItemCount} @ ${ItemPrice:F2} each.)";
    }
    
    }
    

    
}