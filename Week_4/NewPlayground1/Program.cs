using System;

namespace SumOfEvenAndOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumOdd = 0;
            int sumEven = 0;
            Console.Write("Enter a positive integer (n): ");
            int n = int.Parse(Console.ReadLine());

            for

         // Output the results
            Console.WriteLine($"sum_odd: {sumOdd}");
            Console.WriteLine($"sum_even: {sumEven}");
        }
    }
}



    // public static string createSecretCode(string s){
    //     //WRITE YOUR CODE HERE
    //     string sLowered = s.ToLower();
    //     string result = "";
    //     foreach(char coded in sLowered)
    //     {
    //         switch (coded)
    //         {
    //             case 'a':
    //                 result += "01";
    //                 break;
    //             case 'b':
    //                 result += "02";
    //                 break;
    //             case 'c':
    //                 result += "03";
    //                 break;
    //             case 'd':
    //                 result += "04";
    //                 break;
    //             case 'e':
    //                 result += "05";
    //                 break;
    //             case 'f':
    //                 result += "06";
    //                 break;
    //             case 'g':
    //                 result += "07";
    //                 break;
    //             case 'h':
    //                 result += "08";
    //                 break;
    //             case 'i':
    //                 result += "09";
    //                 break;
    //             case 'j':
    //                 result += "10";
    //                 break;
    //             case 'k':
    //                 result += "11";
    //                 break;
    //             case 'l':
    //                 result += "12";
    //                 break;
    //             case 'm':
    //                 result += "13";
    //                 break;
    //             case 'n':
    //                 result += "14";
    //                 break;
    //             case 'o':
    //                 result += "15";
    //                 break;
    //             case 'p':
    //                 result += "16";
    //                 break;
    //             case 'q':
    //                 result += "17";
    //                 break;
    //             case 'r':
    //                 result += "18";
    //                 break;
    //             case 's':
    //                 result += "19";
    //                 break;
    //             case 't':
    //                 result += "20";
    //                 break;
    //             case 'u':
    //                 result += "21";
    //                 break;
    //             case 'v':
    //                 result += "22";
    //                 break;
    //             case 'w':
    //                 result += "23";
    //                 break;
    //             case 'x':
    //                 result += "24";
    //                 break;
    //             case 'y':
    //                 result += "25";
    //                 break;
    //             case 'z':
    //                 result += "26";
    //                 break;
    //             default: 
    //                 result += "";
    //                 break;
    //         }
    //     }
    //     return result;
        
        
        
    // }
    // //DO NOT TOUCH THE CODE BELOW
    // public static void Main(){
    //     string s = "hijklMn";
    //     Console.WriteLine(createSecretCode(s));
    // }