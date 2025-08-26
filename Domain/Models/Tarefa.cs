

using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Tarefa : EntidadeBase
    {
        public Guid TarefaId { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public TaskManager.Enums.TaskStatus Status { get; set; }
        public TaskPriority Prioridade { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataConclusao { get; set; }
        public Guid ProjetoId { get; set; }
        public int? AtribuidaParaId { get; set; }
        public int CriadaPorId { get; set; }
        public double? HorasEstimadas { get; set; }
        public double? HorasReais { get; set; }
        public string? Observacoes { get; set; }

        public bool Atrasada => DataVencimento.HasValue && DataVencimento < DateTime.Now && Status != TaskManager.Enums.TaskStatus.Done;
        public int DiasRestantes => DataVencimento.HasValue ? (int)(DataVencimento.Value - DateTime.Now).TotalDays : 0;

        public virtual Projeto? Projeto { get; set; }
        public virtual Usuario? AtribuidaPara { get; set; }
        public virtual Usuario? CriadaPor { get; set; }
    }
}
