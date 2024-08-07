namespace FunWithMethodOverload;

public class AddOperations
{
 public static int Add(in int x,in int y)
 {
    int res = x+ y;
    return res;
 }

 public static double Add(in double x, in double y)
 {
   double res = x +y;
   return res;
 }

 public static long Add(in long x, in long y)
 {
    long res = x + y;
    return res;
 }

}
