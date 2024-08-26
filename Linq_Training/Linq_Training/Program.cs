using Linq_Training;

class Program
{
    static void Main()
    {
        var students = new List<Student>
        {
            new Student{Name = "Jonh", Age = 20, Grades = new List<int>{88,92,76}},
            new Student{Name = "Alice", Age = 22, Grades = new List<int>{95,84,91}},
            new Student{Name  = "Bob", Age = 18, Grades  =new List<int>{60,70,65}},
            new Student{Name = "Diana", Age = 19, Grades = new List<int>{100,95,98}},
            new Student{Name = "Charlie", Age = 17, Grades = new List<int>{55,60,58}}
        }; 
    var older = students.Where(x=>x.Age>18).Select(x=>x);
    GetSortedStudents(older);   
    var average = students.OrderByDescending(student=>student.Grades.Average()).ToList();
    foreach(var student in average)
    {
        Console.WriteLine("{0} - {1}", student.Name,student.Grades.Average());
    }
    Console.WriteLine("\n");
    var top3average = students.OrderByDescending(student=>student.Grades.Average()).Take(3).ToList();
     foreach(var student in top3average)
    {
        Console.WriteLine("{0} - {1}", student.Name,student.Grades.Average());
    }
    Console.WriteLine("\n");
    var count = students.Count(student=>student.Grades.Any(x=>x>90));
    Console.WriteLine($"Количество студентов с оценкой выше 90 по любому предмету: {count}");
    }
    

    static void GetSortedStudents(IEnumerable<Student>list)
    {
        foreach(var i in list)
        {
            Console.Write("{0} {1} - ", i.Name,i.Age);
            foreach(var a in i.Grades)
            {
            Console.Write($"{a},");
        }
        Console.Write("\n");
    }
    Console.Write("\n");
}

}
