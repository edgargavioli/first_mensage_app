using Npgsql.EntityFrameworkCore.PostgreSQL.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;
using api_msg.Context;
using api_msg.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();// Adquirindo as configurações do arquivo appsettings.json utilizando a interface
             //IConfiguration que traz as funcionalidades de leitura de arquivos de configuração

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
}
));

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<MensagemService>();

builder.Services.AddNpgsql<ApiContext>(configuration.GetConnectionString("DefaultString"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
