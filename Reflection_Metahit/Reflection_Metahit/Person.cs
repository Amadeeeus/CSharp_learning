namespace Reflection_Metahit;

public class Person
{
private readonly IPerson _person;
public Person(IPerson person)
{
    _person = person;
}

public void Eat()
{
 _person.Eat();
}

public void Move()
{
    _person.Move();
}

public void Sleep()
{
    _person.Sleep();
}
}
