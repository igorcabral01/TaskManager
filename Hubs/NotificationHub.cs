using Microsoft.AspNetCore.SignalR;

namespace TaskManager.Hubs
{
    /// <summary>
    /// Hub de notificações para comunicação em tempo real.
    /// </summary>
    public class NotificacaoHub : Hub
    {
        /// <summary>
        /// Envia uma notificação para todos os clientes conectados.
        /// </summary>
        /// <param name="usuario">Nome do usuário</param>
        /// <param name="mensagem">Mensagem da notificação</param>
        public async Task EnviarNotificacao(string usuario, string mensagem)
        {
            await Clients.All.SendAsync("ReceberNotificacao", usuario, mensagem);
        }
    }
}
