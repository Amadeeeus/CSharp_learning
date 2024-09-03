using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
      Console.WriteLine("Call methods");
      await Task.WhenAll(DateFormattes(),OneLiterFormatting());
    }
    
    static async Task OneLiterFormatting()
    {
        DateTime date = DateTime.Now;
        Console.WriteLine($"D:{date.ToString("D")}");
        Console.WriteLine($"d:{date.ToString("d")}");
        Console.WriteLine($"F:{date.ToString("F")}");
        Console.WriteLine($"f:{date:f}");
        Console.WriteLine($"G:{date:G}");
        Console.WriteLine($"g:{date:g}");
        Console.WriteLine($"M:{date:M}");
        Console.WriteLine($"O:{date:O}");
        Console.WriteLine($"o:{date:o}");
        Console.WriteLine($"R:{date:R}");
        Console.WriteLine($"s:{date:s}");
        Console.WriteLine($"T:{date:T}");
        Console.WriteLine($"t:{date:t}");
        Console.WriteLine($"U:{date:U}");
        Console.WriteLine($"u:{date:u}");
        Console.WriteLine($"Y:{date:Y}");
        await Task.Delay(300);
    }

    static async Task DateFormattes()
    {
        DateTime date = DateTime.Now;
        Console.WriteLine(date.ToString("hh:mm:ss"));
        Console.WriteLine(date.ToString("dd:MM:yyyy"));
        await Task.Delay(200);
    }



}
