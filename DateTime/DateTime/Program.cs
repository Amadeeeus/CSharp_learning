
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
  await Task.WhenAll(dateTime(),GetCoupleDays(),GetYears(),Timestamp(),OtherTimestamp());
  
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
        await Task.Delay(200);
    }
    await Task.Delay(1000);
}

static async Task GetCoupleDays()
{   double days = 1;
    DateTime date = new();
    date = DateTime.Now;
    for(int i = 0; i<7; i++){
    date = date.AddDays(days);
    days++;
    Console.WriteLine(date);
    await Task.Delay(1000);
    }
}

static async Task GetYears()
{
    DateTime date =  new();
    int years = 1;
    date = DateTime.Now;
    for(int i=0; i<10; i++)
    {
        date = date.AddYears(years);
        years++;
        Console.WriteLine(date);
        await Task.Delay(200);
    }
}


static async Task Timestamp()
{ double date = ConvertToUnix(DateTime.Now);
  Console.WriteLine($"Unix timestamp - {date}");
  await Task.Delay(200); 
}

static long ConvertToUnix(DateTime date)
{

    return (long)(date - new DateTime(1970,1,1)).TotalSeconds;
}


static async Task OtherTimestamp()
{
  DateTime date  = DateTime.Now;
  long unixtime = ((DateTimeOffset)date).ToUnixTimeSeconds();
  Console.WriteLine($"Unix timestamp = {unixtime}");
  await Task.Delay(200);
}
}