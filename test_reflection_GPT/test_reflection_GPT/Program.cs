int[] numbers = {1,2,3};
Type type = numbers.GetType();
Console.WriteLine($"Type: {type.FullName}\n{type.GetElementType()}");
foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    Console.WriteLine($"Assembly: {assembly.FullName}");
    foreach(var type1 in assembly.GetTypes())
    {
       Console.WriteLine($" Type: {type.FullName}");
    }
} 
