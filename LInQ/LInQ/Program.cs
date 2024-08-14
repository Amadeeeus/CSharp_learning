class Program
{
static void Main()
{
    var courses = new List<Course>{new Course("Java"),new Course("C#")};
    var students =new List<Student>{new Student("Tom"), new Student("Bob")};
    var enrollments = from course in courses 
    from student in students 
    select new{Student = student.Name, Course = course.Title};
    foreach(var enrollment in enrollments)
    {
        Console.WriteLine($"{enrollment.Student} - {enrollment.Course}");
    }
    var companies = new List<Company>
    {
        new Company("Microsoft", new List<Person>{new Person("Tom"),new Person("Bob")}),
        new Company("Google", new List<Person>{new Person("Sam"),new Person("Mike")}),
    };

    var employers = from c in companies
    from emp in c.Staff
    select new{ Name = emp.Name, Company = c.Name};
    
    foreach(var emp in employers)
    {
        Console.WriteLine($"{emp.Name} - {emp.Company}");
    }
}    
}

record class Student(string Name);
record class Course(string Title);

record class Company(string Name, List<Person>Staff);
record class Person(string Name);