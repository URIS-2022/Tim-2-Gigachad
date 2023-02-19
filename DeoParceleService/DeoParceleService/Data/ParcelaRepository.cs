using AutoMapper;
using DeoParceleService.DTO;
using DeoParceleService.Entities;

namespace DeoParceleService.Data
{
	/// <summary>
	/// Repozitorijum za entitet parcela.
	/// </summary>
	public class ParcelaRepository : IParcelaRepository
	{
		private readonly DeoParceleContext context;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
		public ParcelaRepository(DeoParceleContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu parcela iz konteksta.
		/// </summary>
		/// <returns>Vraća listu parcela.</returns>
		public List<ParcelaEntity> GetParcele()
		{
			return context.Parcele.ToList();
		}

		/// <summary>
		/// Vraća jednu parcelu iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="parcelaID">ID parcele.</param>
		/// <returns>Vraća specifiranu parcelu.</returns>
		public ParcelaEntity? GetParcelaByID(Guid parcelaID)
		{
			return context.Parcele.FirstOrDefault(e => e.ID == parcelaID);
		}

		/// <summary>
		/// Dodaje novu parcelu u kontekst.
		/// </summary>
		/// <param name="parcelaCreateDTO">DTO za kreiranje parcela.</param>
		/// <returns>Vraća DTO kreirane parcele.</returns>
		public ParcelaDTO CreateParcela(ParcelaCreateDTO parcelaCreateDTO)
		{
			ParcelaEntity parcela = mapper.Map<ParcelaEntity>(parcelaCreateDTO);
			parcela.ID = Guid.NewGuid();
			context.Add(parcela);
			return mapper.Map<ParcelaDTO>(parcela);
		}

		/// <summary>
		/// Briše parcelu iz konteksta.
		/// </summary>
		/// <param name="parcelaID">ID parcele.</param>
		public void DeleteParcela(Guid parcelaID)
		{
			ParcelaEntity? parcela = GetParcelaByID(parcelaID);
			if (parcela != null)
				context.Remove(parcela);
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
