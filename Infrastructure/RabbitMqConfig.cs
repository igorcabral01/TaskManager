using RabbitMQ.Client;
using System.Threading.Tasks;


namespace TaskManager.Infrastructure
{
    public class RabbitMqConfig
    {
        public string HostName { get; set; } = "localhost";
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public int Port { get; set; } = 5672;
    }

    public static class RabbitMqFactory
    {
        public static ConnectionFactory Create(RabbitMqConfig config)
        {
            return new ConnectionFactory
            {
                HostName = config.HostName,
                UserName = config.UserName,
                Password = config.Password,
                Port = config.Port
            };
        }
    }
}
