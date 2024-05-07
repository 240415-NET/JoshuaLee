// Program.cs

// using System;
// using System.Collections.Generic;

// namespace ShoppingListApp
// {
//     class Program
//     {
//         static void Main()
//         {
//             List<ShoppingItem> shoppingList = new List<ShoppingItem>();

//             while (true)
//             {
//                 Console.WriteLine("Shopping List App");
//                 Console.WriteLine("1. Add Item");
//                 Console.WriteLine("2. Display List");
//                 Console.WriteLine("3. Exit");
//                 Console.Write("Enter your choice: ");
//                 string choice = Console.ReadLine();

//                 switch (choice)
//                 {
//                     case "1":
//                         AddItem(shoppingList);
//                         break;
//                     case "2":
//                         DisplayList(shoppingList);
//                         break;
//                     case "3":
//                         Console.WriteLine("Exiting the application. Have a great day!");
//                         return;
//                     default:
//                         Console.WriteLine("Invalid choice. Please try again.");
//                         break;
//                 }
//             }
//         }

//         static void AddItem(List<ShoppingItem> list)
//         {
//             Console.Write("Enter item name: ");
//             string name = Console.ReadLine();

//             Console.Write("Enter quantity: ");
//             int quantity = int.Parse(Console.ReadLine());

//             Console.Write("Enter price per item: $");
//             decimal price = decimal.Parse(Console.ReadLine());

//             var newItem = new ShoppingItem { Name = name, Quantity = quantity, Price = price };
//             list.Add(newItem);
//             Console.WriteLine("Item added to the list.");
//         }

//         static void DisplayList(List<ShoppingItem> list)
//         {
//             Console.WriteLine("Shopping List:");
//             foreach (var item in list)
//             {
//                 Console.WriteLine(item);
//             }
//         }
//     }
// }