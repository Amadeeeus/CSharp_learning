class Parameters
{
   public int range_min{get;set;}
   public int range_max{get;set;}
}
class Program
{
    static readonly object _lock = new object();
    static int sum = 0;
    static List<int> NumCollection = new List<int>();
    static void Main()
    {
        int a = 1;
        for(int i = 0; i<=50;i++)
        {
            NumCollection.Add(a);
            a+=5;
        }
        foreach(var nums in NumCollection)
        {
            Console.WriteLine(nums);
        }
        var parameters1 = new Parameters{range_min = 0,range_max = 10};
        var parameters2 = new Parameters{range_min = 10,range_max = 20};
        var parameters3 = new Parameters{range_min = 20,range_max = 30};
        var parameters4 = new Parameters{range_min = 30,range_max = 40};
        var parameters5 = new Parameters{range_min = 40,range_max = 50};
        ThreadPool.QueueUserWorkItem(getSum,parameters1);
        ThreadPool.QueueUserWorkItem(getSum,parameters2);
        ThreadPool.QueueUserWorkItem(getSum,parameters3);
        ThreadPool.QueueUserWorkItem(getSum,parameters4);
        ThreadPool.QueueUserWorkItem(getSum,parameters5);
        Thread.Sleep(5000);
        Console.WriteLine($"all sum = {sum}");
    }

    static void getSum(object? state)
    {
        Mutex mutex = new();
        mutex.WaitOne();
        dynamic? parameters = state;
        for(int i=parameters.range_min; i<=parameters.range_max;i++)
        {
            sum+= NumCollection[i];
            Console.WriteLine($"sum = {sum}");
        }
        int result = sum;
        mutex.ReleaseMutex();
    }

    static async Task getDelayAsync()
    {
        await Task.Delay(20000);
    }
}
