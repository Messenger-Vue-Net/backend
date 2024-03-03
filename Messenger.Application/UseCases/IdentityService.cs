using Messenger.Application.Interface;
using Messenger.Domain.Entities;
using Messenger.Presentence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Messenger.Application.UseCases
{
    public class IdentityService : IIdentityService
    {
        private readonly ApplicationDbContext _db;

        public IdentityService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> Login(string login, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Login == login);

            if (user == null || user.Password != password)
            {
                // Возвращаем null в случае, если пользователя не существует или пароль неверен
                return null;
            }

            // Возвращаем токен при успешном входе
            return GenerateToken(user);
        }

        private string GenerateToken(User input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthOptions.KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(JwtRegisteredClaimNames.Name, input.Login),
            new Claim("Name", input.Login),
            new Claim("Id", input.Id.ToString()),
                }),
                Issuer = AuthOptions.ISSUER,
                Audience = AuthOptions.AUDIENCE,
                Expires = DateTime.UtcNow.AddMinutes(999999),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
