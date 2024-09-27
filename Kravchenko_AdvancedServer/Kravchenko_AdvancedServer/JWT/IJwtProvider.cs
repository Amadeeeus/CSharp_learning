namespace Kravchenko_AdvancedServer.Repositories;

public interface IJwtProvider
{
    string GenerateToken(string id, string role);
}