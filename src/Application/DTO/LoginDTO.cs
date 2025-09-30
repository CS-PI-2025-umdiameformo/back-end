using System.ComponentModel.DataAnnotations;

namespace OrganizeAgenda.Application.DTO
{
    public record LoginDto(
        [property: Required] string Username,
        [property: Required] string Password
    );
}
