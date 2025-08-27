using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Examples
{
    public class RabbitMqSendExample
    {
        public static async Task SendAsync()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
            const string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);
            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
            System.Console.WriteLine($"[x] Sent {message}");
        }
    }
}
