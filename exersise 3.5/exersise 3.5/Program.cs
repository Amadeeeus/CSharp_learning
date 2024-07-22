double deposit;
Console.WriteLine("Введите сумму вклада");
deposit = Convert.ToDouble(Console.ReadLine());
if(deposit <100)
{
    deposit+= deposit *0.05;
}
else if(deposit > 100 && deposit < 200)
{
    deposit+=deposit *0.07;
}
else 
{
    deposit+= deposit * 0.10;
}
deposit+=15;
Console.WriteLine($"Cумма депозита + бонус - {deposit}");