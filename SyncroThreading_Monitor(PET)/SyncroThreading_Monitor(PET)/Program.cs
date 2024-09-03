class Program
{   // создаем обьект который будет принимать блокировку


    //lockObject: Объект, на который вы хотите установить блокировку.
    //ref lockTaken: Переменная, которая указывает, была ли блокировка успешно захвачена.

    static public readonly object _lock = new object();
    
    static private int num = 20;
    static private string? ThreadName = "";
    static void Main()
    {
      Thread plusone = new Thread(EqualNum);
      Thread divto2 = new Thread(EqualNum);

      plusone.Start();
      plusone.Name = "plusone";
      divto2.Start();
      divto2.Name = "divto2";
      ThreadName = Thread.CurrentThread.Name;
      Console.WriteLine(Thread.CurrentThread.Name);
      if(ThreadName == "plusone")
      plusone.Join();
      divto2.Join();

      Console.WriteLine();
    }

    static void EqualNum()
    {
        bool locktaken = false;
        try{
        Monitor.TryEnter(_lock,TimeSpan.FromSeconds(5), ref locktaken);
        ThreadName = Thread.CurrentThread.Name;
      if(ThreadName == "plusone")
      {
        while(num<30)
        {
        num++;
        Console.WriteLine($"{Thread.CurrentThread.Name}:{num}");
        }
      }
      else if(ThreadName == "divto2")
      {
        while(num>0){
        num--;
        Console.WriteLine($"{Thread.CurrentThread.Name}:{num}");
        }
      }
      else
      {
        Console.WriteLine("No block");
      }
    }
    finally
    {
         if(locktaken)
         {
            Monitor.Exit(_lock);
         }
    }
    }
}
