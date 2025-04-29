using Microsoft.Data.Sqlite;
using Dapper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Creazione database Ordini
using (var connection = new SqliteConnection("Data Source=orders.db"))
{
    connection.Execute("CREATE TABLE IF NOT EXISTS Orders (Id INTEGER PRIMARY KEY, Status TEXT)");
}

// Creazione connessione RabbitMQ
var factory = new ConnectionFactory() { HostName = "localhost" };
using var connectionMQ = factory.CreateConnection();
using var channel = connectionMQ.CreateModel();

// Dichiarazione della coda per ordini creati
channel.QueueDeclare(queue: "order_created", durable: false, exclusive: false, autoDelete: false);
channel.QueueDeclare(queue: "payment_failed", durable: false, exclusive: false, autoDelete: false);

// Endpoint per creare un ordine
app.MapPost("/orders", async (HttpContext context) =>
{
    using var connection = new SqliteConnection("Data Source=orders.db");
    
    var orderId = await connection.ExecuteScalarAsync<int>(
        "INSERT INTO Orders (Status) VALUES ('Pending'); SELECT last_insert_rowid();"
    );

    var message = JsonSerializer.Serialize(new { OrderId = orderId });
    var body = Encoding.UTF8.GetBytes(message);
    
    channel.BasicPublish(exchange: "", routingKey: "order_created", basicProperties: null, body: body);
    
    Console.WriteLine($"📦 Ordine creato con ID: {orderId}");
    return Results.Ok(new { OrderId = orderId });
});

// Consumer per pagamento fallito
var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var order = JsonSerializer.Deserialize<OrderDto>(message);

    if (order == null || order.OrderId == 0)
    {
        Console.WriteLine("⚠️ Errore: ordine non valido.");
        return;
    }

    using var db = new SqliteConnection("Data Source=orders.db");
    await db.ExecuteAsync("UPDATE Orders SET Status = 'Rejected' WHERE Id = @OrderId", order);

    Console.WriteLine($"🚨 Ordine {order.OrderId} aggiornato a 'Rejected' a causa di pagamento fallito.");
};

// Ascolta la coda `payment_failed`
channel.BasicConsume(queue: "payment_failed", autoAck: true, consumer: consumer);

Console.WriteLine("📡 OrderService in ascolto degli eventi di pagamento fallito...");
app.Run();

public class OrderDto
{
    public int OrderId { get; set; }
}
