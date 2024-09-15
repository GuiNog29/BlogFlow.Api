using DotNetEnv;
using BlogFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BlogFlow.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = $"Server=localhost;Database=blogflowdb;Username=postgres;Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
