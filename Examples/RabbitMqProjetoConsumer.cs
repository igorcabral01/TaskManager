using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Tasks;

namespace OutraApi.Examples
{
    public class RabbitMqProjetoConsumer
    {
        public static async Task StartAsync()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: "projeto-criado", durable: false, exclusive: false, autoDelete: false, arguments: null);
            System.Console.WriteLine("[*] Waiting for projetos criados.");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                System.Console.WriteLine($"[x] Projeto recebido: {message}");
                // Aqui você pode desserializar e processar o projeto
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync("projeto-criado", autoAck: true, consumer: consumer);
            System.Console.WriteLine("Press [enter] to exit.");
            System.Console.ReadLine();
        }
    }
}
