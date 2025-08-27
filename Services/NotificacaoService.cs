using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class NotificacaoService : Interfaces.INotificacaoService
    {
        private readonly AppDbContext _context;

        public NotificacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notificacao>> ObterTodasNotificacoesAsync()
        {
            return await _context.Notificacoes.ToListAsync();
        }

        public async Task<Notificacao?> ObterNotificacaoPorIdAsync(Guid id)
        {
            return await _context.Notificacoes.FindAsync(id);
        }

        public async Task<Notificacao> CriarNotificacaoAsync(Notificacao notificacao)
        {
            notificacao.Lida = false;
            notificacao.DataCriacao = DateTime.Now;
            await _context.Notificacoes.AddAsync(notificacao);
            await _context.SaveChangesAsync();

            return notificacao;
        }

        public async Task AtualizarNotificacaoAsync(Guid id, Notificacao notificacao)
        {
            var notificacaoExistente = await ObterNotificacaoPorIdAsync(id);
            if (notificacaoExistente == null)
                throw new Exception("Notificação não encontrada.");

            notificacaoExistente.Titulo = notificacao.Titulo;
            notificacaoExistente.Mensagem = notificacao.Mensagem;
            notificacaoExistente.Tipo = notificacao.Tipo;
            notificacaoExistente.UsuarioId = notificacao.UsuarioId;
            notificacaoExistente.TarefaRelacionadaId = notificacao.TarefaRelacionadaId;
            notificacaoExistente.ProjetoRelacionadoId = notificacao.ProjetoRelacionadoId;
            notificacaoExistente.Lida = notificacao.Lida;
            notificacaoExistente.DataLeitura = notificacao.DataLeitura;
            notificacaoExistente.UrlAcao = notificacao.UrlAcao;

            await _context.SaveChangesAsync();
        }

        public async Task DeletarNotificacaoAsync(Guid id)
        {
            var notificacao = await ObterNotificacaoPorIdAsync(id);
            if (notificacao != null)
            {
                _context.Notificacoes.Remove(notificacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarcarComoLidaAsync(Guid id)
        {
            var notificacao = await ObterNotificacaoPorIdAsync(id);
            if (notificacao == null)
                throw new Exception("Notificação não encontrada.");

            notificacao.Lida = true;
            notificacao.DataLeitura = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}
