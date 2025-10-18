using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ModuloAPI.Entidades;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ModuloAPI.Configuration
{
    public class TokenService
    {
        
        public string createToken(Usuario usuario)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(KeyConfiguration.PrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2),
                Subject = GenerateClaims(usuario)
            };
            var token = handler.CreateToken(tokenDescription);

            return handler.WriteToken(token);
        }

        public static ClaimsIdentity GenerateClaims(Usuario usuario) 
        {
            var claims = new ClaimsIdentity();
           
            claims.AddClaim(new Claim("Id", usuario.Id_Usuario.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Name, usuario.NomeUsuario));
            claims.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));
            claims.AddClaim(new Claim(ClaimTypes.Role, usuario.Role));
            
            return claims;
        }
    }
}
