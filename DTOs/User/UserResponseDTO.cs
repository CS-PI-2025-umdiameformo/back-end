namespace OrganizeAgenda.DTOs.User
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
