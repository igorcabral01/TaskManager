using AutoMapper;
using TaskManager.Models;
using TaskManager.Application.DTOs.Project;

namespace TaskManager.Mappings
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<ProjetoDto, Projeto>();
            CreateMap<Projeto, ProjetoDto>();

        }
    }
}
