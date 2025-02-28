var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

#region Endpoint della minimal API

app.Use(async (context, next) =>
{
    var logger = app.Logger;
    logger.LogInformation("Middleware: Prima della NEXT");

    await next.Invoke();

    logger.LogInformation("Middleware: Dopo della NEXT");
});

app.MapGet("/", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invocato: /");
    return "Sono il primo endpoint e rispondo a /";
});

app.MapGet("/secondo", () => {
    var logger = app.Logger;
    logger.LogInformation("Invocato: /secondo");
    return "Sono il secondo endpoint e rispondo a /secondo";
});

#endregion

app.Run();
