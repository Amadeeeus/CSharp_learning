namespace Delegate_Metahit_Example;

public class Account
{
 public int sum;

 public Account(int sum)=>this.sum = sum;
 public void Add(int sum)=>this.sum+=sum;

 public void Take(int sum)
 {
    if(this.sum>=sum)
    {
    this.sum -=sum;
    Console.WriteLine($"Со счета взято {sum} единиц");
    }
 }
}
