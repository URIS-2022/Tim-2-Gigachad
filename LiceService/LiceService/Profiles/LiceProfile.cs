using AutoMapper;
using LiceService.Entities;
using LiceService.DTO;

namespace LiceService.Profiles
{
	public class LiceProfile : Profile
	{
		public LiceProfile()
		{
			CreateMap<LiceEntity, LiceDTO>();
			CreateMap<LiceCreateDTO, LiceEntity>();
			CreateMap<LiceUpdateDTO, LiceEntity>();
			CreateMap<LiceEntity, LiceEntity>();
		}
	}
}
