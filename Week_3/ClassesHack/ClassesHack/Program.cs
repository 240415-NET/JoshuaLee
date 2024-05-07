namespace ShoppingListPro;

class Program

{
    static void Main(string[] args)
    {
        var mf = new MenuFunc();
        Console.WriteLine("Welcome to Today's Shopping List!");
        Console.WriteLine("Let's get going.");
        Staller();
        Console.Clear();
        mf.Menu();
    }

    static void Staller()
    {
        for(int s = 0; s < 10; s++)
        {
            Console.Write("*");
            Thread.Sleep(500);
        }
    }
}
    