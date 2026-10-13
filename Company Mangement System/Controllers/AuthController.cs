using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Company_Mangement_System.Dtos;
using Company_Mangement_System.Models;

namespace Company_Mangement_System.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            // Implement your authentication logic here
            // For example, validate the username and password against a database
            if (request.Username == "admin" && request.Password == "password")
            {
                // Generate a JWT token or any other authentication token
                var token = "your_generated_token_here";
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            
            return "your_generated_token_here";
        }
    }
}
