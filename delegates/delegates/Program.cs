class Program
{
    delegate int First(int x,int y);
    delegate int Second(int x, int y);
    delegate decimal Third(int x, int y);
    static void Main()
    {
        First first = (x,y)=>x+y;
        Second second = (x,y)=>x-y;
        Third third = (x,y)=>x*y;
        Console.WriteLine("{0} {1} {2}",first(1,1),second(4,3),third(899,123131));

    }
}
