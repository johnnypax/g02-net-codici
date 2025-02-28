var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

#region Middlewares

app.Use(async (context, next) =>
{
    var logger = app.Logger;
    logger.LogWarning("Middleware 1: Prima della NEXT");

    await next.Invoke();

    logger.LogWarning("Middleware 1: Dopo della NEXT");
});

app.Use(async (context, next) =>
{
    var logger = app.Logger;
    logger.LogWarning("Middleware 2: Prima della NEXT");

    await next.Invoke();

    logger.LogWarning("Middleware 2: Dopo della NEXT");
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