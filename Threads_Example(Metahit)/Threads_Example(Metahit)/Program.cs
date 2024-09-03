using System.Threading;

class Program
{
    static void Main()
    {
        Thread currentthread = Thread.CurrentThread;

        Console.WriteLine($"Имя потока:  {currentthread.Name}");
        currentthread.Name = "Thread 1";
        Console.WriteLine($"Имя потока:  {currentthread.Name}");

        Console.WriteLine($"Запущен ли поток:  {currentthread.IsAlive}");
        Console.WriteLine($"ID:  {currentthread.ManagedThreadId}");
        Console.WriteLine($"Приоритет:  {currentthread.Priority}");
        Console.WriteLine($"Статус:  {currentthread.ThreadState}");
        Console.WriteLine(Thread.GetDomain());    

        for(int i =1; i< 10; i++)
        {
            //Thread.Sleep(2);
            Console.WriteLine(i);
        }

    }
    }
    
