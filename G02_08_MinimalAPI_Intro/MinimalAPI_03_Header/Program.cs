var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

#region Middlewares

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Giovanni-Header", "Ciao Giovanni");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Pace-Header", "Ciao Pace");
    await next.Invoke();
});

#endregion

app.MapGet("/", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invocato delegato per rotta /");

    return "Invocato endpoint /";
});


app.MapGet("/secondo", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invocato delegato per rotta /secondo");

    return "Invocato endpoint /secondo";
});

app.Run();