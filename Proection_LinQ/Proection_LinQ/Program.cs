namespace Proection_LinQ;
class Program
{
    static async Task Main()
    {
        var people = new List<Person>
        {
            new Person("Tom", 23),
            new Person("Bob",27),
            new Person("Sam", 29),
            new Person("Alice", 24)
        };

        var names = from p in people select p.Name;
        var ages = from a in people select a.Age;
        /*
        var names = people.Select(p => p.Name);
        var ages = people.Select(p => p.Age);
        */
        var list = await PersonAsync(names);
        var ageslist = await PersonAgeAsync(ages);
        foreach(string n in list)
        {
          Console.WriteLine($"{n}");
          await Task.Delay(200);
        }
        foreach(int a in ageslist)
        {
            Console.WriteLine($"{a}");
            await Task.Delay(500);
        }
    }

    static async Task<List<string>> PersonAsync(IEnumerable<string> names)
    {
        var list =new List<string>(); 
      foreach(var n in names)
      {
        list.Add(n);
        await Task.Delay(200);
      }
      return list;
    }

    static async Task<List<int>> PersonAgeAsync(IEnumerable<int> ages)
    {
        var list = new List<int>();
        foreach(var a in ages)
        {
            list.Add(a);
            await Task.Delay(100);
        }
        return list;
    }
}
