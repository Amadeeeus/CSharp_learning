namespace Async_Delegate;
delegate Task<(List<int>,List<int>)> Sort();
delegate Task<(int,int)>Min(List<int>a, List<int>b);

delegate Task<(int,int)>Max(List<int>a, List<int>b);

delegate Task<(int,int)>Agr(List<int>a, List<int>b);
delegate Task<int>Sum(List<int>a, List<int>b);
delegate Task Show(List<int>a, List<int>b);
class Program
{
    static async Task Main()
    {
     Sort sort = sortNum;
     Min min = MinElem;
     Max max = MaxElem;
     Agr agregate = AgregElem;
     Sum sumofagregate = AllSumElem;
     Show show = ShowElem;
     Numbers numbers = new();
     var (List1,List2)=await sort();
     var (Min1,Min2) = await min(List1,List2);
     var (Max1,Max2) = await max(List1,List2);
     var (Agregate1, Aggregate2) = await agregate(List1,List2);
     var SumAgregates = await sumofagregate(List1,List2);
     Console.WriteLine("Изначальные коллекции");
     await show(numbers.Col1,numbers.Col2);
     Console.WriteLine("Отсортированные коллекции");
     await show(List1,List2);
     Console.WriteLine($"Минимальное значение элемента: в первой - {Min1}: во второй - {Min2}");
     Console.WriteLine($"Максимальное значение элемента: в первой - {Max1}: во второй - {Max2}");
     Console.WriteLine($"Сумма: в первой - {Agregate1}: во второй - {Aggregate2}");
     Console.WriteLine($"Сумма элементов в обеих коллекциях - {SumAgregates}");
    }

    static async Task<(List<int>num1,List<int>num2)> sortNum()
    {
       var sortedList1 = new List<int>();
       var sortedList2 = new List<int>();
       Numbers numbers = new();
       var numbers1 = numbers.Col1;
       var numbers2 = numbers.Col2;
       var List1 = from i in numbers1 orderby i select i;
       var List2 = from k in numbers2 orderby k ascending select k;
       foreach(var i in List1)
       {
        sortedList1.Add(i);
       }
       foreach(var i in List2)
       {
        sortedList2.Add(i);
       }
       await Task.Delay(200);
       return (sortedList1,sortedList2);
    }

     static async Task<(int,int)> MinElem(List<int> sortedlist1,List<int>sortedlist2)
    {
      var min1 =sortedlist1.Min();
      var min2 = sortedlist2.Min();
      await Task.Delay(200);
      return (min1,min2);
    }
    static async Task<(int,int)> MaxElem(List<int> sortedlist1,List<int>sortedlist2)
    {
      var max1 =sortedlist1.Max();
      var max2 = sortedlist2.Max();
      await Task.Delay(200);
      return (max1,max2);
    }

    static async Task<(int,int)> AgregElem(List<int> sortedlist1,List<int>sortedlist2)
    {
      var agr1 =sortedlist1.Aggregate((x,y)=>x+y);
      var agr2 = sortedlist2.Aggregate((x,y)=>x+y);
      await Task.Delay(200);
      return (agr1,agr2);
    }
     
    static async Task<int> AllSumElem(List<int> sortedlist1,List<int>sortedlist2)
    {
        var agr1 = sortedlist1.Aggregate((x,y)=>x+y);
        var agr2 = sortedlist2.Aggregate((x,y)=>x+y);
        int result = agr1 +agr2;
        await Task.Delay(200);
        return result;
    }

    static async Task ShowElem(List<int>a,List<int>b)
    {
        Console.Write("Result - [");
        foreach(int i in a)
        {
            Console.Write($" {i} ");
        }
        Console.Write("]\n");
        Console.Write("Result - [");
        foreach(int i in b)
        {
            Console.Write($" {i} ");
        }
        Console.Write("]\n");
        await Task.Delay(200);
    }
}

