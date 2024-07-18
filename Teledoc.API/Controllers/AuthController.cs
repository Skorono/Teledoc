using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Teledoc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public IActionResult Login(string key)
    {
        if (key.Equals(Environment.GetEnvironmentVariable("AUTH_PASSWORD")))
        {
            var secretKey = new SymmetricSecurityKey("3911391a-f3e8-4dcf-abda-3556a16a16bb"u8.ToArray());
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                "CodeMaze",
                "https://localhost:5001",
                new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });
        }

        return Unauthorized();
    }
}