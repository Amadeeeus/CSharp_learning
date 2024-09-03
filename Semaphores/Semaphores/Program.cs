for(int i = 1; i < 6;i++)
{
    Reader reader = new Reader(i);
}

class Reader
{
    static Semaphore sem = new Semaphore(3,3);
    Thread myThread;
    int count = 3;
    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"читатель {i}";
        myThread.Start();
    }

    public void Read()
    {
        while(count >0)
        {
            sem.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} входит в зал");
            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
            Console.WriteLine($"{Thread.CurrentThread.Name}освобождает зал");
            sem.Release();
            count--;
            Thread.Sleep(1000);
            
        }
    }
}
