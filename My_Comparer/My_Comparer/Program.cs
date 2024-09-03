using My_Comparer;

class Program
{
    static void Main()
    {
        List<Student> students= new List<Student>
        {
            new Student("Name1",12),
            new Student("Name2",13),
            new Student("Name3",14),
            new Student("Name5",15)
        };
        students.Sort(new StudentNameComparer());
        foreach(var student in students)
        {
            Console.WriteLine(student);
        }
        students.Sort(new StudentAgeComparer());
        foreach(var student in students)
        {
            Console.WriteLine(student);
        }
    }
}