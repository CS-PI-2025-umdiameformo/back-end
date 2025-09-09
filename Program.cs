using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrganizeAgenda.Abstractions;
using OrganizeAgenda.DTOs;
using OrganizeAgenda.Repository;
using OrganizeAgenda.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Organize Agenda", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira 'Bearer ' e então seu token no campo abaixo.\n\nExemplo: \"Bearer 12345abcdef\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
}); ;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<OrganizeAgenda.Abstractions.IUserService, OrganizeAgenda.Services.UserService>();
builder.Services.AddScoped<OrganizeAgenda.Abstractions.IUserRepository, OrganizeAgenda.Repository.UserRepository>();
builder.Services.AddSingleton<IAuthService>(new AuthService(builder.Configuration["Jwt:Key"], builder.Configuration["Jwt:Issuer"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//temporário, apenas pra testar no swagger e criar a issue no github
//
app.MapPost("/api/auth/login", (LoginDto login, IAuthService authService) =>
{
    if (login.Username == "admin" && login.Password == "password123")
    {
        var token = authService.GenerateToken(login.Username, "Admin");
        return Results.Ok(new { token });
    }
    return Results.Unauthorized();
}).WithTags("Auth");
//


app.UseAuthorization();
app.MapControllers();

app.Run();
