using Microsoft.Data.Sqlite;
using Dapper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Creazione database
using (var connection = new SqliteConnection("Data Source=payments.db"))
{
    connection.Execute("CREATE TABLE IF NOT EXISTS Payments (OrderId INTEGER PRIMARY KEY, Status TEXT)");
}

// Creazione connessione RabbitMQ
var factory = new ConnectionFactory() { HostName = "localhost" };
using var connectionMQ = factory.CreateConnection(); // Questo è corretto!
using var channel = connectionMQ.CreateModel();

// Dichiarazione della coda per ricevere ordini
channel.QueueDeclare(queue: "order_created", durable: false, exclusive: false, autoDelete: false);

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

    using var db = new SqliteConnection("Data Source=payments.db");
    await db.ExecuteAsync("INSERT INTO Payments (OrderId, Status) VALUES (@OrderId, 'Paid')", new { order.OrderId });

    // Creazione di un nuovo canale per l'invio dell'evento "payment_completed"
    using var channel2 = connectionMQ.CreateModel();
    channel2.QueueDeclare(queue: "payment_completed", durable: true, exclusive: false, autoDelete: false);

    var response = JsonSerializer.Serialize(order);

    channel2.BasicPublish(
        exchange: "", 
        routingKey: "payment_completed", 
        basicProperties: null, 
        body: Encoding.UTF8.GetBytes(response)
    );

    Console.WriteLine($"Pagamento completato per l'ordine {order.OrderId}");
};

// Avvia il consumer
channel.BasicConsume(queue: "order_created", autoAck: true, consumer: consumer);

app.Run();

public class OrderDto
{
    public int OrderId { get; set; }
}
