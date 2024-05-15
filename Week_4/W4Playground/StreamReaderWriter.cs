// using System.IO;
// using System.Text;

// namespace W4Playground;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Int64 x;
//         try
//         {
//             //Open the File
//             StreamWriter sw = new StreamWriter("C:\\Users\\U1C409\\Desktop\\Training\\Revature\\JoshuaLee\\Week_4\\W4Playground\\Test1.txt", true, Encoding.ASCII);

//             //Write out the numbers 1 to 10 on the same line.
//             for (x = 0; x < 10; x++)
//             {
//                 sw.Write(x);
//             }

//             //close the file
//             sw.Close();
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine("Exception: " + e.Message);
//         }
//         finally
//         {
//             Console.WriteLine("Executing finally block.");
//         }
//     }
// }


//StreamWriter//
// static void Main(string[] args)
//     {
//         String line;

//         try
//         {
//             //Pass the filepath and filename to the StreamWriter Constructor
//             StreamWriter sw = new StreamWriter("C:\\Users\\U1C409\\Desktop\\Training\\Revature\\JoshuaLee\\Week_4\\W4Playground\\Test.txt");
//             //Write a line of text
//             sw.WriteLine("Hello World!!");
//             //Write a second line of text
//             sw.WriteLine("From the StreamWriter class");
//             //Close the file
//             sw.Close();
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine("Exception: " + e.Message);
//         }
//         finally
//         {
//             Console.WriteLine("Executing finally block.");
//         }
//     }
// }
//StreamReader//
// String line;
//         try
//         {
//             //Pass the file path and file name to the StreamReader constructor
//             StreamReader sr = new StreamReader("C:\\Users\\U1C409\\Desktop\\Training\\Revature\\JoshuaLee\\Week_4\\W4Playground\\Sample.txt");
//             //Read the first line of text
//             line = sr.ReadLine();
//             //Continue to read until you reach end of file
//             while (line != null)
//             {
//                 //write the line to console window
//                 Console.WriteLine(line);
//                 //Read the next line
//                 line = sr.ReadLine();
//             }
//             //close the file
//             sr.Close();
//             Console.ReadLine();
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine("Exception: " + e.Message);
//         }
//         finally
//         {
//             Console.WriteLine("Executing finally block.");
//         }