namespace MethodExceptionDemo;
class Program
// In this Hackathon we want to create a C# console application with the following requirements.

// 1 - Prompts the user for some input
// 2 - Does something with that input
// 3 - Handles any exceptions that may arise during the running of the application (no hard crashing)
// 4 - Continues to run until the user quits the application, from within the application (no ctrl+c)

// We also want to make sure this code is visible to all of us! Have someone share their screen and 
// type for the group, making sure that they are inside of their personal repo on this organization. 

// We want to then push this code up before we leave today. I will compile links to their repo's and 
// make a teams post with links to the different groups' work for future reference. 

// Outline:
// 1. Ask about how many squares and triangles exist
// 2. Keep count of them in the background 
// 3. Provide a total after every submission
// 4. Ask the user if they want to quit or continue
{
static void Main(string[] args)
{
int totalCircles = 0;
int totalTriangles = 0;
bool stopTime = false;
int totalShapes = 0;

do {
    try {
        Console.WriteLine($"How many circles do you have?");
        int circleCount = Convert.ToInt32(Console.ReadLine());
        totalCircles = (circleCount + totalCircles);
        Console.WriteLine($"How many triangles do you have?");
        int triangleCount = Convert.ToInt32(Console.ReadLine());
        totalTriangles = (triangleCount + totalTriangles);
        Console.WriteLine($"You now have {totalCircles} circles and {totalTriangles} triangles.");
        totalShapes = (totalCircles + totalTriangles);
        Console.WriteLine($"That's a total of {totalShapes} shapes.");
        Console.WriteLine($"Do you want to total up any additional shapes? (Y or N)");
        string stopAnswer = Console.ReadLine().ToUpper();
        if(stopAnswer == "Y")
        {
            stopTime = false;
        }
        else
        {
            stopTime = true;
        }
    }
    catch (Exception myException)
    {
        Console.WriteLine($"{myException.Message}");
        Console.WriteLine($"{myException.StackTrace}");
        Console.WriteLine("Please make sure you enter Y or N for your answer");
    }
}
while (stopTime == false);
}
}