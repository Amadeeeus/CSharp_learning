/*Переменные и константы
Переменные в c# определяются через тип и имя константы.
Переменные регистрозависимы
*/
int Main = 123;
Console.WriteLine($"переменная - {Main}");

// так можно задать константу
const int Main2 = 9;
Console.WriteLine($"константа - {Main2}");
/* Литералы
Литералами называют неизменяемые значения которые мы передаем
в переменную. Они бывают логическими, целочисленными, 
вещественными, символьными и строчными, и null
*/
Console.WriteLine($"логический литерал - {true}");
Console.WriteLine($"целочисленный литерал - {505}");
Console.WriteLine($"вещественный литерал - {-1.2}");
Console.WriteLine($"Символьный литерал - T");
Console.WriteLine("строковый литерал - эта строка");
/*
Типы данных
*/
int minChar = char.MinValue;
int maxChar = char.MaxValue;
Console.WriteLine($"bool - {true} or {false}");
Console.WriteLine($"byte - от {byte.MinValue} до {byte.MaxValue}");
Console.WriteLine($"sbyte - от {sbyte.MinValue} до {sbyte.MaxValue}");
Console.WriteLine($"short - от {short.MinValue} до {short.MaxValue}");
Console.WriteLine($"ushort - от {ushort.MinValue} до {ushort.MaxValue}");
Console.WriteLine($"int - от {int.MinValue} до {int.MaxValue}");
Console.WriteLine($"uint - от {uint.MinValue} до {uint.MaxValue}");
Console.WriteLine($"long - от {long.MinValue} до {long.MaxValue}");
Console.WriteLine($"ulong - от {ulong.MinValue} до {ulong.MaxValue}");
Console.WriteLine($"float - от {float.MinValue} до {float.MaxValue}");
Console.WriteLine($"double - от {double.MinValue} до {double.MaxValue}");
Console.WriteLine($"decimal - от {decimal.MinValue} до {decimal.MaxValue}");
Console.WriteLine($"ushort - от {ushort.MinValue} до {ushort.MaxValue}");
Console.WriteLine($"char - от {minChar} до {maxChar}");
Console.WriteLine($"string - от 1 байта до 2 гбайт");
Console.WriteLine($" - от {ushort.MinValue} до {ushort.MaxValue}");