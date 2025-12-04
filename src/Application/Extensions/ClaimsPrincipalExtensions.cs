using System;
using System.Security.Claims;

namespace OrganizeAgenda.Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetEmail(this ClaimsPrincipal user) =>
            user?.FindFirst(ClaimTypes.Email)?.Value
            ?? user?.FindFirst("email")?.Value;

        public static string? GetName(this ClaimsPrincipal user) =>
            user?.FindFirst(ClaimTypes.Name)?.Value
            ?? user?.FindFirst("name")?.Value;

        public static int? GetUserIdAsInt(this ClaimsPrincipal user)
        {
            var id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                     ?? user?.FindFirst("sub")?.Value
                     ?? user?.FindFirst("id")?.Value;
            return int.TryParse(id, out var v) ? v : null;
        }

        public static Guid? GetUserIdAsGuid(this ClaimsPrincipal user)
        {
            var id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                     ?? user?.FindFirst("sub")?.Value
                     ?? user?.FindFirst("id")?.Value;
            return Guid.TryParse(id, out var g) ? g : null;
        }

        public static string[] GetRoles(this ClaimsPrincipal user) =>
            user?.FindAll(ClaimTypes.Role) is { } roles ? roles.Select(r => r.Value).ToArray()
            : user?.FindAll("role") is { } r2 ? r2.Select(x => x.Value).ToArray()
            : Array.Empty<string>();
    }
}