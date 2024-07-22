// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Введите 1 число");
int Number1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите 2 число");
int Number2 = Convert.ToInt32(Console.ReadLine());
if (Number1 < Number2)
{
    Console.WriteLine($"Первое число меньше второго - {Number1} < {Number2}");
}
else
{
    Console.WriteLine($"Первое число больше второго - {Number1} > {Number2}");
}
Console.WriteLine(Number1.GetType());
Console.WriteLine(Number2.GetType());

