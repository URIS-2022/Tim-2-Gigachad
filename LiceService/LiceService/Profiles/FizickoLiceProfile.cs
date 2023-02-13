using AutoMapper;
using LiceService.Entities;

namespace LiceService.Profiles
{
	public class FizickoLiceProfile : Profile
	{
		public FizickoLiceProfile()
		{
			CreateMap<FizickoLiceEntity, FizickoLiceDTO>()
				.ForMember(
					dest => dest.PunoIme,
					opt => opt.MapFrom(src => $"{src.Ime} {src.Prezime}"));
		}
	}
}
