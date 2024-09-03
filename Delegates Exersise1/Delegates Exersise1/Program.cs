delegate int MathOperation(int one, int two);
class Program
{
static void Main()
{
    MathOperation addmath  = new MathOperation(Add);
    MathOperation submath = new MathOperation(Substract);
    var calc = new Calculator();
    var AddResult = calc.PerformOperation(addmath, 1,2);
    var SubMath = calc.PerformOperation(submath,3,1);
    Console.WriteLine($"{AddResult} {SubMath}");
}

public static int Add(int a, int b)
{
    return a+b;
}

public static int Substract(int a, int b)
{
    return a-b;
}
}

class Calculator
{
    public int PerformOperation(MathOperation math, int a, int b)
    {

        return math(a,b);
    }
}