namespace testing_reflex;
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        var calculator = new Calculator();
        Type type = calculator.GetType();

        // Динамический вызов метода Add
        MethodInfo? method = type.GetMethod("Add");
        object? result = method.Invoke(calculator, new object[] { 5, 3 });
        Console.WriteLine($"Add(5, 3) = {result}");

        // Динамический вызов метода Multiply
        method = type.GetMethod("Multiply");
        result = method.Invoke(calculator, new object[] { 4, 2 });
        Console.WriteLine($"Multiply(4, 2) = {result}");
    }
}

