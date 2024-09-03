class Program
{
    static async Task Main(string[] agns)
    {   
        int[] numbers = {1,2,3,4,5,6,7,3,6,1,7,7,1};
        var list = await GetNum(numbers);
        foreach(int num in list.chetnum)
        {
            Console.WriteLine($"Четные - {num}");
        }
        foreach(int num in list.sortnum)
        {
            Console.WriteLine($"Отсортировано - {num}");
        }
            Console.WriteLine($"Num - {list.sum}");
      
    }

    static async Task<(int[] sortnum,int[] chetnum, int sum)> GetNum(int[] Numbers)
    {
        var sortnum = Numbers.OrderBy(n=>n).ToArray();
        var chetnum = Numbers.Where(n=>n%2 ==0).ToArray();;
        var sum = Numbers.Sum();
        await Task.Delay(200);
        return (sortnum,chetnum,sum);
    }
}
