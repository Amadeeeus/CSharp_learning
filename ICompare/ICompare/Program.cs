namespace ICompare;
class Program
{
    static async Task Main()
    {
        await Task.WhenAll(ComparingOne());
    }

    static async Task ComparingOne()
    {
        var person = new Person("Pavel", 20);
        var person1 = new Person("Sergei", 22);
        var person2 = new Person("mike", 25);
        var person3 = new Person("Tom", 21);
        var persons = new List<Person>{person,person1,person2,person3};
        persons.Sort(new PersonNameComparer());
        foreach(var pers in persons)
        {
            Console.Write($"{pers}");
        }
        int? res = person.CompareTo(person1);
        if(res==-1)
        {
            Console.WriteLine($"{person.Age} < {person1.Age}");
        }
        else if(res == null)
        {
            Console.WriteLine($"{person.Age} = {person1.Age}");
        }
        else
        {
            Console.WriteLine($"{person.Age}>{person1.Age}");
        }
        Console.WriteLine(res);
        await Task.Delay(200);

    }
}




class Person:IComparable<Person>
    {
        public string? Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person? other)
        {
            if(other == null)return 1;
            return this.Age.CompareTo(other.Age);
        }

    }

    class PersonNameComparer:IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if(x.Name == null || y.Name == null)throw new Exception("Cannot be null");
            return x.Name.CompareTo(y.Name);
        }
    }

    class personAgeComparer:IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if(x.Age ==null || y.Age ==null)throw new Exception("Cannot be null");
            return x.Age.CompareTo(y.Age);
        }
    }