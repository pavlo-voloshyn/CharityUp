using AccountService.Domain.Models;
using AccountService.Application.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AccountService.Application.Helpers;

public static class JwtTokenGenerator
{
    public static string GenerateToken(string userName, Guid userId, List<string> userRoles, JwtSettings jwtSettings)
    {
        var claims = new List<Claim>() {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        };

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(jwtSettings.Issuer, jwtSettings.Issuer, claims,
            expires: DateTime.Now.AddMinutes(jwtSettings.DurationInMinutes), signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
