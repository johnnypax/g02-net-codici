using Microsoft.Data.Sqlite;
using Dapper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Creazione database
using (var connection = new SqliteConnection("Data Source=payments.db"))
{
    connection.Execute("CREATE TABLE IF NOT EXISTS Payments (OrderId INTEGER PRIMARY KEY, Status TEXT)");
}

// Creazione connessione RabbitMQ
var factory = new ConnectionFactory() { HostName = "localhost" };
using var connectionMQ = factory.CreateConnection();
using var channel = connectionMQ.CreateModel();

// Dichiarazione delle code
channel.QueueDeclare(queue: "order_created", durable: false, exclusive: false, autoDelete: false);
channel.QueueDeclare(queue: "payment_completed", durable: false, exclusive: false, autoDelete: false);
channel.QueueDeclare(queue: "payment_failed", durable: false, exclusive: false, autoDelete: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var order = JsonSerializer.Deserialize<OrderDto>(message);

    if (order == null || order.OrderId == 0)
    {
        Console.WriteLine("Errore: dati dell'ordine non validi.");
        return;
    }

    // Simula un rifiuto casuale (30% di probabilità)
    bool isRejected = new Random().NextDouble() < 0.3;

    using var db = new SqliteConnection("Data Source=payments.db");

    if (isRejected)
    {
        await db.ExecuteAsync("INSERT INTO Payments (OrderId, Status) VALUES (@OrderId, 'Rejected')", new { order.OrderId });

        var failureResponse = JsonSerializer.Serialize(order);
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(
            exchange: "",
            routingKey: "payment_failed",
            basicProperties: properties,
            body: Encoding.UTF8.GetBytes(failureResponse)
        );

        Console.WriteLine($"❌ Pagamento rifiutato per OrderId: {order.OrderId}");
    }
    else
    {
        await db.ExecuteAsync("INSERT INTO Payments (OrderId, Status) VALUES (@OrderId, 'Paid')", new { order.OrderId });

        var successResponse = JsonSerializer.Serialize(order);
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(
            exchange: "",
            routingKey: "payment_completed",
            basicProperties: properties,
            body: Encoding.UTF8.GetBytes(successResponse)
        );

        Console.WriteLine($"✅ Pagamento completato per OrderId: {order.OrderId}");
    }
};

// Avvia il consumer
channel.BasicConsume(queue: "order_created", autoAck: true, consumer: consumer);

Console.WriteLine("📡 PaymentService in ascolto sulla coda 'order_created'...");
app.Run();

public class OrderDto
{
    public int OrderId { get; set; }
}
