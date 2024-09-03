class Program
{
    public static void Main()
    {
    int x = 0;
    AutoResetEvent waitHandler = new AutoResetEvent(true);
     for(int i = 1; i<6;i++)
     {
        Thread myThread = new (Print);
        myThread.Name = $"поток{i}";
        myThread.Start();
     }

     void Print()
     {
        waitHandler.WaitOne();
        x=1;
        for(int i=1;i<6;i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
            x++;
            Thread.Sleep(100);
        }
        waitHandler.Set();
     }
    }
    
}
