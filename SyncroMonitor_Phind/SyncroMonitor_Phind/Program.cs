
class Program
{
    private static readonly object _lock = new object();
    private static int _sharedResource = 0;
    public static void Main()
    {
        Thread thread1 = new Thread(IncrementResource);
        Thread thread2 = new Thread(IncrementResource);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Значения общего ресурса - {_sharedResource}");

    }

    private static void IncrementResource()
    {
        bool lockTaken = false;
        try
        {
            Monitor.TryEnter(_lock, TimeSpan.FromSeconds(5), ref lockTaken);
            if(lockTaken)
            {
                _sharedResource++;
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} увеличивает ресурс до {_sharedResource}");
            }
            else
            {
                Console.WriteLine("Блокировка не захвачена");
            }
        }
        finally
        {
           if(lockTaken)
           {
            Monitor.Exit(_lock);
           }
        }
    }
}
