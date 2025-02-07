using G02_06_EF_DB_Negozio.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Configuro i services personalizzati

var credenziali = builder.Configuration.GetConnectionString("TestConn");
builder.Services.AddDbContext<G02DfNegozioContext>(options => options.UseSqlServer(credenziali));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
