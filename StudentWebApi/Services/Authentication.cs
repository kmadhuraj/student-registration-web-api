using Microsoft.IdentityModel.Tokens;
using Student.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentWebApi.Services
{
    public class Authentication
    {
        private IConfiguration _config;
        public Authentication(IConfiguration config)
        {
            _config = config;
        }
        public AdminModel AuthenticateUser(AdminModel login)
        {
            AdminModel admin = null;
            if (login.Username.ToLower() == "admin")
            {
                admin = new AdminModel { Username = login.Username, Email = login.Email };
            }
            return admin;
        }
        public string GenerateToken(AdminModel adminInfo)
        {
            var securutyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securutyKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,adminInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email,adminInfo.Email),


            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
            var finalToken = new JwtSecurityTokenHandler().WriteToken(token);
            return finalToken;
        }
    }
}
