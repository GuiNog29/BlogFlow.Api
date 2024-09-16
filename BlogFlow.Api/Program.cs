using DotNetEnv;
using BlogFlow.Domain.Interfaces;
using BlogFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BlogFlow.Application.Mappings;
using BlogFlow.Application.Services;
using BlogFlow.Application.Interfaces;
using BlogFlow.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = $"Server={Environment.GetEnvironmentVariable("DB_HOST")};Database=blogflowdb;Username=postgres;Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString,
        npgsqlOptions => npgsqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorCodesToAdd: null
        )
    )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "BlogFlow API",
        Version = "v1"
    });
});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPostagemService, PostagemService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowLocalhost3000");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
