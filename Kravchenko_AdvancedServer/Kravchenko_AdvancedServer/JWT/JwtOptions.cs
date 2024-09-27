namespace Kravchenko_AdvancedServer.Repositories;

public class JwtOptions
{
    
    public string SecretKey { get; set; } = string.Empty;
    public int ExpiresHours { get; set; } = 30;
}