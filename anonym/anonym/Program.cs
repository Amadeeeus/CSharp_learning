class Program
{
    delegate Task<int> Sum(int a, int b);
    static async Task Main()
    {
      int num1=9, num2 = 7;
      Sum sum = Calculate;
      int result = await sum(num1,num2);
      Console.WriteLine(result); 
    }

    static async Task<int> Calculate(int a, int b)
    {
       int result = a+b;
       await Task.Delay(200);
      return result;
    }

    
}
