
class Program{
delegate void Print(string message);
delegate void Show(string tits);
    static void Main()
    {
    var human = new{name = "pavel", age = 27};
    Console.WriteLine($"{human.name} - {human.age}");
    Print print = delegate(string message)
    {
    Console.WriteLine(message);
    };
    print("Message");
    Show show = (tits)=>Console.WriteLine(tits);
    show("tits");
    Func<int,int,int> calc = (c, d)=>c+d;
    var result = calc(2,3);
    }





}
