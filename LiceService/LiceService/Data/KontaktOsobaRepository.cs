using AutoMapper;
using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	/// <summary>
	/// Repozitorijum za entitet kontakt osoba.
	/// </summary>
	public class KontaktOsobaRepository : IKontaktOsobaRepository
	{
		private readonly LiceContext context;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
		public KontaktOsobaRepository(LiceContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu kontakt osoba iz konteksta.
		/// </summary>
		/// <returns>Vraća listu kontakt osoba.</returns>
		public List<KontaktOsobaEntity> GetKontaktOsobe()
		{
			return context.KontaktOsobe.ToList();
		}

		/// <summary>
		/// Vraća jednu kontakt osobu iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="kontaktOsobaID">ID kontakt osobe.</param>
		/// <returns>Vraća specifiranu kontakt osobu.</returns>
		public KontaktOsobaEntity? GetKontaktOsobaByID(Guid kontaktOsobaID)
		{
			return context.KontaktOsobe.FirstOrDefault(e => e.ID == kontaktOsobaID);
		}

		/// <summary>
		/// Dodaje novu kontakt osobu u kontekst.
		/// </summary>
		/// <param name="kontaktOsobaCreateDTO">DTO za kreiranje kontakt osobe.</param>
		/// <returns>Vraća DTO kreirane kontakt osobe.</returns>
		public KontaktOsobaDTO CreateKontaktOsoba(KontaktOsobaCreateDTO kontaktOsobaCreateDTO)
		{
			KontaktOsobaEntity kontaktOsoba = mapper.Map<KontaktOsobaEntity>(kontaktOsobaCreateDTO);
			kontaktOsoba.ID = Guid.NewGuid();
			context.Add(kontaktOsoba);
			return mapper.Map<KontaktOsobaDTO>(kontaktOsoba);
		}

		/// <summary>
		/// Briše kontakt osobu iz konteksta.
		/// </summary>
		/// <param name="kontaktOsobaID">ID kontakt osobe.</param>
		public void DeleteKontaktOsoba(Guid kontaktOsobaID)
		{
			KontaktOsobaEntity? kontaktOsoba = GetKontaktOsobaByID(kontaktOsobaID);
			if (kontaktOsoba != null)
				context.Remove(kontaktOsoba);
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
