namespace Reflections_GPT_Test;
using System;
using System.Reflection;
class Program
{
    static void Main()
    {
      Type personType = typeof(Person);
      Console.WriteLine("Fields");
      FieldInfo[] fields = personType.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance);
      foreach(var field in fields)
      {
        Console.WriteLine($"{field.Name}(FieldType:{field.FieldType})");
      }

      MethodInfo[] methods = personType.GetMethods(BindingFlags.Public|BindingFlags.NonPublic| BindingFlags.Instance);
      foreach(var method in methods)
      {
        Console.WriteLine($"{method.Name}(ReturnType:{method.ReturnType})");
      }

      Person person = (Person)Activator.CreateInstance(personType, "Tom", 32);

      MethodInfo IntroduceMethod = personType.GetMethod("Introduce");
      IntroduceMethod.Invoke(person, null);
      MethodInfo secretMethod = personType.GetMethod("SecretMethod", BindingFlags.NonPublic);
      secretMethod.Invoke(person, null);
    }
}
//Understandable Bullshit