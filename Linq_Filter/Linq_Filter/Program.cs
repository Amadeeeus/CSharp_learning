using System.Reflection.PortableExecutable;

string[] people = {"Tom","Mike","Sam","Alice","Timmy","Andrew","Jim"};
var selectedpeople = people.Where(p=>p.Length == 3);
foreach(var person in selectedpeople)
{
    Console.WriteLine($"{person}");
} 
var linqSelectedpeople = from i in people where i.Length==3 select i;
foreach(var person in linqSelectedpeople)
{
    Console.WriteLine($"{person}");
} 

int[] numbers = {1,2,3,4,5,6,7,8,9,10};
var selectnum = from a in numbers where a%2==0 select a;
foreach(var i in selectnum)
{
    Console.WriteLine(i);
}
var personpeople = new List<Person>
{
    new Person("Tom",29,new List<string>{"english","german"}),
    new Person("Bob",24,new List<string>{"english","french"}),
    new Person("Sam",29,new List<string>{"english","spanish"}),
    new Person("Alice",25, new List<string>{"spanish","german"})

};

var selectedpeople1 = from p in personpeople where p.Age <=25 select p;
var langpeople = from i in personpeople 
    from l in i.Languages
    where i.Age == 29
    where l == "german" select i;
 
foreach(var peoples in selectedpeople1)
{
    foreach(var lang in peoples.Languages)
    {
    Console.WriteLine($"Name - {peoples.Name}, Age - {peoples.Age}, Lang -{lang}");
    }
}

foreach(var peop in langpeople)
{
    Console.WriteLine($"{peop.Name} - {peop.Age}");
}

record class Person(string Name, int Age, List<string>Languages);
