delegate int MathOperation(int a, int b);
class Program
{
    static void Main()
    {
        MathOperation add = (a, b) => a + b;
        MathOperation substract = (a, b) => a - b;
        MathOperation multi = (a, b) => a * b;
        MathOperation div = (a, b) => a / b;
        Calculator calculator = new Calculator();
        Console.WriteLine("add {0}", calculator.Calculate(add, 1, 2));
        Console.WriteLine("substract {0}", calculator.Calculate(substract, 6, 5));
        Console.WriteLine("multi {0}", calculator.Calculate(multi, 5, 6));
        Console.WriteLine("div {0}", calculator.Calculate(div, 8, 2));
    }
}

class Calculator
{
    public int Calculate(MathOperation math, int a, int b)
    {
        return math(a, b);
    }
}
