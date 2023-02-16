using AutoMapper;
using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	/// <summary>
	/// Repozitorijum za entitet lice.
	/// </summary>
	public class LiceRepository : ILiceRepository
	{
		private readonly LiceContext context;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
		public LiceRepository(LiceContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu lica iz konteksta.
		/// </summary>
		/// <returns>Vraća listu lica.</returns>
		public List<LiceEntity> GetLica()
		{
			return context.Lica.ToList();
		}

		/// <summary>
		/// Vraća jedno lice iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		/// <returns>Vraća specifirano lice.</returns>
		public LiceEntity? GetLiceByID(Guid liceID)
		{
			return context.Lica.FirstOrDefault(e => e.ID == liceID);
		}

		/// <summary>
		/// Dodaje novo lice u kontekst.
		/// </summary>
		/// <param name="liceCreateDTO">DTO za kreiranje lica.</param>
		/// <returns>Vraća DTO kreiranog lica.</returns>
		public LiceDTO CreateLice(LiceCreateDTO liceCreateDTO)
		{
			LiceEntity lice = mapper.Map<LiceEntity>(liceCreateDTO);
			lice.ID = Guid.NewGuid();
			context.Add(lice);
			return mapper.Map<LiceDTO>(lice);
		}

		/// <summary>
		/// Briše lice iz konteksta.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		public void DeleteLice(Guid liceID)
		{
			LiceEntity? lice = GetLiceByID(liceID);
			if (lice != null)
				context.Remove(lice);
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
