namespace Reflection_Metahit;

public class Teacher:IPerson
{
  public void Move()
  {
    Console.WriteLine("fast moving");
  }

  public void Eat()
  {
    Console.WriteLine("eat ***");
  }

  public void Sleep()
  {
    Console.WriteLine("unstable sleep");
  }
}
