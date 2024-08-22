public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name}, Age: {Age}";
    }

public class StudentNameComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        if (x == null) return (y == null) ? 0 : -1;
        if (y == null) return 1;
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}

public class StudentAgeComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        if (x == null) return (y == null) ? 0 : -1;
        if (y == null) return 1;
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        // Создаем список студентов
        List<Student> students = new List<Student>
        {
            new Student("Alice", 22),
            new Student("Bob", 20),
            new Student("Charlie", 23),
            new Student("David", 20)
        };

        // Сортировка по имени, используя StudentNameComparer
        Console.WriteLine("Students sorted by name:");
        students.Sort(new StudentNameComparer());
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine();

        // Сортировка по возрасту, используя StudentAgeComparer
        Console.WriteLine("Students sorted by age:");
        students.Sort(new StudentAgeComparer());
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}
}

