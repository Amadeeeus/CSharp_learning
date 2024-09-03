Task task1 = new Task(()=>{
Console.WriteLine($"Id Задачи {Task.CurrentId}");
});

Task task2 = task1.ContinueWith(PrintTask);
task1.Start();
task2.Wait();
Console.WriteLine("Конец метода main");

void PrintTask(Task t)
{
    Console.WriteLine($"Id задачи: {Task.CurrentId}");
    Console.WriteLine($"Id предыдущей задачи: {t.Id}");
    Thread.Sleep(1000);
}

Task <int>SumTask = new Task<int>(()=>Sum(4,5));
Task printTask = SumTask.ContinueWith(task=>PrintResult(task.Result));
SumTask.Start();

printTask.Wait();
Console.WriteLine("Конец метода Main");

int Sum(int a, int b)=>a+b;
void PrintResult(int sum)=>Console.WriteLine($"Sum: {sum}");