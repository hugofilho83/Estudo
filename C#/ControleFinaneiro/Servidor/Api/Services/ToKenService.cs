using System;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Models;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services
{
  public class ToKenService
  {
    public string Secret { get; set; }
    public static string GenerateToken(Usuarios usuario, DateTime expiresAt)
    {

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(ServiceConfig.Secret);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(
          new Claim[] {
                new Claim (ClaimTypes.Name, usuario.Name.ToString ()),
                new Claim (ClaimTypes.Sid, usuario.Id.ToString ())
          }
          ),

        Expires = expiresAt,

        SigningCredentials = new SigningCredentials(
          new SymmetricSecurityKey(key),
          SecurityAlgorithms.HmacSha256Signature
          )

      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);

    }
  }
}
