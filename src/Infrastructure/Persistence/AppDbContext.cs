using Microsoft.EntityFrameworkCore;
using OrganizeAgenda.Domain.Entities;

namespace OrganizeAgenda.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Agendamento> Agendamentos { get; set; } = null!;
        
        public DbSet<Prestador> Prestadores { get; set; }
        public DbSet<ServicoPrestador> ServicosPrestador { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("usuarios");
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
                    .HasColumnName("criado_em")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                builder.HasMany(u => u.Agendamentos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_agendamento");

                builder.HasIndex(u => u.Email)
                    .IsUnique();
                
                builder.HasOne(u => u.Prestador)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Prestador>(p => p.UsuarioId);

            });

            modelBuilder.Entity<Agendamento>(builder =>
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

                builder.Property(a => a.Recorrencia)
                    .IsRequired()
                    .HasColumnName("recorrencia");

                //builder.HasOne(a => a.Usuario)
                //    .WithMany(e => e.Agendamentos)
                //    .HasForeignKey(a => a.UsuarioId)
                //    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Prestador>(builder =>
            {
                builder.ToTable("prestadores");
                builder.HasKey(p => p.Id);

                builder.Property(p => p.RegistroProfissional)
                    .HasMaxLength(50)
                    .HasColumnName("registro_profissional");

                builder.Property(p => p.Bio)
                    .HasMaxLength(1000)
                    .HasColumnName("bio");

                builder.HasOne(p => p.Usuario)
                    .WithOne(u => u.Prestador)
                    .HasForeignKey<Prestador>(p => p.UsuarioId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(p => p.ServicosOferecidos)
                    .WithOne(s => s.Prestador)
                    .HasForeignKey(s => s.PrestadorId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ServicoPrestador>(builder =>
            {
                builder.ToTable("servicos_prestador");
                builder.HasKey(s => s.Id);

                builder.Property(s => s.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("nome");

                builder.Property(s => s.Preco)
                    .HasColumnName("preco")
                    .HasPrecision(18, 2);

                builder.Property(s => s.DuracaoMedia)
                    .HasColumnName("duracao_media");

                builder.HasOne(s => s.Prestador)
                    .WithMany(p => p.ServicosOferecidos)
                    .HasForeignKey(s => s.PrestadorId);
            });
        }
    }
}
