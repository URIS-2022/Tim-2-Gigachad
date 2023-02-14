using AutoMapper;
using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	/// <summary>
	/// Repozitorijum za entitet fizičko lice.
	/// </summary>
	public class FizickoLiceRepository : IFizickoLiceRepository
	{
		private readonly LiceContext context;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
		public FizickoLiceRepository(LiceContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		/// <summary>
		/// Iz konteksta uzima fizička lica i pretvara ih u listu.
		/// </summary>
		/// <returns>Vraća listu fizičkih lica.</returns>
		public List<FizickoLiceEntity> GetFizickaLica()
		{
			return context.FizickaLica.ToList();
		}

		/// <summary>
		/// Iz konteksta uzima jedno fizičko lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="fizickoLiceID">ID fizičkog lica.</param>
		/// <returns>Vraća fizičko lice.</returns>
		public FizickoLiceEntity? GetFizickoLiceByID(Guid fizickoLiceID)
		{
			return context.FizickaLica.FirstOrDefault(e => e.ID == fizickoLiceID);
		}

		/// <summary>
		/// U kontekst dodaje novo fizičko lice, koje kasnije vraća kao DTO objekat.
		/// </summary>
		/// <param name="fizickoLiceCreateDTO">Fizičko lice.</param>
		/// <returns>Vraća DTO fizičkog lica.</returns>
		public FizickoLiceDTO CreateFizickoLice(FizickoLiceCreateDTO fizickoLiceCreateDTO)
		{
			FizickoLiceEntity fizickoLice = mapper.Map<FizickoLiceEntity>(fizickoLiceCreateDTO);
			fizickoLice.ID = Guid.NewGuid();
			context.Add(fizickoLice);
			return mapper.Map<FizickoLiceDTO>(fizickoLice);
		}

		public void DeleteFizickoLice(Guid fizickoLiceID)
		{
		}

		public void UpdateFizickoLice(FizickoLiceEntity fizickoLice)
		{
		}

		/// <summary>
		/// U kontekstu sačuva sve promene i onda vraća boolean na osnovu da li je sačuvano ili ne.
		/// </summary>
		/// <returns>Vraća boolean.</returns>
		public bool SaveChanges()
		{
			return context.SaveChanges() > 0;
		}
	}
}
