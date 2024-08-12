int n1 = 4, n2 = 5;
Task<int> sumTask = new Task<int>(()=>Sum(n1,n2));
sumTask.Start();

int Result =sumTask.Result;
Console.WriteLine($"{n1} + {n2}={Result}");

int Sum(int a, int b)=>a+b;