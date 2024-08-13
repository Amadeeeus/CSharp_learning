
class Program{
static double hours = 1.0;
static async Task Main(string[] arns)
{
Console.WriteLine(DateTime.Now);
Console.WriteLine(DateTime.UtcNow);
Console.WriteLine(DateTime.Today);
await GetTime();
}


static async Task GetTime()
{ 
  await dateTime();
  
}

static async Task dateTime()
{   
    DateTime date = new();
    date = DateTime.Now;
    Console.WriteLine(date);
    
    for(int i =1; i<10; i++)
    {
        date = date.AddHours(hours);
        Console.WriteLine(hours);
        hours++;
        Console.WriteLine(date);
        Thread.Sleep(200);
    }
    await Task.Delay(1000);
}
}
