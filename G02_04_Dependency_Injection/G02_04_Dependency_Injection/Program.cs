
using G02_04_Dependency_Injection;
using G02_04_Dependency_Injection.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var stringaConnessione = "Server=BOOK-N57JVKH6HJ\\SQLEXPRESS;Database=opt_CF_otm_di;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";

var builder = Host.CreateDefaultBuilder(args)
                    .ConfigureServices((context, services) => {
                        services.AddDbContext<LibreriaContext>(
                            options => options.UseSqlServer(stringaConnessione)
                            );

                        services.AddTransient<App>();
                    });

var app = builder.Build();

await app.Services.GetRequiredService<App>().RunAsync();