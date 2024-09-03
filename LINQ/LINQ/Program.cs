class Program
{
    static async Task Main(string[] agns)
    {
        var list = new List<string>();
        string[] people = {"Tom","Bob", "kyle","Mike","Tim"};
        list = await SortedArray(people);
        foreach(string names in list)
        {
          Console.WriteLine($"Names - {names}");
        }
        
    }

    static async Task<List<string>> SortedArray(string[] people)
    {   
        var list = new List<string>();
        var selected = from p in people 
        where p.ToUpper().StartsWith("T") 
        orderby p select p;
        
        foreach(string names in selected)
        {
            list.Add(names);
        }
        await Task.Delay(500);
        return list;
    }
}
