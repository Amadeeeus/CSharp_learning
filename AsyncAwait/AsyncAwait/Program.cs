await PrintAsync();
Console.WriteLine("Some actions in main");

void Print()
{
    Thread.Sleep(3000);
    Console.WriteLine("Processing...");
}

async Task PrintAsync()
{
    Console.WriteLine("PrintAsync started");
    await Task.Run(()=>Print());
    Console.WriteLine("End of asyync");
}
