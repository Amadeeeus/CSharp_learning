decimal sum;
decimal TotalSum = 0;
int months;
int i = 1;
Console.WriteLine("Введите сумму вклада");
sum = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Введите количество месяцев");
months = Convert.ToInt32(Console.ReadLine());
while(i <= months)
{
    TotalSum += sum * 0.07m;
    i++;
}
Console.WriteLine($"Сумма вкладов с учетом месяцев - {TotalSum}");