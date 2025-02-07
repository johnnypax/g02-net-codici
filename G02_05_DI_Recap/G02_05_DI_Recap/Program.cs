using G02_05_DI_Recap;
using G02_05_DI_Recap.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(( context, config ) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices( (context, services) =>
    {
        //var credenziali = "Server=BOOK-N57JVKH6HJ\\SQLEXPRESS;Database=g01_CF_libreria;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";

#if DEBUG
        var credenziali = context.Configuration.GetConnectionString("TestConn");
#else
        var credenziali = context.Configuration.GetConnectionString("ProdConn");
#endif

        services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(credenziali));
        services.AddTransient<App>();
    } );


var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<LibreriaContext>();
dbContext.Database.EnsureCreated();

await app.Services.GetRequiredService<App>().RunAsync();