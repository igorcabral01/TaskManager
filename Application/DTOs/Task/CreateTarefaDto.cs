namespace TaskManager.Application.DTOs.Task
{
    public class CreateTarefaDto
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public DateTime? DataVencimento { get; set; }
        public Guid ProjetoId { get; set; }
        public Guid? AtribuidaParaId { get; set; }
        public Guid CriadaPorId { get; set; }
        public double? HorasEstimadas { get; set; }
        public string? Observacoes { get; set; }
    }
}
