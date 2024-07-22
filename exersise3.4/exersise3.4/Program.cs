double deposite;
Console.WriteLine("Введите сумму вклада");
deposite = Convert.ToDouble(Console.ReadLine());
if(deposite < 100)
{
    deposite += deposite * 0.05;
}
else if(deposite > 100 && deposite < 200)
{
    deposite += deposite * 0.07;
}
else
{
    deposite += deposite * 0.10;
}
Console.WriteLine($"депозит - {deposite}");
