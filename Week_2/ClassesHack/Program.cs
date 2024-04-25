namespace ShoppingListPro;

//Shopping List
//Initialize variables
//Create a Menu
//Create a Do While to Exit



class Program

{
    static void Main(string[] args)
    {
        int itemNum = 0;
        List<string> shoppingList = new List<string>();
        
        Console.WriteLine("Welcome to your Shopping List!");
        Console.WriteLine("Please enter an item to add to your list.");
        string shoppingItem = Console.ReadLine();
        itemNum++;
        shoppingList.Add($"{itemNum} - {shoppingItem}");
        
                    // Console.WriteLine($"Please enter the number of {listItem}'s you need.");
                    // int listItem = Convert.ToInt32(Console.ReadLine());
        
        bool doneAdding = false;

           do
           {
                try
                {
                    
                    Console.WriteLine("Do you want to add another item? (Y or N)");
                    string moreItems = Console.ReadLine().ToLower();
                    
                    if(moreItems != "n")
                    {
                        foreach (string item in shoppingList)
                        {
                            Console.WriteLine($"{itemNum}: {item}");
                        }
                        Console.WriteLine("What other item can I add to your list?");
                        shoppingItem = Console.ReadLine();
                        itemNum++;
                        shoppingList.Add($"{itemNum} - {shoppingItem}");
                    }
                    else 
                    {
                        doneAdding = true;
                    }
                }
            
                catch(Exception f)
                {
                    Console.WriteLine($"{f.Message} Please enter a valid selection");
                }   
           }
           while (doneAdding == false);
    }}
    //     do
    //     {
    //         try
    //         {
                
    //         }
    //     catch(Exception f)
    //         {
    //             Console.WriteLine($"{f.Message} Please enter a valid selection");
    //         }
    // }





//         Console.WriteLine("Please select a menu option number from 1-3:");
//         Console.WriteLine("1.  Add an item");
//         Console.WriteLine("2.  Display your shopping list");
//         Console.WriteLine("3.  Quit");
//         int menuSelect = Convert.ToInt32(Console.ReadLine());

//         bool isQuit = false;
//         try
//         {
//             do 
//             {
//                 if(menuSelect == 3)
//                 {
//                     isQuit = true;
//                 }
//                 else if(menuSelect == 2 && )
//                 {

//                 }
//             }
//             while isQuit == false;
//        }
//     }   

// }
