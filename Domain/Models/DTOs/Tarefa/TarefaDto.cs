using System.Threading.Tasks;
using TaskManager.Enums;

namespace TaskManager.Application.DTOs.Task
{
    public class TarefaDto
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public TaskManager.Enums.TaskStatus? Status { get; set; }
        public TaskPriority? Prioridade { get; set; }
        public Guid ProjetoId { get; set; }
        public Guid? AtribuidaParaId { get; set; }
        public Guid CriadaPorId { get; set; }
        public double? HorasEstimadas { get; set; }
        public double? HorasReais { get; set; }
        public string? Observacoes { get; set; }
    }
}
