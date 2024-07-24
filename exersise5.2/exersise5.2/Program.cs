int[]numbers = {-4,-3,-2,-1,0,1,2,3,4,};

int n = numbers.Length;
int k = n/2;
int temp;
for (int i=0; i<k; i++)
{
    temp =numbers[i];
    numbers[i]=numbers[n-i-1];
    numbers[n-i-1] = temp;
}
foreach (int i in numbers)
{
    Console.Write($"{i}\t");
}

