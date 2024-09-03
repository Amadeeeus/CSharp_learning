using System.ComponentModel;


public interface IMove
{
    void Move();
}

public class FastMove: IMove
{
    public void Move()
    {
        Console.WriteLine("fast");
    }
}

public class SlowMove:IMove
{
    public void Move()
    {
        Console.WriteLine("slow");
    }
}

public class Person
{
    private readonly IMove _move;
    public Person(IMove move)
    {
         _move = move;
    }
}
class Program
{
static void Main(string[] args)
{
IMove FastMove = new FastMove();
FastMove.Move();
IMove SlowMove = new SlowMove();
SlowMove.Move();

}
}


