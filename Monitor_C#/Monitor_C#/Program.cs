class Program
{
   static int x = 0;
    static object locker = new();
    static public void Main()
    {
        for(int i = 1;i<9;i++){
        Thread myThread = new(print);
        myThread.Name = $"Поток {i}";
        myThread.Start();
        }
    }

    static public void print()
    {
       bool mainlock = false;
       try
       {
         Monitor.Enter(locker,ref mainlock);
         x=1;
         for(int i =1;i<8;i++)
         {
            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
            x++;
            Thread.Sleep(200);
         }
       }
       finally
       {
        if(mainlock)Monitor.Exit(locker);
       }

    }
}
