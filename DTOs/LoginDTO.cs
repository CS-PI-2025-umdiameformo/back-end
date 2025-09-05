using System.ComponentModel.DataAnnotations;

namespace OrganizeAgenda.DTOs
{
    public record LoginDto(
        [property: Required] string Username,
        [property: Required] string Password
    );
}
