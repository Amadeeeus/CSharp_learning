await MultipleTasks();
int x = 0;
for(int i = 1; i<=100;i++)
{
  x++;
  Console.WriteLine($"x - {x}");
  Thread.Sleep(100);
}
async Task AsyncListSort()
{
  List<int> Sortlist = new List<int>();
  Random random = new Random();
  for(int i= 1; i<50; i++)
  {
    Sortlist.Add(random.Next(2,20));
  }
  Sortlist.Sort();
  Console.Write("[");
  foreach(int res in Sortlist)
  {
    Console.WriteLine($"{res},");
  }
  Console.Write("]");
  await Task.Delay(50);
}

async Task AsyncListGetHighierValue()
{
var Highier = new List<int>();
Random random = new();
for(int i =0;i<=50; i++)
{
    Highier.Add(random.Next(1,25));
}
Console.WriteLine($"result - {Highier.BinarySearch(25)}");
await Task.Delay(100);
/*int left = 0;
int right = 49;
while(left<=right)
{
    int mid = left +(right - left)/2;
    int comparison = Highier[mid].CompareTo(b);
    if(comparison == 0) Console.WriteLine($"Target - {mid}");
    if(comparison <0)left = mid+1;
    else right = mid-1;
}*/
}

async Task GetFactorial()
{
  long factorial = 1;
  Random random = new();
  int num = random.Next(2,6);
  for(int i =2; i<=num;i++)
  {
    Console.WriteLine($"{num}");
    factorial = factorial* num;
  }
  Console.WriteLine($"factorial - {factorial}");
  await Task.Delay(200);
}

async Task MultipleTasks()
{
  await Task.WhenAll(AsyncListSort(),AsyncListGetHighierValue(),GetFactorial());
}
