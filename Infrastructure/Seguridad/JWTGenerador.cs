using Domain.DTOs.UsuarioD;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seguridad
{
    public interface IGenerarToken
    {
        string GenerarTokenUsuario(UsuarioDto usuarioDto);
    }
    public class GenerarToken : IGenerarToken
    {
        private readonly IConfiguration _configuracion;

        public GenerarToken(IConfiguration configuration)
        {
            _configuracion = configuration;
        }

        public string GenerarTokenUsuario(UsuarioDto usuarioDto)
        {
            var key = _configuracion.GetValue<string>("Jwt:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(usuarioDto.IdUsuario)));

            var credencialesToken = new SigningCredentials
            (
               new SymmetricSecurityKey(keyBytes),
               SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;
        }
    }
}
