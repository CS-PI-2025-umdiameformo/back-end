namespace OrganizeAgenda.Abstractions
{
    public interface IAuthService
    {
        string GenerateToken(string username, string role);
    }
}
