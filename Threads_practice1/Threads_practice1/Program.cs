class Program
{
    static int a= 0;
    static void Main()
    {
        Thread IncrementThread = new Thread(Increment);
        Thread DecrementThread = new Thread(Decrement);
        IncrementThread.Start();
        IncrementThread.Join();
        if(a==100)
        {
            Console.WriteLine($"Thread started");
        DecrementThread.Start();
        DecrementThread.Join(); 
        Console.WriteLine(a);
        }
        
    }

    static void Increment()
    {  for (int i =0; i<100;i++)
    {   
        a++;
        Console.WriteLine($"Result = {a}");
    }
    }

    static void Decrement()
    {
        for (int i = 0;i<100;i++)
        {
        a--;
        Console.WriteLine($"Result = {a}");
        }
    }
}