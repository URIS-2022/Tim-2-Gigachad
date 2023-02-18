using DeoParceleService.DTO;
using DeoParceleService.Entities;

namespace DeoParceleService.Data
{
	/// <summary>
	/// Interfejs od repozitorijuma za parcela.
	/// </summary>
	public interface IParcelaRepository
	{
		/// <summary>
		/// Vraća listu parcela iz konteksta.
		/// </summary>
		/// <returns>Vraća listu parcela.</returns>
		List<ParcelaEntity> GetParcele();

		/// <summary>
		/// Vraća jednu parcelu iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="parcelaID">ID parcele.</param>
		/// <returns>Vraća specifiranu parcelu.</returns>
		ParcelaEntity? GetParcelaByID(Guid parcelaID);

		/// <summary>
		/// Dodaje novu parcelu u kontekst.
		/// </summary>
		/// <param name="parcelaCreateDTO">DTO za kreiranje parcela.</param>
		/// <returns>Vraća DTO kreirane parcele.</returns>
		ParcelaDTO CreateParcela(ParcelaCreateDTO parcelaCreateDTO);

		/// <summary>
		/// Briše parcelu iz konteksta.
		/// </summary>
		/// <param name="parcelaID">ID parcele.</param>
		void DeleteParcela(Guid parcelaID);

		/// <summary>
		/// Sačuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
	}
}
