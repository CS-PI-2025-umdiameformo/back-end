using Microsoft.AspNetCore.Mvc;
using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs;
using OrganizeAgenda.Utils;

namespace OrganizeAgenda.Controllers
{
    [ApiController]
    [Route(nameof(ApiRoutes.User))]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        [Route(ApiRoutes.User.GetAll)]
        public async Task<IActionResult> GetAllUsersAsync([FromServices] IUserService service) => (IActionResult)await service.GetAllUsersAsync();

        // GET: api/User/5
        [HttpGet("{id}")]
        [Route(ApiRoutes.User.GetById)]
        public IActionResult GetUserById(int id)
        {
            // Example: return a static user
            var user = new { Id = id, Name = $"User{id}" };
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        [Route(ApiRoutes.User.Create)]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            // Example: return the created user
            return CreatedAtAction(nameof(GetUserById), new { id = 1 }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [Route(ApiRoutes.User.Update)]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO user)
        {
            // Example: return no content
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [Route(ApiRoutes.User.Delete)]
        public IActionResult DeleteUser(int id)
        {
            // Example: return no content
            return NoContent();
        }
    }
}
