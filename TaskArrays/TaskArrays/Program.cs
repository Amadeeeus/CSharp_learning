Task[] tasks = new Task[3]
{
    new Task(()=>{Console.WriteLine("first task");}),
    new Task(()=>{Console.WriteLine("second task");}),
    new Task(()=>{Console.WriteLine("third task");})
};

foreach(var task in tasks)
{
    task.Start();
    
}

Task.WaitAll(tasks);

Task[] tasks1 = new Task[3];
for(var i=0;i<tasks.Length; i++)
{
    tasks[i]= new Task(()=>
    {
        Thread.Sleep(1000);
        Console.WriteLine($"Task {i} finished");
    });
    tasks1[i].Start();
}
//Task.WaitAll(tasks1);