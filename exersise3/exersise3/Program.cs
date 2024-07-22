//Арифметические операции в С#
//Операции сложения 2 чисел
int x = 10; 
int z = x +12;
Console.WriteLine($"Результат сложения при z = 10 + 12 -  {z}");
//Операции вычитания 2 чисел
int x1 = 10;
int z1 = x1 - 4;
Console.WriteLine($"Результат вычитания при z = 10 - 4 - {z1}");
//Преобразование базовых типов данных
byte a = 4;
int b = a +70;
Console.WriteLine($"Result - {b}");
byte a1 = 4;
byte b1 = (byte)(a1 + 70);
Console.WriteLine($"Result - {b1}");
byte b2 = 4;
ushort b3 = b2;
Console.WriteLine("{0}",b3.GetType());
int x2 = 10;
int y2 = 12;
//тернарный оператор
int z2 = x2 < y2 ? (x2+y2) : (x2-y2);
Console.WriteLine(z2); 