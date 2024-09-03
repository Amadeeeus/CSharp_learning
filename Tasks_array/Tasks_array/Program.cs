class Program 
{
static List<int>NumCollection = new List<int>();
static readonly object _lock= new();
static int sum = 0;
  static void Main()
 {
    int a = 1; 
    for(int i= 0;i<=50; i++)
    {
        NumCollection.Add(a);
        a+=5;
        
    }
    var tasks = new[]
    {
    Task.Run(()=>getSum(0,10)),
    Task.Run(()=>getSum(10,20)),
    Task.Run(()=>getSum(20,30)),
    Task.Run(()=>getSum(30,40)),
    Task.Run(()=>getSum(40,50))
    };
    Task.WaitAll(tasks);
    Console.WriteLine(sum);
 }   
    static void getSum(int min_range, int max_range)
    {
        lock(_lock)
        {
        for(int i=min_range; i<=max_range;i++)
        {
            
            
            sum+=NumCollection[i];
            //Console.WriteLine(sum);
            
        } 
        }
    }
}
