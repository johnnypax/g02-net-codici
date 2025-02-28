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

#region Middleware di verifica

app.Use(async (context, next) =>
{
    if(context.Request.Path == "/login")
    {
        await next.Invoke();
        return;
    }

    if (!context.Request.Headers.ContainsKey("Authorization"))
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync("Authorization header non presente ;(");
        return;
    }

    var token = context.Request.Headers["Authorization"].ToString();

    if(string.IsNullOrEmpty(token) || token != "AB12345")
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync("Authorization header non valido ;(");
        return;
    }

    await next.Invoke();
});

#endregion

app.MapPost("/login", (Utente ute) =>
{
    if(ute.username == "admin" && ute.password == "1234")
    {
        return Results.Ok(new { Token = "AB12345" });
    }
    return Results.Unauthorized();
});

app.MapGet("/dashboard", () =>
{
    return "Ecco la dashboard dell'amministratore";
});

app.Run();

record Utente(string username, string password);