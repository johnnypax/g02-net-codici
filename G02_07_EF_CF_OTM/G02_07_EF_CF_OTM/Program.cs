using G02_07_EF_CF_OTM.Context;
using G02_07_EF_CF_OTM.Repositories;
using G02_07_EF_CF_OTM.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<LibrerieContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("TestConnection")
    ));

builder.Services.AddScoped<AutoreRepo>();
builder.Services.AddScoped<LibroRepo>();
builder.Services.AddScoped<AutoreService>();
builder.Services.AddScoped<LibroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
