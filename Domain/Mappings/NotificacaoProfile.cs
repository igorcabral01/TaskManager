using AutoMapper;
using TaskManager.Models;
using TaskManager.Application.DTOs.Notificacao;

namespace TaskManager.Mappings
{
	public class NotificacaoProfile : Profile
	{
		public NotificacaoProfile()
		{
			CreateMap<Notificacao, NotificacaoDto>();
			CreateMap<CreateNotificacaoDto, Notificacao>();
			CreateMap<UpdateNotificacaoDto, Notificacao>();
		}
	}
}
