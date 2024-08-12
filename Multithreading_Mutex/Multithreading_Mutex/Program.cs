Mutex locker = new();
int x = 1;
for(int i = 1; i<=6; i++)
{
    Thread MyThread = new(Print);
    MyThread.Name = $"Поток {i}";
    MyThread.Start();
}

void Print()
{
    locker.WaitOne();
    x = 1;
    for(int i = 1; i<=10; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        Thread.Sleep(100);
        x++;
    }
    locker.ReleaseMutex();
}