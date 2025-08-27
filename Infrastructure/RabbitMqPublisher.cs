using RabbitMQ.Client;
using System.Text;

namespace TaskManager.Infrastructure
{
    public interface IRabbitMqPublisher
    {
        void Publish(string queue, string message);
    }

    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private readonly RabbitMqConnectionFactory _connectionFactory;
        public RabbitMqPublisher(RabbitMqConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public void Publish(string queue, string message)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);
        }
    }
}
