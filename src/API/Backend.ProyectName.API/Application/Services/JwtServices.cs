using Backend.ProyectName.API.Application.Utils;
using Backend.ProyectName.API.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Application.Services
{
    public class JwtServices
    {
        private readonly string _secret;
        private readonly string _expDate;
        private readonly string _secretPortability;
        private readonly string _expDatePortability;
        private readonly string _audience;
        private readonly string _issuer;

        public JwtServices(IConfiguration configuration)
        {
            _secret = configuration.GetSection("JwtConfig").GetSection("Secret").Value;
            _expDate = configuration.GetSection("JwtConfig").GetSection("ExpirationInMinutes").Value;

            _secretPortability = configuration.GetSection("JwtConfig").GetSection("Portability").GetSection("Secret").Value;
            _expDatePortability = configuration.GetSection("JwtConfig").GetSection("Portability").GetSection("ExpirationInMinutes").Value;

            _audience = configuration.GetSection("JwtConfig").GetSection("ValidIssuer").Value;
            _issuer = configuration.GetSection("JwtConfig").GetSection("ValidIssuer").Value;
        }

        public (string Token, DateTime ExpiresAt) GenerateSecurityToken(Guid userId, string name, bool executiveView = false)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var expiresAt = DateTime.UtcNow.AddMinutes(double.Parse(_expDate));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(type: "userid", value: userId.ToString()),
                    new Claim(ClaimTypes.Name, value: name),
                    new Claim(type: "executiveview", value: executiveView.ToString().ToLower()),
                 }),
                Expires = expiresAt,
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (tokenHandler.WriteToken(token), expiresAt);
        }

        public async Task<bool> ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            /*
             * Se agrega ValidAudience y ValidIssuer 
             * ya que sin esos campos no se puede validar el token 
             */
            var validationResult = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ClockSkew = TimeSpan.Zero
            });

            return validationResult.IsValid;
        }

        public Guid GetData(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            string cleanToken = token.Replace("Bearer ", String.Empty);

            if (tokenHandler.ReadToken(cleanToken) is not JwtSecurityToken jwtToken)
                throw new BusinessException("Invalid token provided");

            Guid userId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "userid").Value);
            return userId;
        }

        public string GenerateSecurityTokenPortability(string rut)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretPortability);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Sid, rut),
                    new Claim(ClaimTypes.Email, string.Empty)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDatePortability)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}