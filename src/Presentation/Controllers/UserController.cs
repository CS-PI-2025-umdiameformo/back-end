using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizeAgenda.Application.DTO;
using OrganizeAgenda.Application.Interfaces;
using OrganizeAgenda.Domain.DTOs;
using OrganizeAgenda.Utils;
using System.ComponentModel;

namespace OrganizeAgenda.Controllers
{
    [ApiController]
    [Route(nameof(ApiRoutes.User))]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        [Route(ApiRoutes.User.GetAll)]
        //[Authorize(Roles ="admin")]
        public async Task<IActionResult> GetAllUsers([FromServices] IUserService service)
        {
            var response = await service.GetAllUsersAsync();

            if (!response.Any())
                return NotFound();

            return Ok(response);
        }

        // GET: api/User/5
        [HttpGet]
        [Route(ApiRoutes.User.GetById)]
        [Description("GetByID")]
        public async Task<IActionResult> GetUserById([FromQuery] int id, [FromServices] IUserService service)
        {
            var response = await service.GetUserByIdAsync(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST: api/User
        [HttpPost]
        [Route(ApiRoutes.User.Create)]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user, [FromServices] IUserService service)
        {
            var createdUser = await service.CreateUserAsync(user);
            if (createdUser == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // PUT: api/User/5
        [HttpPut]
        [Route(ApiRoutes.User.Update)]
        public async Task<IActionResult> UpdateUser([FromBody] int user, [FromServices] IUserService service)
        {
            var updated = await service.UpdateUserAsync(user);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete]
        [Route(ApiRoutes.User.Delete)]
        public async Task<IActionResult> DeleteUser([FromQuery] int id, [FromServices] IUserService service)
        {
            var deleted = await service.DeleteUserAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}