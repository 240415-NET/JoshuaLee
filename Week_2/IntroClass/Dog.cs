namespace IntroClass;

public class Dog
{
    //A class has members
    //These members are fields(variables) and methods(behaviors)

    //Fields

    //We need to give our fields (and methods) access modifiers so we can control who gets to access them.
    //The most common are going to be public, private, and internal - but there are others.
    
    /* (most common -> least common)
    public - Access isn't restricted whatsoever
    private - We can only see this from within our Class
    internal - Access is limited to the current assembly
    protected - Access is limited to this class, or classes that inherit from the current class
    protected internal - Access is limited to the current assembly or types derived from the containing class
    private protected - Access is limited to the containing class or types derived from the containing class within the current assembly
    */
   
    public string name {get; set;}
    public string breed {get; set;}

    public int age {get; set;}
    //The {get; set;} shorthand is a shorthand for this.
    // public int age 
    // {
    //     get {return age;} 
    //     set {age = value;}
    // }
    public string gender {get; set;}
    public double weight {get; set;}


    //Methods

    //This is an example of an instance method
    //void = nothing is returning from this method

    //This is an example of an Instance Method. It is called via dot notation from an instance of the class.

    public void Bark()
    {
        Console.WriteLine($"{name}: bark bark!");
    }

    //This is an example of a static method
    //We call it by referencing the class itself, not an object of that class.
    //@ - modifier - Verbatim string/text
    //It allows us to pull in large swaths of text with various puncutation that may play havoc with the code
    

    public static void DefineDog()
    {
        Console.WriteLine(@"The dog is a domesticated descendant of the wolf. Also called the domestic dog, it is derived from extinct gray wolves, and the gray wolf is the dog's closest living relative. The dog was the first species to be domesticated by humans.");
    }
}