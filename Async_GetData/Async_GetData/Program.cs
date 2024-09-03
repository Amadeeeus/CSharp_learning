class Program
{
    static readonly object _lock = new();
    static List<int> PrepairedList =new List<int>();
    static async Task Main()
    {
        await GetDataAsync();
        var list1 = await ProcessDataAsync1(PrepairedList);
        var list2 = await ProcessDataAsync2(PrepairedList);
        await Task.WhenAll(SaveDataAsync(list1),SaveDataAsync(list2));
    }

    static async Task GetDataAsync()
    {
        
        for (int i = 0;i<=100;i++)
        {
            PrepairedList.Add(i);
        }
        await Task.Delay(200);
    }

    static async Task<List<int>> ProcessDataAsync1(List<int> list)
    {   
        await Task.Delay(200);
        return list.Select(x=>x*2).ToList();
    }

    static async Task<List<int>> ProcessDataAsync2(List<int>list)
    {
       await Task.Delay(200);
       return list.Select(x=>x*3).ToList();
    }

    static async Task SaveDataAsync(List<int> list)
    {
        lock(_lock)
        {
        Console.Write("{");
        foreach(int i in list)
        {
            
            Console.Write($"{i},");
        }
        Console.Write("}\n");
        }
        await Task.Delay(1000);
    }
}
