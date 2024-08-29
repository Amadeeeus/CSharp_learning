class Program
{
    static int num = 0;
    static readonly object _lock = new();
    static Mutex mutex = new();
    static void Main()
    {
        Thread thread1 = new(IncrOne);
        Thread thread2 = new(IncrTwo);
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        Console.WriteLine($" num - {num}");
    }

    static void IncrOne()
    {
        //lock (_lock)
        //{
        //mutex.WaitOne();
            for (int i = 0; i < 100; i++)
            {
                Interlocked.Increment(ref num);
                Console.WriteLine($"Increment One{num}");
            }
            //mutex.ReleaseMutex();
        //}
    }

    static void IncrTwo()
    {
        //lock(_lock)
        //{
        //mutex.WaitOne();
        for (int i = 0; i < 100; i++)
        {
            Interlocked.Increment(ref num);
            Console.WriteLine($"Increment Two{num}");
        }
        //mutex.ReleaseMutex();
    //}
    }
}
