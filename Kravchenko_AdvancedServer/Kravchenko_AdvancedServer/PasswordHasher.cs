namespace Kravchenko_AdvancedServer;
using BCrypt;


public class PasswordHasher : IPasswordHasher
{
    public string HashingPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool PasswordVerification(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}