using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infrastructure
{
    public interface IRabbitMqPublisher
    {
        Task PublishAsync(string queue, string message);
    }

    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        public async Task PublishAsync(string queue, string message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queue, body: body);
        }
    }
}
