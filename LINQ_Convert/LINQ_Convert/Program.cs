List<string> stringsNumbers = new List<string>{"1","2","3","4"};
List<int>intNumbers = stringsNumbers.Select(int.Parse).ToList();
foreach(var num in intNumbers)
{
    Console.WriteLine(num);
}
