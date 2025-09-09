using Microsoft.AspNetCore.Mvc;
using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs;
using OrganizeAgenda.Services;

namespace OrganizeAgenda.Controllers
{
    [ApiController]
    [Route("/authorization")]
    public class AuthController : ControllerBase
    {
        // POST: api/Auth
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] AuthDTO Auth, [FromServices] IAuthService service)
        {
            //var token = await service.(Auth);

            //var response = new AuthResponseDto
            //{
            //    Token = token
            //};

            //return CreatedAtAction("logon", new { id = createdAuth.Id }, response);

            if (Auth.Username == "admin" && Auth.Password == "password123")
            {
                var token = service.GenerateToken(Auth.Username, "Admin");
                return (IActionResult)Results.Ok(token.ToString());
            }
            return (IActionResult)Results.Unauthorized();
        }

    }
}