object locker = new object();
int x= 1;
for(int i = 1; i<10; i++)
{
    Thread MyThread = new(print);
    MyThread.Name = $"Поток {i}";
    MyThread.Start();
}

void print()
{
    bool acceplocker = false;
    try{
    Monitor.Enter(locker,ref acceplocker);
    for(int i = 1;i<10;i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
        x++;
        Thread.Sleep(150);
    }
    }
    finally
    {
        if(acceplocker)Monitor.Exit(locker);
    }
}