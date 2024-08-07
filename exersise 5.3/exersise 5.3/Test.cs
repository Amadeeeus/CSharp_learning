
public class Test
{
  int a;
  int b;
  public Test(int a, int b)
  {
     this.a = a;
     this.b = b;
  }

public void Deconstruct(out int aa, out int bb)
{
    aa = a;
    bb = b;
}
}