var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Sto funzionando");


app.MapGet("/saluta/{nome}", (string nome) => {
    return $"Ciao, {nome}";
});

app.MapGet("/saluta/{nome}/{cognome}", (string nome, string cognome) => {
    return $"Ciao, {nome} {cognome}";
});

app.MapGet("/somma", (int a, int b) =>
{
    return $"La somma di {a} e {b} è: {a+b}";
});

app.MapPost("/utente", (Utente ute) =>
{
    return $"L'utente {ute.nominativo} ha una età di: {ute.eta}";
});

app.MapGet("/utente/info", () =>
{
    Utente ute = new Utente("Giovanni Pace", 10);
    return ute;
});

app.MapGet("/conritardo", async () =>
{
    await Task.Delay(3000);
    return Results.Ok("Ciao sono la risposta arrivata tardis");
});

app.Run();

record Utente(string nominativo, int eta);