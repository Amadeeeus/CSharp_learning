delegate void PrintNumber(int one);
class Program
{
    static void Main()
    {
        var print = new Printer();
        PrintNumber print1 =new PrintNumber(PrintEven);
        PrintNumber print2 = new PrintNumber(PrintOdd);
        print.Print(print1,2);
        print.Print(print2,3);
    }

    public static void PrintEven(int num)
    {
        if(num % 2==0)
        {
            Console.WriteLine(num);
        }
    }

    public static void PrintOdd(int num)
    {
        if(num %2!=0)
        {
            Console.WriteLine(num);
        }
    }
}
class Printer
{
    public void Print(PrintNumber print, int num)
    {
        print(num);
    }
}
