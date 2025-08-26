using TaskManager.Models;

namespace TaskManager.Services
{
    /// <summary>
    /// Serviço para regras de negócio e manipulação de tarefas.
    /// </summary>
    public class TarefaService : Interfaces.ITarefaService
    {
        public Tarefa CriarTarefa(Tarefa tarefa)
        {
            tarefa.Status = Enums.TaskStatus.ToDo;
            tarefa.DataCriacao = DateTime.Now;
            return tarefa;
        }

        public Tarefa AtualizarTarefa(Tarefa tarefa)
        {
            tarefa.DataAtualizacao = DateTime.Now;
            return tarefa;
        }
    }
}
