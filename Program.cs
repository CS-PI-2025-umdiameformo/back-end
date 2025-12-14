using OrganizeAgenda.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register IUserService with UserService
builder.Services.AddScoped<OrganizeAgenda.Abstractions.IUserService, OrganizeAgenda.Services.UserService>();

// Register IUserRepository with UserRepository
builder.Services.AddScoped<OrganizeAgenda.Abstractions.IUserRepository, OrganizeAgenda.Repository.UserRepository>();

// Register IAgendamentoRepository with AgendamentoRepository
builder.Services.AddScoped<OrganizeAgenda.Abstractions.IAgendamentoRepository, OrganizeAgenda.Repository.AgendamentoRepository>();

// Register IAgendamentoService with AgendamentoService
builder.Services.AddScoped<OrganizeAgenda.Abstractions.IAgendamentoService, OrganizeAgenda.Services.AgendamentoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
