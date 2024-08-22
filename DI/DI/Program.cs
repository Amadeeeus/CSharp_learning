public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class UserService
{
    private readonly ILogger _logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

    public void CreateUser(string name)
    {
        // Логика создания пользователя
        _logger.Log($"User {name} created");
    }
}

class Program
{
    static void Main()
    {
        ConsoleLogger logger = new();
        UserService user = new(logger);
        logger.Log("123");

    }
}

