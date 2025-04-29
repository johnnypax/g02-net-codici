using Microsoft.Data.Sqlite;
using Dapper;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Creazione database
using (var connection = new SqliteConnection("Data Source=orders.db"))
{
    connection.Execute("CREATE TABLE IF NOT EXISTS Orders (Id INTEGER PRIMARY KEY, Status TEXT)");
}

// API per creare un ordine
app.MapPost("/orders", async (HttpContext context) =>
{
    using var connection = new SqliteConnection("Data Source=orders.db");
    
    var orderId = await connection.ExecuteScalarAsync<int>(
        "INSERT INTO Orders (Status) VALUES ('Pending'); SELECT last_insert_rowid();"
    );

    var factory = new ConnectionFactory() { HostName = "localhost" };
    using var connectionMQ = await factory.CreateConnectionAsync();
    using var channel = await connectionMQ.CreateChannelAsync();

    await channel.QueueDeclareAsync(queue: "order_created", durable: false, exclusive: false, autoDelete: false);
    
    var message = JsonSerializer.Serialize(new { OrderId = orderId });
    var body = Encoding.UTF8.GetBytes(message);
    
    var properties = new RabbitMQ.Client.BasicProperties();

    await channel.BasicPublishAsync(exchange: "", 
                                    routingKey: "order_created", 
                                    mandatory: false, 
                                    basicProperties: properties, 
                                    body: body);
    
    return Results.Ok(new { OrderId = orderId });
});

app.Run();