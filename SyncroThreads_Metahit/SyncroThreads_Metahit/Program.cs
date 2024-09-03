class Program
{
    
    static void Main()
    {
        int x = 0;
        object locker = new();///Заглушка для lock
        for(int i = 0; i<=5; i++)
        {
            Thread myThread = new(Print);
            myThread.Name = $"Поток {i}";
            myThread.Start();
        }

        void Print()
        {
         lock(locker){
         x = 1;
         for(int i= 0; i<=5;i++)
         {
            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
            x++;
            Thread.Sleep(100);
         }
         }
        }
    }

} 
