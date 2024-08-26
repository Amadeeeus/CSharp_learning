class Program
{
    static readonly object _lock = new();
    static async Task Main()
    {
        var randlist = await GetDataAsync();
        var filtered1 = FilterDataAsync1(randlist);
        var filtered2 = FilterDataAsync2(randlist);
        await Task.WhenAll(SaveFilteredDataAsync(await filtered1),SaveFilteredDataAsync(await filtered2));
    }

    static async Task<List<int>> GetDataAsync()
    {
        Random random = new();
        var RandomList = new List<int>();
        for(int i=0;i<=100;i++)
        {
            int rand = random.Next(100);
            RandomList.Add(rand);
        }
        await Task.Delay(200);
        return RandomList;
    }

    static async Task<List<int>>FilterDataAsync1(List<int> list)
    {
        await Task.Delay(200);
        return list.Where(x=>x%2==0).Select(x=>x*2).ToList();
    }
    static async Task<List<int>>FilterDataAsync2(List<int>list)
    {
        await Task.Delay(200);
        return list.Where(x=>x%5==0).Select(x=>x*3).ToList();
    }

    static async Task SaveFilteredDataAsync(List<int>list)
    {
        lock(_lock)
        {
        Console.Write("{");
        foreach(var i in list)
        {
            Task.Delay(100).Wait();
            Console.Write($"{i},");
        }
        Console.Write("}\n\n");
        }
        await Task.Delay(1000);
    }
}