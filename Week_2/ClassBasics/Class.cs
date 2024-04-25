namespace ClassBasics.Classes
{
    public class ExampleClass
    {
        public string exampleString;
        
        //Static Fields
        //Belong to the type/class itself
        //Shared across all instances
        //Accessible only through the type name
        public static int instanceCount;
        
    }
}


//Access Modifiers
//public - 
//private - 
//internal - 
//protected - Only accessible to children of the class and the class itself


//readonly - Can only be assigned during intialization or in the constructor
    //the one below is available all over, but cannot be written to

public readonly int maxLimit = 100;
private readonly int MAC_LIMIT = 100;       //// If someone makes it private, it usually will be in all caps to make it obvious

public string Name {get; set;}

//Property
//These are a pattern of fields in class
//public datatype name
//These properties can have the shorthand {get; set;}

public interface Age {get; set;}

//Getter and Setter Examples
//Example of Encapsulation as you are limiting the field to private
//and allowing access

public string GetName()
{
    return this.Name.ToUpper();
}

public string SetName(string Name)
{
    this.Name = Name.Trim();
}