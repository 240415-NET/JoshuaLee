// using Microsoft.VisualBasic;

// namespace Playground;

// class Program
// {
//     static void Main(string[] args)
//     {
//         List<int> scores = [97, 92, 81, 60];

//         var scoreQuery = scores.Where(s => s > 80).OrderByDescending(s => s);

//         List<int> myScores = scoreQuery.ToList();

//         foreach (var score in myScores)
//         {
//             Console.WriteLine(score);
//         }
//     }

    
// }


using System;
using System.Linq;

namespace BeautifyConsoleSO
{
    class Program
    {
        static void Main(string[] args)
        {
            char inputPrefix = '>';
            bool flag = false;
            int clearConsoleRefreshSpeed = 100;
            int clearConsoleTick = 0;
            string historyInput = string.Empty;
            string currentInput = string.Empty;

            string fix = string.Concat(Enumerable.Repeat(Environment.NewLine, Console.WindowHeight));
            Console.WriteLine(fix);

            historyInput += "Hello World!";

            Console.WriteLine(historyInput);
            Console.Write(inputPrefix);

            while(flag != true)
            {
                ConsoleKeyInfo input = Console.ReadKey();

                switch(input.Key)
                {
                    case ConsoleKey.Spacebar:
                        currentInput += ' ';
                        break;
                    case ConsoleKey.Enter:
                        historyInput += Environment.NewLine;
                        historyInput += currentInput;
                        currentInput = string.Empty;
                        break;
                    case ConsoleKey.Backspace:
                        if(currentInput.Length > 0)
                        {
                            if (!currentInput[currentInput.Length - 1].Equals(' '))
                            {
                                currentInput = currentInput.Remove(currentInput.Length - 1);
                            }
                            else
                            {
                                currentInput = currentInput.Remove(currentInput.Length - 2);
                            }
                        }
                        break;
                    default:
                        currentInput += input.KeyChar;
                        break;
                }

                // attempt to fix flickering associated with Console.Clear()
                Console.WriteLine(fix);

                Console.WriteLine(historyInput);
                Console.Write("{0}{1}", clearConsoleTick + " " +  inputPrefix, currentInput);

                clearConsoleTick++;

                if(clearConsoleTick % clearConsoleRefreshSpeed == 0)
                {
                    Console.Clear();
                    Console.WriteLine(fix);
                }
            }

            Console.ReadLine();
        }

    }
}


// List<string> Names = ["Marley", "Jonesy", "Macky", "Corbin"];

//         IEnumerable<string> NameQuery =
//         from Name in Names
//         where Name != "Jonesy"
//         orderby Name ascending
//         select Name;

//         foreach(string i in NameQuery)
//     {
//         Console.WriteLine(i);
//     }

// // // Specify the data source.
// // List<int> scores = [97, 92, 81, 60];

// // // Define the query expression.
// // IEnumerable<int> scoreQuery =
// //     from score in scores
// //     where score != 60
// //     select score;

// // // Execute the query.
// // foreach (var i in scoreQuery)
// // {
// //     Console.Write(i + " ");
// // }

// // // Output: 97 92 81


// // Console.WriteLine("Please provide some numbers");
// // int count = int.Parse(Console.ReadLine());
// // // Console.WriteLine("Please provide some more numbers");
// // string[] inputs = Console.ReadLine().Split(' ');
// // //inputs = int.Parse(inputs);
// // // int intInputs = inputs.ToInt32();
// // int sum = 0;
// // for (int i = 0; i < count; i++)
// // {
// //     int number = int.Parse(inputs[i]);
// //     if(number % 2 == 0)
// //     {
// //         sum = sum + number;
// //     }
// //     else  
// //     {
// //         sum = sum * number;
// //     }
// // }

// // // Write an answer using Console.WriteLine()
// // // To debug: Console.Error.WriteLine("Debug messages...");

// // Console.WriteLine(sum);