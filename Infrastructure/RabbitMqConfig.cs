using RabbitMQ.Client;
using System;


namespace TaskManager.Infrastructure
{
    public class RabbitMqConfig
    {
        public string HostName { get; set; } = "localhost";
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public int Port { get; set; } = 5672;
    }

    public class RabbitMqConnectionFactory
    {
        private readonly RabbitMqConfig _config;
        public RabbitMqConnectionFactory(RabbitMqConfig config)
        {
            _config = config;
        }
        public IConnection CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = _config.HostName,
                    UserName = _config.UserName,
                    Password = _config.Password,
                    Port = _config.Port
                };
                // O método correto é sem parâmetros
                return factory.CreateConnection();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao conectar ao RabbitMQ: {ex.Message}", ex);
            }
        }
    }
}
