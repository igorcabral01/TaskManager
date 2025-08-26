using Xunit;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Tests
{
    public class NotificacaoServiceTests
    {
        [Fact]
        public void Deve_Criar_Notificacao_Nao_Lida()
        {
            var service = new NotificacaoService();
            var notificacao = new Notificacao { Titulo = "Nova tarefa", Mensagem = "Você recebeu uma nova tarefa." };
            var resultado = service.CriarNotificacao(notificacao);
            Assert.False(resultado.Lida);
            Assert.True(resultado.DataCriacao <= System.DateTime.Now);
        }

        [Fact]
        public void Deve_Marcar_Notificacao_Como_Lida()
        {
            var service = new NotificacaoService();
            var notificacao = new Notificacao { Titulo = "Nova tarefa", Mensagem = "Você recebeu uma nova tarefa." };
            var resultado = service.MarcarComoLida(notificacao);
            Assert.True(resultado.Lida);
            Assert.True(resultado.DataLeitura <= System.DateTime.Now);
        }
    }
}
