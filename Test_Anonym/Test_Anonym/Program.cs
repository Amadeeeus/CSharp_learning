var person = new { Name = "John", Age = 30 };
Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

class Person:IDisposable
{
    private bool _disposed = false;

    public (object,string, int)getData()
    {
     var filed = new {name = "person", age = 22}; 
     string name = filed.name;
     int age  = filed.age;  
     object data = filed;
     return (data, name, age);
    }
     
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(_disposed)return;
        if(disposing)
        {
            Console.WriteLine("Управляемые ресурсы очищены");
        }
        _disposed =  true;
        }
        
    }