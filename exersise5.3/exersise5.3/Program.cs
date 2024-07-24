//тестирование методов(functions)
void Test1(int a, int b)
{
  int z;  
  z = a+b;
  Console.WriteLine($"{a}+{b} = {z}");
}
int x = 9, y = 10, result = 0;
Test1(x,y);

int Test2(int a, int b)
{
 int z = x+y;
 return z;
}
result = Test2(x,y);
Console.WriteLine($"{x}+{y}={result}");



