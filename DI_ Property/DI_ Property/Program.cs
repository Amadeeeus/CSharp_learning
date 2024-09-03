using System;
class Program
{
public static void Main()
{
  Service service = new Service();
  Consumer consumer = new Consumer(){Service = service};
  consumer.Execute();
}
}

public interface IService
{
    void DoSomething();
}
public class Service:IService
{
    public void DoSomething()
    {
        Console.WriteLine("Something");
    }
}

public class Consumer
{
    public IService Service{set;get;}
    public void Execute()
    {
        Service?.DoSomething();
    }
}