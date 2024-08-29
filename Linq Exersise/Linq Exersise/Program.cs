class Program
{
    
static void Main()
{
var ProductList = new List<Product>{
    new Product { Name = "Laptop", Price = 1200m, Category = "Electronics", Stock = 5 },
    new Product { Name = "Smartphone", Price = 800m, Category = "Electronics", Stock = 10 },
    new Product { Name = "Tablet", Price = 300m, Category = "Electronics", Stock = 0 },
    new Product { Name = "Headphones", Price = 150m, Category = "Electronics", Stock = 15 },
    new Product { Name = "Monitor", Price = 250m, Category = "Electronics", Stock = 7 },
    new Product { Name = "Mouse", Price = 50m, Category = "Electronics", Stock = 30 },
    new Product { Name = "Keyboard", Price = 100m, Category = "Electronics", Stock = 20 },
    new Product { Name = "Speaker", Price = 200m, Category = "Electronics", Stock = 0 },
    new Product { Name = "TV", Price = 600m, Category = "Electronics", Stock = 2 },
    new Product { Name = "Smartwatch", Price = 250m, Category = "Electronics", Stock = 8 },
    new Product { Name = "Refrigerator", Price = 1300m, Category = "Appliances", Stock = 3 },
    new Product { Name = "Washing Machine", Price = 900m, Category = "Appliances", Stock = 5 },
    new Product { Name = "Oven", Price = 700m, Category = "Appliances", Stock = 4 },
};
var elec = ProductList.Where(x =>x.Category == "Electronics" && x.Price > 100 && x.Stock>0).OrderByDescending(x=>x.Price).Take(5).Select(x=>x.Name).ToList();
foreach(var i in elec)
{
    Console.WriteLine($"name - {i}");
}
}
}
public class Product
{
    public string Name{get;set;}
    public decimal Price{get;set;}
    public string Category{get;set;}
    public int Stock{get;set;}
}
