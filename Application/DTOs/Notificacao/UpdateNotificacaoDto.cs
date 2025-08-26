namespace TaskManager.Application.DTOs.Notificacao
{
    public class UpdateNotificacaoDto
    {
        public string? Titulo { get; set; }
        public string? Mensagem { get; set; }
        public string? Tipo { get; set; }
        public bool? Lida { get; set; }
        public DateTime? DataLeitura { get; set; }
        public string? UrlAcao { get; set; }
    }
}
