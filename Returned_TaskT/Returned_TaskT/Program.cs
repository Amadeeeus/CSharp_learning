class Program
{
    static async Task Main(string[] agns)
    {
        var list = new List<string>();
        string[] people = {"Tom","Bob", "kyle","Mike","Tim"};
        list = await SortedArray(people);
        foreach(string names in list)
        {
            Console.WriteLine($"Names: {names}");
        }
        
    }

    static async Task<List<string>> SortedArray(string[] people)
    {
        var selected = new List<string>();
        foreach(string peoples in people)
        {
            if(peoples.ToUpper().StartsWith("T"))
            {
                selected.Add(peoples);
            }
        }
        selected.Sort(); 
        await Task.Delay(200);
        return selected;
    }
}