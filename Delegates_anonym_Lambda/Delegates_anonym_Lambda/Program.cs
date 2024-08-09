class Program
{
    //анонимный метод
    delegate int SumOfTwoNum(int x, int y);
    delegate void MessageMethods(string message);
    static void Main()
    {
        string liter = "Message: ";
        MessageMethods print = delegate(string message)
        {
           Console.WriteLine(liter + message); 
        };

        print("hello");
        //lambda выражение простейшее
        
        const int DoubleNum = 2;
        const int QuatroNum = 4;
        var sum = (int x,int y)=>(x + y) *DoubleNum;
        int res = sum(1,2);
        Console.WriteLine(res);
        //Лямбда посложнее
        SumOfTwoNum foursum = (x,y)=>
        {
            res = (x+y)*DoubleNum*QuatroNum;
           Console.WriteLine("{0} + {1} * {2} * {3} = {4}", x,y,DoubleNum,QuatroNum,res); 
           return res;
        };
        foursum(3,7);
        Console.WriteLine($"\n{res}");
        
    }

}