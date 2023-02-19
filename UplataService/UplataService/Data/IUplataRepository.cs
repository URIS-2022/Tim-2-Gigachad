using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Data
{
    /// <summary>
	/// Interfejs od repozitorijuma za entitet uplata.
	/// </summary>
    public interface IUplataRepository
    {
        /// <summary>
		/// Vraća listu uplata.
		/// </summary>
		/// <returns>Vraća listu uplata.</returns>
        List<UplataEntity> GetUplate();

        /// <summary>
		/// Vraća jednu uplatu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="UplataID">ID Uplate.</param>
		/// <returns>Vraća specifirane uplate.</returns>
        UplataEntity GetUplataByID(Guid UplataID);

        /// <summary>
		/// Dodaje novu uplatu.
		/// </summary>
		/// <param name="UplataCreateDTO">DTO za kreiranje uplate.</param>
		/// <returns>Vraća DTO kreirane uplate.</returns>
        UplataDTO CreateUplata(UplataCreateDTO UplataCreateDTO);

        void UpdateUplata(UplataEntity Uplata);

        /// <summary>
		/// Briše uplatu.
		/// </summary>
		/// <param name="UplataID">ID uplate.</param>
        void DeleteUplata(Guid UplataID);

        /// <summary>
        /// Sačuva sve promene.
        /// </summary>
        /// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
        bool SaveChanges();
    }
}
