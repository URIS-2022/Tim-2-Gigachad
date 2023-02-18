using DeoParceleService.DTO;
using DeoParceleService.Entities;

namespace DeoParceleService.Data
{
	/// <summary>
	/// Interfejs od repozitorijuma za deo parcele.
	/// </summary>
	public interface IDeoParceleRepository
	{
		/// <summary>
		/// Vraća listu dela parcele iz konteksta.
		/// </summary>
		/// <returns>Vraća listu dela parcele.</returns>
		List<DeoParceleEntity> GetDeloviParcela();

		/// <summary>
		/// Vraća jedan deo parcele iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="deoParceleID">ID deo parcele.</param>
		/// <returns>Vraća specifirani deo parcele.</returns>
		DeoParceleEntity? GetDeoParceleByID(Guid deoParceleID);

		/// <summary>
		/// Dodaje novi deo parcele u kontekst.
		/// </summary>
		/// <param name="deoParceleCreateDTO">DTO za kreiranje dela parcele.</param>
		/// <returns>Vraća DTO kreirang dela parcele.</returns>
		DeoParceleDTO CreateDeoParcele(DeoParceleCreateDTO deoParceleCreateDTO);

		/// <summary>
		/// Briše deo parcele iz konteksta.
		/// </summary>
		/// <param name="deoParceleID">ID dela parcele.</param>
		void DeleteDeoParcele(Guid deoParceleID);

		/// <summary>
		/// Sačuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		bool SaveChanges();
	}
}
