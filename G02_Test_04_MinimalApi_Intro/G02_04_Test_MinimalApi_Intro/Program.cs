

using G02_04_Test_MinimalApi_Intro.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

#region Endpoint API

List<Product> products = new()
{
    new Product(){ Id = 1, Name = "Laptop Gaming", Description = "Blablabla", Price = 750 },
    new Product(){ Id = 2, Name = "RAM 512MB", Description = "High Performace", Price = 80 }
};

app.MapGet("/", () => "Sto funzionando");

app.MapGet("/products", () => products);

app.MapGet("/products/{id:int}", (int id) => {
    var prod = products.FirstOrDefault(p => p.Id == id);
    return prod is not null ? Results.Ok(prod) : Results.NotFound();
});

app.MapPost("/products", (Product pro) =>
{
    pro.Id = products.Count + 1;
    products.Add(pro);
    return Results.Created($"/products/{pro.Id}", pro);
});

#endregion

app.Run();
public partial class Program { }
















