namespace TaskManager.Application.DTOs.Task
{
    public class UpdateTarefaDto
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Status { get; set; }
        public string? Prioridade { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataConclusao { get; set; }
        public Guid? AtribuidaParaId { get; set; }
        public double? HorasEstimadas { get; set; }
        public double? HorasReais { get; set; }
        public string? Observacoes { get; set; }
    }
}
