static void ExecutePatterMatchingSwitch()
{
    Console.WriteLine("1 [Integer 5], 2 [String(\"hi\")],3[Decimal(2.5)]");
    Console.Write("Please choose an option: ");
    object? choice = Console.ReadLine();
    switch(choice)
    {
        case int i: Console.WriteLine("Your choice is an integer{0}",i);break;
        case string s: Console.WriteLine("Your choice is a string{0}",s);break;
        case decimal d:Console.WriteLine("Your choice is a decimal{0}",d);break;
        default: Console.WriteLine("Your choice is something else");break;
    }
}
ExecutePatterMatchingSwitch();
