using Microsoft.Data.Sqlite;
using Dapper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Creazione database
using (var connection = new SqliteConnection("Data Source=inventory.db"))
{
    connection.Execute("CREATE TABLE IF NOT EXISTS Inventory (OrderId INTEGER PRIMARY KEY, Status TEXT)");
}

// Creazione connessione RabbitMQ
var factory = new ConnectionFactory() { HostName = "localhost" };
using var connectionMQ = factory.CreateConnection();
using var channel = connectionMQ.CreateModel();

// Dichiarazione coda
channel.QueueDeclare(queue: "payment_completed", durable: false, exclusive: false, autoDelete: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (model, ea) =>
{
    Console.WriteLine("📥 Evento ricevuto in InventoryService!");

    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var order = JsonSerializer.Deserialize<OrderDto>(message);

    if (order == null || order.OrderId == 0)
    {
        Console.WriteLine("⚠️ Errore: ordine non valido.");
        return;
    }

    Console.WriteLine($"✅ Aggiornamento stock per OrderId: {order.OrderId}");

    using var db = new SqliteConnection("Data Source=inventory.db");
    await db.ExecuteAsync("INSERT INTO Inventory (OrderId, Status) VALUES (@OrderId, 'Stock Updated')", order);
};

// Mantieni il consumer attivo
channel.BasicConsume(queue: "payment_completed", autoAck: true, consumer: consumer);

Console.WriteLine("📡 InventoryService in ascolto sulla coda 'payment_completed'...");
app.Run();

public class OrderDto
{
    public int OrderId { get; set; }
}
