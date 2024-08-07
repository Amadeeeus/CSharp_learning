using System.Reflection;
using Reflection;

Type MyType = typeof(Person);
Console.WriteLine(MyType);

Person CheckType = new("tom");
Type MyType1 = CheckType.GetType();
Console.WriteLine(MyType1);

Console.WriteLine($"Name - {MyType.Name}");
Console.WriteLine($"Full Name - {MyType.FullName}");
Console.WriteLine($"Namespace - {MyType.Namespace}");
Console.WriteLine($"Is struct - {MyType.IsValueType}");
Console.WriteLine($"Is class- {MyType.IsClass}\n");
foreach(MemberInfo i in MyType.GetMembers())
{
  Console.WriteLine($"{i.DeclaringType}{i.MemberType} {i.Name}");
}

