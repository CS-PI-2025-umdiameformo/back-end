
using OrganizeAgenda.Domain.DTOs;

namespace OrganizeAgenda.Domain.Entities
{
    public record Prestador
    {
        public Guid Id { get; set; }

        // Foreign Key para o Usuário
        public Guid UsuarioId { get; set; }
        public virtual required User Usuario { get; set; }

        public string? RegistroProfissional { get; set; } // Ex: CRM, OAB
        public string? Bio { get; set; }

        // Lista de serviços que este prestador oferece
        public virtual required ICollection<ServicoPrestador> ServicosOferecidos { get; set; }
    }
}
