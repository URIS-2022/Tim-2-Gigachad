using AdresaService.DTO;
using AdresaService.Entities;

namespace AdresaService.Data
{
    /// <summary>
	/// Interfejs od repozitorijuma za entitet adresa.
	/// </summary>
	public interface IAdresaRepository
    {
        /// <summary>
		/// Vraća listu adresa iz konteksta.
		/// </summary>
		/// <returns>Vraća listu adresa.</returns>
        List<AdresaEntity> GetAdrese();

        /// <summary>
		/// Vraća jednu adresu iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="ID">ID adresa.</param>
		/// <returns>Vraća specifirano adresa.</returns>
        AdresaEntity? GetAdresaByID(Guid ID);

        /// <summary>
		/// Dodaje novu adresu u kontekst, koje kasnije vraća kao DTO objekat.
		/// </summary>
		/// <param name="adresaCreateDTO">DTO za kreiranje adrese.</param>
		/// <returns>Vraća DTO kreirane adrese.</returns>
        AdresaDTO CreateAdresa(AdresaCreateDTO adresaCreateDTO);

        /// <summary>
		/// Briše adresu iz konteksta.
		/// </summary>
		/// <param name="adresaID">ID adrese.</param>
        void DeleteAdresa(Guid adresaID);

        /// <summary>
		/// Sačuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
    }
}
