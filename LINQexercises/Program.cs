// My notes for the LINQ online course on https://www.codingame.com/

///////////////////////////////////////////// LAMBDA EXPRESSIONS ////////////////////////////////////////////////////////////

// - anonymous/unnamed function that can be passed around as a variable or as a parameter to a method call
// - delegate
// no return keyword

// example:
Func<int, int> multiplyByFive = num => num * 5;
Console.WriteLine(multiplyByFive(7)); // prints 35

// - => lambda operator
// - parameter does not specify data type -> compiler infers data type from context -> context = lambda expression is stored in a variable of type Func<int, int> -> takes an int parameter and returns an int
// - last int is return data type

// multiple parameters:
Func<int, int, int> multiplyTwoNumbers = (num1, num2) => num1 * num2;
Console.WriteLine(multiplyTwoNumbers(5, 7)); // prints 35

// - if lambda expression has more than 1 line, return keyword and brackets are needes
Func<int, int> multiplyBySeven = num =>
{
    int product = num * 7;
    return product;
};
Console.WriteLine(multiplyBySeven(5)); // prints 35

// Exercise: Write a lambda expression that returns the provided value plus one
Func<int, int> GetNextNumber = num => ++num;
Console.WriteLine(GetNextNumber(34)); // prints 35

///////////////////////////////////////////// IENUMERABLE<T> ///////////////////////////////////////////////////////////////

// - all LINQ methods are extensions to the IEnumerable<T> interface -> you can call any LINQ method on any object that implements IEnumberable<T>
// - guarantees that a class is iterable (sequence of elements) -> lists, arrays, sets
// - <T> = interface is generic -> can be used with any data type, T is placeholder for that data type

///////////////////////////////////////////// ToList(), ToArray() //////////////////////////////////////////////////////////

// - any LINQ method that returns a sequence returns it as an IEnumerable<T> -> difficult to work with -> convert it to a list or an array to make it more intuitive to use

///////////////////////////////////////////// METHOD CATEGORIES ///////////////////////////////////////////////////////////

// - return a single element from the sequence -> First(), Last()
// - return multiple elements from the sequence -> Take(), Skip(), Where()
// - return entire sequence with changed order -> Reverse(), OrderBy()
// - return single calculated value -> Any(), Sum(), Max()
// - return different sequence -> Select(), Cast()

///////////////////////////////////////////// QUERY SYNTAX ////////////////////////////////////////////////////////////////

// Example:
List<string> animalNames = new List<string>
    {"fawn"
    , "gibbon"
    , "heron"
    , "ibex"
    , "jackalope"};

IEnumerable<string> longAnimalNames =
    from name in animalNames
    where name.Length >= 5
    orderby name.Length
    select name;

longAnimalNames.ToList().ForEach(longAnimalName => Console.WriteLine(longAnimalName)); // Prinst heron, gibbon, jackalope

// - need to include using System.Ling;
// - similar to SQL syntax

// Exercise: Return only the strings that have  the pattern in them and order the list alphabetically
IEnumerable<string> FilterAndSort(IEnumerable<string> inValues, string pattern)
{
    return from value in inValues
           where value.Contains(pattern)
           orderby value
           select value;
}

FilterAndSort(animalNames, "n").ToList().ForEach(name => Console.WriteLine(name)); // Prints fawn, gibbon, heron

///////////////////////////////////////////// METHOD SYNTAX ////////////////////////////////////////////////////////////////