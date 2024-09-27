namespace Kravchenko_AdvancedServer;

public interface IPasswordHasher
{
    string HashingPassword(string password);
    bool PasswordVerification(string password, string hashedPassword);
}