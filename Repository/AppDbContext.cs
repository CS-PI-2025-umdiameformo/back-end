namespace OrganizeAgenda.Repository
{
    using Microsoft.EntityFrameworkCore;
    using OrganizeAgenda.DTOs.User;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserDTO> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações do modelo (mapeamento)
            modelBuilder.Entity<UserDTO>(builder =>
            {
                builder.HasKey(u => u.Id);
                builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
                //builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
                builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
                builder.HasIndex(u => u.Email).IsUnique(); // Garante unicidade no banco de dados
                builder.Property(u => u.PasswordHash).IsRequired();
            });
        }
    }
}
