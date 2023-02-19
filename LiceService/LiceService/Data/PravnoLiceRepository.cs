using AutoMapper;
using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	/// <summary>
	/// Repozitorijum za entitet pravno lice.
	/// </summary>
	public class PravnoLiceRepository : IPravnoLiceRepository
	{
		private readonly LiceContext context;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
		public PravnoLiceRepository(LiceContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu pravnih lica iz konteksta.
		/// </summary>
		/// <returns>Vraća listu pravnih lica.</returns>
		public List<PravnoLiceEntity> GetPravnaLica()
		{
			return context.PravnaLica.ToList();
		}

		/// <summary>
		/// Vraća jedno pravno lice iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="pravnoLiceID">ID pravnog lica.</param>
		/// <returns>Vraća specifirano pravno lice.</returns>
		public PravnoLiceEntity? GetPravnoLiceByID(Guid pravnoLiceID)
		{
			return context.PravnaLica.FirstOrDefault(e => e.ID == pravnoLiceID);
		}

		/// <summary>
		/// Dodaje novo pravno lice u kontekst.
		/// </summary>
		/// <param name="pravnoLiceCreateDTO">DTO za kreiranje pravnog lica.</param>
		/// <returns>Vraća DTO kreiranog pravnog lica.</returns>
		public PravnoLiceDTO CreatePravnoLice(PravnoLiceCreateDTO pravnoLiceCreateDTO)
		{
			PravnoLiceEntity pravnoLice = mapper.Map<PravnoLiceEntity>(pravnoLiceCreateDTO);
			pravnoLice.ID = Guid.NewGuid();
			context.Add(pravnoLice);
			return mapper.Map<PravnoLiceDTO>(pravnoLice);
		}

		/// <summary>
		/// Briše pravno lice iz konteksta.
		/// </summary>
		/// <param name="pravnoLiceID">ID pravnog lica.</param>
		public void DeletePravnoLice(Guid pravnoLiceID)
		{
			PravnoLiceEntity? pravnoLice = GetPravnoLiceByID(pravnoLiceID);
			if (pravnoLice != null)
				context.Remove(pravnoLice);
		}

		/// <summary>
		/// Sačuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		public bool SaveChanges()
		{
			return context.SaveChanges() > 0;
		}
	}
}
