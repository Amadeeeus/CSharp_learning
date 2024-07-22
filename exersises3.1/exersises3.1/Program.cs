int a;
int b;
Console.WriteLine("Введите 1 число");
a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите 2 число");
b = Convert.ToInt32(Console.ReadLine());
if(a < b)
{
    Console.WriteLine("Первое меньше ");
}
else if(a > b)
{
    Console.WriteLine("Первое больше");
}
else
{
    Console.WriteLine("Они равны");
}
