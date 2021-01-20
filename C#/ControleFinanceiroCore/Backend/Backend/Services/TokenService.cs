using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services {
    public class TokenService {
        public static string GenerateToken (Usuario usuario,  DateTime expire) {
            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (Configurations.GetKeyToken());

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.Name, usuario.Name.ToString ()),
                new Claim (ClaimTypes.Sid, usuario.Id.ToString ())
                }),

                Expires = expire,

                SigningCredentials = new SigningCredentials (
                new SymmetricSecurityKey (key),
                SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken (tokenDescriptor);

            return tokenHandler.WriteToken (token);
        }
    }
}
