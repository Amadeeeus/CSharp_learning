using System.Security.Cryptography.X509Certificates;

class Program
{
static void Main()
{
    var orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerName = "Alice", OrderDate = DateTime.Now.AddMonths(-1), TotalAmount = 150m, Status = "Completed" },
            new Order { OrderId = 2, CustomerName = "Bob", OrderDate = DateTime.Now.AddMonths(-2), TotalAmount = 200m, Status = "Completed" },
            new Order { OrderId = 3, CustomerName = "Alice", OrderDate = DateTime.Now.AddMonths(-4), TotalAmount = 50m, Status = "Completed" },
            new Order { OrderId = 4, CustomerName = "Charlie", OrderDate = DateTime.Now.AddMonths(-1), TotalAmount = 300m, Status = "Completed" },
            new Order { OrderId = 5, CustomerName = "Bob", OrderDate = DateTime.Now.AddMonths(-3), TotalAmount = 120m, Status = "Pending" },
            new Order { OrderId = 6, CustomerName = "Alice", OrderDate = DateTime.Now.AddMonths(-2), TotalAmount = 180m, Status = "Completed" },
            new Order { OrderId = 7, CustomerName = "Charlie", OrderDate = DateTime.Now.AddMonths(-1), TotalAmount = 90m, Status = "Completed" }
        };
        var sortedorders = orders.Where(x=>x.Status =="Completed" && x.OrderDate > DateTime.Now.AddMonths(-3)&& x.TotalAmount>100).OrderBy(x=>x.OrderDate).GroupBy(x=>x.CustomerName).Select(e=>new{Name = e.Key,TotalAmount = e.Sum(o=>o.TotalAmount),OrderCount = e.Count()}).ToList();
        foreach(var i in sortedorders)
        {
            Console.WriteLine("Name - {0} TotalAmount- {1} Order count- {2}",i.Name,i.TotalAmount, i.OrderCount);
        }
}
}
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }  // Например: "Completed", "Pending", "Cancelled"
}
