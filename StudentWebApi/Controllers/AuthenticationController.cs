using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Student.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StudentWebApi.Services;
namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private Authentication _auth; 
        private IConfiguration _config;
        
        public AuthenticationController(IConfiguration config, Authentication auth)
        {
            _auth = auth;
            _config=config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] AdminModel login)
        {
           // Authentication auth = new();
            IActionResult response = Unauthorized();
            var user = _auth.AuthenticateUser(login);
            if(user != null)
            {
                var  tokenString= _auth.GenerateToken(user);
                response= Ok(new { tokenString = tokenString });
            }
            return response;
        }

        

    }
}
