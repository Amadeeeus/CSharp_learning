delegate void Message();

class Program
{
    static void Main()
    {
        // Определение метода
        void Hello()
        {
            Console.WriteLine("Hello, World!");
        }

        // Инициализация делегата и вызов метода
        Message mes = Hello;
        

        void Hi()
        {
            Console.WriteLine("HI");
        }

        Message greeting  = Hi;
        mes();
        Hi();
        TestDelegate.Calculator calcPlus = new TestDelegate.Calculator(TestDelegate.Plus);
        TestDelegate.Calculator calcMinus = new TestDelegate.Calculator(TestDelegate.Minus);
        TestDelegate.Calculator calcMultiply = new TestDelegate.Calculator(TestDelegate.Multiply);
        TestDelegate.Calculator calcDivide = new TestDelegate.Calculator(TestDelegate.Divide);
        Console.WriteLine("1 - 4 Calculate operation");
        int index = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("x?");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("y?");
        int y = Convert.ToInt32(Console.ReadLine());
        int result = 0;
        switch(index)
        {
            case 1: calcPlus(x, y, out result); break;
            case 2: calcMinus(x, y, out result); break;
            case 3: calcMultiply(x, y, out result); break;
            case 4: calcDivide(x, y, out result); break;
        }
        string? mathsign= " ";
        switch(index)
        {
            case 1: mathsign = "+"; break;
            case 2: mathsign = "-"; break;
            case 3: mathsign = "*"; break;
            case 4: mathsign = "/"; break;
        }
        Console.WriteLine("Result: {0} {1} {2} = {3}",x,mathsign,y, result);
    }
}

class TestDelegate
{

     public delegate void Calculator(int x, int y, out int result);
      
     static public void Plus(int x, int y, out int result)
     {
         result = x + y;
     }

     static public void Minus(int x, int y, out int result)
     {
        result = x - y;
     }
     static public void Multiply(int x, int y, out int result)
     {
        result = x * y;
     }

      static public void Divide(int x, int y,out int result)
     {
        result = x/y;
     }

}


