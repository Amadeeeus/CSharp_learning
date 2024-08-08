namespace Reflections_GPT_Test;

public class Person
{
  public string Name;
  private int Age;

  public Person(string name, int age)
  {
    Name = name;
    Age = age;
  }

  public void Introduce()
  {
    Console.WriteLine($"Hello, I am {Name} and i am {Age} years old");
  }

  private void SecretMethod()
  {
    Console.WriteLine("This is a secret method");
  }
}
