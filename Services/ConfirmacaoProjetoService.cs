using System.Text;
using System.Text.Json;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure;
using TaskManager.Models;
using RabbitMQ.Client;


namespace TaskManager.Services
{
    public class ConfirmacaoProjetoService
    {
        private readonly RabbitMqConfig _config;
        private readonly AppDbContext _dbcontext;

        public ConfirmacaoProjetoService(RabbitMqConfig config, AppDbContext dbcontext)
        {
            _config = config;
            _dbcontext = dbcontext  ;
        }

        public void StartConsumer()
        {
            var factory = RabbitMqFactory.Create(_config);
            var connection = await factory.CreateConnectionAsync();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "projeto_criado", durable: false, exclusive: false, autoDelete: false, arguments: null);

            // Consome continuamente usando polling (BasicGet)
            while (true)
            {
                var result = channel.BasicGet("projeto_criado", true);
                if (result != null)
                {
                    var body = result.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var projeto = JsonSerializer.Deserialize<ConfirmacaoProjeto>(message);

                    var confirmacao = new ConfirmacaoProjeto
                    {
                        ProjetoId = projeto!.ProjetoId,
                        Nome = projeto!.Nome,
                        DataRecebimento = DateTime.UtcNow
                    };
                    _dbcontext.ConfirmacoesProjeto.Add(confirmacao);
                    _dbcontext.SaveChanges();
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
