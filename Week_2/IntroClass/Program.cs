namespace IntroClass;



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("hello, World!");

        Dog pancake = new Dog();

        pancake.name = "pancake";

        //Here we call an instance method - this method 
        pancake.Bark();

        Dog.DefineDog();
        
    }
}
