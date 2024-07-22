// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text.RegularExpressions;
Console.WriteLine("Введите 1 число");
var Number1 = Console.ReadLine();
Console.WriteLine("Введите 2 число");
var Number2 = Convert.ToDouble(Console.ReadLine());
string pattern1 =@"^([0-9]+)(,[0-9]{9})";
string pattern2 = "/^([0-9]+)(.[0-9]{1})/gm";
double Number12;
double Number11;
Match m = Regex.Match(Number1, pattern1);
if (m.Success)
{
    Number11 = Convert.ToDouble(Number1);
}
Console.WriteLine($"{m.Value}");

Console.WriteLine(Number11.GetType());
/*if (Number1 < Number2)
{
    Console.WriteLine($"Первое число меньше второго - {Number1} < {Number2}");
}
else
{
    Console.WriteLine($"Первое число больше второго - {Number1} > {Number2}");
}
Console.WriteLine(Number1.GetType());
*/

