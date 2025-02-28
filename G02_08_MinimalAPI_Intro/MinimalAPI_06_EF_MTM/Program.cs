using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinimalAPI_06_EF_MTM.Context;
using MinimalAPI_06_EF_MTM.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Configurazione del context

var connectionString = builder.Configuration.GetConnectionString("TestConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString));

#endregion

#region Configurazione serializzatore

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

    //options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    ////options.SerializerOptions.WriteIndented = true;
    ////options.SerializerOptions.MaxDepth = 3;
});

#endregion

var app = builder.Build();
app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.MapGet("/", () => "Sto funzioando!");

app.MapGet("/prodotti", async (AppDbContext ctx) =>
{
    return await ctx.Prodottos
                        .Include(p => p.ProdottoCategorias)
                        .ThenInclude(pc => pc.CategoriaNav)
                        .ToListAsync();
});

app.MapGet("/prodotti/dto", async (AppDbContext ctx) =>
{
    return await ctx.Prodottos
                        .Include(p => p.ProdottoCategorias)
                        .ThenInclude(pc => pc.CategoriaNav)
                        .Select(p => new ProdottoDTO
                        {
                            Nome = p.Nome,
                            Prezzo = p.Prezzo,
                            Categorias = p.ProdottoCategorias.Select(pc => pc.CategoriaNav.Nome).ToList()
                        })
                        .ToListAsync();
});

app.MapPost("/prodotti/{pId:int}/categoria/{cId:int}", (AppDbContext ctx, int pId, int cId) =>
{
    //TODO: Da completare...
    return Results.Ok();
});


app.Run();