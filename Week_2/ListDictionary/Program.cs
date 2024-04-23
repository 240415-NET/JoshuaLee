namespace ListDictionary;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> cityList = new List<string>();

        cityList.Add("Miami");
        cityList.Add("Tampa");        
        cityList.Add("Sarasota");
        cityList.Add("Chicago");
        cityList.Add("Clearwater");
        
        foreach(string city in cityList)
        {
            Console.WriteLine(city);
        }

        Dictionary<string, string> simplePets = new Dictionary<string, string>();
        simplePets.Add("Jonathan", "Ellie");
        simplePets.Add("Ross", "Brodie");
        simplePets.Add("Mike", "Carl");
        simplePets.Add("Marcus", "Ziggy");

        //foreach (KeyValuePair<string, string> household in simplePets)
        //This is an example of implicity typing using "var" in C#

        foreach (var household in simplePets)
        {
            Console.WriteLine(household.GetType());
            Console.WriteLine(household.Key + " owns " + household.Value);
        }

        Dictionary<string, List<string>> petDictionary = new();

        //This is an example of nesting collections. You can nest a dictionary within a dictionary, if needed.
        //Instead of creating my lists somewhere else, I can create them while adding to my dictionary

        List<string> jonPets = new List<string>(){"Ellie", "Pancake"};

        petDictionary.Add("Jonathan", jonPets);
        petDictionary.Add("Ross", new List<string>(){"Brody"});
        petDictionary.Add("Mike", new List<string>(){"Carl"});
        petDictionary.Add("Marcus", new List<string>(){"Ziggy", "Luna", "Amelia", "Pyewacket", "Love Muffin"});

        foreach(var person in petDictionary)
        {
            Console.WriteLine(person.Key + person.Value);
        }
    }
}
