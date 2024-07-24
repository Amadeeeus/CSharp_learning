int[] numbers = {-4,-3,-2,-1,0,1,2,3,4};
int result = 0;
foreach (int n in numbers)
{
    if(n > 0)
    {
        result++;
    }
}
    Console.WriteLine($"Количество положительных элементов в массиве - {result}");