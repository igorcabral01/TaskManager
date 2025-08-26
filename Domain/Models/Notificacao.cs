using System;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Notificacao : EntidadeBase
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Mensagem { get; set; }
        public NotificationType Tipo { get; set; }
        public int UsuarioId { get; set; }
        public int? TarefaRelacionadaId { get; set; }
        public int? ProjetoRelacionadoId { get; set; }
        public bool Lida { get; set; }
        public DateTime? DataLeitura { get; set; }
        public string? UrlAcao { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Tarefa? TarefaRelacionada { get; set; }
        public virtual Projeto? ProjetoRelacionado { get; set; }
    }
}
