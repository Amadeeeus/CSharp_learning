int Num1;
int Num2;
int Result;
Console.WriteLine("Введите первое число");
Num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите второе число");
Num2 = Convert.ToInt32(Console.ReadLine());
while (Num1 < 0 || Num1 > 10 || Num2 < 0 || Num2 > 10)
{
    Console.WriteLine("Числа недопустимы");
    Console.WriteLine("Введите первое число");
    Num1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите второе число"); 
    Num2 = Convert.ToInt32(Console.ReadLine());
}
Result = Num1 * Num2;
Console.WriteLine("{0} * {1} = {2}", Num1, Num2, Result);

