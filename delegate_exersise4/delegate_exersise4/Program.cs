using System.Net.NetworkInformation;
delegate int StatOperation(int[] array);
class Program
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        var calculator = new StatisticsCalculator();
        StatOperation min = new(FindMinimum);
        StatOperation max = new(FindMaximum);
        StatOperation aver = new(CalculateAverage);
        Console.WriteLine("MIN - {0} MAX - {1} AVER - {2}", calculator.Compute(min, numbers), calculator.Compute(max, numbers), calculator.Compute(aver, numbers));
    }
    static int FindMaximum(int[] array)
    {
        int result = 0;
        for (int i = 0; i <= array.Length - 1; i++)
        {
            if (i == 0)
            {
                continue;
            }
            if (array[i] >= array[i] - 1)
            {
                result = array[i];
            }
        }
        return result;
    }
    static int FindMinimum(int[] array)
    {
        int result = 0;
        for (int i = 0; i <= array.Length - 1; i++)
        {
            if (i == 0)
            {
                result = array[i];
                continue;
            }
            if (array[i] < array[i] - 1)
            {
                result = array[i];
            }
        }
        return result;
    }

    static int CalculateAverage(int[] array)
    {
        int sum = 0;
        int average = 0;
        {
            foreach (int i in array)
            {
                sum += array[i];
                average = sum / array.Length;
            }
        }
        return average;
    }
    class StatisticsCalculator
    {
        public int Compute(StatOperation stat, int[] array)
        {
            return stat(array);
        }
    }
}