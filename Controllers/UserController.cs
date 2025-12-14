using Microsoft.AspNetCore.Mvc;
using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs.User;
using OrganizeAgenda.Repository;
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
        public async Task<IActionResult> GetAllUsers([FromServices] IUserService service)
        {
            var users = await service.GetAllUsersAsync();

            var response = users.Select(user => new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            });

            return Ok(response);
        }

        // GET: api/User/5
        [HttpGet]
        [Route(ApiRoutes.User.GetById)]
        [Description("GetByID")]
        public async Task<IActionResult> GetUserById([FromQuery] int id, [FromServices] IUserService service)
        {
            var user = await service.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            var response = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };

            return Ok(response);
        }

        // POST: api/User
        [HttpPost]
        [Route(ApiRoutes.User.Create)]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user, [FromServices] IUserService service)
        {
            try
            {
                var createdUser = await service.CreateUserAsync(user);

                var response = new UserResponseDto
                {
                    Id = createdUser.Id,
                    Name = createdUser.Name,
                    Email = createdUser.Email,
                    CreatedAt = createdUser.CreatedAt
                };

                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, response);
            }
            catch (DuplicidadeException ex)
            {
                var erro = new ErroCampoDuplicadoDTO
                {
                    Duplicado = true,
                    Campo = ex.Campo,
                    Mensagem = ex.Message
                };
                return BadRequest(erro);
            }
        }

        // PUT: api/User/5
        [HttpPut]
        [Route(ApiRoutes.User.Update)]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO user, [FromServices] IUserService service)
        {
            try
            {
                var updated = await service.UpdateUserAsync(user);
                if (!updated)
                    return NotFound();

                return NoContent();
            }
            catch (DuplicidadeException ex)
            {
                var erro = new ErroCampoDuplicadoDTO
                {
                    Duplicado = true,
                    Campo = ex.Campo,
                    Mensagem = ex.Message
                };
                return BadRequest(erro);
            }
        }

        // DELETE: api/User/5
        [HttpDelete]
        [Route(ApiRoutes.User.Delete)]
        public async Task<IActionResult> DeleteUser([FromQuery] int id, [FromServices] IUserService service)
        {
            try
            {
                var deleted = await service.DeleteUserAsync(id);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (ExclusaoBloqueadaException ex)
            {
                var erro = new ErroExclusaoBloqueadaDTO
                {
                    Bloqueado = true,
                    QuantidadeAgendamentos = ex.QuantidadeAgendamentos,
                    Mensagem = ex.Message
                };
                return BadRequest(erro);
            }
        }
    }
}
