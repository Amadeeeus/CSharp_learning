namespace Delegate_Metahit_Example;
delegate void OurSum(int sum);
class Program
{
    static void Main()
    {
    Account account = new Account(50);
    OurSum add = account.Add;
    OurSum get = account.Take;
    Console.WriteLine($"full sum - {account.sum}");
    add(100);
    Console.WriteLine($"full sum - {account.sum}");
    get(50);
    Console.WriteLine($"full sum - {account.sum}");
    
}
}
