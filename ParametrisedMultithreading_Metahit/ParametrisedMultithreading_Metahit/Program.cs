class Program
{
    static int i =1;
    static public void Main()
    {
      Thread threadone = new Thread(new ParameterizedThreadStart(CountCopy));
      Thread threadtwo = new Thread(Count);
      Thread threadthree = new Thread(new ThreadStart(Count));
      threadone.Name = "Thread 1";
      threadtwo.Name = "Thread 2";
      threadthree.Name = "Thread 3";
        threadone.Start(100);
        threadtwo.Start();
        threadthree.Start();
        
        for(i = 1; i<=100;i++)
        {
          Console.WriteLine("Main Thread");
          Console.WriteLine($"result - {i}");
          Thread.Sleep(100);
        }
        void Count()
        {
         for(i = 1; i<=100;i++)
        {
          Console.WriteLine(Thread.CurrentThread.Name);
          Console.WriteLine($"result - {i}");
          Thread.Sleep(50);
        }
        }

        void CountCopy(object? range)
    {
        
        int count = (int)range;
        //if(Thread.CurrentThread == )
        for(i = 1; i<=100;i++)
        {
          Console.WriteLine(Thread.CurrentThread.Name);
          Console.WriteLine($"result - {i}");
          Thread.Sleep(count);
        }
        
    }
    }

    
}
