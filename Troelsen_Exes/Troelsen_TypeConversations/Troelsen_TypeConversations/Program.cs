using System;
//<<-------------Неявный перевод short в int --------------->>
Console.WriteLine("**** Fun with type conversations ****");
short numb1= 9, numb2 =10;
Console.WriteLine("{0} + {1} = {2}",numb1,numb2, Add(numb1, numb2));
Console.ReadLine();
static int Add(int x, int y)
{
    return x+y;
}
//<<<--------Превышение обьема short----------->>>
Console.WriteLine("**** Fun with type conversations ****");
short numb3= 30000, numb4 =30000;
//short answer = Add(numb3,numb4);<-- сужающая операция не получилась из за того что max short = 32768;
Console.WriteLine("{0} + {1} = {2}",numb3,numb4, Add(numb3,numb4));
Console.ReadLine();
//<------------------------Еще попытка сужения------------------>
static sbyte NarrowingAttempt()
{
    sbyte myByte = 0;
    int MyInt = 200;
    myByte = (sbyte)MyInt; //не получилось int в byte, потому что byte = 127
    return myByte; 
}
//<----------явное приведение типов------------->
Console.WriteLine("****Fun with type conversion ****");
short num1 = 30000, num2 = 30000;
short answer = (short)Add(num1, num2);
Console.ReadLine();
Console.WriteLine("{0} + {1} = {2} или {3}", num1,num2,answer,NarrowingAttempt());
