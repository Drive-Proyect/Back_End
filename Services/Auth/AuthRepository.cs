using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drive.Data;
using Drive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Drive.Services.Auth;



namespace Drive.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DriveContext  _context;
        private readonly JwtSettings _jwtSettings;

        public AuthRepository(DriveContext context, IOptions<JwtSettings> options)
        {
            _context = context;
            _jwtSettings = options.Value;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // new Claim(ClaimTypes.Role, user.Rol)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.SecurityKey,
                audience: _jwtSettings.SecurityKey,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(string UserName, string Password)
        {
            Console.WriteLine("AQUI---------------!!!!!" );
            Console.WriteLine(UserName);
            //var user = _context.MarketingUsers.FirstOrDefault(u => u.Username == Username);
            var user = _context.Users.FirstOrDefault(u => u.Username == UserName);
            
            if (user != null &&  user.Password == Password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public void LogOutAsync()
        {
            throw new NotImplementedException();
        }
        // gSI=eFk4G3ZRy`(Kg£+<X(1VI4)5=RKw
        // 9Y9+JKvPyNR0qmUGeCT1oHfCwK2E4EK9YiUCRLXL9D8="
    }
}