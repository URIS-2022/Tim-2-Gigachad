using AutoMapper;
using LiceService.Entities;

namespace LiceService.Data
{
	public class FizickoLiceRepository : IFizickoLiceRepository
	{
		private readonly LiceContext context;
		private readonly IMapper mapper;

		public FizickoLiceRepository(LiceContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public List<FizickoLiceEntity> GetFizickaLica()
		{
			return context.FizickaLica.ToList();
		}

		public FizickoLiceEntity CreateFizickoLice(FizickoLiceEntity fizickoLice)
		{
			return null;
		}

		public void DeleteFizickoLice(Guid fizickoLiceID)
		{
		}

		public FizickoLiceEntity GetFizickoLiceByID(Guid fizickoLiceID)
		{
			return null;
		}

		public void UpdateFizickoLice(FizickoLiceEntity fizickoLice)
		{
		}

		public bool SaveChanges()
		{
			return context.SaveChanges() > 0;
		}
	}
}
