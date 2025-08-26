using TaskManager.Models;

namespace TaskManager.Services
{
    /// <summary>
    /// Serviço para regras de negócio e manipulação de notificações.
    /// </summary>
    public class NotificacaoService : Interfaces.INotificacaoService
    {
        public Notificacao CriarNotificacao(Notificacao notificacao)
        {
            notificacao.Lida = false;
            notificacao.DataCriacao = DateTime.Now;
            return notificacao;
        }

        public Notificacao MarcarComoLida(Notificacao notificacao)
        {
            notificacao.Lida = true;
            notificacao.DataLeitura = DateTime.Now;
            return notificacao;
        }
    }
}
