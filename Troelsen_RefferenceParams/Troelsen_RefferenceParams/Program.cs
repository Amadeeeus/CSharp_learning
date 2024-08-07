//<-----------Параметр out----------------->
static void AddUsingOutParams(int x, int y, out int ans)
{
  ans = x+y;
}
int x = 3;
int y = 5;
int ans = 0;
AddUsingOutParams(x,y,out ans);
Console.WriteLine("{0} + {1} = {2}",x,y,ans);
//<---------------Только выходные параметры------------------------------>
static void FillTheseValues(out int a, out string b, out bool c)
{
    a = 9;
    b = "Enjoy your strings";
    c = true;
}

FillTheseValues(out int a, out string b, out bool c);
Console.WriteLine("Int is {0}", a);
Console.WriteLine("String is {0}", b);
Console.WriteLine("Bool is {0}", c);
/* Можно использовать отбрасывание, если какие то выходные переменные не нужны*/
//out __
//<--------------------Параметр ref-------------------------------------->
static void SwapStrings(ref string s1,ref string s2)
{
  string tempStr = s1;
  s1 = s2;
  s2 = tempStr;
}

Console.WriteLine("**** Fun with Methods ****");
string s1 = "Flip";
string s2 = "Flop";
Console.WriteLine("before - {0}-{1}", s1,s2);
SwapStrings(ref s1,ref s2);
Console.WriteLine("after - {0}-{1}", s1,s2);
//<--------------------Параметр in -------------------------------->

static void AddReadOnly(in int x, in int y, out int res)
{
  res = x+ y;
}

AddReadOnly(3,4,out int res);
Console.WriteLine("3 + 4 = {0}", res);
