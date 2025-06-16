using ReflectionTutorial;
using System.Reflection;

var fields = typeof(Car).GetFields(BindingFlags.Static | BindingFlags.NonPublic);

foreach (var field in fields)
{
    Console.WriteLine(field.Name);
}
var addFueMethod = typeof(Car).GetMethod("AddFuel", BindingFlags.Public | BindingFlags.Instance);
Console.WriteLine(addFueMethod.MemberType);
Console.WriteLine(addFueMethod.ReturnParameter);

foreach (var parameter in addFueMethod.GetParameters())
{
    Console.WriteLine(parameter.Name);
    Console.WriteLine(parameter.ParameterType);
}

Console.WriteLine();


//To do on your own 3

var constructors = typeof(Car).GetConstructors();

foreach (var constructor in constructors)
{
    Console.WriteLine($"Constructor {constructor.Name}");
    foreach (var parameter in constructor.GetParameters())
    {
        Console.WriteLine(parameter.Name);
    }
}