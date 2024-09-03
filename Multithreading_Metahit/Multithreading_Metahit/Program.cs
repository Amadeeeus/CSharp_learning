class Program
{
    static int i =1;
    static void Main()
    {

     Thread Second = new Thread(new ThreadStart(Count));
     Second.Start();
     for(i= 1;i<100;i++)
        {
          Thread.Sleep(100);
          Console.WriteLine($"1 result: {i}");
        }
    }
    static void Count()
    {
        for(i= 1;i<100;i++)
        {
          Thread.Sleep(25);
          Console.WriteLine($"2 result: {i}");
        }
    }



}
