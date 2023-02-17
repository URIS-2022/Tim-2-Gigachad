using KorisnikService.DTO;
using KorisnikService.Entities;

namespace KorisnikService.Data
{
	/// <summary>
	/// Interfejs od repozitorijuma za entitet korisnik.
	/// </summary>
	public interface IKorisnikRepository
	{
		/// <summary>
		/// Vraća listu korisnika.
		/// </summary>
		/// <returns>Vraća listu korisnika.</returns>
		List<KorisnikEntity> GetKorisnici();

		/// <summary>
		/// Vraća jednog korisnika na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="korisnikID">ID korisnika.</param>
		/// <returns>Vraća specifiranog korisnika.</returns>
		KorisnikEntity? GetKorisnikByID(Guid korisnikID);

		/// <summary>
		/// Dodaje novog korisnika.
		/// </summary>
		/// <param name="korisnikCreateDTO">DTO za kreiranje korisnika.</param>
		/// <returns>Vraća DTO kreiranog korisnika.</returns>
		KorisnikDTO CreateKorisnik(KorisnikCreateDTO korisnikCreateDTO);

		/// <summary>
		/// Briše korisnika.
		/// </summary>
		/// <param name="korisnikID">ID korisnika.</param>
		void DeleteKorisnik(Guid korisnikID);

		/// <summary>
		/// Sačuva sve promene.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
	}
}
