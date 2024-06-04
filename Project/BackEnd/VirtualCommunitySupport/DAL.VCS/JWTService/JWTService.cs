using DAL.VCS.Repository.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS.JWTService
{
    public class JWTService
    {
        private readonly string _secretKey = "mymy_very_long_secret_key_here12345678901234567890123456789012";
        //public string GenerateToken(String Id, string FirstName, string LastName, string PhoneNumber, string EmailAddress, string UserType, string Password)
        public string GenerateToken(string EmailAddress, string UserType, string Password)
        {
            ////var usersWithRoles = _userRepository.GetUserWithRoles().FirstOrDefault(x => x.UserName == user.UserName).RoleName;
            ////if (usersWithRoles == null)
            ////{
            ////    usersWithRoles = "user";
            ////}
            var userRole = UserType;
            if (userRole == null)
            {
                userRole = "user";
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, EmailAddress),
                    new Claim(ClaimTypes.Role, userRole)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
