int a;
double b;
double c;
double z;
Console.WriteLine("Введите номер операции: 1 - Сложение, 2 - Вычитание, 3 -Умножение");
a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите первую цифру");
b = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите вторую цифру");
c = Convert.ToDouble(Console.ReadLine());
switch (a)
{
    case 1: 
    z = a + b;
    Console.WriteLine($"{a} + {b} = {z}");
    break; 
    case 2: 
    z = a - b;
    Console.WriteLine($"{a} - {b} = {z}");
    break; 
    case 3: z= a * b;
    Console.WriteLine($"{a} * {b} = {z}");
    break;
    default: Console.WriteLine("Неправильный номер операции");break;
}
