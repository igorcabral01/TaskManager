using AutoMapper;
using TaskManager.Models;
using TaskManager.Application.DTOs.User;

namespace TaskManager.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
