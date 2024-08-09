using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
       Thread ThreadOne = new Thread(new ThreadStart(ThreadOneStart));
       ThreadOne.Start();
       Thread ThreadTwo = new Thread(new ThreadStart(ThreadTwoStart));
       ThreadTwo.Start();
       ThreadTwo.Priority = ThreadPriority.Highest;
       ThreadOne.IsBackground = true;
       Console.WriteLine($"Запущен - {ThreadOne.IsAlive},Приоритет: {ThreadOne.Priority} ");
       ThreadPool.GetAvailableThreads(out var workerThreads, out var competitionPortThreads);
       Console.WriteLine($"{workerThreads} - {competitionPortThreads} - {Thread.CurrentThread.IsThreadPoolThread}");
       Console.WriteLine($"статус потока - {ThreadTwo.ThreadState}");
       ThreadOne.Join();
       ThreadTwo.Join();
       
       Console.WriteLine($"статус потока - {ThreadTwo.ThreadState}");
    }

    static void ThreadOneStart()
    {
        Console.WriteLine($"Поток 1 запущен");
        
    }

    static void ThreadTwoStart()
    {
        Console.WriteLine("Поток 2 запущен");
    }
}
