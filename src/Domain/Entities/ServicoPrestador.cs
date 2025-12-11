using System.ComponentModel.DataAnnotations;

namespace OrganizeAgenda.Domain.Entities
{
    public record ServicoPrestador
    {
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set; } // Ex: "Corte de Cabelo", "Consulta"
        public required decimal Preco { get; set; }
        public required TimeSpan DuracaoMedia { get; set; }

        public int PrestadorId { get; set; }
        public virtual required Prestador Prestador { get; set; }
    }
}
