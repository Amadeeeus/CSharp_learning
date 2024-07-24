decimal sum;
int months;
decimal TotalSum = 0;
Console.WriteLine("Введите сумму");
sum = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Введите количество месяцев");
months = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= months;i++)
{
    TotalSum+=sum * 0.07M; 
}
Console.WriteLine($"Сумма с учетом процентов - {TotalSum}");
