using Microsoft.EntityFrameworkCore;
using OrganizeAgenda.Domain.DTOs;

namespace OrganizeAgenda.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserDTO> Users { get; set; } = null!;
        public DbSet<AgendamentoDTO> Agendamentos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDTO>(builder =>
            {
                builder.ToTable("usuario"); // Nome da tabela em minúsculo (convenção PostgreSQL)
                builder.HasKey(u => u.Id);
                
                builder.Property(u => u.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                builder.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                builder.Property(u => u.SenhaHash)
                    .IsRequired()
                    .HasColumnName("password_hash");

                builder.Property(u => u.CriadoEm)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                builder.HasMany(u => u.Agendamentos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasIndex(u => u.Email)
                    .IsUnique();
            });

            modelBuilder.Entity<AgendamentoDTO>(builder =>
            {
                builder.ToTable("agendamentos"); 
                builder.HasKey(a => a.Id);
                
                builder.Property(a => a.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("titulo");

                builder.Property(a => a.DataHora)
                    .IsRequired()
                    .HasColumnName("data_hora");

                builder.Property(a => a.Descricao)
                    .HasMaxLength(500)
                    .HasColumnName("descricao");

                builder.HasOne(a => a.Usuario)
                    .WithMany()
                    .HasForeignKey(a => a.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
