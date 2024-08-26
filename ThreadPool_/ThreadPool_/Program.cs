class Program
{
    static int a =1;
    static readonly object _lock = new object();
    static void Main()
    {
        ThreadPool.QueueUserWorkItem(Increment);
        ThreadPool.QueueUserWorkItem(PlusTwo);
        ThreadPool.QueueUserWorkItem(PlusFive);

        Thread.Sleep(15000);
    }

    static void Increment(object state)
    {
        lock(_lock)
        {
        for(int i = 1; i < 50; i++)
        {
            a++;
            Console.WriteLine($"Result - {a}");
            Thread.Sleep(100);
        }
        }
    }

    static void PlusTwo(object state)
    {
        lock(_lock)
        {
        for(int i = 0;i<50; i++)
        {
            a +=2;
            Console.WriteLine($"Result !! - {a}");
            Thread.Sleep(100);
        }
        }
    }

    static void PlusFive(object state)
    {
        lock(_lock)
        {
        for(int i = 0;i<50; i++)
        {
            a+=5;
            Console.WriteLine($"Result !!! - {a}");
            Thread.Sleep(100);
        }
    }
    }
}
