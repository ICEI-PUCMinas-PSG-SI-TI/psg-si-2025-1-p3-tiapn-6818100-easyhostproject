using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EasyHost.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class JwtService : IJwtService
{
    private readonly string _secret;
    private readonly int _expiresMinutes;

    public JwtService(IConfiguration config)
    {
        _secret = config["Jwt:Secret"] 
            ?? throw new ArgumentNullException(nameof(config), "Jwt:Secret não configurado");
        _expiresMinutes = int.Parse(config["Jwt:ExpiresMinutes"] ?? "60");
    }

    public string GenerateToken(Usuario user)
    {
        JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,   user._id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user._email),
            new Claim(JwtRegisteredClaimNames.Name,  user._nome),
            new Claim("hotelId",                     user._hotelId.ToString()),
            new Claim("userId",                     user._id.ToString()),
            new Claim("tipoUsuario",                user._tipoUsuario.ToString()),

        };

        var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var now   = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
            claims:            claims,
            notBefore:         now,
            expires:           now.AddMinutes(_expiresMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
