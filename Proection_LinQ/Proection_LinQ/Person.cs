namespace Proection_LinQ;

public record class Person
{
    public string Name{get;init;}
    public int Age{get;init;}
 public Person(string name, int age)
 {
    Name = name;
    Age = age;

 }
}
