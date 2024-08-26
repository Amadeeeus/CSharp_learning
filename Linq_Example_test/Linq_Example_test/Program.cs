class Program{
    static void Main(){
List<Student> list = new List<Student>
{
    new Student("name1", 3),
    new Student("name2", 4),
    new Student("name3", 2),
    new Student("name4", 2),
    

};
List<BadStudent>ListBAd = GetBadStudent(list);
foreach(var bad in ListBAd)
{
    Console.WriteLine(bad.Name);
}
    }
static public List<BadStudent> GetBadStudent(List<Student> list)
{
    return list.Where(x => x.AvgScore<3).Select(x => new BadStudent{Name = x.Name}).ToList();
}
    
}
public class Student
{
    public string Name {get;set;}
    public int AvgScore{get;set;}
    public Student(string name, int Score)
    {
        Name = name;
        AvgScore = Score;
    }
}

public class BadStudent
{
    public string? Name {get;set;}
}

// Вернуть список студентов с баллов ниже 3
