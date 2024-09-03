
class Program
{
    delegate void Printed();
    delegate void Check();
    delegate void Print(string message);
    static void Main()
    {
        Func<int, int, int> add = (x, y) => x + y;
        var add1 = new { name = "12", age = 12 };
        var add2 = new { name = 12, age = 11 };
        Action<int> show = (x) => Console.WriteLine(x);
        Predicate<int> check = (x) => x != 6;
        Printed print = delegate
        {
            Console.WriteLine("Printed");
        };
        print();
        show(3);
        Action<int, int> check1 = (x, y) =>
        {
            Console.WriteLine(x + y);
            Console.WriteLine(x - y);
        };
        check1(3, 1);
        Action<int, int> check2 = (x, y) =>
        {
            Console.WriteLine(x + x - y);
        };
        check2(3, 1);
        Check check3 = delegate
        {
            var s = Convert.ToInt32(Console.ReadLine());
            int i = 6;
            Console.WriteLine(i + s);
        };
        check3();
        Func<int, int, int> Return = (x, y) => { return x + y; };
        Console.WriteLine(Return(1, 3));
        var employers = new List<dynamic>{
            new { Name = "Alice", Age = 30, Salary = 60000 },
            new { Name = "Bob", Age = 25, Salary = 50000 },
            new { Name = "Charlie", Age = 35, Salary = 70000 },
            new { Name = "Diana", Age = 28, Salary = 55000 }
        };
        var sorted1 = employers
        .Where(x=>x.Age>20 && x.Salary>50000)
        .OrderByDescending(x=>x.Age)
        .GroupBy(x=>x.Age)
        .Select(e=>new{Names = e.Select(x=>x.Name), Age = e.Key,Salaries=e.Select(s=>s)});
        foreach (var group in sorted1)
        {
            Console.WriteLine($"Age: {group.Age}");
            foreach (var name in group.Names)
            {
                Console.WriteLine($"  Name: {name}");
            }
            foreach (var salary in group.Salaries)
            {
                Console.WriteLine($"  Salary: {salary}");
            }
    }
    Action<int,int> calc = (x,y)=>{
        Console.WriteLine(x+y);
    }; 
    calc(4,5);
    var sorted2 = employers.Where(x=>x.Salary>50000).Select(x=>x).Take(2).ToList();
    var avg = employers.Average(x=>x.Salary);
    Console.WriteLine(avg);
    foreach(var b in sorted2)
    {
        Console.WriteLine("{0} - {1}",b.Name,b.Age);
    }
    Print print1 = delegate(string message) 
    {
        Console.WriteLine($"hello -{message}");
    };
    print1("123");
    Print print2 = delegate(string message)
    {
        Console.WriteLine($"Hi, {message}");
    };
    print2("hui");
    }
}