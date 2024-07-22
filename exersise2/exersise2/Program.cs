//Консольный вывод в C#
Console.WriteLine("Вывод в консоль");
//Вывод в консоль переменной
string a = "hi";
Console.WriteLine($"{a}");
//Вывод в консоль через плейсхолдеры
int b = 1;
int c = 2; 
int d = 3;
Console.WriteLine($"one - {0}, two - {1}, three - {2}", b, c, d);
//Console.Write не добавляет вывод на следующую строку
Console.Write(" Вывод на эту же строку");
//Консольный ввод
string? stroka = " ";//Знак вопроса означает что переменная может не хранить ничего
Console.WriteLine("Введите свое имя");
stroka = Console.ReadLine();
Console.WriteLine($"Добрый день, {stroka}!");
//Конвертация при вводе
Console.WriteLine("В int");
int i = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("В single");
float f = Convert.ToSingle(Console.ReadLine());
