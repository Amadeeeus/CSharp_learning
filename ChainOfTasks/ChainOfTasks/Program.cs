Task task1 = new Task(() =>Console.WriteLine($"current task  - {Task.CurrentId}"));

Task task2 = task1.ContinueWith(t=>Console.WriteLine($"Current Task  - {Task.CurrentId}"));
Task task3 = task2.ContinueWith(t=>Console.WriteLine($"Current Task - {Task.CurrentId}"));
Task task4 = task3.ContinueWith(t=>Console.WriteLine($"Current task - {Task.CurrentId}"));
task1.Start();
task4.Wait();
