Task task = new Task(()=>Console.WriteLine("Hello Task"));
task.Start();
Task task1 = Task.Factory.StartNew(()=>Console.WriteLine("Hello Task"));
Task task2 = Task.Run(()=>Console.WriteLine("Hello Task"));
task.Wait();
task1.Wait();
task2.Wait();
Console.WriteLine("<--------------------------->");
Task task3 = new Task(()=>
{
Console.WriteLine("task start");
Thread.Sleep(1000);
Console.WriteLine("Task End");
});
task3.Start();
Console.WriteLine("zapusk");
task3.Wait();
Console.WriteLine("<---------->");
Console.WriteLine("Main Starts");
Task task4 = new Task(()=>
{
Console.WriteLine("Task Starts");
Thread.Sleep(2000);
Console.WriteLine("Task End");
});
task4.RunSynchronously();
Console.WriteLine(task4.Status);
Console.WriteLine("Main Ends");