class Program
{
    static void Main()
    {
        Mutex mutexobj = new();
        int x = 0;
        for(int i = 1; i<6; i++)
        {
            Thread myThread = new Thread(Print);
            myThread.Name = $"Поток {i}";
            myThread.Start();
        }

        void Print()
        {
            mutexobj.WaitOne();
            x =1;
            for(int i =1; i<6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
                x++;
                Thread.Sleep(100);
            }
            mutexobj.ReleaseMutex();

        }
    }
}
