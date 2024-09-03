class Program
{
    static void Main()
    {
         var EmployeeList = new List<Employee>
        {
            new Employee { Name = "Alice", Department = "IT", Salary = 4000, HireDate = new DateTime(2020, 6, 1) },
            new Employee { Name = "Bob", Department = "HR", Salary = 3500, HireDate = new DateTime(2018, 7, 15) },
            new Employee { Name = "Charlie", Department = "IT", Salary = 4500, HireDate = new DateTime(2019, 1, 20) },
            new Employee { Name = "Dave", Department = "Finance", Salary = 5000, HireDate = new DateTime(2015, 3, 10) },
            new Employee { Name = "Eve", Department = "IT", Salary = 3200, HireDate = new DateTime(2021, 11, 5) },
            new Employee { Name = "Frank", Department = "HR", Salary = 3800, HireDate = new DateTime(2022, 4, 12) },
            new Employee { Name = "Grace", Department = "IT", Salary = 2900, HireDate = new DateTime(2017, 2, 8) },
            new Employee { Name = "Heidi", Department = "HR", Salary = 4100, HireDate = new DateTime(2023, 5, 25) }
        };
        var sortedlist = EmployeeList.Where(x=>x.Department == "IT" || x.Department == "HR"  && x.Salary >3000 && x.HireDate > DateTime.Now.AddYears(-5)).OrderBy(x=>x.Department).ThenByDescending(x=>x.HireDate).GroupBy(x=>x.Department).Select(g=>new {Departament = g.Key,AverageSalary = g.Average(e=>e.Salary),Employees = g});
        foreach(var group in sortedlist)
        {
            Console.WriteLine($"Department: {group.Departament} (Average Salary: {group.AverageSalary:C})");
            foreach (var emp in group.Employees)
            {
                Console.WriteLine($"  Name: {emp.Name}, Hire Date: {emp.HireDate.ToShortDateString()}, Salary: {emp.Salary:C}");
            }
        }
    }
}
public class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
}
