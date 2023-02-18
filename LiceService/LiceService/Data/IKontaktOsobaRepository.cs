using LiceService.DTO;
using LiceService.Entities;

namespace LiceService.Data
{
	/// <summary>
	/// Interfejs od repozitorijuma za entitet kontakt osoba.
	/// </summary>
	public interface IKontaktOsobaRepository
	{
		/// <summary>
		/// Vraća listu kontakt osoba.
		/// </summary>
		/// <returns>Vraća listu kontakt osoba.</returns>
		List<KontaktOsobaEntity> GetKontaktOsobe();

		/// <summary>
		/// Vraća jednu kontakt osobu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="kontaktOsobaID">ID kontakt osobe.</param>
		/// <returns>Vraća specifiranu kontakt osobu.</returns>
		KontaktOsobaEntity? GetKontaktOsobaByID(Guid kontaktOsobaID);

		/// <summary>
		/// Dodaje novu kontakt osobu.
		/// </summary>
		/// <param name="kontaktOsobaCreateDTO">DTO za kreiranje lica.</param>
		/// <returns>Vraća DTO kreiranog lica.</returns>
		KontaktOsobaDTO CreateKontaktOsoba(KontaktOsobaCreateDTO kontaktOsobaCreateDTO);

		/// <summary>
		/// Briše kontakt osobu.
		/// </summary>
		/// <param name="kontaktOsobaID">ID kontakt osobe.</param>
		void DeleteKontaktOsoba(Guid kontaktOsobaID);

		/// <summary>
		/// Sačuva sve promene.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
	}
}
