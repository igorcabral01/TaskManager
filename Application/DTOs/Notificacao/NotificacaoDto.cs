namespace TaskManager.Application.DTOs.Notificacao
{
    public class NotificacaoDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Mensagem { get; set; }
        public string Tipo { get; set; }
        public int UsuarioId { get; set; }
        public int? TarefaRelacionadaId { get; set; }
        public int? ProjetoRelacionadoId { get; set; }
        public bool Lida { get; set; }
        public DateTime? DataLeitura { get; set; }
        public string? UrlAcao { get; set; }
    }
}
