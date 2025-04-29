var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Product> products = new(){
    new Product(){ Id = 1, Name = "Laptop Gaming", Description = "Blablabla", Price = 750 },
    new Product(){ Id = 2, Name = "RAM 512MB", Description = "High Performace", Price = 80 }
};

app.MapGet("/", () => "Sto funzionando!");

app.MapGet("/products", () => products);


app.MapGet("/products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

app.MapPost("/products", (Product prod) =>
{
    prod.Id = products.Count + 1;
    products.Add(prod);
    return Results.Created($"/products/{prod.Id}", prod);
});


app.Run();
