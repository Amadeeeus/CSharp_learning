using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Reflection_Metahit;
public delegate void Moves();
class Program
{ 

     static void Main()
    {
      Person Teacher =new Person(new Teacher());
      Person Ingineer =new Person(new Ingineer());
      Moves teacherMove = Teacher.Move;
      Moves IngineerMove = Ingineer.Move;
      Moves teacherSleep = Teacher.Sleep;
      Moves ingineerSleep = Ingineer.Sleep;
      Moves ingineerEat = Ingineer.Eat;
      Moves teacherEat = Teacher.Eat;
      teacherMove();
      teacherEat();
      teacherSleep();
      IngineerMove();
      ingineerEat();
      ingineerSleep();
      Type typePerson = typeof(Person);
      Type typeTeacher = typeof(Teacher);
      Type typeIngin = typeof(Ingineer);
      Type[] interfaces = typeIngin.GetInterfaces();
    
      ConstructorInfo[] constructorPerson = typePerson.GetConstructors(BindingFlags.Public);
      MethodInfo[] methodsPerson = typePerson.GetMethods(BindingFlags.NonPublic| BindingFlags.Public| BindingFlags.Instance);
      MethodInfo[] methodsteacher = typeTeacher.GetMethods(BindingFlags.Public| BindingFlags.NonPublic| BindingFlags.Instance);
      foreach(var constructor in constructorPerson) 
      {
        Console.WriteLine($"constructor - {constructor.Name}, Parameters: {constructor.GetParameters().Length}");
      }
      foreach(var teacher in methodsteacher)
      {
        Console.WriteLine($"methods - {teacher.Name}Return Type: {teacher.ReturnType}, Is Public: {teacher.IsPublic}, Is Private: {teacher.IsPrivate}, Is Protected: {teacher.IsFamily}");
      }
      foreach(var inter in interfaces)
      {
        Console.WriteLine($"interfaces - {inter}");
      }

      
    }
}

