using AutoMapper;
using TaskManager.Models;
using TaskManager.Application.DTOs.User;
using TaskManager.Domain.Models.DTOs.Usuario;

namespace TaskManager.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDtoTodos>();
            CreateMap<UsuarioDtoTodos, Usuario>();
        }
    }
}
