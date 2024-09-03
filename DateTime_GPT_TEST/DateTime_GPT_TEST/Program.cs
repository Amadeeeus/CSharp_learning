using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args) // Main method is async
    {
        Console.WriteLine("Current Local Time: " + DateTime.Now);
        Console.WriteLine("Current UTC Time: " + DateTime.UtcNow);
        Console.WriteLine("Today's Date: " + DateTime.Today);

        await GetTime(); // Await the async GetTime method
    }

    static async Task GetTime()
    {
        await dateTime(); // Call the dateTime method directly, no need for Task.Run
    }

    static async Task dateTime() // Make sure this method is async
    {
        DateTime date = DateTime.Now; // Get the current date and time
        Console.WriteLine("Starting Date: " + date);

        double hours = 1.0; // Initialize hours variable
        
        for (int i = 1; i < 10; i++)
        {
            date = date.AddHours(5); // Add 5 hours to the current date
            Console.WriteLine($"Hours: {hours}"); // Print current hour increment
            hours++; // Increment hours
            Console.WriteLine("Updated Date: " + date); // Print updated date
            
            await Task.Delay(200); // Await a non-blocking delay of 200 milliseconds
        }

        // Await a Task.Delay to keep the method asynchronous
        await Task.Delay(1000); // Await a delay of 1 second
    }
}
