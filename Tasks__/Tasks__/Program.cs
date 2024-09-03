class Program
{
    static int num = 0;
    static int IncrementNum = 0;
    static void Main()
    {
      for (int i = 0; i < 10; i++)
        {
            List<Task> tasks = new List<Task>{
              Task.Run(()=>Increment()),
              Task.Run(()=>LoggingNum())
            };
         Task.WhenAll(tasks.ToArray()); 
         Thread.Sleep(100);  
        }   
    }
    static void Running()
    {
          
    }
    static void Increment()
    {
        for (int i = 0; i < 10; i++)
        {
            Interlocked.Increment(ref num);
            Console.WriteLine(num);
        }
    }

    static void LoggingNum()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("task");
        }
    }
}
