var outer = Task.Factory.StartNew(()=>
{
Console.WriteLine("Outer task opening");
var inner = Task.Factory.StartNew(()=>
{
Console.WriteLine("Inner task starting...");
Thread.Sleep(1000);
Console.WriteLine("Inner task closing...");

});
inner.Wait();
},TaskCreationOptions.AttachedToParent);
outer.Wait();
Console.WriteLine("End of Main");