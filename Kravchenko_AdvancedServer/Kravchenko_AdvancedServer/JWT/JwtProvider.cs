using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Kravchenko_AdvancedServer.Repositories;
public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateToken(string id, string role)
    {
        Claim[] claims = [new("userId", id), new(ClaimTypes.Role, role)];
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims:claims,
            signingCredentials:signingCredentials, expires: DateTime.UtcNow.AddMinutes(_options.ExpiresHours));
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return $"Bearer {tokenValue}";
    }
}