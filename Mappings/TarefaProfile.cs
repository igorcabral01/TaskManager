using AutoMapper;
using TaskManager.Models;
using TaskManager.Application.DTOs.Task;

namespace TaskManager.Mappings
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaDto>();
            CreateMap<CreateTarefaDto, Tarefa>();
            CreateMap<UpdateTarefaDto, Tarefa>();
        }
    }
}
