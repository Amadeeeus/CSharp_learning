namespace LiNQ_practice;
class Program
{
    static async Task Main()
    {
    var people = new List<Person>()
    {
        new Person("Tom",23),
        new Person("Bob",27),
        new Person("Sam",29),
        new Person("Alice",24)
    };

    var ages = people.Select(u=>u.age);
    var names = people.Select(u=>u.name);
    ages = await Datas(ages);
    names = await Names(names);
    foreach(string n in names) 
    {
      Console.WriteLine($"name-{n}");
    }
    foreach(int a in ages)
    {
      Console.WriteLine($"age - {a}");
    }

    static async Task<List<string>>Names(IEnumerable<string> person)
    {
        var names = new List<string>();
        foreach(string n in person)
        {
            names.Add(n);
            await Task.Delay(500);
        }
        return names;
    }

    static async Task<List<int>>Datas(IEnumerable<int> person)
    {
        var ages = new List<int>();
        foreach(int a in person)
        {
            ages.Add(a);
            await Task.Delay(100);
        }
        return ages;
    }
}
}
