class Program
{
public static void Main()
{

}
}
interface IAction
{
    void DoAction();
}

class Person: IAction
{
    private IAction _action;
    public void DoAction(IAction action)
    {
      _action = action;
    }
    
    public void Start()
    {
        _action.
    }
}